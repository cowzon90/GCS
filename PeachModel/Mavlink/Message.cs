using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Mavlink
{
    /// <summary>
    /// MavLink Message info
    /// </summary>
    public class MessageInfo : Attribute
    {
        public string Description { get; internal set; }
        public byte MessageLen { get; internal set; }
        public byte CRC { get; internal set; }
        public uint MsgId { get; internal set; }
        public MessageInfo(uint msgid, byte len, byte crc, string description)
        {
            this.MsgId = msgid;
            this.MessageLen = len;
            this.CRC = crc;
            this.Description = description;
        }
    }

    public abstract class Message
    {
        public static Dictionary<uint, Type> MessageTypes = new Dictionary<uint, Type>()
        {
            {0, typeof(Message_HEARTBEAT) },
            {1, typeof(Message_SYS_STATUS) },
            {2, typeof(Message_SYSTEM_TIME) },

            {20, typeof(Message_PARAM_REQUEST_READ) },
            {21, typeof(Message_PARAM_REQUEST_LIST) },
            {22, typeof(Message_PARAM_VALUE) },
            {23, typeof(Message_PARAM_SET) },
            {24, typeof(Message_GPS_RAW_INT) },
            {25, typeof(Message_GPS_STATUS) },
            {26, typeof(Message_SCALED_IMU) },
            {27, typeof(Message_RAW_IMU) },
            {28, typeof(Message_RAW_PRESSURE) },
            {29, typeof(Message_SCALED_PRESSURE) },
            {30, typeof(Message_ATTITUDE) },
            {31, typeof(Message_ATTITUDE_QUATERNION) },
            {32, typeof(Message_LOCAL_POSITION_NED) },
            {33, typeof(Message_GLOBAL_POSITION_INT) },
            {34, typeof(Message_RC_CHANNELS_SCALED) },
            {35, typeof(Message_RC_CHANNELS_RAW) },
            {36, typeof(Message_SERVO_OUTPUT_RAW) },

            {42, typeof(Message_MISSION_CURRENT) },

            {62, typeof(Message_NAV_CONTROLLER_OUTPUT) },
            {63, typeof(Message_GLOBAL_POSITION_INT_COV) },
            {64, typeof(Message_LOCAL_POSITION_NED_COV) },
            {65, typeof(Message_RC_CHANNELS) },
            {66, typeof(Message_REQUEST_DATA_STREAM) },

            {74, typeof(Message_VFR_HUD) },
            {75, typeof(Message_COMMAND_INT) },
            {76, typeof(Message_COMMAND_LONG) },
            {77, typeof(Message_COMMAND_ACK) },

            {111, typeof(Message_TIMESYNC) },
            {112, typeof(Message_CAMERA_TRIGGER) },
            {113, typeof(Message_HIL_GPS) },
            {114, typeof(Message_HIL_OPTICAL_FLOW) },
            {115, typeof(Message_HIL_STATE_QUATERNION) },
            {116, typeof(Message_SCALED_IMU2) },

            {125, typeof(Message_POWER_STATUS) },

            {129, typeof(Message_SCALED_IMU3) },

            {136, typeof(Message_TERRAIN_REPORT) },
            {137, typeof(Message_SCALED_PRESSURE2) },

            {147, typeof(Message_BATTERY_STATUS) },
            {148, typeof(Message_AUTOPILOT_VERSION) },
            {149, typeof(Message_LANDING_TARGET) },
            {150, typeof(Message_SENSOR_OFFSETS) },
            {151, typeof(Message_SET_MAG_OFFSETS) },
            {152, typeof(Message_MEMINFO) },

            {163, typeof(Message_AHRS) },
            {164, typeof(Message_SIMSTATE) },
            {165, typeof(Message_HWSTATUS) },

            {178, typeof(Message_AHRS2) },
            {179, typeof(Message_CAMERA_STATUS) },
            {180, typeof(Message_CAMERA_FEEDBACK)},
            {181, typeof(Message_BATTERY2)},
            {182, typeof(Message_AHRS3)},
            {183, typeof(Message_AUTOPILOT_VERSION_REQUEST) },
            
            {191, typeof(Message_MAG_CAL_PROGRESS) },
            {192, typeof(Message_MAG_CAL_REPORT) },
            {193, typeof(Message_EKF_STATUS_REPORT) },

            {241, typeof(Message_VIBRRATION) },
            {242, typeof(Message_HOME_POSITION) },
            {243, typeof(Message_SET_HOME_POSITION) },
            {244, typeof(Message_MESSAGE_INTERVAL) },

            {253, typeof(Message_STATUSTEXT) },

        };

        /// <summary>
        /// Constructor with Message values.
        /// </summary>
        /// <param name="values"></param>
        public Message(params object[] values)
        {
            var result = ToBytes(values);
            this.IsValid = result.Item1;
            this.Buffer = result.Item2;
        }

        /// <summary>
        /// message values to byte array and if it can't parse then return false.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        protected (bool, byte[]) ToBytes(object values)
        {
            List<byte> bytes = new List<byte>();
            try
            {
                object[] objects = (object[])values;

                foreach (object obj in objects)
                {
                    string fieldOfName = obj.GetType().FullName;
                    byte[] temp;
                    switch (fieldOfName)
                    {
                        case "System.Byte":
                            temp = new byte[] { (byte)obj };

                            break;
                        case "System.SByte":    // TODO : sbyte
                            temp = new byte[] { (byte)obj };
                            break;
                        case "System.Byte[]":
                            temp = (byte[])obj;

                            break;
                        case "System.UInt16":

                            temp = BitConverter.GetBytes((ushort)obj);

                            break;
                        case "System.UInt32":
                            temp = BitConverter.GetBytes((uint)obj);

                            break;
                        case "System.UInt64":
                            temp = BitConverter.GetBytes((ulong)obj);

                            break;
                        case "System.Int16":
                            temp = BitConverter.GetBytes((Int16)obj);

                            break;
                        case "System.Int32":
                            temp = BitConverter.GetBytes((int)obj);

                            break;
                        case "System.Int64":
                            temp = BitConverter.GetBytes((long)obj);

                            break;
                        case "System.Single":
                            temp = BitConverter.GetBytes((float)obj);

                            break;
                        case "System.Double":
                            temp = BitConverter.GetBytes((double)obj);

                            break;
                        default:
                            temp = new byte[0];

                            break;
                    }

                    foreach (byte t in temp)
                    {
                        bytes.Add(t);
                    }
                }
            }
            catch (Exception e)
            {
                return (false, null);
            }
            return (true, bytes.ToArray());
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Message()
        {

        }

        /// <summary>
        /// Create Message
        /// </summary>
        /// <param name="msgid"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Message CreateMessage(uint msgid, byte[] buffer)
        {
            try
            {
                // msgid => HeartBeat
                Type type;
                if (!MessageTypes.TryGetValue(msgid, out type))
                {
                    return null;
                    throw new Exception($"Can not find message type. MSGID : {msgid}");
                }

                var instance = Activator.CreateInstance(type);

                (instance as Message).Buffer = buffer;
                bool result = (instance as Message).Parsing(instance, type, buffer);
                ((Message)instance).IsValid = result;

                if (!result)
                {
                    string parsing_error = $"Parsing error.\n" +
                        $"message id : {msgid}\n" +
                        $"message type : {type.Name}";
                    throw new Exception(parsing_error);
                }

                return (Message)instance;
            }
            catch (Exception e)
            {
                // No Message.
                //Debug.WriteLine(e.Message);   // TODO 
                return null;
                throw;
            }
        }

        /// <summary>
        /// parsing
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="type"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        protected bool Parsing(object instance, Type type, byte[] buffer)
        {
            try
            {
                int i = 0;

                FieldInfo[] fields = type.GetFields();

                for (int f = 0; f < fields.Length; f++)
                {
                    if (i >= buffer.Length) break;

                    FieldInfo field = fields[f];

                    string nameOfField = field.FieldType.FullName;
                    switch (nameOfField)
                    {
                        case "System.Byte": // byte
                            field.SetValue(instance, buffer[i++]);

                            break;
                        //case "System.SByte":    // sbyte
                        //    field.SetValue(instance, buffer[i++]);

                        //    break;
                        case "System.Byte[]":   // byte array.

                            byte[] value = (byte[])field.GetValue(instance);
                            for (int v = 0; v < value.Length; v++)
                            {
                                value[v] = buffer[i++];
                            }

                            break;
                        case "System.UInt16":
                            field.SetValue(instance, BitConverter.ToUInt16(buffer, i));
                            i += 2;

                            break;
                        case "System.UInt32":
                            field.SetValue(instance, BitConverter.ToUInt32(buffer, i));
                            i += 4;

                            break;
                        case "System.UInt64":
                            field.SetValue(instance, BitConverter.ToUInt64(buffer, i));
                            i += 8;

                            break;
                        case "System.Int16":
                            field.SetValue(instance, BitConverter.ToInt16(buffer, i));
                            i += 2;

                            break;
                        case "System.Int32":
                            field.SetValue(instance, BitConverter.ToInt32(buffer, i));
                            i += 4;

                            break;
                        case "System.Int64":
                            field.SetValue(instance, BitConverter.ToInt64(buffer, i));
                            i += 8;

                            break;
                        case "System.Single":
                            field.SetValue(instance, BitConverter.ToSingle(buffer, i));
                            i += 4;

                            break;
                        case "System.Double":
                            field.SetValue(instance, BitConverter.ToDouble(buffer, i));
                            i += 8;

                            break;
                        default:
                            break;
                    }

                }

            }
            catch (Exception e)
            {
                return false;
                throw;
            }
            return true;
        }

        /// <summary>
        /// payload
        /// </summary>
        public byte[] Buffer { get; internal set; }

        /// <summary>
        /// check validation of this message.
        /// </summary>
        public bool IsValid { get; internal set; }

        #region TODO : below

        /// <summary>
        /// Get MessageInfo instance of message object.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static MessageInfo GetMessageInfo(Message message)
        {
            try
            {
                return message.GetType().GetCustomAttribute<MessageInfo>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get crc value of message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static byte GetCRC(Message message)
        {
            try
            {
                var t = message.GetType().GetCustomAttribute<MessageInfo>();
                return t.CRC;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get length of message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static byte GetMessageLen(Message message)
        {
            try
            {
                var t = message.GetType().GetCustomAttribute<MessageInfo>();
                return t.MessageLen;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get Message id.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static uint GetMessageId(Message message)
        {
            try
            {
                var t = message.GetType().GetCustomAttribute<MessageInfo>();
                return t.MsgId;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
