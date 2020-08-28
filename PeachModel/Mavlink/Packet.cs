using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Mavlink
{
    // MavLink1 Packet Frame.
    /* 
     * 8 - 263 Bytes
     * 
     * STX / LEN / SEQ / SYS ID / COMP ID / MSG ID / PAYLOAD / CHECKSUM
     * 
     * STX : Packet Start Marker == 0xFE (1byte)
     * LEN : Payload length (1byte)
     * SEQ : Packet seqence number (1byte)
     * SYS ID : System ID (1byte)
     * COMP ID : Component ID (1byte)
     * MSG ID : Message ID (1byte)
     * PAYLOAD : Message Data -> byte[LEN]
     * CHECKSUM : X.25 CRC excluding 'STX' -> (2bytes)
     */

    // Mavlink 2 Frame Format
    /* 
     * 11 - 279 Bytes
     * 
     * STX | LEN | INC FLAGS | CMP FLAGS | SEQ | SYS ID | COMP ID | MSG ID | PAYLOAD | CHECKSUM | SIGNATURE
     * 
     * STX : protocol magic marker
     * LEN : length of payload
     * INC FLAGS : if 0x01 use Incompatibiltiy flag field and add SIGNATURE field.
     * CMP FLAGS : 
     * SEQ : sequence of packet
     * SYS ID : id of message sender system/aircraft
     * COMP ID : id of the message sender component
     * MSG ID : 3bytes , 
     * PAYLOAD : 0-255bytes, 
     * CHECKSUM : 2bytes, X.25 CRC
     * SIGNATURE : 13bytes / link id (1byte) | tm.stamp (6bytes) | signature(6bytes)
     */

    public partial class Packet
    {
        private byte[] _payload;
        private byte[] _signature;

        private Message _message;

        public byte[] Buffer { get; internal set; }
        public byte STX { get; internal set; }
        public byte LEN { get; internal set; }
        public byte INCOMPATIBILITY_FLAGS { get; internal set; }
        public byte COMPATIBILITY_FLAGS { get; internal set; }
        public byte SEQ { get; internal set; }
        public byte SYSID { get; internal set; }
        public byte COMPID { get; internal set; }
        public uint MSGID { get; internal set; }
        public ushort CHECKSUM { get; internal set; }

        public DateTime ReceiveTime { get; private set; }
        public bool IsValid { get; private set; } = false;
        public bool IsMavLink2
        {
            get
            {
                if (this.STX == 0xFD)
                {
                    return true;
                }
                return false;
            }
        }

        public Message Message
        {
            get
            {
                if (_message is null)
                {
                    _message = Message.CreateMessage(this.MSGID, _payload);
                }
                return _message;
            }
        }
    }
}
