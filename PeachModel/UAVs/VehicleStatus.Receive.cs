using PeachModel.Mavlink;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.UAVs
{
    public partial class VehicleStatus
    {
        public object Receive_Vehicledatas(Packet packet)
        {
            if (packet is null)
            {
                return null;
            }

            this.IsMavlink2 = packet.IsMavLink2;

            switch (packet.MSGID)
            {
                case 0:
                    this.CheckHeartBeat(packet.ReceiveTime);

                    this.Receive_HeartBeat(packet.Message);
                    break;
                case 1:
                    this.Receive_SYS_STATUS(packet.Message);
                    break;
                case 22:
                    this.Receive_Param_Value(packet.Message);
                    break;
                case 24:
                    this.Receive_GPS_RAW_INT(packet.Message);
                    break;
                case 30:
                    this.Receive_Altitude(packet.Message);
                    break;
                case 35:
                    this.Receive_RC_CHANNELS_RAW(packet.Message);
                    break;
                case 74:
                    this.Receive_VFR_HUD(packet.Message);
                    break;
                case 77:
                    this.Receive_COMMAND_ACK(packet.Message);
                    break;
                case 253:
                    this.Receive_STATUS_TEXT(packet.Message);
                    break;
                default:
                    break;
            }

            return true;
        }

        //0
        #region HearBeat
        public uint custom_mode { get; set; }
        public byte type { get; set; }
        public byte autopilot { get; set; }
        public byte base_mode { get; set; }  // bitmask
        public byte system_status { get; set; }
        public byte mavlink_version { get; set; }

        private void Receive_HeartBeat(Message message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            try
            {
                var heartbeat = (Message_HEARTBEAT)message;
                this.current_battery = heartbeat.custom_mode;
                this.type = heartbeat.type;
                this.autopilot = heartbeat.autopilot;
                this.base_mode = heartbeat.base_mode;
                this.system_status = heartbeat.system_status;
                this.mavlink_version = heartbeat.mavlink_version;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        // 1
        #region SYS_STATUS
        public uint onboard_control_sensors_present { get; set; }
        public uint onboard_control_sensors_enabled { get; set; }
        public uint onboard_control_sensors_health { get; set; }
        public double load { get; set; }                            // d% 
        public double voltage_battery { get; set; }                 // mV -> Voltage
        public double current_battery { get; set; }                 // %
        public ushort drop_rate_comm { get; set; }
        public ushort errors_comm { get; set; }
        public ushort errors_count1 { get; set; }
        public ushort errors_count2 { get; set; }
        public ushort errors_count3 { get; set; }
        public ushort errors_count4 { get; set; }
        public sbyte battery_remaining { get; set; }

        private void Receive_SYS_STATUS(Message message)
        {
            try
            {
                var sys_status = (Message_SYS_STATUS)message;

                this.onboard_control_sensors_present = sys_status.onboard_control_sensors_present;
                this.onboard_control_sensors_enabled = sys_status.onboard_control_sensors_enabled;
                this.onboard_control_sensors_health = sys_status.onboard_control_sensors_health;
                this.load = sys_status.load / 10.0;
                this.voltage_battery = sys_status.voltage_battery;
                this.current_battery = sys_status.current_battery;
                this.drop_rate_comm = sys_status.drop_rate_comm;
                this.errors_comm = sys_status.errors_comm;
                this.errors_count1 = sys_status.errors_count1;
                this.errors_count2 = sys_status.errors_count2;
                this.errors_count3 = sys_status.errors_count3;
                this.errors_count4 = sys_status.errors_count4;
                this.battery_remaining = sys_status.battery_remaining;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        // 22
        #region PARAM_VALUE
        public int ParameterCount { get; private set; } = -1;

        // TODO 
        public Dictionary<string, VehicleParameter> unknown = new Dictionary<string, VehicleParameter>();
        
        private void Receive_Param_Value(Message message)
        {
            try
            {
                var param_value = (Message_PARAM_VALUE)message;
                this.ParameterCount = param_value.param_count;

                VehicleParameter parameter = VehicleParameter.ConvertToParameter(param_value);

                if(parameter.Index >= this.ParameterCount)
                {
                    /// for when known parameter has index over total parameter count.
                    if (this.Parameters.ContainsKey(parameter.StringId))
                    {
                        this.Parameters[parameter.StringId].Value = parameter.Value;
                        return;
                    }

                    if (this.unknown.ContainsKey(parameter.StringId))
                    {
                        this.unknown[parameter.StringId].Value = parameter.Value;
                        return;
                    }
                    this.unknown[parameter.StringId] = parameter;
                    return;
                }

                if (this.Parameters.ContainsKey(parameter.StringId))
                {
                    this.Parameters[parameter.StringId].Value = parameter.Value;
                    return;
                }

                this.Parameters.Add(parameter.StringId, parameter);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion

        // 24
        #region GPS_RAW_INT
        public double lat { get; set; }
        public double lon { get; set; }
        public int alt { get; set; }
        public ushort eph { get; set; }
        public ushort epv { get; set; }
        public ushort vel { get; set; }
        public ushort cog { get; set; }
        public byte fix_type { get; set; }
        public byte satellites_visible { get; set; }

        private void Receive_GPS_RAW_INT(Message message)
        {
            try
            {
                var gps_raw_int = (Message_GPS_RAW_INT)message;

                this.fix_type = gps_raw_int.fix_type;
                this.lat = gps_raw_int.lat;
                this.lon = gps_raw_int.lon;
                this.alt = gps_raw_int.alt;
                this.eph = gps_raw_int.eph;
                this.epv = gps_raw_int.epv;
                this.vel = gps_raw_int.vel;
                this.cog = gps_raw_int.cog;
                this.satellites_visible = gps_raw_int.satellites_visible;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion

        // 30
        #region Altitude
        public double roll { get; set; }        // deg
        public double pitch { get; set; }       // deg
        public double yaw { get; set; }         // deg
        public double rollspeed { get; set; }
        public double pitchspeed { get; set; }
        public double yawspeed { get; set; }

        private void Receive_Altitude(Message message)
        {
            try
            {
                var altitude = (Message_ATTITUDE)message;

                this.roll = altitude.roll * 180.0 / Math.PI;
                this.pitch = altitude.pitch * 180.0 / Math.PI;
                this.yaw = altitude.yaw * 180.0 / Math.PI;
                this.rollspeed = altitude.rollspeed * 180.0 / Math.PI;
                this.pitchspeed = altitude.pitchspeed * 180.0 / Math.PI;
                this.yawspeed = altitude.yawspeed * 180.0 / Math.PI;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        // 35
        #region RC_CHANNELS_RAW
        public ushort Chan1_raw { get; set; }
        public ushort Chan2_raw { get; set; }
        public ushort Chan3_raw { get; set; }
        public ushort Chan4_raw { get; set; }
        public ushort Chan5_raw { get; set; }
        public ushort Chan6_raw { get; set; }
        public ushort Chan7_raw { get; set; }
        public ushort Chan8_raw { get; set; }
        public byte Port { get; set; }
        public byte Rssi { get; set; }

        private void Receive_RC_CHANNELS_RAW(Message message)
        {
            try
            {
                var rc_channels_raw = (Message_RC_CHANNELS_RAW)message;

                this.Chan1_raw = rc_channels_raw.chan1_raw;
                this.Chan2_raw = rc_channels_raw.chan2_raw;
                this.Chan3_raw = rc_channels_raw.chan3_raw;
                this.Chan4_raw = rc_channels_raw.chan4_raw;
                this.Chan5_raw = rc_channels_raw.chan5_raw;
                this.Chan6_raw = rc_channels_raw.chan6_raw;
                this.Chan7_raw = rc_channels_raw.chan7_raw;
                this.Chan8_raw = rc_channels_raw.chan8_raw;
                this.Port = rc_channels_raw.port;
                this.Rssi = rc_channels_raw.rssi;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion

        // 74
        #region VFR_HUD
        public double VFR_HUD_Airspeed { get; set; }
        public double VFR_HUD_Groundspeed { get; set; }
        public double VFR_HUD_Alt { get; set; }
        public double VFR_HUD_Climb { get; set; }
        public short VFR_HUD_Heading { get; set; }
        public ushort VFR_HUD_Throttle { get; set; }

        private void Receive_VFR_HUD(Message message)
        {
            try
            {
                var vfr_hud = (Message_VFR_HUD)message;

                this.VFR_HUD_Airspeed = vfr_hud.airspeed;
                this.VFR_HUD_Groundspeed = vfr_hud.groundspeed;
                this.VFR_HUD_Alt = vfr_hud.alt;
                this.VFR_HUD_Climb = vfr_hud.climb;
                this.VFR_HUD_Heading = vfr_hud.heading;
                this.VFR_HUD_Throttle = vfr_hud.throttle;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        // 77
        #region COMMAND_ACK
        public ushort command { get; set; }
        public byte result { get; set; }

        private void Receive_COMMAND_ACK(Message m)
        {
            try
            {
                var ack = (Message_COMMAND_ACK)m;
                this.command = ack.command;
                this.result = ack.result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        // 253
        #region STATUS_TEXT
        
        public byte severity { get; set; }
        public string Text { get; set; }
        public ushort id { get; set; }
        public byte chunk_seq { get; set; }

        private void Receive_STATUS_TEXT(Message m)
        {
            try
            {
                var status_text = (Message_STATUSTEXT)m;

                this.severity = status_text.severity;
                this.Text = status_text.Text;
                this.id = status_text.id;
                this.chunk_seq = status_text.chunk_seq;

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
