using PeachModel.CommunicationPort;
using PeachModel.UAVs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Interface
{
    /// <summary>
    /// Partial class of Interface.
    /// This part have 3 large funtionality.
    /// 1. Control ComPort.
    /// 2. Control packet subscribing.
    /// 3. Control Vehicle status datas.
    /// </summary>
    public partial class ComInterface : IDisposable
    {

        ///// <summary>
        ///// Get Autopilot version Message.
        ///// </summary>
        ///// <returns></returns>
        //public async Task<bool> GetAutopilotVersion(double timeoutMilliseconds = 2.0)
        //{
        //    try
        //    {
        //        this.SendMessage(new Message_AUTOPILOT_VERSION_REQUEST((byte)this.SysId, (byte)this.CompId));

        //        DateTime timeout = DateTime.Now.AddMilliseconds(timeoutMilliseconds * 1000);
        //        Dictionary<int, int> re;

        //        while (true)
        //        {
        //            if (timeout < DateTime.Now)
        //            {
        //                string timeout_error = $"GetAutopiloVersion timeout.";
        //                throw new Exception(timeout_error);
        //            }

        //            byte[] raws = await this.ComPort.ReadMavlink();

        //            Packet packet = new Packet(raws);

        //            if (packet.IsValid == false | packet.MSGID == 0 | packet.MSGID == 111)
        //            {
        //                continue;
        //            }

        //            if (packet.MSGID == 148)
        //            {
        //                if(packet.SYSID == this.SysId & packet.COMPID == this.CompId)
        //                {
        //                    Message_AUTOPILOT_VERSION v = (Message_AUTOPILOT_VERSION)packet.Message;
        //                    break;
        //                }
        //                // 64495
        //                //re = new Dictionary<int, int>();

        //                //for (int i = 1; i <= 65536; i = i * 2)
        //                //{
        //                //    if ((v.capabilities & (ulong)i) == (ulong)i)
        //                //    {
        //                //        re.Add(i, i);
        //                //    }
        //                //    else
        //                //    {
        //                //        re.Add(i, 0);
        //                //    }
        //                //}
        //            }
        //        }
        //        return true;

        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message);
        //        return false;
        //    }
        //}

        //public async Task<bool> ConnectAsync()
        //{
        //    try
        //    {
        //        Debug.WriteLine($"Try Connection...");

        //        int[] items = await DetectHeartBeat(20);    // 20sec. 

        //        // set sys id and component id
        //        this.MavLinkVersion = (byte)items[0];
        //        this.SysId = items[1];
        //        this.CompId = items[2];

        //        // get version.
        //        // TODO : Mavlink2 version problem.
        //        //bool isGetVersion = await this.GetAutopilotVersion(2.0);   // 1sec.

        //        Tuple<bool, bool> result = await GetParams(20);        // 20sec.
        //        this.IsCompleteGetParameters = result.Item1;
        //        bool getparamresult = result.Item2;

        //        ///// TODO : 
        //        //bool gps = await StartDataStream();

        //        Debug.WriteLine("Connection succeed");
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine("Connection failed.");
        //        return false;
        //        throw e;
        //    }


        //}

        ///// <summary>
        ///// Get Heart Beat from UAV in 30 sec.
        ///// </summary>
        ///// <returns></returns>
        //public async Task<int[]> DetectHeartBeat(double time_sec = 30.0)
        //{
        //    Debug.WriteLine("Start detecting heartbeat.");

        //    List<Packet> heartbeats = new List<Packet>();
        //    int heartbeat_count = 0;
        //    int max_count = 5;
        //    try
        //    {
        //        DateTime timeout = DateTime.Now.AddMilliseconds(time_sec * 1000);

        //        while (true)
        //        {
        //            if (heartbeat_count >= max_count)
        //                break;

        //            if (timeout < DateTime.Now)
        //            {
        //                string error = $"Heart Beat Time out...\n" +
        //                               $"{heartbeat_count} heart beat detected...";
        //                throw new Exception(error);
        //            }

        //            byte[] bytes = await this.ComPort.ReadMavlink();
        //            if (bytes is null)
        //            {
        //                continue;
        //            }

        //            Packet packet = new Packet(bytes);

        //            if (!packet.IsValid)
        //            {
        //                continue;
        //            }

        //            if (packet.MSGID == 0)
        //            {
        //                heartbeats.Add(packet);
        //                heartbeat_count += 1;
        //            }
        //        }

        //        /// connect and set system and component id.
        //        // TODO : search in heart beats list.
        //        //this.SysId = heartbeats[0].SysId;
        //        //this.CompId = heartbeats[0].CompId;
        //        int[] result = new int[3];
        //        result[0] = heartbeats[0].STX;
        //        result[1] = heartbeats[0].SYSID;
        //        result[2] = heartbeats[0].COMPID;

        //        Message_HEARTBEAT m = (Message_HEARTBEAT)heartbeats[0].Message;
        //        this.MAV_AUTOPILOT = (MAV_AUTOPILOT)m.autopilot;
        //        this.MAV_TYPE = (MAV_TYPE)m.type;

        //        Debug.WriteLine($"{heartbeat_count} : heart beat detected.");

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        System.Diagnostics.Debug.WriteLine(e.Message);
        //        throw e;
        //    }
        //}

        ///// <summary>
        ///// Get all param from uav.
        ///// </summary>
        ///// <returns></returns>
        //public async Task<Tuple<bool, bool>> GetParams(double timeoutSecond = 20)
        //{
        //    try
        //    {
        //        Message message = new Message_PARAM_REQUEST_LIST((byte)this.SysId, (byte)this.CompId);
        //        this.SendMessage(message);

        //        Thread.Sleep(1000);
        //        DateTime timeout = DateTime.Now.AddMilliseconds(timeoutSecond * 1000);

        //        bool isReceivingStart = false;

        //        int retry = 3;
        //        while (true)
        //        {
        //            if (timeout < DateTime.Now)
        //                throw new Exception("timeout");

        //            if(retry > 0)
        //            {
        //                retry--;
        //                this.SendMessage(message);
        //            }

        //            byte[] raws = await this.ComPort.ReadMavlink();
        //            Packet packet = new Packet(raws);

        //            if (!packet.IsValid)
        //                continue;

        //            if (packet.MSGID == 22)
        //            {
        //                if (!isReceivingStart)
        //                {
        //                    this.Params = new Dictionary<ushort, Message_PARAM_VALUE>();
        //                    this.ParameterCount = (packet.Message as Message_PARAM_VALUE).param_count;
        //                    isReceivingStart = true;
        //                }

        //                Message_PARAM_VALUE parameter = (Message_PARAM_VALUE)packet.Message;
        //                if (!this.Params.ContainsKey(parameter.param_index) & parameter.param_index < this.ParameterCount)
        //                {
        //                    this.Params.Add(parameter.param_index, parameter);
        //                    //string name = Encoding.ASCII.GetString(parameter.param_id).TrimEnd('\0');

        //                    //Debug.WriteLine($"{name}/ {parameter.param_index}, {parameter.param_count}");

        //                }

        //                if (this.Params.Count == this.ParameterCount)
        //                {
        //                    Debug.WriteLine("Complete receiving parameter.");
        //                    break;
        //                }
        //            }
        //        }

        //        return new Tuple<bool, bool>(true, true);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine(e.Message);
        //        return new Tuple<bool, bool>(true, false);
        //    }
        //}

        /*
         * Peach Interface is based on singleton
         *  - read and write mavlink packet using just one instance. 
         */

        #region Instance & Constructor
        private static readonly object instanceLock = new object();

        private static ComInterface _instance;

        /// <summary>
        /// static Instance.
        /// </summary>
        public static ComInterface Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (_instance is null)
                    {
                        _instance = new ComInterface();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        private ComInterface()
        {

        }

        /// <summary>
        /// DeConstructor
        /// </summary>
        ~ComInterface()
        {
        }

        #endregion

        /// <summary>
        /// Communication port to connected vehicle and used temporary.
        /// </summary>
        public ComPort ComPort { get; private set; } = null;

        /// <summary>
        /// Current System id
        /// </summary>
        public int CurrentSystemId { get; private set; } = -1;

        /// <summary>
        /// Current Component Id
        /// </summary>
        public int CurrentComponentId { get; private set; } = -1;

        /// <summary>
        /// Vehicle Dictionary.
        /// </summary>
        public Vehicles Vehicles { get; internal set; } = new Vehicles();

        /// <summary>
        /// Get Current Vehicle. Nullable.
        /// </summary>
        /// <returns></returns>
        public Vehicle GetCurrnetVehicle()
        {
            return this.Vehicles.Get(this.CurrentSystemId, this.CurrentComponentId);
        }

        /// <summary>
        /// Check the given portname is used or not and return ComPort(Nullable)
        /// </summary>
        /// <param name="portname"></param>
        /// <returns></returns>
        private ComPort IsComportUsed(string portname)
        {
            foreach (KeyValuePair<Tuple<int, int>, Vehicle> pair in this.Vehicles)
            {
                if (pair.Value.ComPort.PortName == portname)
                {
                    return pair.Value.ComPort;
                }
            }
            return null;
        }

        /// <summary>
        /// Check the given portname is used single instance or not.
        /// </summary>
        /// <param name="portname"> Communication port name.</param>
        /// <returns>true if ComPort is used for two or more vehicles.</returns>
        private bool IsComportMultiUsed(string portname)
        {
            int r = 0;
            foreach(KeyValuePair<Tuple<int, int>, Vehicle> pair in this.Vehicles)
            {
                if(pair.Value.ComPort.PortName == portname)
                {
                    r++;
                    if (r >= 1) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Connect UAV
        /// </summary>
        /// <param name="portname"></param>
        /// <param name="baudrate"></param>
        /// <returns></returns>
        public bool ConnectUAV(string portname, int baudrate)
        {
            try
            {
                // check comport is used.
                this.ComPort = this.IsComportUsed(portname);

                if (this.ComPort is null)
                {
                    this.ComPort = new ComPort(portname, baudrate);
                    this.ComPort.Open();
                }

                // get heartbeat.
                Vehicle temp = new Vehicle(this.ComPort);
                if (!temp.DetectHeartBeat())
                {
                    throw new Exception("HeartBeat is not detected.");
                }
                this.Vehicles.Add(temp.SystemId, temp.ComponentId, temp);
                this.CurrentSystemId = temp.SystemId;
                this.CurrentComponentId = temp.ComponentId;

                // get parameters.
                temp.RequestAllParameters();
                temp.InitializeSubscribing();

                return true;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                this.ComPort = null;
            }
        }

        /// <summary>
        /// Dis Connect UAV
        /// </summary>
        /// <param name="systemid"></param>
        /// <param name="componentid"></param>
        public void DisConnectUAV(int systemid, int componentid)
        {
            Vehicle vehicle;
            try
            {
                vehicle = this.Vehicles.Get(systemid, componentid);
                if (vehicle is null)
                {
                    // not connected vehicle.
                    return;
                }
                this.Vehicles.Remove(systemid, componentid);

                this.ComPort = vehicle.ComPort;
                if (this.ComPort is null)
                {
                    // ComPort is already null.
                    return;
                }

                vehicle.CleanSubscribe();

                bool isMulti = this.IsComportMultiUsed(this.ComPort.PortName);
                if (!isMulti)
                {
                    this.ComPort.Close();
                    this.ComPort.Dispose();
                    this.ComPort = null;
                }

                GC.Collect();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            try
            {
                foreach(var v in this.Vehicles)
                {
                    this.DisConnectUAV(v.Key.Item1, v.Key.Item2);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Interface DIspose");
                Debug.WriteLine(e.Message);
            }
            
        }
    }
}
