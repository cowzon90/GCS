using PeachModel.Mavlink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.UAVs
{
    public class VehicleParameter
    {
        /// <summary>
        /// Index of parameter
        /// </summary>
        public ushort Index { get; internal set; }

        /// <summary>
        /// Value of parameter
        /// </summary>
        public float Value { get; internal set; }

        /// <summary>
        /// byte array of id
        /// </summary>
        public byte[] Id { get; internal set; }

        /// <summary>
        /// data type of this parameter
        /// </summary>
        public byte Type { get; internal set; }

        /// <summary>
        /// string id
        /// </summary>
        public string StringId
        {
            get
            {
                return Encoding.ASCII.GetString(this.Id).TrimEnd('\0');
            }
        }

        /// <summary>
        /// Description of this parameter.
        /// </summary>
        public string Description
        {
            get; internal set;
        }

        private VehicleParameter()
        {

        }

        public VehicleParameter(ushort index, float value, byte[] id, byte type)
        {
            this.Index = index;
            this.Value = value;
            this.Id = id;
            this.Type = type;
        }

        /// <summary>
        /// Parameter Message to Parameter instance.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static VehicleParameter ConvertToParameter(Message_PARAM_VALUE message)
        {
            if (!message.IsValid)
            {
                return null;
            }

            try
            {
                VehicleParameter temp = new VehicleParameter();
                temp.Id = message.param_id;
                temp.Index = message.param_index;
                temp.Type = message.param_type;
                temp.Value = message.param_value;
                return temp;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static byte[] ConvertTo16Bytes(string id)
        {
            int length = id.Length;
            char[] chars = id.ToCharArray();

            byte[] bytes = new byte[16];

            for (int i = 0; i < 16; i++)
            {
                if (i < length)
                    bytes[i] = (byte)chars[i];
                else
                    bytes[i] = (byte)'\0';

            }

            return bytes;
        }
    }
}
