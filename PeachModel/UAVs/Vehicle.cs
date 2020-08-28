using PeachModel.CommunicationPort;
using PeachModel.Mavlink;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeachModel.UAVs
{
    public partial class Vehicle : VehicleStatus, IDisposable
    {
        public int SystemId { get; private set; } = -1;
        public int ComponentId { get; private set; } = -1;

        internal ComPort ComPort { get; set; }

        public Vehicle(ComPort comport)
        {
            this.ComPort = comport;
        }

        /// <summary>
        /// sequence of vehicle message.
        /// </summary>
        private int _seq = 0;
        /// <summary>
        /// Sequence
        /// </summary>
        public byte Seq
        {
            get => (byte)(_seq++ % 256);
        }

        /// <summary>
        /// confirmation of command.
        /// </summary>
        private int _confirmation = 0;
        /// <summary>
        /// Confirmation
        /// </summary>
        public byte Confirmation
        {
            get => (byte)(_confirmation++ % 256);
        }


        /// <summary>
        /// TODO :
        /// for memory release.
        /// </summary>
        private List<uint> _subscribedMessages = new List<uint>();
    }
}
