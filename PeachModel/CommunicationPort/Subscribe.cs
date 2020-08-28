using PeachModel.Mavlink;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeachModel.CommunicationPort
{
    public class Subscribe
    {
        /// <summary>
        /// Communication Port
        /// </summary>
        private ComPort ComPort { get; set; }

        protected List<Subscriber> Subscribers = new List<Subscriber>();
        private readonly object subscribeLock = new object();
        private SemaphoreSlim subscriberSemaphoreSlim = new SemaphoreSlim(1, 1);

        private SemaphoreSlim waitListSemaphore = new SemaphoreSlim(1, 1);
        private readonly object waitListLock = new object();
        protected List<string> WaitToRemove { get; set; }

        public Subscribe(ComPort comport)
        {
            this.ComPort = comport;
            this.Reader = new Thread(this.Read);
            this.Reader.Start();
        }

        #region About Thread
        public bool IsThreadAlive
        {
            get
            {
                if(this.Reader == null)
                {
                    return false;
                }

                return this.Reader.IsAlive;
            }
        }
        
        /// <summary>
        /// Reading Thread
        /// </summary>
        private Thread Reader { get; set; }

        /// <summary>
        /// Stop Thread.
        /// </summary>
        public void StopReader()
        {
            try
            {
                if (Reader is null)
                {
                    return;
                }

                if (Reader.IsAlive == false)
                {
                    // already dead.
                    return;
                }

                this.Reader.Abort();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Force to start thread.
        /// </summary>
        /// <returns></returns>
        public bool StartReader()
        {
            try
            {
                if (this.Reader.IsAlive)
                {
                    // already running
                    return true;
                }

                this.Reader.Start();

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Subscribe StartReader method throw exception.");
                Debug.WriteLine(e.Message);
                return false;
                throw;
            }
        }

        /// <summary>
        /// Reading packet function.
        /// </summary>
        private void Read()
        {
            while (true)
            {
                bool isStopCondition = true;
                if (this.ComPort is null) isStopCondition &= false;

                if (!this.ComPort.IsOpen) isStopCondition &= false;

                if (!isStopCondition)
                {
                    // stop thread
                    this.ComPort.Close();
                    this.Reader.Abort();
                    return;
                }

                byte[] raws = this.ComPort.ReadMavlink().Result;

                Packet packet = new Packet(raws);

                if (!packet.IsValid)
                {
                    Debug.WriteLine("invalid packet ");
                    continue;
                }

                #region TODO : unreadable
                Message message = packet.Message;
                if (message is null)
                {
                    if (!unreadableMessageIds.ContainsKey(packet.MSGID))
                    {
                        unreadableMessageIds.Add(packet.MSGID, packet.MSGID);
                    }
                }
                #endregion

                this.DoSubscriberTasks(packet);
            }
        }

        /// <summary>
        /// run each subscriber's task for input packet.
        /// </summary>
        /// <param name="packet"></param>
        private void DoSubscriberTasks(Packet packet)
        {
            List<string> removes = new List<string>();
            // search Subsribers.
            this.subscriberSemaphoreSlim.Wait();
            lock (this.subscribeLock)
            {
                foreach (Subscriber subscriber in Subscribers)
                {
                    if (subscriber.SystemId == packet.SYSID & subscriber.ComponentId == packet.COMPID)
                    {
                        if (subscriber.MsgId != packet.MSGID) continue;

                        // TODO : async Task.
                        bool result = subscriber.InvokeFunc(packet);

                        if (subscriber.PERMANENCY != PERMANENCY.DISPOSABLE) continue;

                        if (result)
                        {
                            //this.Subscribers.Remove(subscriber);
                            removes.Add(subscriber.Name);
                        }
                        continue;
                    }

                    /// for Detecting new heart beat.
                    /// system id & component id == -1.
                    if (packet.MSGID == 0)
                    {
                        bool result = subscriber.InvokeFunc(packet);
                    }
                }
                this.RemoveSubscribers(removes);
            }
            this.subscriberSemaphoreSlim.Release();
        }

        #endregion

        #region Subscribing

        /// <summary>
        /// Add subscriber with func and set timeout seconds. default = 3.0
        /// </summary>
        /// <param name="name"></param>
        /// <param name="msgid"></param>
        /// <param name="func"></param>
        /// <param name="timeoutSeconds"></param>
        public void DoSubscribe(int sysid, int compid, uint msgid, Func<Packet, object> func, PERMANENCY permanency = PERMANENCY.DISPOSABLE, double timeoutSeconds = 5.0)
        {
            this.DoSubscribe(new Subscriber(sysid, compid, msgid, func, permanency: permanency, timeoutSec: timeoutSeconds));
        }

        /// <summary>
        /// Add Subscribe func
        /// </summary>
        /// <param name="subscriber"></param>
        public async void DoSubscribe(Subscriber subscriber)
        {
            Debug.WriteLine($"Subscriber Sub : wait semaphore {subscriber.Name}");

            bool getSemaphore = await this.subscriberSemaphoreSlim.WaitAsync(1000);
            if (getSemaphore)
            {
                Debug.WriteLine($"Subscriber Sub : got semaphore {subscriber.Name}");
                lock (this.Subscribers)
                {
                    this.Subscribers.Add(subscriber);
                }
                this.subscriberSemaphoreSlim.Release();
                return;
            }

            Debug.WriteLine($"Subscriber Sub : pass semaphore {subscriber.Name}");

        }

        /// <summary>
        /// Make UnSubscribe list.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="msgid"></param>
        public async void AddUnSubscriber(int sysid, int compid, uint msgid)
        {
            string unique = Subscriber.MakeUnique(sysid, compid, msgid);
            if (await this.waitListSemaphore.WaitAsync(1000))
            {
                lock (this.waitListLock)
                {
                    if (this.WaitToRemove is null)
                    {
                        this.WaitToRemove = new List<string>();
                    }

                    this.WaitToRemove.Add(unique);
                }
                this.waitListSemaphore.Release();
                return;
            }
        }
        #endregion

        #region TODOs

        /// <summary>
        /// TODO : just test.
        /// </summary>
        private Dictionary<uint, uint> unreadableMessageIds = new Dictionary<uint, uint>();

        /// <summary>
        /// TODO : Do not use...
        /// </summary>
        /// <param name="name"></param>
        /// <param name="msgid"></param>
        public async void DoUnSubscribeBulk(int sysid, int compid, params uint[] msgid)
        {
            List<string> uniques = new List<string>();
            foreach (uint id in msgid)
            {
                uniques.Add(Subscriber.MakeUnique(sysid, compid, id));
            }

            // TODO : checker
            StringBuilder sb = new StringBuilder();
            foreach (string unique in uniques)
            {
                sb.AppendLine(unique);
            }
            string names = sb.ToString();


            Debug.WriteLine($"{names} wait semaphore");
            bool getSemaphore = await this.subscriberSemaphoreSlim.WaitAsync(1000);
            if (getSemaphore)
            {
                Debug.WriteLine($"{names} got semaphore");
                lock (this.Subscribers)
                {
                    try
                    {
                        foreach (string unique in uniques)
                        {
                            Subscriber subscriber = this.Subscribers.Where(s => s.Name == unique).FirstOrDefault();

                            if (subscriber is null)
                            {
                                continue;
                            }

                            this.Subscribers.Remove(subscriber);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        throw;
                    }
                }
                this.subscriberSemaphoreSlim.Release();
                return;
            }


            Debug.WriteLine($"{names} pass semaphore");
        }

        private void RemoveSubscribers(List<string> names)
        {
            // wait list
            this.waitListSemaphore.WaitAsync(200);
            if (this.WaitToRemove != null)
            {
                lock (this.waitListLock)
                {
                    foreach (string temp in this.WaitToRemove)
                    {
                        names.Add(temp);
                    }
                    this.WaitToRemove = null;
                }
            }
            this.waitListSemaphore.Release();


            // remove time out subscriber
            foreach (Subscriber subscriber in this.Subscribers)
            {
                if (subscriber.IsTimeout)
                {
                    names.Add(subscriber.Name);
                    // TODO :
                    //subscriber.InvokeFunc(null);
                }
            }

            foreach (string name in names)
            {
                Subscriber subscriber = this.Subscribers.Where(sub => sub.Name.Equals(name) == true).FirstOrDefault();
                if (subscriber is null)
                {
                    continue;
                }
                this.Subscribers.Remove(subscriber);
                Debug.Write($"Subscriber Remove : {subscriber.Name}");
            }
        }

        #endregion
    }
}
