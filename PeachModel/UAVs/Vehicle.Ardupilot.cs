using Ardupilot = PeachModel.Mavlink.Ardupilotmega;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeachModel.Mavlink;

namespace PeachModel.UAVs
{
    public partial class Vehicle
    {
        public bool SetCopterMode(Ardupilot.MavEnums.COPTER_MODE mode)
        {
            float p1 = (float)MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_CUSTOM_MODE_ENABLED;
            float p2 = (float)mode;
            float p3 = 0;

            return SendCommandLong(176, p1, p2, p3, 0, 0, 0, 0);
        }

        public string GetCopterMode()
        {
            if (this.IsCustomModeEnabled)
            {
                try
                {
                    Ardupilot.MavEnums.COPTER_MODE mode = (Ardupilot.MavEnums.COPTER_MODE)this.custom_mode;

                    return mode.ToString().Replace("COPTER_MODE_", "").Replace("_", " ");
                }
                catch (Exception)
                {
                    return "UnKnown";
                }
            }
            return "Unknown";
        }

    }
}
