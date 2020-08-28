using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Mavlink
{
    public partial class Packet
    {
        public Packet()
        {

        }

        /// <summary>
        /// Constructor with buffer and receive time.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="receiveTime"></param>
        public Packet(byte[] buffer, DateTime receiveTime)
        {
            this.ReceiveTime = receiveTime;
            this.Buffer = buffer;
            this.IsValid = this.ParseToValues(buffer);
        }

        /// <summary>
        /// Contructor with buffer
        /// </summary>
        /// <param name="buffer"></param>
        public Packet(byte[] buffer) : this(buffer, DateTime.UtcNow)
        {

        }

        /// <summary>
        /// parse buffer to packet values.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private bool ParseToValues(byte[] buffer)
        {
            if (buffer is null)
            {
                return false;
            }

            try
            {
                // set datas.
                int i = 0;
                this.STX = buffer[i++];
                this.LEN = buffer[i++];

                if (this.IsMavLink2)
                {
                    this.INCOMPATIBILITY_FLAGS = buffer[i++];
                    this.COMPATIBILITY_FLAGS = buffer[i++];
                }

                this.SEQ = buffer[i++];
                this.SYSID = buffer[i++];
                this.COMPID = buffer[i++];


                if (this.IsMavLink2)
                {
                    this.MSGID = (uint)(buffer[i++] + (buffer[i++] << 8) + (buffer[i++] << 16));
                }
                else
                {
                    this.MSGID = (uint)(buffer[i++]);
                }

                _payload = new byte[this.LEN];
                for (int p = 0; p < this.LEN; p++)
                {
                    _payload[p] = buffer[i++];
                }

                // TODO : check crc -> CHECKSUM
                this.CHECKSUM = (ushort)((buffer[i++] << 8) + buffer[i++]);

                // _signature
                if (this.INCOMPATIBILITY_FLAGS == 0x01)
                {
                    _signature = new byte[13];
                    for (int p = 0; p < 13; p++)
                    {
                        _signature[p] = buffer[i++];
                    }
                }


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Make mavlink1 packet.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="system_id"></param>
        /// <param name="component_id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Packet CreateMavLink1(byte sequence,
                                               byte system_id,
                                               byte component_id,
                                               Message message)
        {

            List<byte> bytes = new List<byte>();
            bytes.Add(0xFE);
            bytes.Add(Message.GetMessageLen(message));
            bytes.Add(sequence);
            bytes.Add(system_id);
            bytes.Add(component_id);
            bytes.Add((byte)(Message.GetMessageId(message)));

            // _payload.
            foreach (byte b in message.Buffer)
            {
                bytes.Add(b);
            }

            // checksum
            byte[] p = bytes.ToArray();
            ushort checksum = MavLinkCRC.crc_calculate(p, 6 + bytes[1]);
            byte crc = Message.GetCRC(message);
            checksum = MavLinkCRC.crc_accumulate(crc, checksum);
            bytes.Add((byte)(checksum & 0xFF));
            bytes.Add((byte)(checksum >> 8));

            return new Packet(bytes.ToArray());
        }

        /// <summary>
        /// Make Mavlink2 packet.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="system_id"></param>
        /// <param name="component_id"></param>
        /// <param name="message"></param>
        /// <param name="isIncompatibility"></param>
        /// <param name="signature"></param>
        /// <returns></returns>
        public static Packet CreateMavLink2(byte sequence,
                                               byte system_id,
                                               byte component_id,
                                               Message message,
                                               bool isIncompatibility = false,
                                               object signature = null)
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(0xFD);
            bytes.Add(Message.GetMessageLen(message));

            // incompatibiltiy_flags
            if (isIncompatibility)
                bytes.Add(0x01);
            else
                bytes.Add(0);
            bytes.Add(0);   //compatibility_flags

            bytes.Add(sequence);
            bytes.Add(system_id);
            bytes.Add(component_id);

            uint msgid = Message.GetMessageId(message);
            bytes.Add((byte)(msgid));       // low
            bytes.Add((byte)(msgid << 8));  // mid
            bytes.Add((byte)(msgid << 16)); // high

            foreach (byte b in message.Buffer)
            {
                bytes.Add(b);
            }

            // add signature
            if (isIncompatibility)
            {
                // TODO
            }

            return new Packet(bytes.ToArray());
        }
    }
}
