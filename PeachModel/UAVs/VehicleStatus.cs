using PeachModel.Mavlink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeachModel.UAVs
{
    public partial class VehicleStatus
    {
        public VehicleStatus()
        {
            this.Parameters = new VehicleParameters();
        }

        /// <summary>
        /// Mavlink version
        /// </summary>
        public bool IsMavlink2 { get; private set; } = false;

        /// <summary>
        /// vehicle type as MAV_TYPE from HEARTBEAT
        /// </summary>
        public string Type
        {
            get => ((MavEnums.MAV_TYPE)this.type).ToString().Replace("MAV_TYPE_", "");
        }

        /// <summary>
        /// AutoPilot name as MAV_AUTOPILOT from HEATBEAT
        /// </summary>
        public string AutoPilot
        {
            get => ((MavEnums.MAV_AUTOPILOT)this.autopilot).ToString().Replace("MAV_AUTOPILOT_", "");
        }

        #region base mode
        
        /// <summary>
        /// Check mav mode
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool IsMavMode(MavEnums.MAV_MODE_FLAG mode)
        {
            return ((this.base_mode & (byte)mode) == (byte)mode);
        }

        /// <summary>
        /// Arming from HEARTBEAT
        /// </summary>
        public bool IsArmed
        {
            get => IsMavMode(MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_SAFETY_ARMED);
        }

        /// <summary>
        /// remote control input is enabled.
        /// </summary>
        public bool IsManualInputEnabled
        {
            get => IsMavMode(MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_MANUAL_INPUT_ENABLED);
        }

        /// <summary>
        /// hardware in the loop simulation is enabled.
        /// </summary>
        public bool IsHILEnanbled
        {
            get => IsMavMode(MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_HIL_ENABLED);
        }

        /// <summary>
        /// stabilize mode is enabled.
        /// </summary>
        public bool IsStabilizeEnabled
        {
            get => IsMavMode(MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_STABILIZE_ENABLED);
        }

        /// <summary>
        /// guided mode is enabled.
        /// </summary>
        public bool IsGuidedEnabled
        {
            get => IsMavMode(MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_GUIDED_ENABLED);
        }

        /// <summary>
        /// autonomous mode is enabled.
        /// </summary>
        public bool IsAutoEnabled
        {
            get => IsMavMode(MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_AUTO_ENABLED);
        }

        /// <summary>
        /// system has a test mode enabled.
        /// </summary>
        public bool IsTestEnabled
        {
            get => IsMavMode(MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_TEST_ENABLED);
        }

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public bool IsCustomModeEnabled
        {
            get => IsMavMode(MavEnums.MAV_MODE_FLAG.MAV_MODE_FLAG_CUSTOM_MODE_ENABLED);
        }

        #endregion

        /// <summary>
        /// MAV_STATE from HEARTBEAT
        /// </summary>
        public string SystemStatus
        {
            get => ((MavEnums.MAV_STATE)this.system_status).ToString().Replace("MAV_STATE_", "");
        }

        #region onboard control sensors (present, enabled, health)
        private readonly string MAV_SYS_STATUS_SENSOR_ = "MAV_SYS_STATUS_SENSOR_";
        private readonly string MAV_SYS_STATUS_ = "MAV_SYS_STATUS_";

        /// <summary>
        /// MAV_SYS_STATUS_SENSOR to string
        /// </summary>
        /// <param name="sensor"></param>
        /// <returns></returns>
        public string GetMAV_SYS_STATUS_SENSOR(uint sensor)
        {
            try
            {
                object o = Enum.ToObject(typeof(MavEnums.MAV_SYS_STATUS_SENSOR), sensor);
                string r = ((MavEnums.MAV_SYS_STATUS_SENSOR)o).ToString();
                if (r.StartsWith(MAV_SYS_STATUS_SENSOR_))
                {
                    return r.Replace(MAV_SYS_STATUS_SENSOR_, "");
                }
                return r.Replace(MAV_SYS_STATUS_, "");
            }
            catch (Exception)
            {
                return MavEnums.MAV_SYS_STATUS_SENSOR.NONE.ToString();
            }
        }

        /// <summary>
        /// onboard control sensors present value to string.
        /// </summary>
        public string PresentSensor
        {
            get => this.GetMAV_SYS_STATUS_SENSOR(this.onboard_control_sensors_present);
        }

        /// <summary>
        /// onboard control sensors enabled value to string.
        /// </summary>
        public string EnabledSensor
        {
            get => this.GetMAV_SYS_STATUS_SENSOR(this.onboard_control_sensors_enabled);
        }

        /// <summary>
        /// onboard control sensors health value to string.
        /// </summary>
        public string HealthSensor
        {
            get => this.GetMAV_SYS_STATUS_SENSOR(this.onboard_control_sensors_health);
        }
        #endregion

        #region GPS
        /// <summary>
        /// Number of satellites visibile. 255 is unknown. from GPS_RAW_INT
        /// </summary>
        public string SatellitesNum
        {
            get
            {
                if (this.satellites_visible == 255) return "Unknown";
                return $"{this.satellites_visible}";
            }
        }

        /// <summary>
        /// GPS Fix Type from GPS_RAW_INT
        /// </summary>
        public string FixType
        {
            get => ((MavEnums.GPS_FIX_TYPE)this.fix_type).ToString().Replace("GPS_FIX_TYPE_", "").Replace("_", " ");
        }

        /// <summary>
        /// ushort value to double dop
        /// </summary>
        /// <param name="dop"></param>
        /// <returns></returns>
        public double ConvertDOP(ushort dop)
        {
            if (dop == ushort.MaxValue) return -1;
            return Math.Round(dop / 100.0, 2);
        }

        /// <summary>
        /// Horizontal Dilution of position
        /// </summary>
        public double HDOP
        {
            get => this.ConvertDOP(this.eph);
        }

        /// <summary>
        /// Vertical Dilution of position
        /// </summary>
        public double VDOP
        {
            get => this.ConvertDOP(this.epv);
        }

        /// <summary>
        /// Latitude from gps
        /// </summary>
        public double Latitude
        {
            get => this.lat / 1e7;
        }

        /// <summary>
        /// Longitude from gps
        /// </summary>
        public double Longitude
        {
            get => this.lon / 1e7;
        }

        /// <summary>
        /// Altitude from gps
        /// </summary>
        public double Altitude
        {
            get => this.alt / 1000.0;
        }

        #endregion

        #region Battery
        
        public double VoltageBattery
        {
            get => this.voltage_battery / 1000.0;
        }
        
        public double CurrentBattery
        {
            get => this.current_battery / 100.0;
        }

        #endregion

        #region STATUS TEXT
        #endregion

        #region TODO : Connected
        public bool IsConnected { get; private set; } = false;

        private Thread _connectionThread;

        /// <summary>
        ///  TODO -> check.
        /// </summary>
        /// <param name="lasttime"></param>
        private void CheckHeartBeat(DateTime lasttime)
        {
            if(_connectionThread == null)
            {
                _connectionThread = new Thread(() =>
                {
                    while (true)
                    {

                    }
                });
            }

        }
        #endregion

        public VehicleParameters Parameters { get; protected set; }
    }
}
