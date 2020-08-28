using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Firmwares
{
    public abstract class Firmware
    {

        /// <summary> Image string </summary>
        public string Image { get; internal set; }

        /// <summary> Size of image. </summary>
        public int ImageSize { get; internal set; }

        /// <summary> Image to Bytes </summary>
        public byte[] ImageBytes { get; internal set; }

        /// <summary> Board id. </summary>
        public int BoardId { get; internal set; }

    }
}
