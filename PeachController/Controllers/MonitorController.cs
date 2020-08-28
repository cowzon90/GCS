using PeachModel.CommunicationPort;
using PeachModel.Mavlink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachController.Controllers
{
    public class MonitorController
    {
        public static MonitorController @Instance { get => SingleTon<MonitorController>.Instance; }

        public void SetMonitoringDataStream()
        {
            // Map -> #24 GPS_RAW_INT
            InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_ALL);             // 0
            //InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_RAW_SENSORS);     // 1
            //InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_EXTENDED_STATUS); // 2
            //InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_RC_CHANNELS);     // 3
            //InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_RAW_CONTROLLER);  // 4
            
            //InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_EXTRA1);
            //InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_EXTRA2);
            //InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_EXTRA3);

            InterfaceController.Instance.GetCurrentVehicle().SendMessage(new Message_MESSAGE_INTERVAL(10, 34));

            // HUD -> #76 VFR_HUD
            InterfaceController.Instance.SetDataStream(10, (byte)MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_EXTRA2);

            InterfaceController.Instance.GetCurrentVehicle().DoSubscribeDataStream(30);
            InterfaceController.Instance.GetCurrentVehicle().DoSubscribeDataStream(74);

        }

        public int GetSystemId()
        {
            return InterfaceController.Instance.GetCurrentVehicle().SystemId;
        }

        public int GetComponentId()
        {
            return InterfaceController.Instance.GetCurrentVehicle().ComponentId;
        }

        public int GetMavlinkVersion()
        {
            bool result = InterfaceController.Instance.GetCurrentVehicle().IsMavlink2;
            if(result)
            {
                return 253;
            }
            return 254;
        }

        public byte GetBaseMode()
        {
            return InterfaceController.Instance.GetCurrentVehicle().base_mode;
        }

        public byte GetSystemStatus()
        {
            return InterfaceController.Instance.GetCurrentVehicle().system_status;
        }

        #region HUD
        

        
        #endregion

    }
}
