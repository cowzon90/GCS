using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Mavlink
{
    public abstract class MavCMD
    {
        public float Param1 { get; set; } = 0.0f;
        public float Param2 { get; set; } = 0.0f;
        public float Param3 { get; set; } = 0.0f;
        public float Param4 { get; set; } = 0.0f;
        public float Param5 { get; set; } = 0.0f;
        public float Param6 { get; set; } = 0.0f;
        public float Param7 { get; set; } = 0.0f;

        public byte[] ToBuffer()
        {
            return null;
        }
    }
}
