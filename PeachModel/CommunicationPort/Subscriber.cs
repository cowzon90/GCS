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
    public enum PERMANENCY
    {
        PERMANENT = 0,
        SEMI_PERMANENT = 1,
        DISPOSABLE = 2,
    }

    public class Subscriber : IDisposable
    {
        /// <summary>
        ///  TODO : 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="msgid"></param>
        /// <returns></returns>
        public static string MakeUnique(int sysid, int compid, uint msgid)
        {
            return $"{sysid}_{compid}_{msgid}";
        }

        /// <summary> Name </summary>
        public string Name { get; private set; }
        /// <summary> Message ID </summary>
        public uint MsgId { get; private set; }
        /// <summary> Nullable value </summary>
        public object Result { get; private set; }

        public int SystemId { get; private set; }
        public int ComponentId { get; private set; }

        private PERMANENCY _permanency;
        public PERMANENCY PERMANENCY
        {
            get
            {
                return _permanency;
            }
            private set
            {
                _permanency = value;

                switch (_permanency)
                {
                    case PERMANENCY.DISPOSABLE:
                        // run thread.
                        this.RunTimeoutThread();
                        break;
                    case PERMANENCY.SEMI_PERMANENT:
                        // run thread.
                        this.RunTimeoutThread();
                        break;
                    case PERMANENCY.PERMANENT:
                        // do nothing.
                        break;
                }
            }
        }

        #region Constructors and De-Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="msgid"></param>
        /// <param name="func"></param>
        private Subscriber(int sysid, int compid, uint msgid, Func<Packet, object> func)
        {
            this.Name = MakeUnique(sysid, compid, msgid);
            this.SystemId = sysid;
            this.ComponentId = compid;
            this.MsgId = msgid;
            this.Func = func;
        }

        /// <summary>
        /// Constructor with permanent option.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="msgid"></param>
        /// <param name="func"></param>
        /// <param name="isPermanent"></param>
        public Subscriber(int sysid, int compid, uint msgid, Func<Packet, object> func, PERMANENCY permanency, double timeoutSec = 5.0) : this(sysid, compid, msgid, func)
        {
            this.PERMANENCY = permanency;
            this.TimeoutSeconds = timeoutSec;
        }

        ~Subscriber()
        {
            // TODO : Dispose.
        }
        #endregion

        #region Timeout
        /// <summary> Timeout. </summary>
        public bool IsTimeout { get; private set; } = false;
        /// <summary>
        /// True mean that this Subscriber used for one-time only.
        /// False mean that this Subscriber Not affected by timeout.
        /// </summary>
        /// <summary> Seconds value for timeout </summary>
        public double TimeoutSeconds { get; private set; } = 5.0;
        /// <summary> Timeout Threading function. must be invoke when this instance is made </summary>
        private void RunTimeoutThread()
        {
            this.IsTimeout = false;
            Thread temp = new Thread(() =>
            {
                DateTime timeout = DateTime.Now.AddMilliseconds(this.TimeoutSeconds * 1000);
                while (true)
                {
                    if (DateTime.Now > timeout)
                    {
                        break;
                    }
                }
                Debug.WriteLine($"{Name}_{MsgId}_Timeout");
                this.IsTimeout = true;
            });
            temp.Start();
        }
        #endregion

        #region Func
        /// <summary> functuation </summary>
        private Func<Packet, object> Func { get; set; }

        /// <summary>
        /// Invoke functions.
        /// </summary>
        /// <param name="packet"></param>
        public bool InvokeFunc(Packet packet)
        {
            if (this.IsTimeout)
            {
                return false;
            }

            try
            {
                this.Result = this.Func.Invoke(packet);
                
                this.IsWait = false;    // done 
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                this.Result = null;
                return false;
            }
        }

        #endregion

        /// <summary>
        /// if false wait to result of func.
        /// </summary>
        public bool IsWait { get; private set; } = true;

        /// <summary>
        /// Check the state of result which be set or not.
        /// </summary>
        /// <returns></returns>
        private bool Checker()
        {
            //if (this.PERMANENCY == PERMANENCY.PERMANENT)
            //{
            //    return true;
            //}

            while (true)
            {
                if (IsTimeout)
                {
                    return false;
                }

                if (IsWait == false)
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Get Reulst Async can raise timeout.
        /// </summary>
        /// <returns></returns>
        public async Task<object> GetResultAsync()
        {
            try
            {
                this.IsWait = true;
                bool temp = await Task.Run(this.Checker).ConfigureAwait(false);

                if (temp)
                {
                    //return Convert.ChangeType(this.Result, this.ResultType);
                    return this.Result;
                }

                return null;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Dispose()
        {
            // TODO :
        }
    }
}
