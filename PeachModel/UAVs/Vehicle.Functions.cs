using PeachModel.CommunicationPort;
using PeachModel.Mavlink;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.UAVs
{
    public partial class Vehicle
    {
        #region For First Connection

        /// <summary>
        /// Heart Beat receiver
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        private object Receive_heartbeat(Packet packet)
        {
            try
            {
                if (packet is null)
                {
                    return null;
                }

                return packet;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public delegate void HeartBeatHandler(string state, string description);

        public event HeartBeatHandler HeartBeatEvent;

        private void InvokeHeartBeatEvent(string state, string description)
        {
            this.HeartBeatEvent?.Invoke(state, description);
        }

        /// <summary>
        /// Detect most received heartbeat.
        /// </summary>
        /// <returns></returns>
        public bool DetectHeartBeat()
        {
            try
            {
                Dictionary<Tuple<int, int>, int> history = new Dictionary<Tuple<int, int>, int>();

                this.InvokeHeartBeatEvent("Wait HeartBeat", "");

                int i = 0;
                while (i < 10)
                {
                    Subscriber s = new Subscriber(this.SystemId, this.ComponentId, 0, this.Receive_heartbeat, PERMANENCY.DISPOSABLE, timeoutSec: 3.0);
                    this.ComPort.Subscribe.DoSubscribe(s);
                    object r = s.GetResultAsync().Result;

                    if (r != null)
                    {
                        Packet t = (Packet)r;
                        var tuple = new Tuple<int, int>(t.SYSID, t.COMPID);

                        if (!history.ContainsKey(tuple))
                        {
                            history.Add(tuple, 0);
                        }
                        history[tuple] += 1;

                        this.InvokeHeartBeatEvent("Detect HeartBeat", $"count - {history.Count}, system id - {t.SYSID}, component id - {t.COMPID}");
                    }
                    i++;
                }

                if (history.Count == 0) return false;

                int max = 0;
                Tuple<int, int> search = new Tuple<int, int>(-1, -1);
                foreach (KeyValuePair<Tuple<int, int>, int> pair in history)
                {
                    if (pair.Value > max)
                    {
                        search = pair.Key;
                    }
                }
                this.SystemId = search.Item1;
                this.ComponentId = search.Item2;

                this.InvokeHeartBeatEvent("Complete HeartBeat", $"Connect to system id - {this.SystemId}, component id - {this.ComponentId} vehicle.");

                // subscribe heart beat
                this.DoSubscribeDataStream(0);

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        /// <summary>
        /// Parameter initializing.
        /// </summary>
        public void RequestAllParameters()
        {
            try
            {
                // send message.
                Message_PARAM_REQUEST_LIST message = new Message_PARAM_REQUEST_LIST((byte)this.SystemId, (byte)this.ComponentId);
                this.SendMessage(message);
                int retry = 3;

                this.ComPort.Subscribe.DoSubscribe(this.SystemId, this.ComponentId, 22, this.Receive_Vehicledatas, PERMANENCY.SEMI_PERMANENT, 20);
                DateTime timeout = DateTime.Now.AddMilliseconds(20 * 1000);

                while (true)
                {
                    if (timeout < DateTime.Now)
                        return;

                    if (retry > 0)
                    {
                        this.SendMessage(message);
                        retry--;
                    }

                    if (this.ParameterCount == -1) continue;

                    // Complete.
                    if (this.ParameterCount == this.Parameters.Count) break;

                }

                Debug.WriteLine($"Total : {this.ParameterCount}, Received : {this.Parameters}");

            }
            catch (Exception e)
            {
                return;
                throw;
            }

        }

        /// <summary>
        /// Subscribe default data stream. 
        /// </summary>
        public void InitializeSubscribing()
        {
            this.DoSubscribeDataStream(1);  // sys status -> must.
            this.DoSubscribeDataStream(22); // param value -> must
            this.DoSubscribeDataStream(24); // gps raw int -> must?
            this.DoSubscribeDataStream(35); // rc channels raw -> ?? or monitor?
            this.DoSubscribeDataStream(77); // command long -> must
            this.DoSubscribeDataStream(253); // status text -> must??
        }
        #endregion

        #region For Subscribing

        /// <summary>
        /// Do Subscribe Data Stream with permanent.
        /// </summary>
        /// <param name="msgid"></param>
        public void DoSubscribeDataStream(uint msgid)
        {
            if (_subscribedMessages.Contains(msgid))
            {
                return;
            }
            _subscribedMessages.Add(msgid);
            this.ComPort.Subscribe.DoSubscribe((byte)this.SystemId, (byte)this.ComponentId, msgid, this.Receive_Vehicledatas, PERMANENCY.PERMANENT, -1);
        }

        /// <summary>
        /// Do Subscribe
        /// </summary>
        /// <param name="msgid"></param>
        /// <param name="func"></param>
        /// <param name="permanency"></param>
        /// <param name="timeoutsec"></param>
        public void DoSubscribe(uint msgid, Func<Packet, object> func, PERMANENCY permanency, double timeoutsec = 5)
        {
            this.ComPort.Subscribe.DoSubscribe((byte)this.SystemId, (byte)this.ComponentId, msgid, func, permanency, timeoutsec);
        }

        /// <summary>
        /// Do Subscribe
        /// </summary>
        /// <param name="s"></param>
        public void DoSubscribe(Subscriber s)
        {
            this.ComPort.Subscribe.DoSubscribe(s);
        }

        /// <summary>
        /// Add UnSubscriber
        /// </summary>
        /// <param name="msgid"></param>
        public void AddUnSubscriber(uint msgid)
        {
            this.ComPort.Subscribe.AddUnSubscriber((byte)this.SystemId, (byte)this.ComponentId, msgid);
        }
        #endregion

        private readonly double timeout_parameter = 1.5;

        /// <summary>
        /// Set Parameter Sync
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetParameter(string id, float value)
        {
            var r = this.SetParameterAsync(id, value).GetAwaiter().GetResult();
            return r;
        }

        /// <summary>
        /// Set Parameter Async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> SetParameterAsync(string id, float value)
        {
            VehicleParameter pa;
            if (!this.Parameters.TryGetValue(id, out pa))
            {
                return false;
            }

            byte[] ids = VehicleParameter.ConvertTo16Bytes(id);
            Message_PARAM_SET m = new Message_PARAM_SET(value, (byte)this.SystemId, (byte)this.ComponentId, ids, pa.Type);

            float oldValue = pa.Value;
            this.SendMessage(m);

            bool result = false;
            //Debug.WriteLine($"run checker");
            var checker = Task.Run(() =>
            {
                DateTime timeout = DateTime.Now.AddMilliseconds(1.5 * 1000);

                while (true)
                {
                    if (timeout < DateTime.Now)
                    {
                        //Debug.WriteLine("Checker out with timeout");
                        result = false;
                        return;
                    }

                    if (this.Parameters[id].Value == value)
                    {
                        //Debug.WriteLine("Cheker out with same value.");
                        result = true;
                        return;
                    }
                }
            });
            //Debug.WriteLine($"wait checker");
            checker.Wait();
            //Debug.WriteLine($"get checker");
            return result;
        }

        /// <summary>
        /// Send Mavlink message.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(Message message)
        {
            try
            {
                Packet packet;
                if (this.IsMavlink2)
                {
                    // mavlink2
                    packet = Packet.CreateMavLink2(this.Seq, (byte)this.SystemId, (byte)this.ComponentId,
                        message);
                }
                else
                {
                    packet = Packet.CreateMavLink1(this.Seq, (byte)this.SystemId, (byte)this.ComponentId,
                        message);
                }

                this.ComPort.WriteBytes(packet.Buffer);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        /// <summary>
        /// Set data stream.
        /// </summary>
        /// <param name="req_message_rate"></param>
        /// <param name="req_stream_id"></param>
        /// <param name="isStart"></param>
        public void SetDataStream(byte req_message_rate = 10, byte req_stream_id = 0, bool isStart = true)
        {
            byte start_stop = 0;
            if (isStart) start_stop = 1;

            this.SendMessage(new Message_REQUEST_DATA_STREAM(req_message_rate,
                (byte)this.SystemId, (byte)this.ComponentId, req_stream_id, start_stop));

        }

        private readonly double timeout_ack = 2.0;

        /// <summary>
        /// TODO :
        /// Send Command long message by async
        /// </summary>
        /// <param name="command"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private async Task<bool> SendCommandLongAsync(ushort command, params float[] p)
        {
            try
            {
                Message_COMMAND_LONG command_long = new Message_COMMAND_LONG(p[0], p[1], p[2], p[3], p[4], p[5], p[6],
                command, (byte)this.SystemId, (byte)this.ComponentId, this.Confirmation);
                this.SendMessage(command_long);

                DateTime timeout = DateTime.Now.AddMilliseconds(timeout_ack * 1000);
                while (true)
                {
                    if (timeout < DateTime.Now) return false;

                    if (this.command == command)
                    {
                        var value = (MavEnums.MAV_RESULT)this.result;
                        switch (value)
                        {
                            case MavEnums.MAV_RESULT.MAV_RESULT_ACCEPTED:
                                return true;
                            default:
                                return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            
        }

        /// <summary>
        /// Senc command long
        /// </summary>
        /// <param name="command"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <param name="p5"></param>
        /// <param name="p6"></param>
        /// <param name="p7"></param>
        /// <returns></returns>
        public bool SendCommandLong(ushort command, float p1, float p2, float p3, float p4, float p5, float p6, float p7)
        {
            return this.SendCommandLongAsync(command, p1, p2, p3, p4, p5, p6, p7).Result;
        }

        /// <summary>
        /// Clean up 
        /// </summary>
        public void CleanSubscribe()
        {
            if (!this.ComPort.IsOpen)
                return;

            foreach(uint msgid in this._subscribedMessages)
            {
                this.AddUnSubscriber(msgid);
            }

            // subscribe clean.
            // TODO : 
        }

        public void Dispose()
        {
            // TODO : dispose.
        }
    }
}
