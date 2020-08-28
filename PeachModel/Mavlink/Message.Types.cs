using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Mavlink
{

    /// <summary>
    /// No Message.
    /// </summary>
    [MessageInfo(0, 0, 0,
        "No Message.")]
    public class Message_No_Message : Message
    {
        public Message_No_Message()
        {
            this.IsValid = false;
            this.Buffer = null;
        }
    }

    /// <summary>
    /// HeartBeat #0
    /// </summary>
    [MessageInfo(0, 9, 50,
        "The heartbeat message shows that a system or component is present and responding. " +
        "The type and autopilot fields (along with the message component id), allow the receiving system to treat further messages from this system appropriately " +
        "(e.g. by laying out the user interface based on the autopilot). " +
        "This microservice is documented at https://mavlink.io/en/services/heartbeat.html")]
    public class Message_HEARTBEAT : Message
    {
        /// <summary>A bitfield for use for autopilot-specific flags   </summary>
        public uint custom_mode;
        /// <summary>Vehicle or component type. For a flight controller component the vehicle type (quadrotor, helicopter, etc.). For other components the component type (e.g. camera, gimbal, etc.). This should be used in preference to component id for identifying the component type. MAV_TYPE  </summary>
        public  /*MAV_TYPE*/byte type;
        /// <summary>Autopilot type / class. Use MAV_AUTOPILOT_INVALID for components that are not flight controllers. MAV_AUTOPILOT  </summary>
        public  /*MAV_AUTOPILOT*/byte autopilot;
        /// <summary>System mode bitmap. MAV_MODE_FLAG  bitmask</summary>
        public  /*MAV_MODE_FLAG*/byte base_mode;
        /// <summary>System status flag. MAV_STATE  </summary>
        public  /*MAV_STATE*/byte system_status;
        /// <summary>MAVLink version, not writable by user, gets added by protocol because of magic data type: uint8_t_mavlink_version   </summary>
        public byte mavlink_version;

        public Message_HEARTBEAT(uint custom_mode, byte type, byte autopilot, byte base_mode, byte system_status, byte mavlink_version) :
            base(custom_mode, type, autopilot, base_mode, system_status, mavlink_version)
        {
            this.custom_mode = custom_mode;
            this.type = type;
            this.autopilot = autopilot;
            this.base_mode = base_mode;
            this.system_status = system_status;
            this.mavlink_version = mavlink_version;
        }

        public Message_HEARTBEAT()
        {

        }
    }

    [MessageInfo(1, 31, 124,
        "The general system state." +
        "If the system is following the MAVLink standard, the system state is mainly defined by three orthogonal states/modes: The system mode, which is either LOCKED (motors shut down and locked), MANUAL (system under RC control), GUIDED (system with autonomous position control, position setpoint controlled manually) or AUTO (system guided by path/waypoint planner)." +
        "The NAV_MODE defined the current flight state: LIFTOFF (often an open-loop maneuver), LANDING, WAYPOINTS or VECTOR." +
        "This represents the internal navigation state machine." +
        "The system status shows whether the system is currently active or not and if an emergency occurred." +
        "During the CRITICAL and EMERGENCY states the MAV is still considered to be active, but should start emergency procedures autonomously." +
        "After a failure occurred it should first move from active to critical to allow manual intervention and then move to emergency after a certain timeout.")]
    public class Message_SYS_STATUS : Message
    {
        /// <summary>Bitmap showing which onboard controllers and sensors are present. Value of 0: not present. Value of 1: present. MAV_SYS_STATUS_SENSOR  bitmask</summary>
        public  /*MAV_SYS_STATUS_SENSOR*/uint onboard_control_sensors_present;
        /// <summary>Bitmap showing which onboard controllers and sensors are enabled:  Value of 0: not enabled. Value of 1: enabled. MAV_SYS_STATUS_SENSOR  bitmask</summary>
        public  /*MAV_SYS_STATUS_SENSOR*/uint onboard_control_sensors_enabled;
        /// <summary>Bitmap showing which onboard controllers and sensors have an error (or are operational). Value of 0: error. Value of 1: healthy. MAV_SYS_STATUS_SENSOR  bitmask</summary>
        public  /*MAV_SYS_STATUS_SENSOR*/uint onboard_control_sensors_health;
        /// <summary>Maximum usage in percent of the mainloop time. Values: [0-1000] - should always be below 1000  [d%] </summary>
        public ushort load;
        /// <summary>Battery voltage, UINT16_MAX: Voltage not sent by autopilot  [mV] </summary>
        public ushort voltage_battery;
        /// <summary>Battery current, -1: Current not sent by autopilot  [cA] </summary>
        public short current_battery;
        /// <summary>Communication drop rate, (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)  [c%] </summary>
        public ushort drop_rate_comm;
        /// <summary>Communication errors (UART, I2C, SPI, CAN), dropped packets on all links (packets that were corrupted on reception on the MAV)   </summary>
        public ushort errors_comm;
        /// <summary>Autopilot-specific errors   </summary>
        public ushort errors_count1;
        /// <summary>Autopilot-specific errors   </summary>
        public ushort errors_count2;
        /// <summary>Autopilot-specific errors   </summary>
        public ushort errors_count3;
        /// <summary>Autopilot-specific errors   </summary>
        public ushort errors_count4;
        /// <summary>Battery energy remaining, -1: Battery remaining energy not sent by autopilot  [%] </summary>
        public sbyte battery_remaining;

        public Message_SYS_STATUS(uint onboard_control_sensors_present, uint onboard_control_sensors_enabled, uint onboard_control_sensors_health,
            ushort load, ushort voltage_battery, short current_battery, ushort drop_rate_comm, ushort errors_comm, ushort errors_count1,
            ushort errors_count2, ushort errors_count3, ushort errors_count4, sbyte battery_remaining) :
            base(onboard_control_sensors_present, onboard_control_sensors_enabled, onboard_control_sensors_health,
                load, voltage_battery, current_battery, drop_rate_comm, errors_comm, errors_count1,
                errors_count2, errors_count3, errors_count4, battery_remaining)
        {
            this.onboard_control_sensors_present = onboard_control_sensors_present;
            this.onboard_control_sensors_enabled = onboard_control_sensors_enabled;
            this.onboard_control_sensors_health = onboard_control_sensors_health;
            this.load = load;
            this.voltage_battery = voltage_battery;
            this.current_battery = current_battery;
            this.drop_rate_comm = drop_rate_comm;
            this.errors_comm = errors_comm;
            this.errors_count1 = errors_count1;
            this.errors_count2 = errors_count2;
            this.errors_count3 = errors_count3;
            this.errors_count4 = errors_count4;
            this.battery_remaining = battery_remaining;
        }

        public Message_SYS_STATUS()
        {

        }
    }

    [MessageInfo(2, 12, 137,
        "The system time is the time of the master clock, typically the computer clock of the main onboard computer.")]
    public class Message_SYSTEM_TIME : Message
    {
        /// <summary>Timestamp (UNIX epoch time).  [us] </summary>
        public ulong time_unix_usec;
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;

        public Message_SYSTEM_TIME(ulong time_unix_usec, uint time_boot_ms) : base(time_unix_usec, time_boot_ms)
        {
            this.time_unix_usec = time_unix_usec;
            this.time_boot_ms = time_boot_ms;
        }

        public Message_SYSTEM_TIME() { }
    }

    #region TODO : #3 ~ #19
    #endregion

    [MessageInfo(20, 20, 214,
        "Request to read the onboard parameter with the param_id string id." +
        "Onboard parameters are stored as key[const char*] -> value[float]." +
        "This allows to send a parameter to any other component (such as the GCS) without the need of previous knowledge of possible parameter names." +
        "Thus the same GCS can store different parameters for different autopilots." +
        "See also https://mavlink.io/en/services/parameter.html for a full documentation of QGroundControl and IMU code.")]
    public class Message_PARAM_REQUEST_READ : Message
    {
        /// <summary>Parameter index. Send -1 to use the param ID field as identifier (else the param id will be ignored)   </summary>
        public short param_index;
        /// <summary>System ID   </summary>
        public byte target_system;
        /// <summary>Component ID   </summary>
        public byte target_component;
        /// <summary>Onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string   </summary>
        public byte[] param_id;

        public Message_PARAM_REQUEST_READ(short param_index, byte target_system, byte target_component, byte[] param_id)
        : base(param_index, target_system, target_component, param_id)
        {
            this.param_index = param_index;
            this.target_system = target_system;
            this.target_component = target_component;
            this.param_id = param_id;
        }

        public Message_PARAM_REQUEST_READ()
        {

        }

    }

    /// <summary>
    /// PARAM_REQUEST_LIST #21
    /// </summary>
    [MessageInfo(21, 2, 159,
        "Request all parameters of this component. After this request, all parameters are emitted." +
        "The parameter microservice is documented at https://mavlink.io/en/services/parameter.html")]
    public class Message_PARAM_REQUEST_LIST : Message
    {
        /// <summary>System ID   </summary>
        public byte target_system;
        /// <summary>Component ID   </summary>
        public byte target_component;

        public Message_PARAM_REQUEST_LIST(byte target_system, byte target_component) :
            base(target_system, target_component)
        {
            this.target_system = target_system;
            this.target_component = target_component;
        }

        public Message_PARAM_REQUEST_LIST()
        {

        }
    }

    /// <summary>
    /// PARAM_VALUE #22
    /// </summary>
    [MessageInfo(22, 25, 220,
        "Emit the value of a onboard parameter. " +
        "The inclusion of param_count and param_index in the message allows the recipient to keep track of received parameters and allows him to re-request missing parameters after a loss or timeout. " +
        "The parameter microservice is documented at https://mavlink.io/en/services/parameter.html")]
    public class Message_PARAM_VALUE : Message
    {
        /// <summary>Onboard parameter value   </summary>
        public float param_value;
        /// <summary>Total number of onboard parameters   </summary>
        public ushort param_count;
        /// <summary>Index of this onboard parameter   </summary>
        public ushort param_index;
        /// <summary>Onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string   </summary>
        public byte[] param_id = new byte[16];
        /// <summary>Onboard parameter type. MAV_PARAM_TYPE  </summary>
        public  /*MAV_PARAM_TYPE*/byte param_type;

        public Message_PARAM_VALUE(float param_value, ushort param_count, ushort param_index, byte[] param_id, byte param_type) :
            base(param_value, param_count, param_index, param_id, param_type)
        {
            this.param_value = param_value;
            this.param_count = param_count;
            this.param_index = param_index;
            this.param_id = param_id;
            this.param_type = param_type;
        }

        public Message_PARAM_VALUE()
        {
        }
    }

    /// <summary>
    /// PARAM_SET #23
    /// </summary>
    [MessageInfo(23, 23, 168,
        "Set a parameter value (write new value to permanent storage). " +
        "IMPORTANT: The receiving component should acknowledge the new parameter value by sending a PARAM_VALUE message to all communication partners. " +
        "This will also ensure that multiple GCS all have an up-to-date list of all parameters. " +
        "If the sending GCS did not receive a PARAM_VALUE message within its timeout time, it should re-send the PARAM_SET message. " +
        "The parameter microservice is documented at https://mavlink.io/en/services/parameter.html")]
    public class Message_PARAM_SET : Message
    {
        /// <summary>Onboard parameter value   </summary>
        public float param_value;
        /// <summary>System ID   </summary>
        public byte target_system;
        /// <summary>Component ID   </summary>
        public byte target_component;
        /// <summary>Onboard parameter id, terminated by NULL if the length is less than 16 human-readable chars and WITHOUT null termination (NULL) byte if the length is exactly 16 chars - applications have to provide 16+1 bytes storage if the ID is stored as string   </summary>
        public byte[] param_id = new byte[16];
        /// <summary>Onboard parameter type. MAV_PARAM_TYPE  </summary>
        public  /*MAV_PARAM_TYPE*/byte param_type;

        public Message_PARAM_SET(float param_value, byte target_system, byte target_component, byte[] param_id, byte param_type) :
            base(param_value, target_system, target_component, param_id, param_type)
        {
            this.param_value = param_value;
            this.target_system = target_system;
            this.target_component = target_component;
            this.param_id = param_id;
            this.param_type = param_type;
        }

        public Message_PARAM_SET()
        {

        }
    }

    /// <summary>
    /// GPS_RAW_INT #24
    /// </summary>
    [MessageInfo(24, 52, 24,
        "The global position, as returned by the Global Positioning System (GPS). " +
        "This is NOT the global position estimate of the system, but rather a RAW sensor value. " +
        "See message GLOBAL_POSITION for the global position estimate.")]
    public class Message_GPS_RAW_INT : Message
    {

        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>Latitude (WGS84, EGM96 ellipsoid)  [degE7] </summary>
        public int lat;
        /// <summary>Longitude (WGS84, EGM96 ellipsoid)  [degE7] </summary>
        public int lon;
        /// <summary>Altitude (MSL). Positive for up. Note that virtually all GPS modules provide the MSL altitude in addition to the WGS84 altitude.  [mm] </summary>
        public int alt;
        /// <summary>GPS HDOP horizontal dilution of position (unitless). If unknown, set to: UINT16_MAX   </summary>
        public ushort eph;
        /// <summary>GPS VDOP vertical dilution of position (unitless). If unknown, set to: UINT16_MAX   </summary>
        public ushort epv;
        /// <summary>GPS ground speed. If unknown, set to: UINT16_MAX  [cm/s] </summary>
        public ushort vel;
        /// <summary>Course over ground (NOT heading, but direction of movement) in degrees * 100, 0.0..359.99 degrees. If unknown, set to: UINT16_MAX  [cdeg] </summary>
        public ushort cog;
        /// <summary>GPS fix type. GPS_FIX_TYPE  </summary>
        public  /*GPS_FIX_TYPE*/byte fix_type;
        /// <summary>Number of satellites visible. If unknown, set to 255   </summary>
        public byte satellites_visible;
        /// <summary>Altitude (above WGS84, EGM96 ellipsoid). Positive for up.  [mm] </summary>
        public int alt_ellipsoid;
        /// <summary>Position uncertainty. Positive for up.  [mm] </summary>
        public uint h_acc;
        /// <summary>Altitude uncertainty. Positive for up.  [mm] </summary>
        public uint v_acc;
        /// <summary>Speed uncertainty. Positive for up.  [mm] </summary>
        public uint vel_acc;
        /// <summary>Heading / track uncertainty  [degE5] </summary>
        public uint hdg_acc;
        /// <summary>Yaw in earth frame from north. Use 0 if this GPS does not provide yaw. Use 65535 if this GPS is configured to provide yaw and is currently unable to provide it. Use 36000 for north.  [cdeg] </summary>
        public ushort yaw;

        public Message_GPS_RAW_INT(ulong time_usec, int lat, int lon, int alt,
                                    ushort eph, ushort epv, ushort vel, ushort cog,
                                    byte fix_type, byte satellites_visible, int alt_ellipsoid,
                                    uint h_acc, uint v_acc, uint vel_acc, uint hdg_acc, ushort yaw) :
                                    base(time_usec, lat, lon, alt,
                                    eph, epv, vel, cog,
                                    fix_type, satellites_visible, alt_ellipsoid,
                                    h_acc, v_acc, vel_acc, hdg_acc, yaw)
        {
            this.time_usec = time_usec;
            this.lat = lat;
            this.lon = lon;
            this.alt = alt;
            this.eph = eph;
            this.epv = epv;
            this.vel = vel;
            this.cog = cog;
            this.fix_type = fix_type;
            this.satellites_visible = satellites_visible;
            this.alt_ellipsoid = alt_ellipsoid;
            this.h_acc = h_acc;
            this.v_acc = v_acc;
            this.vel_acc = vel_acc;
            this.hdg_acc = hdg_acc;
            this.yaw = yaw;
        }

        public Message_GPS_RAW_INT()
        {

        }

    }

    /// <summary>
    /// GPS_STATUS #25
    /// </summary>
    [MessageInfo(25, 101, 23,
        "The positioning status, as reported by GPS. " +
        "This message is intended to display status information about each satellite visible to the receiver. " +
        "See message GLOBAL_POSITION for the global position estimate. " +
        "This message can contain information for up to 20 satellites.")]
    public class Message_GPS_STATUS : Message
    {
        /// <summary>Number of satellites visible   </summary>
        public byte satellites_visible;
        /// <summary>Global satellite ID   </summary>
        public byte[] satellite_prn = new byte[20];
        /// <summary>0: Satellite not used, 1: used for localization   </summary>
        public byte[] satellite_used = new byte[20];
        /// <summary>Elevation (0: right on top of receiver, 90: on the horizon) of satellite  [deg] </summary>
        public byte[] satellite_elevation = new byte[20];
        /// <summary>Direction of satellite, 0: 0 deg, 255: 360 deg.  [deg] </summary>
        public byte[] satellite_azimuth = new byte[20];
        /// <summary>Signal to noise ratio of satellite  [dB] </summary>
        public byte[] satellite_snr = new byte[20];

        public Message_GPS_STATUS()
        {

        }

        public Message_GPS_STATUS(byte satellites_visible, byte[] satellite_prn, byte[] satellite_used,
            byte[] satellite_elevation, byte[] satellite_azimuth, byte[] satellite_snr) :
            base(satellites_visible, satellite_prn, satellite_used, satellite_elevation, satellite_azimuth, satellite_snr)
        {
            this.satellites_visible = satellites_visible;
            this.satellite_prn = satellite_prn;
            this.satellite_used = satellite_used;
            this.satellite_elevation = satellite_elevation;
            this.satellite_azimuth = satellite_azimuth;
            this.satellite_snr = satellite_snr;
        }
    }

    /// <summary>
    /// SCALED_IMU #26
    /// </summary>
    [MessageInfo(26, 24, 170,
       "The RAW IMU readings for the usual 9DOF sensor setup. " +
       "This message should contain the scaled values to the described units")]
    public class Message_SCALED_IMU : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>X acceleration  [mG] </summary>
        public short xacc;
        /// <summary>Y acceleration  [mG] </summary>
        public short yacc;
        /// <summary>Z acceleration  [mG] </summary>
        public short zacc;
        /// <summary>Angular speed around X axis  [mrad/s] </summary>
        public short xgyro;
        /// <summary>Angular speed around Y axis  [mrad/s] </summary>
        public short ygyro;
        /// <summary>Angular speed around Z axis  [mrad/s] </summary>
        public short zgyro;
        /// <summary>X Magnetic field  [mgauss] </summary>
        public short xmag;
        /// <summary>Y Magnetic field  [mgauss] </summary>
        public short ymag;
        /// <summary>Z Magnetic field  [mgauss] </summary>
        public short zmag;
        /// <summary>Temperature, 0: IMU does not provide temperature values. If the IMU is at 0C it must send 1 (0.01C).  [cdegC] </summary>
        public short temperature;

        public Message_SCALED_IMU(uint time_boot_ms,
            short xacc, short yacc, short zacc,
            short xgyro, short ygyro, short zgyro,
            short xmag, short ymag, short zmag,
            short temperature) :
            base(time_boot_ms, xacc, yacc, zacc, xgyro, ygyro, zgyro, xmag, ymag, zmag, temperature)
        {
            this.time_boot_ms = time_boot_ms;
            this.xacc = xacc;
            this.yacc = yacc;
            this.zacc = zacc;
            this.xgyro = xgyro;
            this.ygyro = ygyro;
            this.zgyro = zgyro;
            this.xmag = xmag;
            this.ymag = ymag;
            this.zmag = zmag;
            this.temperature = temperature;
        }

        public Message_SCALED_IMU()
        {

        }

    }

    /// <summary>
    /// RAW_IMU #27
    /// </summary>
    [MessageInfo(27, 29, 144,
        "The RAW IMU readings for a 9DOF sensor, which is identified by the id (default IMU1). " +
        "This message should always contain the true raw values without any scaling to allow data capture and system debugging.")]
    public class Message_RAW_IMU : Message
    {
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>X acceleration (raw)   </summary>
        public short xacc;
        /// <summary>Y acceleration (raw)   </summary>
        public short yacc;
        /// <summary>Z acceleration (raw)   </summary>
        public short zacc;
        /// <summary>Angular speed around X axis (raw)   </summary>
        public short xgyro;
        /// <summary>Angular speed around Y axis (raw)   </summary>
        public short ygyro;
        /// <summary>Angular speed around Z axis (raw)   </summary>
        public short zgyro;
        /// <summary>X Magnetic field (raw)   </summary>
        public short xmag;
        /// <summary>Y Magnetic field (raw)   </summary>
        public short ymag;
        /// <summary>Z Magnetic field (raw)   </summary>
        public short zmag;
        /// <summary>Id. Ids are numbered from 0 and map to IMUs numbered from 1 (e.g. IMU1 will have a message with id=0)   </summary>
        public byte id;
        /// <summary>Temperature, 0: IMU does not provide temperature values. If the IMU is at 0C it must send 1 (0.01C).  [cdegC] </summary>
        public short temperature;

        public Message_RAW_IMU(ulong time_usec,
            short xacc, short yacc, short zacc,
            short xgyro, short ygyro, short zgyro,
            short xmag, short ymag, short zmag,
            byte id, short temperature) :
            base(time_usec, xacc, yacc, zacc, xgyro, ygyro, zgyro, xmag, ymag, zmag, id, temperature)
        {
            this.time_usec = time_usec;
            this.xacc = xacc;
            this.yacc = yacc;
            this.zacc = zacc;
            this.xgyro = xgyro;
            this.ygyro = ygyro;
            this.zgyro = zgyro;
            this.xmag = xmag;
            this.ymag = ymag;
            this.zmag = zmag;
            this.id = id;
            this.temperature = temperature;
        }

        public Message_RAW_IMU()
        {

        }

    }

    /// <summary>
    /// RAW_PRESSURE #28
    /// </summary>
    [MessageInfo(28, 16, 67,
        "The RAW pressure readings for the typical setup of one absolute pressure and one differential pressure sensor. " +
        "The sensor values should be the raw, UNSCALED ADC values.")]
    public class Message_RAW_PRESSURE : Message
    {
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>Absolute pressure (raw)   </summary>
        public short press_abs;
        /// <summary>Differential pressure 1 (raw, 0 if nonexistent)   </summary>
        public short press_diff1;
        /// <summary>Differential pressure 2 (raw, 0 if nonexistent)   </summary>
        public short press_diff2;
        /// <summary>Raw Temperature measurement (raw)   </summary>
        public short temperature;

        public Message_RAW_PRESSURE(ulong time_usec, short press_abs, short press_diff1, short press_diff2, short temperature) :
            base(time_usec, press_abs, press_diff1, press_diff2, temperature)
        {
            this.time_usec = time_usec;
            this.press_abs = press_abs;
            this.press_diff1 = press_diff1;
            this.press_diff2 = press_diff2;
            this.temperature = temperature;
        }

        public Message_RAW_PRESSURE()
        {

        }
    }

    /// <summary>
    /// SCALED_PRESSURE #29
    /// </summary>
    [MessageInfo(29, 14, 115,
        "The pressure readings for the typical setup of one absolute and differential pressure sensor. " +
        "The units are as specified in each field.")]
    public class Message_SCALED_PRESSURE : Message
    {
        public uint time_boot_ms;
        /// <summary>Absolute pressure  [hPa] </summary>
        public float press_abs;
        /// <summary>Differential pressure 1  [hPa] </summary>
        public float press_diff;
        /// <summary>Temperature  [cdegC] </summary>
        public short temperature;

        public Message_SCALED_PRESSURE(uint time_boot_ms, float press_abs, float press_diff, short temperature) :
            base(time_boot_ms, press_abs, press_diff, temperature)
        {
            this.time_boot_ms = time_boot_ms;
            this.press_abs = press_abs;
            this.press_diff = press_diff;
            this.temperature = temperature;
        }

        public Message_SCALED_PRESSURE()
        {

        }
    }

    /// <summary>
    /// ATTITUDE #30
    /// </summary>
    [MessageInfo(30, 28, 39,
        "The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right).")]
    public class Message_ATTITUDE : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>Roll angle (-pi..+pi)  [rad] </summary>
        public float roll;
        /// <summary>Pitch angle (-pi..+pi)  [rad] </summary>
        public float pitch;
        /// <summary>Yaw angle (-pi..+pi)  [rad] </summary>
        public float yaw;
        /// <summary>Roll angular speed  [rad/s] </summary>
        public float rollspeed;
        /// <summary>Pitch angular speed  [rad/s] </summary>
        public float pitchspeed;
        /// <summary>Yaw angular speed  [rad/s] </summary>
        public float yawspeed;

        public Message_ATTITUDE(uint time_boot_ms,
            float roll, float pitch, float yaw,
            float rollspeed, float pitchspeed, float yawspeed) :
            base(time_boot_ms,
                 roll, pitch, yaw,
                 rollspeed, pitchspeed, yawspeed)
        {
            this.time_boot_ms = time_boot_ms;
            this.roll = roll;
            this.pitch = pitch;
            this.yaw = yaw;
            this.rollspeed = rollspeed;
            this.pitchspeed = pitchspeed;
            this.yawspeed = yawspeed;
        }

        public Message_ATTITUDE()
        {

        }
    }

    /// <summary>
    /// ATTITUDE_QUATERNION #31
    /// </summary>
    [MessageInfo(31, 48, 246,
        "The attitude in the aeronautical frame (right-handed, Z-down, X-front, Y-right), expressed as quaternion." +
        "Quaternion order is w, x, y, z and a zero rotation would be expressed as (1 0 0 0).")]
    public class Message_ATTITUDE_QUATERNION : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>Quaternion component 1, w (1 in null-rotation)   </summary>
        public float q1;
        /// <summary>Quaternion component 2, x (0 in null-rotation)   </summary>
        public float q2;
        /// <summary>Quaternion component 3, y (0 in null-rotation)   </summary>
        public float q3;
        /// <summary>Quaternion component 4, z (0 in null-rotation)   </summary>
        public float q4;
        /// <summary>Roll angular speed  [rad/s] </summary>
        public float rollspeed;
        /// <summary>Pitch angular speed  [rad/s] </summary>
        public float pitchspeed;
        /// <summary>Yaw angular speed  [rad/s] </summary>
        public float yawspeed;
        /// <summary>Rotation offset by which the attitude quaternion and angular speed vector should be rotated for user display (quaternion with [w, x, y, z] order, zero-rotation is [1, 0, 0, 0], send [0, 0, 0, 0] if field not supported). This field is intended for systems in which the reference attitude may change during flight. For example, tailsitters VTOLs rotate their reference attitude by 90 degrees between hover mode and fixed wing mode, thus repr_offset_q is equal to [1, 0, 0, 0] in hover mode and equal to [0.7071, 0, 0.7071, 0] in fixed wing mode.   </summary>
        public float[] repr_offset_q = new float[4];

        public Message_ATTITUDE_QUATERNION(uint time_boot_ms,
            float q1, float q2, float q3, float q4,
            float rollspeed, float pitchspeed, float yawspeed,
            float[] repr_offset_q)
            : base(time_boot_ms,
            q1, q2, q3, q4,
            rollspeed, pitchspeed, yawspeed,
            repr_offset_q)
        {
            this.time_boot_ms = time_boot_ms;
            this.q1 = q1;
            this.q2 = q2;
            this.q3 = q3;
            this.q4 = q4;
            this.rollspeed = rollspeed;
            this.pitchspeed = pitchspeed;
            this.yawspeed = yawspeed;
            this.repr_offset_q = repr_offset_q;
        }

        public Message_ATTITUDE_QUATERNION()
        {

        }
    }

    [MessageInfo(32, 38, 185,
        "The filtered local position (e.g. fused computer vision and accelerometers)." +
        "Coordinate frame is right-handed, Z-axis down (aeronautical frame, NED / north-east-down convention)")]
    public class Message_LOCAL_POSITION_NED : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>X Position  [m] </summary>
        public float x;
        /// <summary>Y Position  [m] </summary>
        public float y;
        /// <summary>Z Position  [m] </summary>
        public float z;
        /// <summary>X Speed  [m/s] </summary>
        public float vx;
        /// <summary>Y Speed  [m/s] </summary>
        public float vy;
        /// <summary>Z Speed  [m/s] </summary>
        public float vz;

        public Message_LOCAL_POSITION_NED(uint time_boot_ms, float x, float y, float z, float vx, float vy, float vz)
        : base(time_boot_ms, x, y, z, vx, vy, vz)
        {
            this.time_boot_ms = time_boot_ms;
            this.x = x;
            this.y = y;
            this.z = z;
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;

        }

        public Message_LOCAL_POSITION_NED()
        {

        }
    }

    [MessageInfo(33, 28, 104,
        "The filtered global position (e.g. fused GPS and accelerometers)." +
        "The position is in GPS-frame (right-handed, Z-up)." +
        "It is designed as scaled integer message since the resolution of float is not sufficient.")]
    public class Message_GLOBAL_POSITION_INT : Message
    {
        public Message_GLOBAL_POSITION_INT()
        {

        }

        public Message_GLOBAL_POSITION_INT(uint time_boot_ms, int lat, int lon, int alt, int relative_alt, short vx, short vy, short vz, ushort hdg)
        : base(time_boot_ms, lat, lon, alt, relative_alt, vx, vy, vz, hdg)
        {
            this.time_boot_ms = time_boot_ms;
            this.lat = lat;
            this.lon = lon;
            this.alt = alt;
            this.relative_alt = relative_alt;
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;
            this.hdg = hdg;

        }
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>Latitude, expressed  [degE7] </summary>
        public int lat;
        /// <summary>Longitude, expressed  [degE7] </summary>
        public int lon;
        /// <summary>Altitude (MSL). Note that virtually all GPS modules provide both WGS84 and MSL.  [mm] </summary>
        public int alt;
        /// <summary>Altitude above ground  [mm] </summary>
        public int relative_alt;
        /// <summary>Ground X Speed (Latitude, positive north)  [cm/s] </summary>
        public short vx;
        /// <summary>Ground Y Speed (Longitude, positive east)  [cm/s] </summary>
        public short vy;
        /// <summary>Ground Z Speed (Altitude, positive down)  [cm/s] </summary>
        public short vz;
        /// <summary>Vehicle heading (yaw angle), 0.0..359.99 degrees. If unknown, set to: UINT16_MAX  [cdeg] </summary>
        public ushort hdg;
    }

    [MessageInfo(34, 22, 237,
        "The scaled values of the RC channels received: (-100%) -10000, (0%) 0, (100%) 10000." +
        "Channels that are inactive should be set to UINT16_MAX.")]
    public class Message_RC_CHANNELS_SCALED : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>RC channel 1 value scaled.   </summary>
        public short chan1_scaled;
        /// <summary>RC channel 2 value scaled.   </summary>
        public short chan2_scaled;
        /// <summary>RC channel 3 value scaled.   </summary>
        public short chan3_scaled;
        /// <summary>RC channel 4 value scaled.   </summary>
        public short chan4_scaled;
        /// <summary>RC channel 5 value scaled.   </summary>
        public short chan5_scaled;
        /// <summary>RC channel 6 value scaled.   </summary>
        public short chan6_scaled;
        /// <summary>RC channel 7 value scaled.   </summary>
        public short chan7_scaled;
        /// <summary>RC channel 8 value scaled.   </summary>
        public short chan8_scaled;
        /// <summary>Servo output port (set of 8 outputs = 1 port). Flight stacks running on Pixhawk should use: 0 = MAIN, 1 = AUX.   </summary>
        public byte port;
        /// <summary>Receive signal strength indicator in device-dependent units/scale. Values: [0-254], 255: invalid/unknown.   </summary>
        public byte rssi;

        public Message_RC_CHANNELS_SCALED(uint time_boot_ms,
            short chan1_scaled, short chan2_scaled, short chan3_scaled, short chan4_scaled,
            short chan5_scaled, short chan6_scaled, short chan7_scaled, short chan8_scaled,
            byte port, byte rssi) :
            base(time_boot_ms, chan1_scaled, chan2_scaled, chan3_scaled, chan4_scaled,
                chan5_scaled, chan6_scaled, chan7_scaled, chan8_scaled,
                port, rssi)
        {
            this.time_boot_ms = time_boot_ms;
            this.chan1_scaled = chan1_scaled;
            this.chan2_scaled = chan2_scaled;
            this.chan3_scaled = chan3_scaled;
            this.chan4_scaled = chan4_scaled;
            this.chan5_scaled = chan5_scaled;
            this.chan6_scaled = chan6_scaled;
            this.chan7_scaled = chan7_scaled;
            this.chan8_scaled = chan8_scaled;
            this.port = port;
            this.rssi = rssi;
        }

        public Message_RC_CHANNELS_SCALED()
        {

        }

    }

    [MessageInfo(35, 22, 244,
        "The RAW values of the RC channels received." +
        "The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%." +
        "A value of UINT16_MAX implies the channel is unused." +
        "Individual receivers/transmitters might violate this specification.")]
    public class Message_RC_CHANNELS_RAW : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>RC channel 1 value.  [us] </summary>
        public ushort chan1_raw;
        /// <summary>RC channel 2 value.  [us] </summary>
        public ushort chan2_raw;
        /// <summary>RC channel 3 value.  [us] </summary>
        public ushort chan3_raw;
        /// <summary>RC channel 4 value.  [us] </summary>
        public ushort chan4_raw;
        /// <summary>RC channel 5 value.  [us] </summary>
        public ushort chan5_raw;
        /// <summary>RC channel 6 value.  [us] </summary>
        public ushort chan6_raw;
        /// <summary>RC channel 7 value.  [us] </summary>
        public ushort chan7_raw;
        /// <summary>RC channel 8 value.  [us] </summary>
        public ushort chan8_raw;
        /// <summary>Servo output port (set of 8 outputs = 1 port). Flight stacks running on Pixhawk should use: 0 = MAIN, 1 = AUX.   </summary>
        public byte port;
        /// <summary>Receive signal strength indicator in device-dependent units/scale. Values: [0-254], 255: invalid/unknown.   </summary>
        public byte rssi;

        public Message_RC_CHANNELS_RAW(uint time_boot_ms,
            ushort chan1_raw, ushort chan2_raw, ushort chan3_raw, ushort chan4_raw,
            ushort chan5_raw, ushort chan6_raw, ushort chan7_raw, ushort chan8_raw,
            byte port, byte rssi) :
            base(time_boot_ms, chan1_raw, chan2_raw, chan3_raw, chan4_raw, chan5_raw, chan6_raw, chan7_raw, chan8_raw,
                port, rssi)
        {
            this.time_boot_ms = time_boot_ms;
            this.chan1_raw = chan1_raw;
            this.chan2_raw = chan2_raw;
            this.chan3_raw = chan3_raw;
            this.chan4_raw = chan4_raw;
            this.chan5_raw = chan5_raw;
            this.chan6_raw = chan6_raw;
            this.chan7_raw = chan7_raw;
            this.chan8_raw = chan8_raw;
            this.port = port;
            this.rssi = rssi;
        }

        public Message_RC_CHANNELS_RAW()
        {

        }

    }

    [MessageInfo(36, 37, 222,
        "Superseded by ACTUATOR_OUTPUT_STATUS." +
        "The RAW values of the servo outputs (for RC input from the remote, use the RC_CHANNELS messages)." +
        "The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%.")]
    public class Message_SERVO_OUTPUT_RAW : Message
    {
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public uint time_usec;
        /// <summary>Servo output 1 value  [us] </summary>
        public ushort servo1_raw;
        /// <summary>Servo output 2 value  [us] </summary>
        public ushort servo2_raw;
        /// <summary>Servo output 3 value  [us] </summary>
        public ushort servo3_raw;
        /// <summary>Servo output 4 value  [us] </summary>
        public ushort servo4_raw;
        /// <summary>Servo output 5 value  [us] </summary>
        public ushort servo5_raw;
        /// <summary>Servo output 6 value  [us] </summary>
        public ushort servo6_raw;
        /// <summary>Servo output 7 value  [us] </summary>
        public ushort servo7_raw;
        /// <summary>Servo output 8 value  [us] </summary>
        public ushort servo8_raw;
        /// <summary>Servo output port (set of 8 outputs = 1 port). Flight stacks running on Pixhawk should use: 0 = MAIN, 1 = AUX.   </summary>
        public byte port;
        /// <summary>Servo output 9 value  [us] </summary>
        public ushort servo9_raw;
        /// <summary>Servo output 10 value  [us] </summary>
        public ushort servo10_raw;
        /// <summary>Servo output 11 value  [us] </summary>
        public ushort servo11_raw;
        /// <summary>Servo output 12 value  [us] </summary>
        public ushort servo12_raw;
        /// <summary>Servo output 13 value  [us] </summary>
        public ushort servo13_raw;
        /// <summary>Servo output 14 value  [us] </summary>
        public ushort servo14_raw;
        /// <summary>Servo output 15 value  [us] </summary>
        public ushort servo15_raw;
        /// <summary>Servo output 16 value  [us] </summary>
        public ushort servo16_raw;

        public Message_SERVO_OUTPUT_RAW(uint time_usec,
            ushort servo1_raw, ushort servo2_raw, ushort servo3_raw, ushort servo4_raw,
            ushort servo5_raw, ushort servo6_raw, ushort servo7_raw, ushort servo8_raw,
            byte port,
            ushort servo9_raw, ushort servo10_raw, ushort servo11_raw, ushort servo12_raw,
            ushort servo13_raw, ushort servo14_raw, ushort servo15_raw, ushort servo16_raw) :
            base(time_usec,
                servo1_raw, servo2_raw, servo3_raw, servo4_raw,
                servo5_raw, servo6_raw, servo7_raw, servo8_raw,
                port,
                servo9_raw, servo10_raw, servo11_raw, servo12_raw,
                servo13_raw, servo14_raw, servo15_raw, servo16_raw)
        {
            this.time_usec = time_usec;
            this.servo1_raw = servo1_raw;
            this.servo2_raw = servo2_raw;
            this.servo3_raw = servo3_raw;
            this.servo4_raw = servo4_raw;
            this.servo5_raw = servo5_raw;
            this.servo6_raw = servo6_raw;
            this.servo7_raw = servo7_raw;
            this.servo8_raw = servo8_raw;
            this.port = port;
            this.servo9_raw = servo9_raw;
            this.servo10_raw = servo10_raw;
            this.servo11_raw = servo11_raw;
            this.servo12_raw = servo12_raw;
            this.servo13_raw = servo13_raw;
            this.servo14_raw = servo14_raw;
            this.servo15_raw = servo15_raw;
            this.servo16_raw = servo16_raw;
        }


        public Message_SERVO_OUTPUT_RAW()
        {

        }

    }

    #region TODO : Message # 37 - # 41
    #endregion

    [MessageInfo(42, 2, 28,
        "Message that announces the sequence number of the current active mission item." +
        "The MAV will fly towards this mission item.")]
    public class Message_MISSION_CURRENT : Message
    {
        /// <summary>Sequence   </summary>
        public ushort seq;

        public Message_MISSION_CURRENT(ushort seq) : base(seq)
        {
            this.seq = seq;
        }

        public Message_MISSION_CURRENT() { }
    }

    #region TODO : Message # 43 ~ # 61
    #endregion

    [MessageInfo(62, 26, 183,
        "The state of the fixed wing navigation and position controller.")]
    public class Message_NAV_CONTROLLER_OUTPUT : Message
    {
        /// <summary>Current desired roll  [deg] </summary>
        public float nav_roll;
        /// <summary>Current desired pitch  [deg] </summary>
        public float nav_pitch;
        /// <summary>Current altitude error  [m] </summary>
        public float alt_error;
        /// <summary>Current airspeed error  [m/s] </summary>
        public float aspd_error;
        /// <summary>Current crosstrack error on x-y plane  [m] </summary>
        public float xtrack_error;
        /// <summary>Current desired heading  [deg] </summary>
        public short nav_bearing;
        /// <summary>Bearing to current waypoint/target  [deg] </summary>
        public short target_bearing;
        /// <summary>Distance to active waypoint  [m] </summary>
        public ushort wp_dist;

        public Message_NAV_CONTROLLER_OUTPUT(float nav_roll, float nav_pitch, float alt_error, float aspd_error,
            float xtrack_erro, short nav_bearing, short target_bearing, ushort wp_dist)
        : base(nav_roll, nav_pitch, alt_error, aspd_error, xtrack_erro, nav_bearing, target_bearing, wp_dist)
        {
            this.nav_roll = nav_roll;
            this.nav_pitch = nav_pitch;
            this.alt_error = alt_error;
            this.aspd_error = aspd_error;
            this.xtrack_error = xtrack_erro;
            this.nav_bearing = nav_bearing;
            this.target_bearing = target_bearing;
            this.wp_dist = wp_dist;
        }

        public Message_NAV_CONTROLLER_OUTPUT()
        {

        }
    }

    [MessageInfo(63, 181, 119,
        "The filtered global position (e.g. fused GPS and accelerometers)." +
        "The position is in GPS-frame (right-handed, Z-up)." +
        "It is designed as scaled integer message since the resolution of float is not sufficient." +
        "NOTE: This message is intended for onboard networks / companion computers and higher-bandwidth links and optimized for accuracy and completeness." +
        "Please use the GLOBAL_POSITION_INT message for a minimal subset.")]
    public class Message_GLOBAL_POSITION_INT_COV : Message
    {
        public Message_GLOBAL_POSITION_INT_COV(ulong time_usec, int lat, int lon, int alt, int relative_alt, float vx, float vy, float vz, float[] covariance,/*MAV_ESTIMATOR_TYPE*/byte estimator_type)
        : base(time_usec, lat, lon, alt, relative_alt, vx, vy, vz, covariance, estimator_type)
        {
            this.time_usec = time_usec;
            this.lat = lat;
            this.lon = lon;
            this.alt = alt;
            this.relative_alt = relative_alt;
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;
            this.covariance = covariance;
            this.estimator_type = estimator_type;

        }

        public Message_GLOBAL_POSITION_INT_COV()
        {

        }

        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>Latitude  [degE7] </summary>
        public int lat;
        /// <summary>Longitude  [degE7] </summary>
        public int lon;
        /// <summary>Altitude in meters above MSL  [mm] </summary>
        public int alt;
        /// <summary>Altitude above ground  [mm] </summary>
        public int relative_alt;
        /// <summary>Ground X Speed (Latitude)  [m/s] </summary>
        public float vx;
        /// <summary>Ground Y Speed (Longitude)  [m/s] </summary>
        public float vy;
        /// <summary>Ground Z Speed (Altitude)  [m/s] </summary>
        public float vz;
        /// <summary>Row-major representation of a 6x6 position and velocity 6x6 cross-covariance matrix (states: lat, lon, alt, vx, vy, vz; first six entries are the first ROW, next six entries are the second row, etc.). If unknown, assign NaN value to first element in the array.   </summary>
        public float[] covariance = new float[36];
        /// <summary>Class id of the estimator this estimate originated from. MAV_ESTIMATOR_TYPE  </summary>
        public  /*MAV_ESTIMATOR_TYPE*/byte estimator_type;
    }

    [MessageInfo(64, 225, 191,
        "The filtered local position (e.g. fused computer vision and accelerometers)." +
        "Coordinate frame is right-handed, Z-axis down (aeronautical frame, NED / north-east-down convention)")]
    public class Message_LOCAL_POSITION_NED_COV : Message
    {
        public Message_LOCAL_POSITION_NED_COV(ulong time_usec, float x, float y, float z, float vx, float vy, float vz, float ax, float ay, float az, float[] covariance,/*MAV_ESTIMATOR_TYPE*/byte estimator_type)
        : base(time_usec, x, y, z, vx, vy, vz, ax, ay, az, covariance, estimator_type)
        {
            this.time_usec = time_usec;
            this.x = x;
            this.y = y;
            this.z = z;
            this.vx = vx;
            this.vy = vy;
            this.vz = vz;
            this.ax = ax;
            this.ay = ay;
            this.az = az;
            this.covariance = covariance;
            this.estimator_type = estimator_type;
        }

        public Message_LOCAL_POSITION_NED_COV()
        {

        }

        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>X Position  [m] </summary>
        public float x;
        /// <summary>Y Position  [m] </summary>
        public float y;
        /// <summary>Z Position  [m] </summary>
        public float z;
        /// <summary>X Speed  [m/s] </summary>
        public float vx;
        /// <summary>Y Speed  [m/s] </summary>
        public float vy;
        /// <summary>Z Speed  [m/s] </summary>
        public float vz;
        /// <summary>X Acceleration  [m/s/s] </summary>
        public float ax;
        /// <summary>Y Acceleration  [m/s/s] </summary>
        public float ay;
        /// <summary>Z Acceleration  [m/s/s] </summary>
        public float az;
        /// <summary>Row-major representation of position, velocity and acceleration 9x9 cross-covariance matrix upper right triangle (states: x, y, z, vx, vy, vz, ax, ay, az; first nine entries are the first ROW, next eight entries are the second row, etc.). If unknown, assign NaN value to first element in the array.   </summary>
        public float[] covariance = new float[36];
        /// <summary>Class id of the estimator this estimate originated from. MAV_ESTIMATOR_TYPE  </summary>
        public  /*MAV_ESTIMATOR_TYPE*/byte estimator_type;
    }

    [MessageInfo(65, 42, 118,
        "The PPM values of the RC channels received." +
        "The standard PPM modulation is as follows: 1000 microseconds: 0%, 2000 microseconds: 100%." +
        "A value of UINT16_MAX implies the channel is unused." +
        "Individual receivers/transmitters might violate this specification.")]
    public class Message_RC_CHANNELS : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>RC channel 1 value.  [us] </summary>
        public ushort chan1_raw;
        /// <summary>RC channel 2 value.  [us] </summary>
        public ushort chan2_raw;
        /// <summary>RC channel 3 value.  [us] </summary>
        public ushort chan3_raw;
        /// <summary>RC channel 4 value.  [us] </summary>
        public ushort chan4_raw;
        /// <summary>RC channel 5 value.  [us] </summary>
        public ushort chan5_raw;
        /// <summary>RC channel 6 value.  [us] </summary>
        public ushort chan6_raw;
        /// <summary>RC channel 7 value.  [us] </summary>
        public ushort chan7_raw;
        /// <summary>RC channel 8 value.  [us] </summary>
        public ushort chan8_raw;
        /// <summary>RC channel 9 value.  [us] </summary>
        public ushort chan9_raw;
        /// <summary>RC channel 10 value.  [us] </summary>
        public ushort chan10_raw;
        /// <summary>RC channel 11 value.  [us] </summary>
        public ushort chan11_raw;
        /// <summary>RC channel 12 value.  [us] </summary>
        public ushort chan12_raw;
        /// <summary>RC channel 13 value.  [us] </summary>
        public ushort chan13_raw;
        /// <summary>RC channel 14 value.  [us] </summary>
        public ushort chan14_raw;
        /// <summary>RC channel 15 value.  [us] </summary>
        public ushort chan15_raw;
        /// <summary>RC channel 16 value.  [us] </summary>
        public ushort chan16_raw;
        /// <summary>RC channel 17 value.  [us] </summary>
        public ushort chan17_raw;
        /// <summary>RC channel 18 value.  [us] </summary>
        public ushort chan18_raw;
        /// <summary>Total number of RC channels being received. This can be larger than 18, indicating that more channels are available but not given in this message. This value should be 0 when no RC channels are available.   </summary>
        public byte chancount;
        /// <summary>Receive signal strength indicator in device-dependent units/scale. Values: [0-254], 255: invalid/unknown.   </summary>
        public byte rssi;

        public Message_RC_CHANNELS(uint time_boot_ms,
        ushort chan1_raw, ushort chan2_raw, ushort chan3_raw, ushort chan4_raw,
        ushort chan5_raw, ushort chan6_raw, ushort chan7_raw, ushort chan8_raw,
        ushort chan9_raw, ushort chan10_raw, ushort chan11_raw, ushort chan12_raw,
        ushort chan13_raw, ushort chan14_raw, ushort chan15_raw, ushort chan16_raw,
        ushort chan17_raw, ushort chan18_raw, byte chancount, byte rssi)
        : base(time_boot_ms,
              chan1_raw, chan2_raw, chan3_raw, chan4_raw,
              chan5_raw, chan6_raw, chan7_raw, chan8_raw,
              chan9_raw, chan10_raw, chan11_raw, chan12_raw,
              chan13_raw, chan14_raw, chan15_raw, chan16_raw,
              chan17_raw, chan18_raw, chancount, rssi)
        {
            this.time_boot_ms = time_boot_ms;
            this.chan1_raw = chan1_raw;
            this.chan2_raw = chan2_raw;
            this.chan3_raw = chan3_raw;
            this.chan4_raw = chan4_raw;
            this.chan5_raw = chan5_raw;
            this.chan6_raw = chan6_raw;
            this.chan7_raw = chan7_raw;
            this.chan8_raw = chan8_raw;
            this.chan9_raw = chan9_raw;
            this.chan10_raw = chan10_raw;
            this.chan11_raw = chan11_raw;
            this.chan12_raw = chan12_raw;
            this.chan13_raw = chan13_raw;
            this.chan14_raw = chan14_raw;
            this.chan15_raw = chan15_raw;
            this.chan16_raw = chan16_raw;
            this.chan17_raw = chan17_raw;
            this.chan18_raw = chan18_raw;
            this.chancount = chancount;
            this.rssi = rssi;
        }

        public Message_RC_CHANNELS()
        {

        }

    }

    [MessageInfo(66, 6, 148,
        "Request a data stream.")]
    public class Message_REQUEST_DATA_STREAM : Message
    {
        /// <summary> The target requested to send the message stream. </summary>
        public ushort req_message_rate;
        /// <summary> The target requested to send the message stream. </summary>
        public byte target_system;
        /// <summary> The ID of the requested data stream. </summary>
        public byte target_component;
        /// <summary> The requested message rate. </summary>
        public byte req_stream_id;
        /// <summary> 1 to start sending, 0 to stop sending. </summary>
        public byte start_stop;

        public Message_REQUEST_DATA_STREAM(ushort req_message_rate, byte target_system, byte target_component,
            byte req_stream_id, byte start_stop) : base(req_message_rate, target_system, target_component, req_stream_id, start_stop)
        {
            this.req_message_rate = req_message_rate;
            this.target_system = target_system;
            this.target_component = target_component;
            this.req_stream_id = req_stream_id;
            this.start_stop = start_stop;
        }

        public Message_REQUEST_DATA_STREAM()
        {

        }

    }

    #region TODO : # 67 ~ # 73
    #endregion

    [MessageInfo(74, 20, 20,
        "Metrics typically displayed on a HUD for fixed wing aircraft.")]
    public class Message_VFR_HUD : Message
    {
        /// <summary>Current indicated airspeed (IAS).  [m/s] </summary>
        public float airspeed;
        /// <summary>Current ground speed.  [m/s] </summary>
        public float groundspeed;
        /// <summary>Current altitude (MSL).  [m] </summary>
        public float alt;
        /// <summary>Current climb rate.  [m/s] </summary>
        public float climb;
        /// <summary>Current heading in compass units (0-360, 0=north).  [deg] </summary>
        public short heading;
        /// <summary>Current throttle setting (0 to 100).  [%] </summary>
        public ushort throttle;

        public Message_VFR_HUD(float airspeed, float groundspeed, float alt, float climb, short heading, ushort throttle) :
            base(airspeed, groundspeed, alt, climb, heading, throttle)
        {
            this.airspeed = airspeed;
            this.groundspeed = groundspeed;
            this.alt = alt;
            this.climb = climb;
            this.heading = heading;
            this.throttle = throttle;
        }

        public Message_VFR_HUD()
        {

        }

    }

    /// <summary>
    /// COMMAND_INT #75
    /// </summary>
    [MessageInfo(75, 35, 158,
        "Message encoding a command with parameters as scaled integers." +
        "Scaling depends on the actual command value." +
        "The command microservice is documented at https://mavlink.io/en/services/command.html")]
    public class Message_COMMAND_INT : Message
    {
        /// <summary>PARAM1, see MAV_CMD enum   </summary>
        public float param1;
        /// <summary>PARAM2, see MAV_CMD enum   </summary>
        public float param2;
        /// <summary>PARAM3, see MAV_CMD enum   </summary>
        public float param3;
        /// <summary>PARAM4, see MAV_CMD enum   </summary>
        public float param4;
        /// <summary>PARAM5 / local: x position in meters * 1e4, global: latitude in degrees * 10^7   </summary>
        public int x;
        /// <summary>PARAM6 / local: y position in meters * 1e4, global: longitude in degrees * 10^7   </summary>
        public int y;
        /// <summary>PARAM7 / z position: global: altitude in meters (relative or absolute, depending on frame).   </summary>
        public float z;
        /// <summary>The scheduled action for the mission item. MAV_CMD  </summary>
        public  /*MAV_CMD*/ushort command;
        /// <summary>System ID   </summary>
        public byte target_system;
        /// <summary>Component ID   </summary>
        public byte target_component;
        /// <summary>The coordinate system of the COMMAND. MAV_FRAME  </summary>
        public  /*MAV_FRAME*/byte frame;
        /// <summary>false:0, true:1   </summary>
        public byte current;
        /// <summary>autocontinue to next wp   </summary>
        public byte autocontinue;

        // TODO : Testing.
    }

    /// <summary>
    /// COMMAND_LONG # 76
    /// </summary>
    [MessageInfo(76, 33, 152,
        "Send a command with up to seven parameters to the MAV." +
        "The command microservice is documented at https://mavlink.io/en/services/command.html")]
    public class Message_COMMAND_LONG : Message
    {
        /// <summary>Parameter 1 (for the specific command).   </summary>
        public float param1;
        /// <summary>Parameter 2 (for the specific command).   </summary>
        public float param2;
        /// <summary>Parameter 3 (for the specific command).   </summary>
        public float param3;
        /// <summary>Parameter 4 (for the specific command).   </summary>
        public float param4;
        /// <summary>Parameter 5 (for the specific command).   </summary>
        public float param5;
        /// <summary>Parameter 6 (for the specific command).   </summary>
        public float param6;
        /// <summary>Parameter 7 (for the specific command).   </summary>
        public float param7;
        /// <summary>Command ID (of command to send). MAV_CMD  </summary>
        public  /*MAV_CMD*/ushort command;
        /// <summary>System which should execute the command   </summary>
        public byte target_system;
        /// <summary>Component which should execute the command, 0 for all components   </summary>
        public byte target_component;
        /// <summary>0: First transmission of this command. 1-255: Confirmation transmissions (e.g. for kill command)   </summary>
        public byte confirmation;

        public Message_COMMAND_LONG(float param1, float param2, float param3, float param4,
                                       float param5, float param6, float param7,
                                       ushort command, byte target_system, byte target_component, byte confirmation)
        : base(param1, param2, param3, param4, param5, param6, param7, command, target_system, target_component, confirmation)
        {
            this.param1 = param1;
            this.param2 = param2;
            this.param3 = param3;
            this.param4 = param4;
            this.param5 = param5;
            this.param6 = param6;
            this.param7 = param7;
            this.command = command;
            this.target_system = target_system;
            this.target_component = target_component;
            this.confirmation = confirmation;

        }

        public Message_COMMAND_LONG()
        {

        }

    }

    /// <summary>
    /// COMMAND_ACK #77
    /// </summary>
    [MessageInfo(77, 3, 143,
        "Report status of a command." +
        "Includes feedback whether the command was executed." +
        "The command microservice is documented at https://mavlink.io/en/services/command.html")]
    public class Message_COMMAND_ACK : Message
    {
        /// <summary>Command ID (of acknowledged command). MAV_CMD  </summary>
        public  /*MAV_CMD*/ushort command;
        /// <summary>Result of command. MAV_RESULT  </summary>
        public  /*MAV_RESULT*/byte result;

        public Message_COMMAND_ACK(ushort command, byte result) : base(command, result)
        {
            this.command = command;
            this.result = result;
        }

        public Message_COMMAND_ACK()
        {

        }

    }

    #region TODO : # 78 ~ # 110
    #endregion

    /// <summary>
    /// TIMESYNC #111
    /// </summary>
    [MessageInfo(111, 16, 34,
        "Time synchronization message.")]
    public class Message_TIMESYNC : Message
    {
        /// <summary>Time sync timestamp 1   </summary>
        public long tc1;
        /// <summary>Time sync timestamp 2   </summary>
        public long ts1;

        public Message_TIMESYNC(long tc1, long ts1) : base(tc1, ts1)
        {
            this.tc1 = tc1;
            this.ts1 = ts1;
        }

        public Message_TIMESYNC()
        {

        }
    }

    /// <summary>
    /// CAMERA_TRIGGER # 112
    /// </summary>
    [MessageInfo(112, 12, 174,
        "Camera-IMU triggering and synchronisation message.")]
    public class Message_CAMERA_TRIGGER : Message
    {
        /// <summary>Timestamp for image frame (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>Image frame sequence   </summary>
        public uint seq;

        public Message_CAMERA_TRIGGER(ulong time_usec, uint seq) : base(time_usec, seq)
        {
            this.time_usec = time_usec;
            this.seq = seq;
        }
        public Message_CAMERA_TRIGGER()
        {

        }
    }

    /// <summary>
    /// HIL_GPS #113
    /// </summary>
    [MessageInfo(113, 36, 124,
        "The global position, as returned by the Global Positioning System (GPS)." +
        "This is NOT the global position estimate of the sytem, but rather a RAW sensor value." +
        "See message GLOBAL_POSITION for the global position estimate.")]
    public class Message_HIL_GPS : Message
    {
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>Latitude (WGS84)  [degE7] </summary>
        public int lat;
        /// <summary>Longitude (WGS84)  [degE7] </summary>
        public int lon;
        /// <summary>Altitude (MSL). Positive for up.  [mm] </summary>
        public int alt;
        /// <summary>GPS HDOP horizontal dilution of position. If unknown, set to: 65535  [cm] </summary>
        public ushort eph;
        /// <summary>GPS VDOP vertical dilution of position. If unknown, set to: 65535  [cm] </summary>
        public ushort epv;
        /// <summary>GPS ground speed. If unknown, set to: 65535  [cm/s] </summary>
        public ushort vel;
        /// <summary>GPS velocity in north direction in earth-fixed NED frame  [cm/s] </summary>
        public short vn;
        /// <summary>GPS velocity in east direction in earth-fixed NED frame  [cm/s] </summary>
        public short ve;
        /// <summary>GPS velocity in down direction in earth-fixed NED frame  [cm/s] </summary>
        public short vd;
        /// <summary>Course over ground (NOT heading, but direction of movement), 0.0..359.99 degrees. If unknown, set to: 65535  [cdeg] </summary>
        public ushort cog;
        /// <summary>0-1: no fix, 2: 2D fix, 3: 3D fix. Some applications will not use the value of this field unless it is at least two, so always correctly fill in the fix.   </summary>
        public byte fix_type;
        /// <summary>Number of satellites visible. If unknown, set to 255   </summary>
        public byte satellites_visible;

        public Message_HIL_GPS(ulong time_usec,
            int lat, int lon, int alt,
            ushort eph, ushort epv, ushort vel,
            short vn, short ve, short vd,
            ushort cog, byte fix_type, byte satellites_visible) :
            base(time_usec,
                lat, lon, alt,
                eph, epv, vel,
                vn, ve, vd,
                cog, fix_type, satellites_visible)
        {
            this.time_usec = time_usec;
            this.lat = lat;
            this.lon = lon;
            this.alt = alt;
            this.eph = eph;
            this.epv = epv;
            this.vel = vel;
            this.vn = vn;
            this.ve = ve;
            this.vd = vd;
            this.cog = cog;
            this.fix_type = fix_type;
            this.satellites_visible = satellites_visible;
        }

        public Message_HIL_GPS()
        {

        }
    }

    /// <summary>
    /// HIL_OPTICAL_FLOW #114
    /// </summary>
    [MessageInfo(114, 44, 237,
        "Simulated optical flow from a flow sensor (e.g. PX4FLOW or optical mouse sensor)")]
    public class Message_HIL_OPTICAL_FLOW : Message
    {
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>Integration time. Divide integrated_x and integrated_y by the integration time to obtain average flow. The integration time also indicates the.  [us] </summary>
        public uint integration_time_us;
        /// <summary>Flow in radians around X axis (Sensor RH rotation about the X axis induces a positive flow. Sensor linear motion along the positive Y axis induces a negative flow.)  [rad] </summary>
        public float integrated_x;
        /// <summary>Flow in radians around Y axis (Sensor RH rotation about the Y axis induces a positive flow. Sensor linear motion along the positive X axis induces a positive flow.)  [rad] </summary>
        public float integrated_y;
        /// <summary>RH rotation around X axis  [rad] </summary>
        public float integrated_xgyro;
        /// <summary>RH rotation around Y axis  [rad] </summary>
        public float integrated_ygyro;
        /// <summary>RH rotation around Z axis  [rad] </summary>
        public float integrated_zgyro;
        /// <summary>Time since the distance was sampled.  [us] </summary>
        public uint time_delta_distance_us;
        /// <summary>Distance to the center of the flow field. Positive value (including zero): distance known. Negative value: Unknown distance.  [m] </summary>
        public float distance;
        /// <summary>Temperature  [cdegC] </summary>
        public short temperature;
        /// <summary>Sensor ID   </summary>
        public byte sensor_id;
        /// <summary>Optical flow quality / confidence. 0: no valid flow, 255: maximum quality   </summary>
        public byte quality;

        public Message_HIL_OPTICAL_FLOW(ulong time_usec, uint integration_time_us,
            float integrated_x, float integrated_y,
            float integrated_xgyro, float integrated_ygyro, float integrated_zgyro,
            uint time_delta_distance_us, float distance, short temperature, byte sensor_id, byte quality) :
            base(time_usec, integration_time_us,
            integrated_x, integrated_y,
            integrated_xgyro, integrated_ygyro, integrated_zgyro,
            time_delta_distance_us, distance, temperature, sensor_id, quality)
        {
            this.time_usec = time_usec;
            this.integration_time_us = integration_time_us;
            this.integrated_x = integrated_x;
            this.integrated_y = integrated_y;
            this.integrated_xgyro = integrated_xgyro;
            this.integrated_ygyro = integrated_ygyro;
            this.integrated_zgyro = integrated_zgyro;
            this.time_delta_distance_us = time_delta_distance_us;
            this.distance = distance;
            this.temperature = temperature;
            this.sensor_id = sensor_id;
            this.quality = quality;
        }

        public Message_HIL_OPTICAL_FLOW()
        {

        }
    }

    /// <summary>
    /// HIL_STATE_QUATERNION # 115
    /// </summary>
    [MessageInfo(115, 64, 4,
        "Sent from simulation to autopilot, avoids in contrast to HIL_STATE singularities." +
        "This packet is useful for high throughput applications such as hardware in the loop simulations.")]
    public class Message_HIL_STATE_QUATERNION : Message
    {
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>Vehicle attitude expressed as normalized quaternion in w, x, y, z order (with 1 0 0 0 being the null-rotation)   </summary>
        public float[] attitude_quaternion = new float[4];
        /// <summary>Body frame roll / phi angular speed  [rad/s] </summary>
        public float rollspeed;
        /// <summary>Body frame pitch / theta angular speed  [rad/s] </summary>
        public float pitchspeed;
        /// <summary>Body frame yaw / psi angular speed  [rad/s] </summary>
        public float yawspeed;
        /// <summary>Latitude  [degE7] </summary>
        public int lat;
        /// <summary>Longitude  [degE7] </summary>
        public int lon;
        /// <summary>Altitude  [mm] </summary>
        public int alt;
        /// <summary>Ground X Speed (Latitude)  [cm/s] </summary>
        public short vx;
        /// <summary>Ground Y Speed (Longitude)  [cm/s] </summary>
        public short vy;
        /// <summary>Ground Z Speed (Altitude)  [cm/s] </summary>
        public short vz;
        /// <summary>Indicated airspeed  [cm/s] </summary>
        public ushort ind_airspeed;
        /// <summary>True airspeed  [cm/s] </summary>
        public ushort true_airspeed;
        /// <summary>X acceleration  [mG] </summary>
        public short xacc;
        /// <summary>Y acceleration  [mG] </summary>
        public short yacc;
        /// <summary>Z acceleration  [mG] </summary>
        public short zacc;

        // TODO : Constructor
    }

    /// <summary>
    /// SCALED_IMU2 #116
    /// </summary>
    [MessageInfo(116, 24, 76,
        "The RAW IMU readings for secondary 9DOF sensor setup." +
        "This message should contain the scaled values to the described units")]
    public class Message_SCALED_IMU2 : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>X acceleration  [mG] </summary>
        public short xacc;
        /// <summary>Y acceleration  [mG] </summary>
        public short yacc;
        /// <summary>Z acceleration  [mG] </summary>
        public short zacc;
        /// <summary>Angular speed around X axis  [mrad/s] </summary>
        public short xgyro;
        /// <summary>Angular speed around Y axis  [mrad/s] </summary>
        public short ygyro;
        /// <summary>Angular speed around Z axis  [mrad/s] </summary>
        public short zgyro;
        /// <summary>X Magnetic field  [mgauss] </summary>
        public short xmag;
        /// <summary>Y Magnetic field  [mgauss] </summary>
        public short ymag;
        /// <summary>Z Magnetic field  [mgauss] </summary>
        public short zmag;
        /// <summary>Temperature, 0: IMU does not provide temperature values. If the IMU is at 0C it must send 1 (0.01C).  [cdegC] </summary>
        public short temperature;

        // TODO : Contructor
    }

    #region TODO : message #117 - #128

    [MessageInfo(125, 6, 203,
        "Power supply status")]
    public class Message_POWER_STATUS : Message
    {
        public Message_POWER_STATUS()
        {

        }

        public Message_POWER_STATUS(ushort Vcc, ushort Vservo,/*MAV_POWER_STATUS*/ushort flags)
        : base(Vcc, Vservo, flags)
        {
            this.Vcc = Vcc;
            this.Vservo = Vservo;
            this.flags = flags;

        }
        /// <summary>5V rail voltage.  [mV] </summary>
        public ushort Vcc;
        /// <summary>Servo rail voltage.  [mV] </summary>
        public ushort Vservo;
        /// <summary>Bitmap of power supply status flags. MAV_POWER_STATUS  bitmask</summary>
        public  /*MAV_POWER_STATUS*/ushort flags;
    }

    #endregion

    /// <summary>
    /// SCALED_IMU3 # 129
    /// </summary>
    [MessageInfo(129, 24, 46,
        "The RAW IMU readings for 3rd 9DOF sensor setup. " +
        "This message should contain the scaled values to the described units")]
    public class Message_SCALED_IMU3 : Message
    {
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>X acceleration  [mG] </summary>
        public short xacc;
        /// <summary>Y acceleration  [mG] </summary>
        public short yacc;
        /// <summary>Z acceleration  [mG] </summary>
        public short zacc;
        /// <summary>Angular speed around X axis  [mrad/s] </summary>
        public short xgyro;
        /// <summary>Angular speed around Y axis  [mrad/s] </summary>
        public short ygyro;
        /// <summary>Angular speed around Z axis  [mrad/s] </summary>
        public short zgyro;
        /// <summary>X Magnetic field  [mgauss] </summary>
        public short xmag;
        /// <summary>Y Magnetic field  [mgauss] </summary>
        public short ymag;
        /// <summary>Z Magnetic field  [mgauss] </summary>
        public short zmag;
        /// <summary>Temperature, 0: IMU does not provide temperature values. If the IMU is at 0C it must send 1 (0.01C).  [cdegC] </summary>
        public short temperature;

        // TODO : Constructor.
    }

    #region TODO : # 130 ~ # 146

    [MessageInfo(136, 22, 1,
            "Streamed from drone to report progress of terrain map download (or response from a TERRAIN_CHECK request - deprecated)." +
        "See terrain protocol docs: https://mavlink.io/en/services/terrain.html")]
    public class Message_TERRAIN_REPORT : Message
    {
        public Message_TERRAIN_REPORT()
        {

        }
        public Message_TERRAIN_REPORT(int lat, int lon, float terrain_height, float current_height, ushort spacing, ushort pending, ushort loaded)
        : base(lat, lon, terrain_height, current_height, spacing, pending, loaded)
        {
            this.lat = lat;
            this.lon = lon;
            this.terrain_height = terrain_height;
            this.current_height = current_height;
            this.spacing = spacing;
            this.pending = pending;
            this.loaded = loaded;

        }
        /// <summary>Latitude  [degE7] </summary>
        public int lat;
        /// <summary>Longitude  [degE7] </summary>
        public int lon;
        /// <summary>Terrain height MSL  [m] </summary>
        public float terrain_height;
        /// <summary>Current vehicle height above lat/lon terrain height  [m] </summary>
        public float current_height;
        /// <summary>grid spacing (zero if terrain at this location unavailable)   </summary>
        public ushort spacing;
        /// <summary>Number of 4x4 terrain blocks waiting to be received or read from disk   </summary>
        public ushort pending;
        /// <summary>Number of 4x4 terrain blocks in memory   </summary>
        public ushort loaded;

    }

    [MessageInfo(137, 14, 195,
        "Barometer readings for 2nd barometer")]
    public class Message_SCALED_PRESSURE2 : Message
    {
        public Message_SCALED_PRESSURE2()
        {

        }

        public Message_SCALED_PRESSURE2(uint time_boot_ms, float press_abs, float press_diff, short temperature)
        : base(time_boot_ms, press_abs, press_diff, temperature)
        {
            this.time_boot_ms = time_boot_ms;
            this.press_abs = press_abs;
            this.press_diff = press_diff;
            this.temperature = temperature;

        }
        /// <summary>Timestamp (time since system boot).  [ms] </summary>
        public uint time_boot_ms;
        /// <summary>Absolute pressure  [hPa] </summary>
        public float press_abs;
        /// <summary>Differential pressure  [hPa] </summary>
        public float press_diff;
        /// <summary>Temperature measurement  [cdegC] </summary>
        public short temperature;

    }

    #endregion

    [MessageInfo(147, 36, 153,
        "Battery information." +
        "Updates GCS with flight controller battery status." +
        "Use SMART_BATTERY_* messages instead for smart batteries.")]
    public class Message_BATTERY_STATUS : Message
    {
        /// <summary>Consumed charge, -1: autopilot does not provide consumption estimate  [mAh] </summary>
        public int current_consumed;
        /// <summary>Consumed energy, -1: autopilot does not provide energy consumption estimate  [hJ] </summary>
        public int energy_consumed;
        /// <summary>Temperature of the battery. INT16_MAX for unknown temperature.  [cdegC] </summary>
        public short temperature;
        /// <summary>Battery voltage of cells. Cells above the valid cell count for this battery should have the UINT16_MAX value.  [mV] </summary>
        public ushort[] voltages = new ushort[10];
        /// <summary>Battery current, -1: autopilot does not measure the current  [cA] </summary>
        public short current_battery;
        /// <summary>Battery ID   </summary>
        public byte id;
        /// <summary>Function of the battery MAV_BATTERY_FUNCTION  </summary>
        public  /*MAV_BATTERY_FUNCTION*/byte battery_function;
        /// <summary>Type (chemistry) of the battery MAV_BATTERY_TYPE  </summary>
        public  /*MAV_BATTERY_TYPE*/byte type;
        /// <summary>Remaining battery energy. Values: [0-100], -1: autopilot does not estimate the remaining battery.  [%] </summary>
        public sbyte battery_remaining;

        public Message_BATTERY_STATUS(int current_consumed, int energy_consumed, short temperature, ushort[] voltages,
            short current_battery, byte id, byte battery_function, byte type, sbyte battery_remaining)
            : base(current_consumed, energy_consumed, temperature, voltages, current_battery, id, battery_function, type, battery_remaining)
        {
            this.current_consumed = current_consumed;
            this.energy_consumed = energy_consumed;
            this.temperature = temperature;
            this.voltages = voltages;
            this.current_battery = current_battery;
            this.id = id;
            this.battery_function = battery_function;
            this.type = type;
            this.battery_remaining = battery_remaining;
        }

        public Message_BATTERY_STATUS() { }
    }

    /// <summary>
    /// AUTOPILOT_VERSION # 148
    /// </summary>
    [MessageInfo(148, 78, 178,
        "Version and capability of autopilot software." +
        "This should be emitted in response to a request with MAV_CMD_REQUEST_MESSAGE.")]
    public class Message_AUTOPILOT_VERSION : Message
    {
        /// <summary>Bitmap of capabilities MAV_PROTOCOL_CAPABILITY  bitmask</summary>
        public  /*MAV_PROTOCOL_CAPABILITY*/ulong capabilities;
        /// <summary>UID if provided by hardware (see uid2)   </summary>
        public ulong uid;
        /// <summary>Firmware version number   </summary>
        public uint flight_sw_version;
        /// <summary>Middleware version number   </summary>
        public uint middleware_sw_version;
        /// <summary>Operating system version number   </summary>
        public uint os_sw_version;
        /// <summary>HW / board version (last 8 bytes should be silicon ID, if any)   </summary>
        public uint board_version;
        /// <summary>ID of the board vendor   </summary>
        public ushort vendor_id;
        /// <summary>ID of the product   </summary>
        public ushort product_id;
        /// <summary>Custom version field, commonly the first 8 bytes of the git hash. This is not an unique identifier, but should allow to identify the commit using the main version number even for very large code bases.   </summary>
        public byte[] flight_custom_version = new byte[8];
        /// <summary>Custom version field, commonly the first 8 bytes of the git hash. This is not an unique identifier, but should allow to identify the commit using the main version number even for very large code bases.   </summary>
        public byte[] middleware_custom_version = new byte[8];
        /// <summary>Custom version field, commonly the first 8 bytes of the git hash. This is not an unique identifier, but should allow to identify the commit using the main version number even for very large code bases.   </summary>
        public byte[] os_custom_version = new byte[8];
        /// <summary>UID if provided by hardware (supersedes the uid field. If this is non-zero, use this field, otherwise use uid)   </summary>
        public byte[] uid2 = new byte[18];

        public Message_AUTOPILOT_VERSION(ulong capabilities, ulong uid,
                                            uint flight_sw_version, uint middleware_sw_version, uint os_sw_version, uint board_version,
                                            ushort vendor_id, ushort product_id,
                                            byte[] flight_custom_version,
                                            byte[] middleware_custom_version,
                                            byte[] os_custom_version,
                                            byte[] uid2) :
            base(capabilities, uid, flight_sw_version, middleware_sw_version, os_sw_version, board_version,
                vendor_id, product_id, flight_custom_version, middleware_custom_version, os_custom_version, uid2)

        {
            this.capabilities = capabilities;
            this.uid = uid;
            this.flight_sw_version = flight_sw_version;
            this.middleware_sw_version = middleware_sw_version;
            this.os_sw_version = os_sw_version;
            this.board_version = board_version;
            this.vendor_id = vendor_id;
            this.product_id = product_id;
            this.flight_custom_version = flight_custom_version;
            this.middleware_custom_version = middleware_custom_version;
            this.os_custom_version = os_custom_version;
            this.uid2 = uid2;
        }

        public Message_AUTOPILOT_VERSION()
        {

        }
    }

    [MessageInfo(149, 30, 200,
        "The location of a landing target. See: https://mavlink.io/en/services/landing_target.html")]
    public class Message_LANDING_TARGET : Message
    {
        public Message_LANDING_TARGET()
        {

        }

        public Message_LANDING_TARGET(ulong time_usec, float angle_x, float angle_y, float distance, float size_x, float size_y, byte target_num,byte frame /*float x, float y, float z, float[] q,LANDING_TARGET_TYPEbyte type, byte position_valid*/)
        : base(time_usec, angle_x, angle_y, distance, size_x, size_y, target_num, frame)
        {
            this.time_usec = time_usec;
            this.angle_x = angle_x;
            this.angle_y = angle_y;
            this.distance = distance;
            this.size_x = size_x;
            this.size_y = size_y;
            this.target_num = target_num;
            this.frame = frame;


            //this.x = x;
            //this.y = y;
            //this.z = z;
            //this.q = q;
            //this.type = type;
            //this.position_valid = position_valid;

        }
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>X-axis angular offset of the target from the center of the image  [rad] </summary>
        public float angle_x;
        /// <summary>Y-axis angular offset of the target from the center of the image  [rad] </summary>
        public float angle_y;
        /// <summary>Distance to the target from the vehicle  [m] </summary>
        public float distance;
        /// <summary>Size of target along x-axis  [rad] </summary>
        public float size_x;
        /// <summary>Size of target along y-axis  [rad] </summary>
        public float size_y;
        /// <summary>The ID of the target if multiple targets are present   </summary>
        public byte target_num;
        /// <summary>Coordinate frame used for following fields. MAV_FRAME  </summary>
        public  /*MAV_FRAME*/byte frame;
        /// <summary>X Position of the landing target in MAV_FRAME  [m] </summary>
        //public float x;
        /// <summary>Y Position of the landing target in MAV_FRAME  [m] </summary>
        //public float y;
        /// <summary>Z Position of the landing target in MAV_FRAME  [m] </summary>
        //public float z;
        /// <summary>Quaternion of landing target orientation (w, x, y, z order, zero-rotation is 1, 0, 0, 0)   </summary>
        //public float[] q;
        /// <summary>Type of landing target LANDING_TARGET_TYPE  </summary>
        //public  /*LANDING_TARGET_TYPE*/byte type;
        /// <summary>Boolean indicating whether the position fields (x, y, z, q, type) contain valid target position information (valid: 1, invalid: 0). Default is 0 (invalid).   </summary>
        //public byte position_valid;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(150, 42, 134,
        "Offsets and calibrations values for hardware sensors." +
        "This makes it easier to debug the calibration process.")]
    public class Message_SENSOR_OFFSETS : Message
    {
        public Message_SENSOR_OFFSETS()
        {

        }

        public Message_SENSOR_OFFSETS(float mag_declination, int raw_press, int raw_temp, float gyro_cal_x, float gyro_cal_y, float gyro_cal_z, float accel_cal_x, float accel_cal_y, float accel_cal_z, short mag_ofs_x, short mag_ofs_y, short mag_ofs_z)
        : base(mag_declination, raw_press, raw_temp, gyro_cal_x, gyro_cal_y, gyro_cal_z, accel_cal_x, accel_cal_y, accel_cal_z, mag_ofs_x, mag_ofs_y, mag_ofs_z)
        {
            this.mag_declination = mag_declination;
            this.raw_press = raw_press;
            this.raw_temp = raw_temp;
            this.gyro_cal_x = gyro_cal_x;
            this.gyro_cal_y = gyro_cal_y;
            this.gyro_cal_z = gyro_cal_z;
            this.accel_cal_x = accel_cal_x;
            this.accel_cal_y = accel_cal_y;
            this.accel_cal_z = accel_cal_z;
            this.mag_ofs_x = mag_ofs_x;
            this.mag_ofs_y = mag_ofs_y;
            this.mag_ofs_z = mag_ofs_z;

        }
        /// <summary>Magnetic declination.  [rad] </summary>
        public float mag_declination;
        /// <summary>Raw pressure from barometer.   </summary>
        public int raw_press;
        /// <summary>Raw temperature from barometer.   </summary>
        public int raw_temp;
        /// <summary>Gyro X calibration.   </summary>
        public float gyro_cal_x;
        /// <summary>Gyro Y calibration.   </summary>
        public float gyro_cal_y;
        /// <summary>Gyro Z calibration.   </summary>
        public float gyro_cal_z;
        /// <summary>Accel X calibration.   </summary>
        public float accel_cal_x;
        /// <summary>Accel Y calibration.   </summary>
        public float accel_cal_y;
        /// <summary>Accel Z calibration.   </summary>
        public float accel_cal_z;
        /// <summary>Magnetometer X offset.   </summary>
        public short mag_ofs_x;
        /// <summary>Magnetometer Y offset.   </summary>
        public short mag_ofs_y;
        /// <summary>Magnetometer Z offset.   </summary>
        public short mag_ofs_z;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(151, 8, 219,
        "Set the magnetometer offsets")]
    public class Message_SET_MAG_OFFSETS : Message
    {
        public Message_SET_MAG_OFFSETS()
        {

        }

        public Message_SET_MAG_OFFSETS(short mag_ofs_x, short mag_ofs_y, short mag_ofs_z, byte target_system, byte target_component)
        : base(mag_ofs_x, mag_ofs_y, mag_ofs_z, target_system, target_component)
        {
            this.mag_ofs_x = mag_ofs_x;
            this.mag_ofs_y = mag_ofs_y;
            this.mag_ofs_z = mag_ofs_z;
            this.target_system = target_system;
            this.target_component = target_component;

        }
        /// <summary>Magnetometer X offset.   </summary>
        public short mag_ofs_x;
        /// <summary>Magnetometer Y offset.   </summary>
        public short mag_ofs_y;
        /// <summary>Magnetometer Z offset.   </summary>
        public short mag_ofs_z;
        /// <summary>System ID.   </summary>
        public byte target_system;
        /// <summary>Component ID.   </summary>
        public byte target_component;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(152, 4, 208,
        "State of APM memory.")]
    public class Message_MEMINFO : Message
    {
        public Message_MEMINFO()
        {

        }

        public Message_MEMINFO(ushort brkval, ushort freemem)//, uint freemem32)
        : base(brkval, freemem)//, freemem32)
        {
            this.brkval = brkval;
            this.freemem = freemem;
            //this.freemem32 = freemem32;

        }
        /// <summary>Heap top.   </summary>
        public ushort brkval;
        /// <summary>Free memory.  [bytes] </summary>
        public ushort freemem;
        /// <summary>Free memory (32 bit).  [bytes] </summary>
        //public uint freemem32;
    }

    #region TODO : # 153 ~ # 162
    #endregion

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(163, 28, 127,
        "Status of DCM attitude estimator.")]
    public class Message_AHRS : Message
    {
        public Message_AHRS()
        {

        }

        public Message_AHRS(float omegaIx, float omegaIy, float omegaIz, float accel_weight, float renorm_val, float error_rp, float error_yaw)
        :base (omegaIx, omegaIy, omegaIz, accel_weight, renorm_val, error_rp, error_yaw)
            {
            this.omegaIx = omegaIx;
            this.omegaIy = omegaIy;
            this.omegaIz = omegaIz;
            this.accel_weight = accel_weight;
            this.renorm_val = renorm_val;
            this.error_rp = error_rp;
            this.error_yaw = error_yaw;

        }
        /// <summary>X gyro drift estimate.  [rad/s] </summary>
        public float omegaIx;
        /// <summary>Y gyro drift estimate.  [rad/s] </summary>
        public float omegaIy;
        /// <summary>Z gyro drift estimate.  [rad/s] </summary>
        public float omegaIz;
        /// <summary>Average accel_weight.   </summary>
        public float accel_weight;
        /// <summary>Average renormalisation value.   </summary>
        public float renorm_val;
        /// <summary>Average error_roll_pitch value.   </summary>
        public float error_rp;
        /// <summary>Average error_yaw value.   </summary>
        public float error_yaw;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(164, 44, 154,
        "Status of simulation environment, if used.")]
    public class Message_SIMSTATE : Message
    {
        public Message_SIMSTATE()
        {

        }

        public Message_SIMSTATE(float roll, float pitch, float yaw, float xacc, float yacc, float zacc, float xgyro, float ygyro, float zgyro, int lat, int lng)
        : base(roll, pitch, yaw, xacc, yacc, zacc, xgyro, ygyro, zgyro, lat, lng)
              {
            this.roll = roll;
            this.pitch = pitch;
            this.yaw = yaw;
            this.xacc = xacc;
            this.yacc = yacc;
            this.zacc = zacc;
            this.xgyro = xgyro;
            this.ygyro = ygyro;
            this.zgyro = zgyro;
            this.lat = lat;
            this.lng = lng;

        }
        /// <summary>Roll angle.  [rad] </summary>
        public float roll;
        /// <summary>Pitch angle.  [rad] </summary>
        public float pitch;
        /// <summary>Yaw angle.  [rad] </summary>
        public float yaw;
        /// <summary>X acceleration.  [m/s/s] </summary>
        public float xacc;
        /// <summary>Y acceleration.  [m/s/s] </summary>
        public float yacc;
        /// <summary>Z acceleration.  [m/s/s] </summary>
        public float zacc;
        /// <summary>Angular speed around X axis.  [rad/s] </summary>
        public float xgyro;
        /// <summary>Angular speed around Y axis.  [rad/s] </summary>
        public float ygyro;
        /// <summary>Angular speed around Z axis.  [rad/s] </summary>
        public float zgyro;
        /// <summary>Latitude.  [degE7] </summary>
        public int lat;
        /// <summary>Longitude.  [degE7] </summary>
        public int lng;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(165, 3, 21,
        "Status of key hardware.")]
    public class Message_HWSTATUS : Message
    {
        public Message_HWSTATUS()
        {

        }

        public Message_HWSTATUS(ushort Vcc, byte I2Cerr)
        : base(Vcc, I2Cerr)
        {
            this.Vcc = Vcc;
            this.I2Cerr = I2Cerr;

        }
        /// <summary>Board voltage.  [mV] </summary>
        public ushort Vcc;
        /// <summary>I2C error count.   </summary>
        public byte I2Cerr;
    }

    #region TODO : # 166 ~ # 177
    #endregion

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(178, 24, 47,
        "Status of secondary AHRS filter if available.")]
    public class Message_AHRS2 : Message
    {
        public Message_AHRS2()
        {

        }

        public Message_AHRS2(float roll, float pitch, float yaw, float altitude, int lat, int lng)
            : base(roll, pitch, yaw, altitude, lat, lng)
        {
            this.roll = roll;
            this.pitch = pitch;
            this.yaw = yaw;
            this.altitude = altitude;
            this.lat = lat;
            this.lng = lng;

        }
        /// <summary>Roll angle.  [rad] </summary>
        public float roll;
        /// <summary>Pitch angle.  [rad] </summary>
        public float pitch;
        /// <summary>Yaw angle.  [rad] </summary>
        public float yaw;
        /// <summary>Altitude (MSL).  [m] </summary>
        public float altitude;
        /// <summary>Latitude.  [degE7] </summary>
        public int lat;
        /// <summary>Longitude.  [degE7] </summary>
        public int lng;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(179, 29, 189,
        "Camera Event.")]
    public class Message_CAMERA_STATUS : Message
    {
        public Message_CAMERA_STATUS()
        {

        }

        public Message_CAMERA_STATUS(ulong time_usec, float p1, float p2, float p3, float p4, ushort img_idx, byte target_system, byte cam_idx,/*CAMERA_STATUS_TYPES*/byte event_id)
        : base(time_usec, p1, p2, p3, p4, img_idx, target_system, cam_idx, event_id)
        {
            this.time_usec = time_usec;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
            this.img_idx = img_idx;
            this.target_system = target_system;
            this.cam_idx = cam_idx;
            this.event_id = event_id;

        }
        /// <summary>Image timestamp (since UNIX epoch, according to camera clock).  [us] </summary>
        public ulong time_usec;
        /// <summary>Parameter 1 (meaning depends on event_id, see CAMERA_STATUS_TYPES enum).   </summary>
        public float p1;
        /// <summary>Parameter 2 (meaning depends on event_id, see CAMERA_STATUS_TYPES enum).   </summary>
        public float p2;
        /// <summary>Parameter 3 (meaning depends on event_id, see CAMERA_STATUS_TYPES enum).   </summary>
        public float p3;
        /// <summary>Parameter 4 (meaning depends on event_id, see CAMERA_STATUS_TYPES enum).   </summary>
        public float p4;
        /// <summary>Image index.   </summary>
        public ushort img_idx;
        /// <summary>System ID.   </summary>
        public byte target_system;
        /// <summary>Camera ID.   </summary>
        public byte cam_idx;
        /// <summary>Event type. CAMERA_STATUS_TYPES  </summary>
        public  /*CAMERA_STATUS_TYPES*/byte event_id;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(180, 45, 52,
        "Camera Capture Feedback.")]
    public class Message_CAMERA_FEEDBACK : Message
    {
        public Message_CAMERA_FEEDBACK()
        {

        }

        public Message_CAMERA_FEEDBACK(ulong time_usec, int lat, int lng, float alt_msl, float alt_rel, 
            float roll, float pitch, float yaw, 
            float foc_len, ushort img_idx, byte target_system, byte cam_idx,/*CAMERA_FEEDBACK_FLAGS*/byte flags)//, ushort completed_captures)
        : base(time_usec, lat, lng, alt_msl, alt_rel, foc_len, img_idx, target_system, cam_idx, flags)
        {
            this.time_usec = time_usec;
            this.lat = lat;
            this.lng = lng;
            this.alt_msl = alt_msl;
            this.alt_rel = alt_rel;
            this.roll = roll;
            this.pitch = pitch;
            this.yaw = yaw;
            this.foc_len = foc_len;
            this.img_idx = img_idx;
            this.target_system = target_system;
            this.cam_idx = cam_idx;
            this.flags = flags;
            //this.completed_captures = completed_captures;

        }
        /// <summary>Image timestamp (since UNIX epoch), as passed in by CAMERA_STATUS message (or autopilot if no CCB).  [us] </summary>
        public ulong time_usec;
        /// <summary>Latitude.  [degE7] </summary>
        public int lat;
        /// <summary>Longitude.  [degE7] </summary>
        public int lng;
        /// <summary>Altitude (MSL).  [m] </summary>
        public float alt_msl;
        /// <summary>Altitude (Relative to HOME location).  [m] </summary>
        public float alt_rel;
        /// <summary>Camera Roll angle (earth frame, +-180).  [deg] </summary>
        public float roll;
        /// <summary>Camera Pitch angle (earth frame, +-180).  [deg] </summary>
        public float pitch;
        /// <summary>Camera Yaw (earth frame, 0-360, true).  [deg] </summary>
        public float yaw;
        /// <summary>Focal Length.  [mm] </summary>
        public float foc_len;
        /// <summary>Image index.   </summary>
        public ushort img_idx;
        /// <summary>System ID.   </summary>
        public byte target_system;
        /// <summary>Camera ID.   </summary>
        public byte cam_idx;
        /// <summary>Feedback flags. CAMERA_FEEDBACK_FLAGS  </summary>
        public  /*CAMERA_FEEDBACK_FLAGS*/byte flags;
        /// <summary>Completed image captures.   </summary>
        //public ushort completed_captures;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(181, 4, 174,
        "2nd Battery status")]
    public class Message_BATTERY2 : Message
    {
        public Message_BATTERY2()
        {

        }

        public Message_BATTERY2(ushort voltage, short current_battery)
        : base(voltage, current_battery)
        {
            this.voltage = voltage;
            this.current_battery = current_battery;

        }
        /// <summary>Voltage.  [mV] </summary>
        public ushort voltage;
        /// <summary>Battery current, -1: autopilot does not measure the current.  [cA] </summary>
        public short current_battery;
    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(182, 40, 229,
        "Status of third AHRS filter if available." +
        "This is for ANU research group (Ali and Sean).")]
    public class Message_AHRS3 : Message
    {
        public Message_AHRS3()
        {

        }

        public Message_AHRS3(float roll, float pitch, float yaw, float altitude, int lat, int lng, float v1, float v2, float v3, float v4)
        : base(roll, pitch, yaw, altitude, lat, lng, v1, v2, v3, v4)
        {
            this.roll = roll;
            this.pitch = pitch;
            this.yaw = yaw;
            this.altitude = altitude;
            this.lat = lat;
            this.lng = lng;
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;

        }
        /// <summary>Roll angle.  [rad] </summary>
        public float roll;
        /// <summary>Pitch angle.  [rad] </summary>
        public float pitch;
        /// <summary>Yaw angle.  [rad] </summary>
        public float yaw;
        /// <summary>Altitude (MSL).  [m] </summary>
        public float altitude;
        /// <summary>Latitude.  [degE7] </summary>
        public int lat;
        /// <summary>Longitude.  [degE7] </summary>
        public int lng;
        /// <summary>Test variable1.   </summary>
        public float v1;
        /// <summary>Test variable2.   </summary>
        public float v2;
        /// <summary>Test variable3.   </summary>
        public float v3;
        /// <summary>Test variable4.   </summary>
        public float v4;
    }

    /// <summary>
    /// AUTOPILOT_VERSION_REQUEST # 183 -> ardupilotmega.xml
    /// </summary>
    [MessageInfo(183, 2, 85,
        "Request the autopilot version from the system/component.")]
    public class Message_AUTOPILOT_VERSION_REQUEST : Message
    {
        /// <summary>System ID.   </summary>
        public byte target_system;
        /// <summary>Component ID.   </summary>
        public byte target_component;

        public Message_AUTOPILOT_VERSION_REQUEST(byte target_system, byte target_component) :
            base(target_system, target_component)
        {
            this.target_system = target_system;
            this.target_component = target_component;
        }

        public Message_AUTOPILOT_VERSION_REQUEST()
        {

        }
    }

    #region TODO : # 184 ~ # 190
    #endregion

    /// <summary>
    /// MAG_CAL_PROGRESS # 191 -> ardupilotmega.
    /// </summary>
    [MessageInfo(191, 27, 92,
        "Reports progress of compass calibration.")]
    public class Message_MAG_CAL_PROGRESS : Message
    {
        /// <summary>Body frame direction vector for display.   </summary>
        public float direction_x;
        /// <summary>Body frame direction vector for display.   </summary>
        public float direction_y;
        /// <summary>Body frame direction vector for display.   </summary>
        public float direction_z;
        /// <summary>Compass being calibrated.   </summary>
        public byte compass_id;
        /// <summary>Bitmask of compasses being calibrated.   bitmask</summary>
        public byte cal_mask;
        /// <summary>Calibration Status. MAG_CAL_STATUS  </summary>
        public  /*MAG_CAL_STATUS*/byte cal_status;
        /// <summary>Attempt number.   </summary>
        public byte attempt;
        /// <summary>Completion percentage.  [%] </summary>
        public byte completion_pct;
        /// <summary>Bitmask of sphere sections (see http://en.wikipedia.org/wiki/Geodesic_grid).   </summary>
        public byte[] completion_mask = new byte[10];

        public Message_MAG_CAL_PROGRESS(float direction_x, float direction_y, float direction_z,
                                           byte compass_id, byte cal_mask, byte cal_status, byte attempt, byte completion_pct,
                                           byte[] completion_mask) :
            base(direction_x, direction_y, direction_z, compass_id, cal_mask, cal_status, attempt, completion_pct, completion_mask)
        {
            this.direction_x = direction_x;
            this.direction_y = direction_y;
            this.direction_z = direction_z;
            this.compass_id = compass_id;
            this.cal_mask = cal_mask;
            this.cal_status = cal_status;
            this.attempt = attempt;
            this.completion_pct = completion_pct;
            this.completion_mask = completion_mask;
        }

        public Message_MAG_CAL_PROGRESS()
        {

        }

    }

    /// <summary>
    /// MAG_CAL_REPORT #192 -> ardupilotmega.
    /// </summary>
    [MessageInfo(192, 54, 36,
        "Reports results of completed compass calibration." +
        "Sent until MAG_CAL_ACK received.")]
    public class Message_MAG_CAL_REPORT : Message
    {
        /// <summary>RMS milligauss residuals.  [mgauss] </summary>
        public float fitness;
        /// <summary>X offset.   </summary>
        public float ofs_x;
        /// <summary>Y offset.   </summary>
        public float ofs_y;
        /// <summary>Z offset.   </summary>
        public float ofs_z;
        /// <summary>X diagonal (matrix 11).   </summary>
        public float diag_x;
        /// <summary>Y diagonal (matrix 22).   </summary>
        public float diag_y;
        /// <summary>Z diagonal (matrix 33).   </summary>
        public float diag_z;
        /// <summary>X off-diagonal (matrix 12 and 21).   </summary>
        public float offdiag_x;
        /// <summary>Y off-diagonal (matrix 13 and 31).   </summary>
        public float offdiag_y;
        /// <summary>Z off-diagonal (matrix 32 and 23).   </summary>
        public float offdiag_z;
        /// <summary>Compass being calibrated.   </summary>
        public byte compass_id;
        /// <summary>Bitmask of compasses being calibrated.   bitmask</summary>
        public byte cal_mask;
        /// <summary>Calibration Status. MAG_CAL_STATUS  </summary>
        public  /*MAG_CAL_STATUS*/byte cal_status;
        /// <summary>0=requires a MAV_CMD_DO_ACCEPT_MAG_CAL, 1=saved to parameters.   </summary>
        public byte autosaved;
        /// <summary>Confidence in orientation (higher is better).   </summary>
        public float orientation_confidence;
        /// <summary>orientation before calibration. MAV_SENSOR_ORIENTATION  </summary>
        public  /*MAV_SENSOR_ORIENTATION*/byte old_orientation;
        /// <summary>orientation after calibration. MAV_SENSOR_ORIENTATION  </summary>
        public  /*MAV_SENSOR_ORIENTATION*/byte new_orientation;
        /// <summary>field radius correction factor   </summary>
        public float scale_factor;

        public Message_MAG_CAL_REPORT(float fitness, float ofs_x, float ofs_y, float ofs_z,
                                         float diag_x, float diag_y, float diag_z,
                                         float offdiag_x, float offdiag_y, float offdiag_z,
                                         byte compass_id, byte cal_mask, byte cal_status, byte autosaved,
                                         float orientation_confidence, byte old_orientation, byte new_orientation, float scale_factor) :
            base(fitness, ofs_x, ofs_y, ofs_z, diag_x, diag_y, diag_z, offdiag_x, offdiag_y, offdiag_z,
                 compass_id, cal_mask, cal_status, autosaved, orientation_confidence, old_orientation, new_orientation, scale_factor)
        {
            this.fitness = fitness;
            this.ofs_x = ofs_x;
            this.ofs_y = ofs_y;
            this.ofs_z = ofs_z;
            this.diag_x = diag_x;
            this.diag_y = diag_y;
            this.diag_z = diag_z;
            this.offdiag_x = offdiag_x;
            this.offdiag_y = offdiag_y;
            this.offdiag_z = offdiag_z;
            this.compass_id = compass_id;
            this.cal_mask = cal_mask;
            this.cal_status = cal_status;
            this.autosaved = autosaved;
            this.orientation_confidence = orientation_confidence;
            this.old_orientation = old_orientation;
            this.new_orientation = new_orientation;
            this.scale_factor = scale_factor;
        }

        public Message_MAG_CAL_REPORT()
        {

        }

    }

    /// <summary>
    /// Ardupilot
    /// </summary>
    [MessageInfo(193, 22, 71,
        "EKF Status message including flags and variances.")]
    public class Message_EKF_STATUS_REPORT : Message
    {
        public Message_EKF_STATUS_REPORT()
        {

        }

        public Message_EKF_STATUS_REPORT(float velocity_variance, float pos_horiz_variance, float pos_vert_variance, 
            float compass_variance, float terrain_alt_variance,/*EKF_STATUS_FLAGS*/ushort flags)//, float airspeed_variance)
        : base(velocity_variance, pos_horiz_variance, pos_vert_variance, compass_variance, terrain_alt_variance, flags)//, airspeed_variance)
        {
            this.velocity_variance = velocity_variance;
            this.pos_horiz_variance = pos_horiz_variance;
            this.pos_vert_variance = pos_vert_variance;
            this.compass_variance = compass_variance;
            this.terrain_alt_variance = terrain_alt_variance;
            this.flags = flags;
            //this.airspeed_variance = airspeed_variance;

        }

        /// <summary>Velocity variance.   </summary>
        public float velocity_variance;
        /// <summary>Horizontal Position variance.   </summary>
        public float pos_horiz_variance;
        /// <summary>Vertical Position variance.   </summary>
        public float pos_vert_variance;
        /// <summary>Compass variance.   </summary>
        public float compass_variance;
        /// <summary>Terrain Altitude variance.   </summary>
        public float terrain_alt_variance;
        /// <summary>Flags. EKF_STATUS_FLAGS  bitmask</summary>
        public  /*EKF_STATUS_FLAGS*/ushort flags;
        /// <summary>Airspeed variance.   </summary>
        //public float airspeed_variance;
    }

    #region TODO : # 194 ~ # 240
    #endregion

    [MessageInfo(241, 32, 90,
        "Vibration levels and accelerometer clipping")]
    public class Message_VIBRRATION : Message
    {
        public Message_VIBRRATION()
        {

        }

        public Message_VIBRRATION(ulong time_usec, float vibration_x, float vibration_y, float vibration_z, uint clipping_0, uint clipping_1, uint clipping_2)
        : base(time_usec, vibration_x, vibration_y, vibration_z, clipping_0, clipping_1, clipping_2)
        {
            this.time_usec = time_usec;
            this.vibration_x = vibration_x;
            this.vibration_y = vibration_y;
            this.vibration_z = vibration_z;
            this.clipping_0 = clipping_0;
            this.clipping_1 = clipping_1;
            this.clipping_2 = clipping_2;

        }
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        public ulong time_usec;
        /// <summary>Vibration levels on X-axis   </summary>
        public float vibration_x;
        /// <summary>Vibration levels on Y-axis   </summary>
        public float vibration_y;
        /// <summary>Vibration levels on Z-axis   </summary>
        public float vibration_z;
        /// <summary>first accelerometer clipping count   </summary>
        public uint clipping_0;
        /// <summary>second accelerometer clipping count   </summary>
        public uint clipping_1;
        /// <summary>third accelerometer clipping count   </summary>
        public uint clipping_2;
    }

    [MessageInfo(242, 52, 104,
        "This message can be requested by sending the MAV_CMD_GET_HOME_POSITION command." +
        "The position the system will return to and land on." +
        "The position is set automatically by the system during the takeoff in case it was not explicitly set by the operator before or after." +
        "The global and local positions encode the position in the respective coordinate frames, while the q parameter encodes the orientation of the surface." +
        "Under normal conditions it describes the heading and terrain slope, which can be used by the aircraft to adjust the approach." +
        "The approach 3D vector describes the point to which the system should fly in normal flight mode and then perform a landing sequence along the vector.")]
    public class Message_HOME_POSITION : Message
    {
        public Message_HOME_POSITION()
        {

        }

        public Message_HOME_POSITION(int latitude, int longitude, int altitude, 
            float x, float y, float z, float[] q, 
            float approach_x, float approach_y, float approach_z)//, ulong time_usec)
            : base(latitude, longitude, altitude, x, y, z, q, approach_x, approach_y, approach_z)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
            this.x = x;
            this.y = y;
            this.z = z;
            this.q = q;
            this.approach_x = approach_x;
            this.approach_y = approach_y;
            this.approach_z = approach_z;
            //this.time_usec = time_usec;

        }
        /// <summary>Latitude (WGS84)  [degE7] </summary>
        public int latitude;
        /// <summary>Longitude (WGS84)  [degE7] </summary>
        public int longitude;
        /// <summary>Altitude (MSL). Positive for up.  [mm] </summary>
        public int altitude;
        /// <summary>Local X position of this position in the local coordinate frame  [m] </summary>
        public float x;
        /// <summary>Local Y position of this position in the local coordinate frame  [m] </summary>
        public float y;
        /// <summary>Local Z position of this position in the local coordinate frame  [m] </summary>
        public float z;
        /// <summary>World to surface normal and heading transformation of the takeoff position. Used to indicate the heading and slope of the ground   </summary>
        public float[] q = new float[4];
        /// <summary>Local X position of the end of the approach vector. Multicopters should set this position based on their takeoff path. Grass-landing fixed wing aircraft should set it the same way as multicopters. Runway-landing fixed wing aircraft should set it to the opposite direction of the takeoff, assuming the takeoff happened from the threshold / touchdown zone.  [m] </summary>
        public float approach_x;
        /// <summary>Local Y position of the end of the approach vector. Multicopters should set this position based on their takeoff path. Grass-landing fixed wing aircraft should set it the same way as multicopters. Runway-landing fixed wing aircraft should set it to the opposite direction of the takeoff, assuming the takeoff happened from the threshold / touchdown zone.  [m] </summary>
        public float approach_y;
        /// <summary>Local Z position of the end of the approach vector. Multicopters should set this position based on their takeoff path. Grass-landing fixed wing aircraft should set it the same way as multicopters. Runway-landing fixed wing aircraft should set it to the opposite direction of the takeoff, assuming the takeoff happened from the threshold / touchdown zone.  [m] </summary>
        public float approach_z;
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        //public ulong time_usec;
    }

    [MessageInfo(243, 53, 85,
        "The position the system will return to and land on." +
        "The position is set automatically by the system during the takeoff in case it was not explicitly set by the operator before or after." +
        "The global and local positions encode the position in the respective coordinate frames, while the q parameter encodes the orientation of the surface." +
        "Under normal conditions it describes the heading and terrain slope, which can be used by the aircraft to adjust the approach." +
        "The approach 3D vector describes the point to which the system should fly in normal flight mode and then perform a landing sequence along the vector.")]
    public class Message_SET_HOME_POSITION : Message
    {
        public Message_SET_HOME_POSITION()
        {

        }

        public Message_SET_HOME_POSITION(int latitude, int longitude, int altitude, 
            float x, float y, float z, float[] q, 
            float approach_x, float approach_y, float approach_z, byte target_system)//, ulong time_usec)
            :base(latitude, longitude, altitude, x, y, z, q, approach_x, approach_y, approach_z, target_system)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
            this.x = x;
            this.y = y;
            this.z = z;
            this.q = q;
            this.approach_x = approach_x;
            this.approach_y = approach_y;
            this.approach_z = approach_z;
            this.target_system = target_system;
            //this.time_usec = time_usec;

        }
        /// <summary>Latitude (WGS84)  [degE7] </summary>
        public int latitude;
        /// <summary>Longitude (WGS84)  [degE7] </summary>
        public int longitude;
        /// <summary>Altitude (MSL). Positive for up.  [mm] </summary>
        public int altitude;
        /// <summary>Local X position of this position in the local coordinate frame  [m] </summary>
        public float x;
        /// <summary>Local Y position of this position in the local coordinate frame  [m] </summary>
        public float y;
        /// <summary>Local Z position of this position in the local coordinate frame  [m] </summary>
        public float z;
        /// <summary>World to surface normal and heading transformation of the takeoff position. Used to indicate the heading and slope of the ground   </summary>
        public float[] q = new float[4];
        /// <summary>Local X position of the end of the approach vector. Multicopters should set this position based on their takeoff path. Grass-landing fixed wing aircraft should set it the same way as multicopters. Runway-landing fixed wing aircraft should set it to the opposite direction of the takeoff, assuming the takeoff happened from the threshold / touchdown zone.  [m] </summary>
        public float approach_x;
        /// <summary>Local Y position of the end of the approach vector. Multicopters should set this position based on their takeoff path. Grass-landing fixed wing aircraft should set it the same way as multicopters. Runway-landing fixed wing aircraft should set it to the opposite direction of the takeoff, assuming the takeoff happened from the threshold / touchdown zone.  [m] </summary>
        public float approach_y;
        /// <summary>Local Z position of the end of the approach vector. Multicopters should set this position based on their takeoff path. Grass-landing fixed wing aircraft should set it the same way as multicopters. Runway-landing fixed wing aircraft should set it to the opposite direction of the takeoff, assuming the takeoff happened from the threshold / touchdown zone.  [m] </summary>
        public float approach_z;
        /// <summary>System ID.   </summary>
        public byte target_system;
        /// <summary>Timestamp (UNIX Epoch time or time since system boot). The receiving end can infer timestamp format (since 1.1.1970 or since system boot) by checking for the magnitude the number.  [us] </summary>
        //public ulong time_usec;
    }

    [MessageInfo(244, 6, 95,
        "The interval between messages for a particular MAVLink message ID." +
        "This message is the response to the MAV_CMD_GET_MESSAGE_INTERVAL command." +
        "This interface replaces DATA_STREAM.")]
    public class Message_MESSAGE_INTERVAL : Message
    {
        /// <summary>The interval between two messages. A value of -1 indicates this stream is disabled, 0 indicates it is not available, > 0 indicates the interval at which it is sent.  [us] </summary>
        public int interval_us;
        /// <summary>The ID of the requested MAVLink message. v1.0 is limited to 254 messages.   </summary>
        public ushort message_id;

        public Message_MESSAGE_INTERVAL(int interval_us, ushort message_id)
            : base(interval_us, message_id)
        {
            this.interval_us = interval_us;
            this.message_id = message_id;
        }

        public Message_MESSAGE_INTERVAL()
        {

        }
    }

    #region TODO : # 245 ~ # 252
    #endregion

    [MessageInfo(253, 54, 83,
        "Status text message." +
        "These messages are printed in yellow in the COMM console of QGroundControl." +
        "WARNING: They consume quite some bandwidth, so use only for important status and error messages." +
        "If implemented wisely, these messages are buffered on the MCU and sent only at a limited rate (e.g. 10 Hz).")]
    public class Message_STATUSTEXT : Message
    {
        /// <summary>Severity of status. Relies on the definitions within RFC-5424. MAV_SEVERITY  </summary>
        public  /*MAV_SEVERITY*/byte severity;
        /// <summary>Status text message, without null termination character   </summary>
        public byte[] text = new byte[50];
        /// <summary>Unique (opaque) identifier for this statustext message.  May be used to reassemble a logical long-statustext message from a sequence of chunks.  A value of zero indicates this is the only chunk in the sequence and the message can be emitted immediately.   </summary>
        public ushort id;
        /// <summary>This chunk's sequence number; indexing is from zero.  Any null character in the text field is taken to mean this was the last chunk.   </summary>
        public byte chunk_seq;

        public string Text
        {
            get
            {
                try
                {
                    return Encoding.ASCII.GetString(text).TrimEnd('\0');
                }
                catch (Exception)
                {
                    return BitConverter.ToString(text);
                }
            }
        }

        public Message_STATUSTEXT(byte severity, byte[] text, ushort id = 0, byte chunk_seq = 0)
            : base(severity, text, id, chunk_seq)
        {
            this.severity = severity;
            this.text = text;
            this.id = id;
            this.chunk_seq = chunk_seq;
        }

        public Message_STATUSTEXT()
        {

        }
    }

}
