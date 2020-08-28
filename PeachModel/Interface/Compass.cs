using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Interface
{
    public class Compass
    {
        public int CompassID { get; set; }
        public double CompassUse { get; set; }
        public double CompassExternal { get; set; }
        public double CompassOrient { get; set; }
        public double CompassOFSX { get; set; }
        public double CompassOFSY { get; set; }
        public double CompassOFSZ { get; set; }
        public double CompassMOTX { get; set; }
        public double CompassMOTY { get; set; }
        public double CompassMOTZ { get; set; }
    }
}
