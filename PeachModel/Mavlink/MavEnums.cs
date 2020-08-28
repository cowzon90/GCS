using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Mavlink
{
    public static class MavEnums
    {
        /// <summary> Micro air vehicle / autopilot classes. This identifies the individual model. </summary>
        public enum MAV_AUTOPILOT : byte
        {
            /// <summary> Generic autopilot, full support for everything </summary>
            MAV_AUTOPILOT_GENERIC = 0,
            /// <summary> Reserved for future use. </summary>
            MAV_AUTOPILOT_RESERVED = 1,
            /// <summary> SLUGS autopilot, http://slugsuav.soe.ucsc.edu </summary>
            MAV_AUTOPILOT_SLUGS = 2,
            /// <summary> ArduPilot - Plane/Copter/Rover/Sub/Tracker, https://ardupilot.org </summary>
            MAV_AUTOPILOT_ARDUPILOTMEGA = 3,
            /// <summary> OpenPilot, http://openpilot.org </summary>
            MAV_AUTOPILOT_OPENPILOT = 4,
            /// <summary> Generic autopilot only supporting simple waypoints </summary>
            MAV_AUTOPILOT_GENERIC_WAYPOINTS_ONLY = 5,
            /// <summary> Generic autopilot supporting waypoints and other simple navigation commands </summary>
            MAV_AUTOPILOT_GENERIC_WAYPOINTS_AND_SIMPLE_NAVIGATION_ONLY = 6,
            /// <summary> Generic autopilot supporting the full mission command set </summary>
            MAV_AUTOPILOT_GENERIC_MISSION_FULL = 7,
            /// <summary> No valid autopilot, e.g. a GCS or other MAVLink component </summary>
            MAV_AUTOPILOT_INVALID = 8,
            /// <summary> PPZ UAV - http://nongnu.org/paparazzi </summary>
            MAV_AUTOPILOT_PPZ = 9,
            /// <summary> UAV Dev Board </summary>
            MAV_AUTOPILOT_UDB = 10,
            /// <summary> FlexiPilot </summary>
            MAV_AUTOPILOT_FP = 11,
            /// <summary> PX4 Autopilot - http://px4.io/ </summary>
            MAV_AUTOPILOT_PX4 = 12,
            /// <summary> SMACCMPilot - http://smaccmpilot.org </summary>
            MAV_AUTOPILOT_SMACCMPILOT = 13,
            /// <summary> AutoQuad -- http://autoquad.org </summary>
            MAV_AUTOPILOT_AUTOQUAD = 14,
            /// <summary> Armazila -- http://armazila.com </summary>
            MAV_AUTOPILOT_ARMAZILA = 15,
            /// <summary> Aerob -- http://aerob.ru </summary>
            MAV_AUTOPILOT_AEROB = 16,
            /// <summary> ASLUAV autopilot -- http://www.asl.ethz.ch </summary>
            MAV_AUTOPILOT_ASLUAV = 17,
            /// <summary> SmartAP Autopilot - http://sky-drones.com </summary>
            MAV_AUTOPILOT_SMARTAP = 18,
            /// <summary> AirRails - http://uaventure.com </summary>
            MAV_AUTOPILOT_AIRRAILS = 19,
        }
        /// <summary> MAVLINK component type reported in HEARTBEAT message. Flight controllers must report the type of the vehicle on which they are mounted (e.g. MAV_TYPE_OCTOROTOR). All other components must report a value appropriate for their type (e.g. a camera must use MAV_TYPE_CAMERA). </summary>
        public enum MAV_TYPE
        {
            /// <summary> Generic micro air vehicle </summary>
            MAV_TYPE_GENERIC = 0,
            /// <summary> Fixed wing aircraft. </summary>
            MAV_TYPE_FIXED_WING = 1,
            /// <summary> Quadrotor </summary>
            MAV_TYPE_QUADROTOR = 2,
            /// <summary> Coaxial helicopter </summary>
            MAV_TYPE_COAXIAL = 3,
            /// <summary> Normal helicopter with tail rotor. </summary>
            MAV_TYPE_HELICOPTER = 4,
            /// <summary> Ground installation </summary>
            MAV_TYPE_ANTENNA_TRACKER = 5,
            /// <summary> Operator control unit / ground control station </summary>
            MAV_TYPE_GCS = 6,
            /// <summary> Airship, controlled </summary>
            MAV_TYPE_AIRSHIP = 7,
            /// <summary> Free balloon, uncontrolled </summary>
            MAV_TYPE_FREE_BALLOON = 8,
            /// <summary> Rocket </summary>
            MAV_TYPE_ROCKET = 9,
            /// <summary> Ground rover </summary>
            MAV_TYPE_GROUND_ROVER = 10,
            /// <summary> Surface vessel, boat, ship </summary>
            MAV_TYPE_SURFACE_BOAT = 11,
            /// <summary> Submarine </summary>
            MAV_TYPE_SUBMARINE = 12,
            /// <summary> Hexarotor </summary>
            MAV_TYPE_HEXAROTOR = 13,
            /// <summary> Octorotor </summary>
            MAV_TYPE_OCTOROTOR = 14,
            /// <summary> Tricopter </summary>
            MAV_TYPE_TRICOPTER = 15,
            /// <summary> Flapping wing </summary>
            MAV_TYPE_FLAPPING_WING = 16,
            /// <summary> Kite </summary>
            MAV_TYPE_KITE = 17,
            /// <summary> Onboard companion controller </summary>
            MAV_TYPE_ONBOARD_CONTROLLER = 18,
            /// <summary> Two-rotor VTOL using control surfaces in vertical operation in addition. Tailsitter. </summary>
            MAV_TYPE_VTOL_DUOROTOR = 19,
            /// <summary> Quad-rotor VTOL using a V-shaped quad config in vertical operation. Tailsitter. </summary>
            MAV_TYPE_VTOL_QUADROTOR = 20,
            /// <summary> Tiltrotor VTOL </summary>
            MAV_TYPE_VTOL_TILTROTOR = 21,
            /// <summary> VTOL reserved 2 </summary>
            MAV_TYPE_VTOL_RESERVED2 = 22,
            /// <summary> VTOL reserved 3 </summary>
            MAV_TYPE_VTOL_RESERVED3 = 23,
            /// <summary> VTOL reserved 4 </summary>
            MAV_TYPE_VTOL_RESERVED4 = 24,
            /// <summary> VTOL reserved 5 </summary>
            MAV_TYPE_VTOL_RESERVED5 = 25,
            /// <summary> Gimbal </summary>
            MAV_TYPE_GIMBAL = 26,
            /// <summary> ADSB system </summary>
            MAV_TYPE_ADSB = 27,
            /// <summary> Steerable, nonrigid airfoil </summary>
            MAV_TYPE_PARAFOIL = 28,
            /// <summary> Dodecarotor </summary>
            MAV_TYPE_DODECAROTOR = 29,
            /// <summary> Camera </summary>
            MAV_TYPE_CAMERA = 30,
            /// <summary> Charging station </summary>
            MAV_TYPE_CHARGING_STATION = 31,
            /// <summary> FLARM collision avoidance system </summary>
            MAV_TYPE_FLARM = 32,
            /// <summary> Servo </summary>
            MAV_TYPE_SERVO = 33,
            /// <summary> Open Drone ID. See https://mavlink.io/en/services/opendroneid.html. </summary>
            MAV_TYPE_ODID = 34,
        }
        /// <summary> These values define the type of firmware release.  These values indicate the first version or release of this type.  For example the first alpha release would be 64, the second would be 65. </summary>
        public enum FIRMWARE_VERSION_TYPE
        {
            /// <summary> development release </summary>
            FIRMWARE_VERSION_TYPE_DEV = 0,
            /// <summary> alpha release </summary>
            FIRMWARE_VERSION_TYPE_ALPHA = 64,
            /// <summary> beta release </summary>
            FIRMWARE_VERSION_TYPE_BETA = 128,
            /// <summary> release candidate </summary>
            FIRMWARE_VERSION_TYPE_RC = 192,
            /// <summary> official stable release </summary>
            FIRMWARE_VERSION_TYPE_OFFICIAL = 255,
        }
        /// <summary> Flags to report failure cases over the high latency telemtry. </summary>
        public enum HL_FAILURE_FLAG
        {
            /// <summary> GPS failure. </summary>
            HL_FAILURE_FLAG_GPS = 1,
            /// <summary> Differential pressure sensor failure. </summary>
            HL_FAILURE_FLAG_DIFFERENTIAL_PRESSURE = 2,
            /// <summary> Absolute pressure sensor failure. </summary>
            HL_FAILURE_FLAG_ABSOLUTE_PRESSURE = 4,
            /// <summary> Accelerometer sensor failure. </summary>
            HL_FAILURE_FLAG_3D_ACCEL = 8,
            /// <summary> Gyroscope sensor failure. </summary>
            HL_FAILURE_FLAG_3D_GYRO = 16,
            /// <summary> Magnetometer sensor failure. </summary>
            HL_FAILURE_FLAG_3D_MAG = 32,
            /// <summary> Terrain subsystem failure. </summary>
            HL_FAILURE_FLAG_TERRAIN = 64,
            /// <summary> Battery failure/critical low battery. </summary>
            HL_FAILURE_FLAG_BATTERY = 128,
            /// <summary> RC receiver failure/no rc connection. </summary>
            HL_FAILURE_FLAG_RC_RECEIVER = 256,
            /// <summary> Offboard link failure. </summary>
            HL_FAILURE_FLAG_OFFBOARD_LINK = 512,
            /// <summary> Engine failure. </summary>
            HL_FAILURE_FLAG_ENGINE = 1024,
            /// <summary> Geofence violation. </summary>
            HL_FAILURE_FLAG_GEOFENCE = 2048,
            /// <summary> Estimator failure, for example measurement rejection or large variances. </summary>
            HL_FAILURE_FLAG_ESTIMATOR = 4096,
            /// <summary> Mission failure. </summary>
            HL_FAILURE_FLAG_MISSION = 8192,
        }
        /// <summary> These flags encode the MAV mode. </summary>
        public enum MAV_MODE_FLAG
        {
            /// <summary> 0b10000000 MAV safety set to armed. Motors are enabled / running / can start. Ready to fly. Additional note: this flag is to be ignore when sent in the command MAV_CMD_DO_SET_MODE and MAV_CMD_COMPONENT_ARM_DISARM shall be used instead. The flag can still be used to report the armed state. </summary>
            MAV_MODE_FLAG_SAFETY_ARMED = 128,
            /// <summary> 0b01000000 remote control input is enabled. </summary>
            MAV_MODE_FLAG_MANUAL_INPUT_ENABLED = 64,
            /// <summary> 0b00100000 hardware in the loop simulation. All motors / actuators are blocked, but internal software is full operational. </summary>
            MAV_MODE_FLAG_HIL_ENABLED = 32,
            /// <summary> 0b00010000 system stabilizes electronically its attitude (and optionally position). It needs however further control inputs to move around. </summary>
            MAV_MODE_FLAG_STABILIZE_ENABLED = 16,
            /// <summary> 0b00001000 guided mode enabled, system flies waypoints / mission items. </summary>
            MAV_MODE_FLAG_GUIDED_ENABLED = 8,
            /// <summary> 0b00000100 autonomous mode enabled, system finds its own goal positions. Guided flag can be set or not, depends on the actual implementation. </summary>
            MAV_MODE_FLAG_AUTO_ENABLED = 4,
            /// <summary> 0b00000010 system has a test mode enabled. This flag is intended for temporary system tests and should not be used for stable implementations. </summary>
            MAV_MODE_FLAG_TEST_ENABLED = 2,
            /// <summary> 0b00000001 Reserved for future use. </summary>
            MAV_MODE_FLAG_CUSTOM_MODE_ENABLED = 1,
        }
        /// <summary> These values encode the bit positions of the decode position. These values can be used to read the value of a flag bit by combining the base_mode variable with AND with the flag position value. The result will be either 0 or 1, depending on if the flag is set or not. </summary>
        public enum MAV_MODE_FLAG_DECODE_POSITION
        {
            /// <summary> First bit:  10000000 </summary>
            MAV_MODE_FLAG_DECODE_POSITION_SAFETY = 128,
            /// <summary> Second bit: 01000000 </summary>
            MAV_MODE_FLAG_DECODE_POSITION_MANUAL = 64,
            /// <summary> Third bit:  00100000 </summary>
            MAV_MODE_FLAG_DECODE_POSITION_HIL = 32,
            /// <summary> Fourth bit: 00010000 </summary>
            MAV_MODE_FLAG_DECODE_POSITION_STABILIZE = 16,
            /// <summary> Fifth bit:  00001000 </summary>
            MAV_MODE_FLAG_DECODE_POSITION_GUIDED = 8,
            /// <summary> Sixth bit:   00000100 </summary>
            MAV_MODE_FLAG_DECODE_POSITION_AUTO = 4,
            /// <summary> Seventh bit: 00000010 </summary>
            MAV_MODE_FLAG_DECODE_POSITION_TEST = 2,
            /// <summary> Eighth bit: 00000001 </summary>
            MAV_MODE_FLAG_DECODE_POSITION_CUSTOM_MODE = 1,
        }
        /// <summary> Actions that may be specified in MAV_CMD_OVERRIDE_GOTO to override mission execution. </summary>
        public enum MAV_GOTO
        {
            /// <summary> Hold at the current position. </summary>
            MAV_GOTO_DO_HOLD = 0,
            /// <summary> Continue with the next item in mission execution. </summary>
            MAV_GOTO_DO_CONTINUE = 1,
            /// <summary> Hold at the current position of the system </summary>
            MAV_GOTO_HOLD_AT_CURRENT_POSITION = 2,
            /// <summary> Hold at the position specified in the parameters of the DO_HOLD action </summary>
            MAV_GOTO_HOLD_AT_SPECIFIED_POSITION = 3,
        }
        /// <summary> These defines are predefined OR-combined mode flags. There is no need to use values from this enum, but it simplifies the use of the mode flags.Note that manual input is enabled in all modes as a safety override. </summary>
        public enum MAV_MODE
        {
            /// <summary> System is not ready to fly, booting, calibrating, etc. No flag is set. </summary>
            MAV_MODE_PREFLIGHT = 0,
            /// <summary> System is allowed to be active, under assisted RC control. </summary>
            MAV_MODE_STABILIZE_DISARMED = 80,
            /// <summary> System is allowed to be active, under assisted RC control. </summary>
            MAV_MODE_STABILIZE_ARMED = 208,
            /// <summary> System is allowed to be active, under manual (RC) control, no stabilization </summary>
            MAV_MODE_MANUAL_DISARMED = 64,
            /// <summary> System is allowed to be active, under manual (RC) control, no stabilization </summary>
            MAV_MODE_MANUAL_ARMED = 192,
            /// <summary> System is allowed to be active, under autonomous control, manual setpoint </summary>
            MAV_MODE_GUIDED_DISARMED = 88,
            /// <summary> System is allowed to be active, under autonomous control, manual setpoint </summary>
            MAV_MODE_GUIDED_ARMED = 216,
            /// <summary> System is allowed to be active, under autonomous control and navigation (the trajectory is decided onboard and not pre-programmed by waypoints) </summary>
            MAV_MODE_AUTO_DISARMED = 92,
            /// <summary> System is allowed to be active, under autonomous control and navigation (the trajectory is decided onboard and not pre-programmed by waypoints) </summary>
            MAV_MODE_AUTO_ARMED = 220,
            /// <summary> UNDEFINED mode. This solely depends on the autopilot - use with caution, intended for developers only. </summary>
            MAV_MODE_TEST_DISARMED = 66,
            /// <summary> UNDEFINED mode. This solely depends on the autopilot - use with caution, intended for developers only. </summary>
            MAV_MODE_TEST_ARMED = 194,
        }
        /// <summary>  </summary>
        public enum MAV_STATE
        {
            /// <summary> Uninitialized system, state is unknown. </summary>
            MAV_STATE_UNINIT = 0,
            /// <summary> System is booting up. </summary>
            MAV_STATE_BOOT,
            /// <summary> System is calibrating and not flight-ready. </summary>
            MAV_STATE_CALIBRATING,
            /// <summary> System is grounded and on standby. It can be launched any time. </summary>
            MAV_STATE_STANDBY,
            /// <summary> System is active and might be already airborne. Motors are engaged. </summary>
            MAV_STATE_ACTIVE,
            /// <summary> System is in a non-normal flight mode. It can however still navigate. </summary>
            MAV_STATE_CRITICAL,
            /// <summary> System is in a non-normal flight mode. It lost control over parts or over the whole airframe. It is in mayday and going down. </summary>
            MAV_STATE_EMERGENCY,
            /// <summary> System just initialized its power-down sequence, will shut down now. </summary>
            MAV_STATE_POWEROFF,
            /// <summary> System is terminating itself. </summary>
            MAV_STATE_FLIGHT_TERMINATION,
        }
        /// <summary> Component ids (values) for the different types and instances of onboard hardware/software that might make up a MAVLink system (autopilot, cameras, servos, GPS systems, avoidance systems etc.).
        /// Components must use the appropriate ID in their source address when sending messages.Components can also use IDs to determine if they are the intended recipient of an incoming message.The MAV_COMP_ID_ALL value is used to indicate messages that must be processed by all components.
        /// When creating new entries, components that can have multiple instances(e.g.cameras, servos etc.) should be allocated sequential values.An appropriate number of values should be left free after these components to allow the number of instances to be expanded. </summary>
        public enum MAV_COMPONENT
        {
            /// <summary> Target id (target_component) used to broadcast messages to all components of the receiving system. Components should attempt to process messages with this component ID and forward to components on any other interfaces. Note: This is not a valid *source* component id for a message. </summary>
            MAV_COMP_ID_ALL = 0,
            /// <summary> System flight controller component ("autopilot"). Only one autopilot is expected in a particular system. </summary>
            MAV_COMP_ID_AUTOPILOT1 = 1,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER1 = 25,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER2 = 26,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER3 = 27,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER4 = 28,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER5 = 29,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER6 = 30,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER7 = 31,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER8 = 32,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER9 = 33,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER10 = 34,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER11 = 35,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER12 = 36,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER13 = 37,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER14 = 38,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER15 = 39,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER16 = 40,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER17 = 41,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER18 = 42,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER19 = 43,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER20 = 44,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER21 = 45,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER22 = 46,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER23 = 47,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER24 = 48,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER25 = 49,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER26 = 50,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER27 = 51,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER28 = 52,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER29 = 53,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER30 = 54,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER31 = 55,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER32 = 56,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER33 = 57,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER34 = 58,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER35 = 59,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER36 = 60,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER37 = 61,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER38 = 62,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER39 = 63,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER40 = 64,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER41 = 65,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER42 = 66,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER43 = 67,
            /// <summary> Telemetry radio (e.g. SiK radio, or other component that emits RADIO_STATUS messages). </summary>
            MAV_COMP_ID_TELEMETRY_RADIO = 68,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER45 = 69,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER46 = 70,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER47 = 71,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER48 = 72,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER49 = 73,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER50 = 74,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER51 = 75,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER52 = 76,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER53 = 77,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER54 = 78,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER55 = 79,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER56 = 80,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER57 = 81,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER58 = 82,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER59 = 83,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER60 = 84,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER61 = 85,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER62 = 86,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER63 = 87,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER64 = 88,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER65 = 89,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER66 = 90,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER67 = 91,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER68 = 92,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER69 = 93,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER70 = 94,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER71 = 95,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER72 = 96,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER73 = 97,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER74 = 98,
            /// <summary> Id for a component on privately managed MAVLink network. Can be used for any purpose but may not be published by components outside of the private network. </summary>
            MAV_COMP_ID_USER75 = 99,
            /// <summary> Camera #1. </summary>
            MAV_COMP_ID_CAMERA = 100,
            /// <summary> Camera #2. </summary>
            MAV_COMP_ID_CAMERA2 = 101,
            /// <summary> Camera #3. </summary>
            MAV_COMP_ID_CAMERA3 = 102,
            /// <summary> Camera #4. </summary>
            MAV_COMP_ID_CAMERA4 = 103,
            /// <summary> Camera #5. </summary>
            MAV_COMP_ID_CAMERA5 = 104,
            /// <summary> Camera #6. </summary>
            MAV_COMP_ID_CAMERA6 = 105,
            /// <summary> Servo #1. </summary>
            MAV_COMP_ID_SERVO1 = 140,
            /// <summary> Servo #2. </summary>
            MAV_COMP_ID_SERVO2 = 141,
            /// <summary> Servo #3. </summary>
            MAV_COMP_ID_SERVO3 = 142,
            /// <summary> Servo #4. </summary>
            MAV_COMP_ID_SERVO4 = 143,
            /// <summary> Servo #5. </summary>
            MAV_COMP_ID_SERVO5 = 144,
            /// <summary> Servo #6. </summary>
            MAV_COMP_ID_SERVO6 = 145,
            /// <summary> Servo #7. </summary>
            MAV_COMP_ID_SERVO7 = 146,
            /// <summary> Servo #8. </summary>
            MAV_COMP_ID_SERVO8 = 147,
            /// <summary> Servo #9. </summary>
            MAV_COMP_ID_SERVO9 = 148,
            /// <summary> Servo #10. </summary>
            MAV_COMP_ID_SERVO10 = 149,
            /// <summary> Servo #11. </summary>
            MAV_COMP_ID_SERVO11 = 150,
            /// <summary> Servo #12. </summary>
            MAV_COMP_ID_SERVO12 = 151,
            /// <summary> Servo #13. </summary>
            MAV_COMP_ID_SERVO13 = 152,
            /// <summary> Servo #14. </summary>
            MAV_COMP_ID_SERVO14 = 153,
            /// <summary> Gimbal #1. </summary>
            MAV_COMP_ID_GIMBAL = 154,
            /// <summary> Logging component. </summary>
            MAV_COMP_ID_LOG = 155,
            /// <summary> Automatic Dependent Surveillance-Broadcast (ADS-B) component. </summary>
            MAV_COMP_ID_ADSB = 156,
            /// <summary> On Screen Display (OSD) devices for video links. </summary>
            MAV_COMP_ID_OSD = 157,
            /// <summary> Generic autopilot peripheral component ID. Meant for devices that do not implement the parameter microservice. </summary>
            MAV_COMP_ID_PERIPHERAL = 158,
            /// <summary> Gimbal ID for QX1. </summary>
            MAV_COMP_ID_QX1_GIMBAL = 159,
            /// <summary> FLARM collision alert component. </summary>
            MAV_COMP_ID_FLARM = 160,
            /// <summary> Gimbal #2. </summary>
            MAV_COMP_ID_GIMBAL2 = 171,
            /// <summary> Gimbal #3. </summary>
            MAV_COMP_ID_GIMBAL3 = 172,
            /// <summary> Gimbal #4 </summary>
            MAV_COMP_ID_GIMBAL4 = 173,
            /// <summary> Gimbal #5. </summary>
            MAV_COMP_ID_GIMBAL5 = 174,
            /// <summary> Gimbal #6. </summary>
            MAV_COMP_ID_GIMBAL6 = 175,
            /// <summary> Component that can generate/supply a mission flight plan (e.g. GCS or developer API). </summary>
            MAV_COMP_ID_MISSIONPLANNER = 190,
            /// <summary> Component that finds an optimal path between points based on a certain constraint (e.g. minimum snap, shortest path, cost, etc.). </summary>
            MAV_COMP_ID_PATHPLANNER = 195,
            /// <summary> Component that plans a collision free path between two points. </summary>
            MAV_COMP_ID_OBSTACLE_AVOIDANCE = 196,
            /// <summary> Component that provides position estimates using VIO techniques. </summary>
            MAV_COMP_ID_VISUAL_INERTIAL_ODOMETRY = 197,
            /// <summary> Component that manages pairing of vehicle and GCS. </summary>
            MAV_COMP_ID_PAIRING_MANAGER = 198,
            /// <summary> Inertial Measurement Unit (IMU) #1. </summary>
            MAV_COMP_ID_IMU = 200,
            /// <summary> Inertial Measurement Unit (IMU) #2. </summary>
            MAV_COMP_ID_IMU_2 = 201,
            /// <summary> Inertial Measurement Unit (IMU) #3. </summary>
            MAV_COMP_ID_IMU_3 = 202,
            /// <summary> GPS #1. </summary>
            MAV_COMP_ID_GPS = 220,
            /// <summary> GPS #2. </summary>
            MAV_COMP_ID_GPS2 = 221,
            /// <summary> Open Drone ID transmitter/receiver (Bluetooth/WiFi/Internet). </summary>
            MAV_COMP_ID_ODID_TXRX_1 = 236,
            /// <summary> Open Drone ID transmitter/receiver (Bluetooth/WiFi/Internet). </summary>
            MAV_COMP_ID_ODID_TXRX_2 = 237,
            /// <summary> Open Drone ID transmitter/receiver (Bluetooth/WiFi/Internet). </summary>
            MAV_COMP_ID_ODID_TXRX_3 = 238,
            /// <summary> Component to bridge MAVLink to UDP (i.e. from a UART). </summary>
            MAV_COMP_ID_UDP_BRIDGE = 240,
            /// <summary> Component to bridge to UART (i.e. from UDP). </summary>
            MAV_COMP_ID_UART_BRIDGE = 241,
            /// <summary> Component handling TUNNEL messages (e.g. vendor specific GUI of a component). </summary>
            MAV_COMP_ID_TUNNEL_NODE = 242,
            /// <summary> Component for handling system messages (e.g. to ARM, takeoff, etc.). </summary>
            MAV_COMP_ID_SYSTEM_CONTROL = 250,
        }
        /// <summary> These encode the sensors whose status is sent as part of the SYS_STATUS message. </summary>
        public enum MAV_SYS_STATUS_SENSOR
        {
            /// <summary>
            /// added by user, NONE Type.
            /// </summary>
            NONE = 0,
            /// <summary> 0x01 3D gyro </summary>
            MAV_SYS_STATUS_SENSOR_3D_GYRO = 1,
            /// <summary> 0x02 3D accelerometer </summary>
            MAV_SYS_STATUS_SENSOR_3D_ACCEL = 2,
            /// <summary> 0x04 3D magnetometer </summary>
            MAV_SYS_STATUS_SENSOR_3D_MAG = 4,
            /// <summary> 0x08 absolute pressure </summary>
            MAV_SYS_STATUS_SENSOR_ABSOLUTE_PRESSURE = 8,
            /// <summary> 0x10 differential pressure </summary>
            MAV_SYS_STATUS_SENSOR_DIFFERENTIAL_PRESSURE = 16,
            /// <summary> 0x20 GPS </summary>
            MAV_SYS_STATUS_SENSOR_GPS = 32,
            /// <summary> 0x40 optical flow </summary>
            MAV_SYS_STATUS_SENSOR_OPTICAL_FLOW = 64,
            /// <summary> 0x80 computer vision position </summary>
            MAV_SYS_STATUS_SENSOR_VISION_POSITION = 128,
            /// <summary> 0x100 laser based position </summary>
            MAV_SYS_STATUS_SENSOR_LASER_POSITION = 256,
            /// <summary> 0x200 external ground truth (Vicon or Leica) </summary>
            MAV_SYS_STATUS_SENSOR_EXTERNAL_GROUND_TRUTH = 512,
            /// <summary> 0x400 3D angular rate control </summary>
            MAV_SYS_STATUS_SENSOR_ANGULAR_RATE_CONTROL = 1024,
            /// <summary> 0x800 attitude stabilization </summary>
            MAV_SYS_STATUS_SENSOR_ATTITUDE_STABILIZATION = 2048,
            /// <summary> 0x1000 yaw position </summary>
            MAV_SYS_STATUS_SENSOR_YAW_POSITION = 4096,
            /// <summary> 0x2000 z/altitude control </summary>
            MAV_SYS_STATUS_SENSOR_Z_ALTITUDE_CONTROL = 8192,
            /// <summary> 0x4000 x/y position control </summary>
            MAV_SYS_STATUS_SENSOR_XY_POSITION_CONTROL = 16384,
            /// <summary> 0x8000 motor outputs / control </summary>
            MAV_SYS_STATUS_SENSOR_MOTOR_OUTPUTS = 32768,
            /// <summary> 0x10000 rc receiver </summary>
            MAV_SYS_STATUS_SENSOR_RC_RECEIVER = 65536,
            /// <summary> 0x20000 2nd 3D gyro </summary>
            MAV_SYS_STATUS_SENSOR_3D_GYRO2 = 131072,
            /// <summary> 0x40000 2nd 3D accelerometer </summary>
            MAV_SYS_STATUS_SENSOR_3D_ACCEL2 = 262144,
            /// <summary> 0x80000 2nd 3D magnetometer </summary>
            MAV_SYS_STATUS_SENSOR_3D_MAG2 = 524288,
            /// <summary> 0x100000 geofence </summary>
            MAV_SYS_STATUS_GEOFENCE = 1048576,
            /// <summary> 0x200000 AHRS subsystem health </summary>
            MAV_SYS_STATUS_AHRS = 2097152,
            /// <summary> 0x400000 Terrain subsystem health </summary>
            MAV_SYS_STATUS_TERRAIN = 4194304,
            /// <summary> 0x800000 Motors are reversed </summary>
            MAV_SYS_STATUS_REVERSE_MOTOR = 8388608,
            /// <summary> 0x1000000 Logging </summary>
            MAV_SYS_STATUS_LOGGING = 16777216,
            /// <summary> 0x2000000 Battery </summary>
            MAV_SYS_STATUS_SENSOR_BATTERY = 33554432,
            /// <summary> 0x4000000 Proximity </summary>
            MAV_SYS_STATUS_SENSOR_PROXIMITY = 67108864,
            /// <summary> 0x8000000 Satellite Communication  </summary>
            MAV_SYS_STATUS_SENSOR_SATCOM = 134217728,
            /// <summary> 0x10000000 pre-arm check status. Always healthy when armed </summary>
            MAV_SYS_STATUS_PREARM_CHECK = 268435456,
            /// <summary> 0x20000000 Avoidance/collision prevention </summary>
            MAV_SYS_STATUS_OBSTACLE_AVOIDANCE = 536870912,
        }
        /// <summary>  </summary>
        public enum MAV_FRAME
        {
            /// <summary> Global (WGS84) coordinate frame + MSL altitude. First value / x: latitude, second value / y: longitude, third value / z: positive altitude over mean sea level (MSL). </summary>
            MAV_FRAME_GLOBAL = 0,
            /// <summary> Local coordinate frame, Z-down (x: North, y: East, z: Down). </summary>
            MAV_FRAME_LOCAL_NED = 1,
            /// <summary> NOT a coordinate frame, indicates a mission command. </summary>
            MAV_FRAME_MISSION = 2,
            /// <summary> Global (WGS84) coordinate frame + altitude relative to the home position. First value / x: latitude, second value / y: longitude, third value / z: positive altitude with 0 being at the altitude of the home location. </summary>
            MAV_FRAME_GLOBAL_RELATIVE_ALT = 3,
            /// <summary> Local coordinate frame, Z-up (x: East, y: North, z: Up). </summary>
            MAV_FRAME_LOCAL_ENU = 4,
            /// <summary> Global (WGS84) coordinate frame (scaled) + MSL altitude. First value / x: latitude in degrees*1.0e-7, second value / y: longitude in degrees*1.0e-7, third value / z: positive altitude over mean sea level (MSL). </summary>
            MAV_FRAME_GLOBAL_INT = 5,
            /// <summary> Global (WGS84) coordinate frame (scaled) + altitude relative to the home position. First value / x: latitude in degrees*10e-7, second value / y: longitude in degrees*10e-7, third value / z: positive altitude with 0 being at the altitude of the home location. </summary>
            MAV_FRAME_GLOBAL_RELATIVE_ALT_INT = 6,
            /// <summary> Offset to the current local frame. Anything expressed in this frame should be added to the current local frame position. </summary>
            MAV_FRAME_LOCAL_OFFSET_NED = 7,
            /// <summary> Setpoint in body NED frame. This makes sense if all position control is externalized - e.g. useful to command 2 m/s^2 acceleration to the right. </summary>
            MAV_FRAME_BODY_NED = 8,
            /// <summary> Offset in body NED frame. This makes sense if adding setpoints to the current flight path, to avoid an obstacle - e.g. useful to command 2 m/s^2 acceleration to the east. </summary>
            MAV_FRAME_BODY_OFFSET_NED = 9,
            /// <summary> Global (WGS84) coordinate frame with AGL altitude (at the waypoint coordinate). First value / x: latitude in degrees, second value / y: longitude in degrees, third value / z: positive altitude in meters with 0 being at ground level in terrain model. </summary>
            MAV_FRAME_GLOBAL_TERRAIN_ALT = 10,
            /// <summary> Global (WGS84) coordinate frame (scaled) with AGL altitude (at the waypoint coordinate). First value / x: latitude in degrees*10e-7, second value / y: longitude in degrees*10e-7, third value / z: positive altitude in meters with 0 being at ground level in terrain model. </summary>
            MAV_FRAME_GLOBAL_TERRAIN_ALT_INT = 11,
            /// <summary> Body fixed frame of reference, Z-down (x: Forward, y: Right, z: Down). </summary>
            MAV_FRAME_BODY_FRD = 12,
            /// <summary> MAV_FRAME_BODY_FLU - Body fixed frame of reference, Z-up (x: Forward, y: Left, z: Up). </summary>
            MAV_FRAME_RESERVED_13 = 13,
            /// <summary> MAV_FRAME_MOCAP_NED - Odometry local coordinate frame of data given by a motion capture system, Z-down (x: North, y: East, z: Down). </summary>
            MAV_FRAME_RESERVED_14 = 14,
            /// <summary> MAV_FRAME_MOCAP_ENU - Odometry local coordinate frame of data given by a motion capture system, Z-up (x: East, y: North, z: Up). </summary>
            MAV_FRAME_RESERVED_15 = 15,
            /// <summary> MAV_FRAME_VISION_NED - Odometry local coordinate frame of data given by a vision estimation system, Z-down (x: North, y: East, z: Down). </summary>
            MAV_FRAME_RESERVED_16 = 16,
            /// <summary> MAV_FRAME_VISION_ENU - Odometry local coordinate frame of data given by a vision estimation system, Z-up (x: East, y: North, z: Up). </summary>
            MAV_FRAME_RESERVED_17 = 17,
            /// <summary> MAV_FRAME_ESTIM_NED - Odometry local coordinate frame of data given by an estimator running onboard the vehicle, Z-down (x: North, y: East, z: Down). </summary>
            MAV_FRAME_RESERVED_18 = 18,
            /// <summary> MAV_FRAME_ESTIM_ENU - Odometry local coordinate frame of data given by an estimator running onboard the vehicle, Z-up (x: East, y: North, z: Up). </summary>
            MAV_FRAME_RESERVED_19 = 19,
            /// <summary> Forward, Right, Down coordinate frame. This is a local frame with Z-down and arbitrary F/R alignment (i.e. not aligned with NED/earth frame). </summary>
            MAV_FRAME_LOCAL_FRD = 20,
            /// <summary> Forward, Left, Up coordinate frame. This is a local frame with Z-up and arbitrary F/L alignment (i.e. not aligned with ENU/earth frame). </summary>
            MAV_FRAME_LOCAL_FLU = 21,
        }
        /// <summary>  </summary>
        public enum MAVLINK_DATA_STREAM_TYPE
        {
            /// <summary>  </summary>
            MAVLINK_DATA_STREAM_IMG_JPEG,/// <summary>  </summary>
            MAVLINK_DATA_STREAM_IMG_BMP,/// <summary>  </summary>
            MAVLINK_DATA_STREAM_IMG_RAW8U,/// <summary>  </summary>
            MAVLINK_DATA_STREAM_IMG_RAW32U,/// <summary>  </summary>
            MAVLINK_DATA_STREAM_IMG_PGM,/// <summary>  </summary>
            MAVLINK_DATA_STREAM_IMG_PNG,
        }
        /// <summary>  </summary>
        public enum FENCE_ACTION
        {
            /// <summary> Disable fenced mode </summary>
            FENCE_ACTION_NONE = 0,
            /// <summary> Switched to guided mode to return point (fence point 0) </summary>
            FENCE_ACTION_GUIDED = 1,
            /// <summary> Report fence breach, but don't take action </summary>
            FENCE_ACTION_REPORT = 2,
            /// <summary> Switched to guided mode to return point (fence point 0) with manual throttle control </summary>
            FENCE_ACTION_GUIDED_THR_PASS = 3,
            /// <summary> Switch to RTL (return to launch) mode and head for the return point. </summary>
            FENCE_ACTION_RTL = 4,
        }
        /// <summary>  </summary>
        public enum FENCE_BREACH
        {
            /// <summary> No last fence breach </summary>
            FENCE_BREACH_NONE = 0,
            /// <summary> Breached minimum altitude </summary>
            FENCE_BREACH_MINALT = 1,
            /// <summary> Breached maximum altitude </summary>
            FENCE_BREACH_MAXALT = 2,
            /// <summary> Breached fence boundary </summary>
            FENCE_BREACH_BOUNDARY = 3,
        }
        /// <summary> Actions being taken to mitigate/prevent fence breach </summary>
        public enum FENCE_MITIGATE
        {
            /// <summary> Unknown </summary>
            FENCE_MITIGATE_UNKNOWN = 0,
            /// <summary> No actions being taken </summary>
            FENCE_MITIGATE_NONE = 1,
            /// <summary> Velocity limiting active to prevent breach </summary>
            FENCE_MITIGATE_VEL_LIMIT = 2,
        }
        /// <summary> Enumeration of possible mount operation modes. This message is used by obsolete/deprecated gimbal messages. </summary>
        public enum MAV_MOUNT_MODE
        {
            /// <summary> Load and keep safe position (Roll,Pitch,Yaw) from permant memory and stop stabilization </summary>
            MAV_MOUNT_MODE_RETRACT = 0,
            /// <summary> Load and keep neutral position (Roll,Pitch,Yaw) from permanent memory. </summary>
            MAV_MOUNT_MODE_NEUTRAL = 1,
            /// <summary> Load neutral position and start MAVLink Roll,Pitch,Yaw control with stabilization </summary>
            MAV_MOUNT_MODE_MAVLINK_TARGETING = 2,
            /// <summary> Load neutral position and start RC Roll,Pitch,Yaw control with stabilization </summary>
            MAV_MOUNT_MODE_RC_TARGETING = 3,
            /// <summary> Load neutral position and start to point to Lat,Lon,Alt </summary>
            MAV_MOUNT_MODE_GPS_POINT = 4,
            /// <summary> Gimbal tracks system with specified system ID </summary>
            MAV_MOUNT_MODE_SYSID_TARGET = 5,
        }
        /// <summary> Gimbal device (low level) capability flags (bitmap) </summary>
        public enum GIMBAL_DEVICE_CAP_FLAGS
        {
            /// <summary> Gimbal device supports a retracted position </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_RETRACT = 1,
            /// <summary> Gimbal device supports a horizontal, forward looking position, stabilized </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_NEUTRAL = 2,
            /// <summary> Gimbal device supports rotating around roll axis. </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_ROLL_AXIS = 4,
            /// <summary> Gimbal device supports to follow a roll angle relative to the vehicle </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_ROLL_FOLLOW = 8,
            /// <summary> Gimbal device supports locking to an roll angle (generally that's the default with roll stabilized) </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_ROLL_LOCK = 16,
            /// <summary> Gimbal device supports rotating around pitch axis. </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_PITCH_AXIS = 32,
            /// <summary> Gimbal device supports to follow a pitch angle relative to the vehicle </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_PITCH_FOLLOW = 64,
            /// <summary> Gimbal device supports locking to an pitch angle (generally that's the default with pitch stabilized) </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_PITCH_LOCK = 128,
            /// <summary> Gimbal device supports rotating around yaw axis. </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_YAW_AXIS = 256,
            /// <summary> Gimbal device supports to follow a yaw angle relative to the vehicle (generally that's the default) </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_YAW_FOLLOW = 512,
            /// <summary> Gimbal device supports locking to an absolute heading (often this is an option available) </summary>
            GIMBAL_DEVICE_CAP_FLAGS_HAS_YAW_LOCK = 1024,
            /// <summary> Gimbal device supports yawing/panning infinetely (e.g. using slip disk). </summary>
            GIMBAL_DEVICE_CAP_FLAGS_SUPPORTS_INFINITE_YAW = 2048,
        }
        /// <summary> Gimbal manager high level capability flags (bitmap). The first 16 bits are identical to the GIMBAL_DEVICE_CAP_FLAGS which are identical with GIMBAL_DEVICE_FLAGS. However, the gimbal manager does not need to copy the flags from the gimbal but can also enhance the capabilities and thus add flags. </summary>
        public enum GIMBAL_MANAGER_CAP_FLAGS
        {
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_RETRACT. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_RETRACT = 1,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_NEUTRAL. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_NEUTRAL = 2,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_ROLL_AXIS. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_ROLL_AXIS = 4,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_ROLL_FOLLOW. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_ROLL_FOLLOW = 8,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_ROLL_LOCK. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_ROLL_LOCK = 16,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_PITCH_AXIS. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_PITCH_AXIS = 32,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_PITCH_FOLLOW. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_PITCH_FOLLOW = 64,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_PITCH_LOCK. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_PITCH_LOCK = 128,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_YAW_AXIS. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_YAW_AXIS = 256,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_YAW_FOLLOW. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_YAW_FOLLOW = 512,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_HAS_YAW_LOCK. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_YAW_LOCK = 1024,
            /// <summary> Based on GIMBAL_DEVICE_CAP_FLAGS_SUPPORTS_INFINITE_YAW. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_SUPPORTS_INFINITE_YAW = 2048,
            /// <summary> Gimbal manager supports to point to a local position. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_CAN_POINT_LOCATION_LOCAL = 65536,
            /// <summary> Gimbal manager supports to point to a global latitude, longitude, altitude position. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_CAN_POINT_LOCATION_GLOBAL = 131072,
            /// <summary> Gimbal manager supports tracking of a point on the camera. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_TRACKING_POINT = 262144,
            /// <summary> Gimbal manager supports tracking of a point on the camera. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_HAS_TRACKING_RECTANGLE = 524288,
            /// <summary> Gimbal manager supports pitching and yawing at an angular velocity scaled by focal length (the more zoomed in, the slower the movement). </summary>
            GIMBAL_MANAGER_CAP_FLAGS_SUPPORTS_FOCAL_LENGTH_SCALE = 1048576,
            /// <summary> Gimbal manager supports nudging when pointing to a location or tracking. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_SUPPORTS_NUDGING = 2097152,
            /// <summary> Gimbal manager supports overriding when pointing to a location or tracking. </summary>
            GIMBAL_MANAGER_CAP_FLAGS_SUPPORTS_OVERRIDE = 4194304,
        }
        /// <summary> Flags for gimbal device (lower level) operation. </summary>
        public enum GIMBAL_DEVICE_FLAGS
        {
            /// <summary> Set to retracted safe position (no stabilization), takes presedence over all other flags. </summary>
            GIMBAL_DEVICE_FLAGS_RETRACT = 1,
            /// <summary> Set to neutral position (horizontal, forward looking, with stabiliziation), takes presedence over all other flags except RETRACT. </summary>
            GIMBAL_DEVICE_FLAGS_NEUTRAL = 2,
            /// <summary> Lock roll angle to absolute angle relative to horizon (not relative to drone). This is generally the default with a stabilizing gimbal. </summary>
            GIMBAL_DEVICE_FLAGS_ROLL_LOCK = 4,
            /// <summary> Lock pitch angle to absolute angle relative to horizon (not relative to drone). This is generally the default. </summary>
            GIMBAL_DEVICE_FLAGS_PITCH_LOCK = 8,
            /// <summary> Lock yaw angle to absolute angle relative to North (not relative to drone). If this flag is set, the quaternion is in the Earth frame with the x-axis pointing North (yaw absolute). If this flag is not set, the quaternion frame is in the Earth frame rotated so that the x-axis is pointing forward (yaw relative to vehicle). </summary>
            GIMBAL_DEVICE_FLAGS_YAW_LOCK = 16,
        }
        /// <summary> Flags for high level gimbal manager operation The first 16 bytes are identical to the GIMBAL_DEVICE_FLAGS. </summary>
        public enum GIMBAL_MANAGER_FLAGS
        {
            /// <summary> Based on GIMBAL_DEVICE_FLAGS_RETRACT </summary>
            GIMBAL_MANAGER_FLAGS_RETRACT = 1,
            /// <summary> Based on GIMBAL_DEVICE_FLAGS_NEUTRAL </summary>
            GIMBAL_MANAGER_FLAGS_NEUTRAL = 2,
            /// <summary> Based on GIMBAL_DEVICE_FLAGS_ROLL_LOCK </summary>
            GIMBAL_MANAGER_FLAGS_ROLL_LOCK = 4,
            /// <summary> Based on GIMBAL_DEVICE_FLAGS_PITCH_LOCK </summary>
            GIMBAL_MANAGER_FLAGS_PITCH_LOCK = 8,
            /// <summary> Based on GIMBAL_DEVICE_FLAGS_YAW_LOCK </summary>
            GIMBAL_MANAGER_FLAGS_YAW_LOCK = 16,
            /// <summary> Scale angular velocity relative to focal length. This means the gimbal moves slower if it is zoomed in. </summary>
            GIMBAL_MANAGER_FLAGS_ANGULAR_VELOCITY_RELATIVE_TO_FOCAL_LENGTH = 1048576,
            /// <summary> Interpret attitude control on top of pointing to a location or tracking. If this flag is set, the quaternion is relative to the existing tracking angle. </summary>
            GIMBAL_MANAGER_FLAGS_NUDGE = 2097152,
            /// <summary> Completely override pointing to a location or tracking. If this flag is set, the quaternion is (as usual) according to GIMBAL_MANAGER_FLAGS_YAW_LOCK. </summary>
            GIMBAL_MANAGER_FLAGS_OVERRIDE = 4194304,
            /// <summary> This flag can be set to give up control previously set using MAV_CMD_DO_GIMBAL_MANAGER_ATTITUDE. This flag must not be combined with other flags. </summary>
            GIMBAL_MANAGER_FLAGS_NONE = 8388608,
        }
        /// <summary> Gimbal device (low level) error flags (bitmap, 0 means no error) </summary>
        public enum GIMBAL_DEVICE_ERROR_FLAGS
        {
            /// <summary> Gimbal device is limited by hardware roll limit. </summary>
            GIMBAL_DEVICE_ERROR_FLAGS_AT_ROLL_LIMIT = 1,
            /// <summary> Gimbal device is limited by hardware pitch limit. </summary>
            GIMBAL_DEVICE_ERROR_FLAGS_AT_PITCH_LIMIT = 2,
            /// <summary> Gimbal device is limited by hardware yaw limit. </summary>
            GIMBAL_DEVICE_ERROR_FLAGS_AT_YAW_LIMIT = 4,
            /// <summary> There is an error with the gimbal encoders. </summary>
            GIMBAL_DEVICE_ERROR_FLAGS_ENCODER_ERROR = 8,
            /// <summary> There is an error with the gimbal power source. </summary>
            GIMBAL_DEVICE_ERROR_FLAGS_POWER_ERROR = 16,
            /// <summary> There is an error with the gimbal motor's. </summary>
            GIMBAL_DEVICE_ERROR_FLAGS_MOTOR_ERROR = 32,
            /// <summary> There is an error with the gimbal's software. </summary>
            GIMBAL_DEVICE_ERROR_FLAGS_SOFTWARE_ERROR = 64,
            /// <summary> There is an error with the gimbal's communication. </summary>
            GIMBAL_DEVICE_ERROR_FLAGS_COMMS_ERROR = 128,
        }
        /// <summary> Generalized UAVCAN node health </summary>
        public enum UAVCAN_NODE_HEALTH
        {
            /// <summary> The node is functioning properly. </summary>
            UAVCAN_NODE_HEALTH_OK = 0,
            /// <summary> A critical parameter went out of range or the node has encountered a minor failure. </summary>
            UAVCAN_NODE_HEALTH_WARNING = 1,
            /// <summary> The node has encountered a major failure. </summary>
            UAVCAN_NODE_HEALTH_ERROR = 2,
            /// <summary> The node has suffered a fatal malfunction. </summary>
            UAVCAN_NODE_HEALTH_CRITICAL = 3,
        }
        /// <summary> Generalized UAVCAN node mode </summary>
        public enum UAVCAN_NODE_MODE
        {
            /// <summary> The node is performing its primary functions. </summary>
            UAVCAN_NODE_MODE_OPERATIONAL = 0,
            /// <summary> The node is initializing; this mode is entered immediately after startup. </summary>
            UAVCAN_NODE_MODE_INITIALIZATION = 1,
            /// <summary> The node is under maintenance. </summary>
            UAVCAN_NODE_MODE_MAINTENANCE = 2,
            /// <summary> The node is in the process of updating its software. </summary>
            UAVCAN_NODE_MODE_SOFTWARE_UPDATE = 3,
            /// <summary> The node is no longer available online. </summary>
            UAVCAN_NODE_MODE_OFFLINE = 7,
        }
        /// <summary> Indicates the ESC connection type. </summary>
        public enum ESC_CONNECTION_TYPE
        {
            /// <summary> Traditional PPM ESC. </summary>
            ESC_CONNECTION_TYPE_PPM = 0,
            /// <summary> Serial Bus connected ESC. </summary>
            ESC_CONNECTION_TYPE_SERIAL = 1,
            /// <summary> One Shot PPM ESC. </summary>
            ESC_CONNECTION_TYPE_ONESHOT = 2,
            /// <summary> I2C ESC. </summary>
            ESC_CONNECTION_TYPE_I2C = 3,
            /// <summary> CAN-Bus ESC. </summary>
            ESC_CONNECTION_TYPE_CAN = 4,
            /// <summary> DShot ESC. </summary>
            ESC_CONNECTION_TYPE_DSHOT = 5,
        }
        /// <summary> Flags to report ESC failures. </summary>
        public enum ESC_FAILURE_FLAGS
        {
            /// <summary> No ESC failure. </summary>
            ESC_FAILURE_NONE = 0,
            /// <summary> Over current failure. </summary>
            ESC_FAILURE_OVER_CURRENT = 1,
            /// <summary> Over voltage failure. </summary>
            ESC_FAILURE_OVER_VOLTAGE = 2,
            /// <summary> Over temperature failure. </summary>
            ESC_FAILURE_OVER_TEMPERATURE = 4,
            /// <summary> Over RPM failure. </summary>
            ESC_FAILURE_OVER_RPM = 8,
            /// <summary> Inconsistent command failure i.e. out of bounds. </summary>
            ESC_FAILURE_INCONSISTENT_CMD = 16,
            /// <summary> Motor stuck failure. </summary>
            ESC_FAILURE_MOTOR_STUCK = 32,
            /// <summary> Generic ESC failure. </summary>
            ESC_FAILURE_GENERIC = 64,
        }
        /// <summary> Flags to indicate the status of camera storage. </summary>
        public enum STORAGE_STATUS
        {
            /// <summary> Storage is missing (no microSD card loaded for example.) </summary>
            STORAGE_STATUS_EMPTY = 0,
            /// <summary> Storage present but unformatted. </summary>
            STORAGE_STATUS_UNFORMATTED = 1,
            /// <summary> Storage present and ready. </summary>
            STORAGE_STATUS_READY = 2,
            /// <summary> Camera does not supply storage status information. Capacity information in STORAGE_INFORMATION fields will be ignored. </summary>
            STORAGE_STATUS_NOT_SUPPORTED = 3,
        }
        /// <summary> Yaw behaviour during orbit flight. </summary>
        public enum ORBIT_YAW_BEHAVIOUR
        {
            /// <summary> Vehicle front points to the center (default). </summary>
            ORBIT_YAW_BEHAVIOUR_HOLD_FRONT_TO_CIRCLE_CENTER = 0,
            /// <summary> Vehicle front holds heading when message received. </summary>
            ORBIT_YAW_BEHAVIOUR_HOLD_INITIAL_HEADING = 1,
            /// <summary> Yaw uncontrolled. </summary>
            ORBIT_YAW_BEHAVIOUR_UNCONTROLLED = 2,
            /// <summary> Vehicle front follows flight path (tangential to circle). </summary>
            ORBIT_YAW_BEHAVIOUR_HOLD_FRONT_TANGENT_TO_CIRCLE = 3,
            /// <summary> Yaw controlled by RC input. </summary>
            ORBIT_YAW_BEHAVIOUR_RC_CONTROLLED = 4,
        }
        /// <summary> Possible responses from a WIFI_CONFIG_AP message. </summary>
        public enum WIFI_CONFIG_AP_RESPONSE
        {
            /// <summary> Undefined response. Likely an indicative of a system that doesn't support this request. </summary>
            WIFI_CONFIG_AP_RESPONSE_UNDEFINED = 0,
            /// <summary> Changes accepted. </summary>
            WIFI_CONFIG_AP_RESPONSE_ACCEPTED = 1,
            /// <summary> Changes rejected. </summary>
            WIFI_CONFIG_AP_RESPONSE_REJECTED = 2,
            /// <summary> Invalid Mode. </summary>
            WIFI_CONFIG_AP_RESPONSE_MODE_ERROR = 3,
            /// <summary> Invalid SSID. </summary>
            WIFI_CONFIG_AP_RESPONSE_SSID_ERROR = 4,
            /// <summary> Invalid Password. </summary>
            WIFI_CONFIG_AP_RESPONSE_PASSWORD_ERROR = 5,
        }
        /// <summary> Possible responses from a CELLULAR_CONFIG message. </summary>
        public enum CELLULAR_CONFIG_RESPONSE
        {
            /// <summary> Changes accepted. </summary>
            CELLULAR_CONFIG_RESPONSE_ACCEPTED = 0,
            /// <summary> Invalid APN. </summary>
            CELLULAR_CONFIG_RESPONSE_APN_ERROR = 1,
            /// <summary> Invalid PIN. </summary>
            CELLULAR_CONFIG_RESPONSE_PIN_ERROR = 2,
            /// <summary> Changes rejected. </summary>
            CELLULAR_CONFIG_RESPONSE_REJECTED = 3,
            /// <summary> PUK is required to unblock SIM card. </summary>
            CELLULAR_CONFIG_BLOCKED_PUK_REQUIRED = 4,
        }
        /// <summary> WiFi Mode. </summary>
        public enum WIFI_CONFIG_AP_MODE
        {
            /// <summary> WiFi mode is undefined. </summary>
            WIFI_CONFIG_AP_MODE_UNDEFINED = 0,
            /// <summary> WiFi configured as an access point. </summary>
            WIFI_CONFIG_AP_MODE_AP = 1,
            /// <summary> WiFi configured as a station connected to an existing local WiFi network. </summary>
            WIFI_CONFIG_AP_MODE_STATION = 2,
            /// <summary> WiFi disabled. </summary>
            WIFI_CONFIG_AP_MODE_DISABLED = 3,
        }
        /// <summary> Possible values for COMPONENT_INFORMATION.comp_metadata_type. </summary>
        public enum COMP_METADATA_TYPE
        {
            /// <summary> Version information which also includes information on other optional supported COMP_METADATA_TYPE's. Must be supported. Only downloadable from vehicle. </summary>
            COMP_METADATA_TYPE_VERSION = 0,
            /// <summary> Parameter meta data. </summary>
            COMP_METADATA_TYPE_PARAMETER = 1,
        }
        /// <summary> Possible responses from a PARAM_START_TRANSACTION and PARAM_COMMIT_TRANSACTION messages. </summary>
        public enum PARAM_TRANSACTION_RESPONSE
        {
            /// <summary> Transaction accepted. </summary>
            PARAM_TRANSACTION_RESPONSE_ACCEPTED = 0,
            /// <summary> Transaction failed. </summary>
            PARAM_TRANSACTION_RESPONSE_FAILED = 1,
            /// <summary> Transaction unsupported. </summary>
            PARAM_TRANSACTION_RESPONSE_UNSUPPORTED = 2,
            /// <summary> Transaction in progress. </summary>
            PARAM_TRANSACTION_RESPONSE_INPROGRESS = 3,
        }
        /// <summary> Possible transport layers to set and get parameters via mavlink during a parameter transaction. </summary>
        public enum PARAM_TRANSACTION_TRANSPORT
        {
            /// <summary> Transaction over param transport. </summary>
            PARAM_TRANSACTION_TRANSPORT_PARAM = 0,
            /// <summary> Transaction over param_ext transport. </summary>
            PARAM_TRANSACTION_TRANSPORT_PARAM_EXT = 1,
        }
        /// <summary> Possible parameter transaction action during a commit. </summary>
        public enum PARAM_TRANSACTION_ACTION
        {
            /// <summary> Commit the current parameter transaction. </summary>
            PARAM_TRANSACTION_ACTION_COMMIT = 0,
            /// <summary> Cancel the current parameter transaction. </summary>
            PARAM_TRANSACTION_ACTION_CANCEL = 1,
        }
        /// <summary> Commands to be executed by the MAV. They can be executed on user request, or as part of a mission script. If the action is used in a mission, the parameter mapping to the waypoint/mission message is as follows: Param 1, Param 2, Param 3, Param 4, X: Param 5, Y:Param 6, Z:Param 7. This command list is similar what ARINC 424 is for commercial aircraft: A data format how to interpret waypoint/mission data. NaN and INT32_MAX may be used in float/integer params (respectively) to indicate optional/default values (e.g. to use the component's current yaw or latitude rather than a specific value). See https://mavlink.io/en/guide/xml_schema.html#MAV_CMD for information about the structure of the MAV_CMD entries </summary>
        public enum MAV_CMD
        {
            /// <summary> Navigate to waypoint. </summary>
            MAV_CMD_NAV_WAYPOINT = 16,
            /// <summary> Loiter around this waypoint an unlimited amount of time </summary>
            MAV_CMD_NAV_LOITER_UNLIM = 17,
            /// <summary> Loiter around this waypoint for X turns </summary>
            MAV_CMD_NAV_LOITER_TURNS = 18,
            /// <summary> Loiter at the specified latitude, longitude and altitude for a certain amount of time. Multicopter vehicles stop at the point (within a vehicle-specific acceptance radius). Forward-only moving vehicles (e.g. fixed-wing) circle the point with the specified radius/direction. If the Heading Required parameter (2) is non-zero forward moving aircraft will only leave the loiter circle once heading towards the next waypoint. </summary>
            MAV_CMD_NAV_LOITER_TIME = 19,
            /// <summary> Return to launch location </summary>
            MAV_CMD_NAV_RETURN_TO_LAUNCH = 20,
            /// <summary> Land at location. </summary>
            MAV_CMD_NAV_LAND = 21,
            /// <summary> Takeoff from ground / hand. Vehicles that support multiple takeoff modes (e.g. VTOL quadplane) should take off using the currently configured mode. </summary>
            MAV_CMD_NAV_TAKEOFF = 22,
            /// <summary> Land at local position (local frame only) </summary>
            MAV_CMD_NAV_LAND_LOCAL = 23,
            /// <summary> Takeoff from local position (local frame only) </summary>
            MAV_CMD_NAV_TAKEOFF_LOCAL = 24,
            /// <summary> Vehicle following, i.e. this waypoint represents the position of a moving vehicle </summary>
            MAV_CMD_NAV_FOLLOW = 25,
            /// <summary> Continue on the current course and climb/descend to specified altitude.  When the altitude is reached continue to the next command (i.e., don't proceed to the next command until the desired altitude is reached. </summary>
            MAV_CMD_NAV_CONTINUE_AND_CHANGE_ALT = 30,
            /// <summary> Begin loiter at the specified Latitude and Longitude.  If Lat=Lon=0, then loiter at the current position.  Don't consider the navigation command complete (don't leave loiter) until the altitude has been reached. Additionally, if the Heading Required parameter is non-zero the aircraft will not leave the loiter until heading toward the next waypoint. </summary>
            MAV_CMD_NAV_LOITER_TO_ALT = 31,
            /// <summary> Begin following a target </summary>
            MAV_CMD_DO_FOLLOW = 32,
            /// <summary> Reposition the MAV after a follow target command has been sent </summary>
            MAV_CMD_DO_FOLLOW_REPOSITION = 33,
            /// <summary> Start orbiting on the circumference of a circle defined by the parameters. Setting any value NaN results in using defaults. </summary>
            MAV_CMD_DO_ORBIT = 34,
            /// <summary> Sets the region of interest (ROI) for a sensor set or the vehicle itself. This can then be used by the vehicle's control system to control the vehicle attitude and the attitude of various sensors such as cameras. </summary>
            MAV_CMD_NAV_ROI = 80,
            /// <summary> Control autonomous path planning on the MAV. </summary>
            MAV_CMD_NAV_PATHPLANNING = 81,
            /// <summary> Navigate to waypoint using a spline path. </summary>
            MAV_CMD_NAV_SPLINE_WAYPOINT = 82,
            /// <summary> Takeoff from ground using VTOL mode, and transition to forward flight with specified heading. The command should be ignored by vehicles that dont support both VTOL and fixed-wing flight (multicopters, boats,etc.). </summary>
            MAV_CMD_NAV_VTOL_TAKEOFF = 84,
            /// <summary> Land using VTOL mode </summary>
            MAV_CMD_NAV_VTOL_LAND = 85,
            /// <summary> hand control over to an external controller </summary>
            MAV_CMD_NAV_GUIDED_ENABLE = 92,
            /// <summary> Delay the next navigation command a number of seconds or until a specified time </summary>
            MAV_CMD_NAV_DELAY = 93,
            /// <summary> Descend and place payload. Vehicle moves to specified location, descends until it detects a hanging payload has reached the ground, and then releases the payload. If ground is not detected before the reaching the maximum descent value (param1), the command will complete without releasing the payload. </summary>
            MAV_CMD_NAV_PAYLOAD_PLACE = 94,
            /// <summary> NOP - This command is only used to mark the upper limit of the NAV/ACTION commands in the enumeration </summary>
            MAV_CMD_NAV_LAST = 95,
            /// <summary> Delay mission state machine. </summary>
            MAV_CMD_CONDITION_DELAY = 112,
            /// <summary> Ascend/descend to target altitude at specified rate. Delay mission state machine until desired altitude reached. </summary>
            MAV_CMD_CONDITION_CHANGE_ALT = 113,
            /// <summary> Delay mission state machine until within desired distance of next NAV point. </summary>
            MAV_CMD_CONDITION_DISTANCE = 114,
            /// <summary> Reach a certain target angle. </summary>
            MAV_CMD_CONDITION_YAW = 115,
            /// <summary> NOP - This command is only used to mark the upper limit of the CONDITION commands in the enumeration </summary>
            MAV_CMD_CONDITION_LAST = 159,
            /// <summary> Set system mode. </summary>
            MAV_CMD_DO_SET_MODE = 176,
            /// <summary> Jump to the desired command in the mission list.  Repeat this action only the specified number of times </summary>
            MAV_CMD_DO_JUMP = 177,
            /// <summary> Change speed and/or throttle set points. </summary>
            MAV_CMD_DO_CHANGE_SPEED = 178,
            /// <summary> Changes the home location either to the current location or a specified location. </summary>
            MAV_CMD_DO_SET_HOME = 179,
            /// <summary> Set a system parameter.  Caution!  Use of this command requires knowledge of the numeric enumeration value of the parameter. </summary>
            MAV_CMD_DO_SET_PARAMETER = 180,
            /// <summary> Set a relay to a condition. </summary>
            MAV_CMD_DO_SET_RELAY = 181,
            /// <summary> Cycle a relay on and off for a desired number of cycles with a desired period. </summary>
            MAV_CMD_DO_REPEAT_RELAY = 182,
            /// <summary> Set a servo to a desired PWM value. </summary>
            MAV_CMD_DO_SET_SERVO = 183,
            /// <summary> Cycle a between its nominal setting and a desired PWM for a desired number of cycles with a desired period. </summary>
            MAV_CMD_DO_REPEAT_SERVO = 184,
            /// <summary> Terminate flight immediately </summary>
            MAV_CMD_DO_FLIGHTTERMINATION = 185,
            /// <summary> Change altitude set point. </summary>
            MAV_CMD_DO_CHANGE_ALTITUDE = 186,
            /// <summary> Sets actuators (e.g. servos) to a desired value. The actuator numbers are mapped to specific outputs (e.g. on any MAIN or AUX PWM or UAVCAN) using a flight-stack specific mechanism (i.e. a parameter). </summary>
            MAV_CMD_DO_SET_ACTUATOR = 187,
            /// <summary> Mission command to perform a landing. This is used as a marker in a mission to tell the autopilot where a sequence of mission items that represents a landing starts. It may also be sent via a COMMAND_LONG to trigger a landing, in which case the nearest (geographically) landing sequence in the mission will be used. The Latitude/Longitude is optional, and may be set to 0 if not needed. If specified then it will be used to help find the closest landing sequence. </summary>
            MAV_CMD_DO_LAND_START = 189,
            /// <summary> Mission command to perform a landing from a rally point. </summary>
            MAV_CMD_DO_RALLY_LAND = 190,
            /// <summary> Mission command to safely abort an autonomous landing. </summary>
            MAV_CMD_DO_GO_AROUND = 191,
            /// <summary> Reposition the vehicle to a specific WGS84 global position. </summary>
            MAV_CMD_DO_REPOSITION = 192,
            /// <summary> If in a GPS controlled position mode, hold the current position or continue. </summary>
            MAV_CMD_DO_PAUSE_CONTINUE = 193,
            /// <summary> Set moving direction to forward or reverse. </summary>
            MAV_CMD_DO_SET_REVERSE = 194,
            /// <summary> Sets the region of interest (ROI) to a location. This can then be used by the vehicle's control system to control the vehicle attitude and the attitude of various sensors such as cameras. This command can be sent to a gimbal manager but not to a gimbal device. A gimbal is not to react to this message. </summary>
            MAV_CMD_DO_SET_ROI_LOCATION = 195,
            /// <summary> Sets the region of interest (ROI) to be toward next waypoint, with optional pitch/roll/yaw offset. This can then be used by the vehicle's control system to control the vehicle attitude and the attitude of various sensors such as cameras. This command can be sent to a gimbal manager but not to a gimbal device. A gimbal device is not to react to this message. </summary>
            MAV_CMD_DO_SET_ROI_WPNEXT_OFFSET = 196,
            /// <summary> Cancels any previous ROI command returning the vehicle/sensors to default flight characteristics. This can then be used by the vehicle's control system to control the vehicle attitude and the attitude of various sensors such as cameras. This command can be sent to a gimbal manager but not to a gimbal device. A gimbal device is not to react to this message. After this command the gimbal manager should go back to manual input if available, and otherwise assume a neutral position. </summary>
            MAV_CMD_DO_SET_ROI_NONE = 197,
            /// <summary> Mount tracks system with specified system ID. Determination of target vehicle position may be done with GLOBAL_POSITION_INT or any other means. This command can be sent to a gimbal manager but not to a gimbal device. A gimbal device is not to react to this message. </summary>
            MAV_CMD_DO_SET_ROI_SYSID = 198,
            /// <summary> Control onboard camera system. </summary>
            MAV_CMD_DO_CONTROL_VIDEO = 200,
            /// <summary> Sets the region of interest (ROI) for a sensor set or the vehicle itself. This can then be used by the vehicle's control system to control the vehicle attitude and the attitude of various sensors such as cameras. </summary>
            MAV_CMD_DO_SET_ROI = 201,
            /// <summary> Configure digital camera. This is a fallback message for systems that have not yet implemented PARAM_EXT_XXX messages and camera definition files (see https://mavlink.io/en/services/camera_def.html ). </summary>
            MAV_CMD_DO_DIGICAM_CONFIGURE = 202,
            /// <summary> Control digital camera. This is a fallback message for systems that have not yet implemented PARAM_EXT_XXX messages and camera definition files (see https://mavlink.io/en/services/camera_def.html ). </summary>
            MAV_CMD_DO_DIGICAM_CONTROL = 203,
            /// <summary> Mission command to configure a camera or antenna mount </summary>
            MAV_CMD_DO_MOUNT_CONFIGURE = 204,
            /// <summary> Mission command to control a camera or antenna mount </summary>
            MAV_CMD_DO_MOUNT_CONTROL = 205,
            /// <summary> Mission command to set camera trigger distance for this flight. The camera is triggered each time this distance is exceeded. This command can also be used to set the shutter integration time for the camera. </summary>
            MAV_CMD_DO_SET_CAM_TRIGG_DIST = 206,
            /// <summary> Mission command to enable the geofence </summary>
            MAV_CMD_DO_FENCE_ENABLE = 207,
            /// <summary> Mission item/command to release a parachute or enable/disable auto release. </summary>
            MAV_CMD_DO_PARACHUTE = 208,
            /// <summary> Mission command to perform motor test. </summary>
            MAV_CMD_DO_MOTOR_TEST = 209,
            /// <summary> Change to/from inverted flight. </summary>
            MAV_CMD_DO_INVERTED_FLIGHT = 210,
            /// <summary> Sets a desired vehicle turn angle and speed change. </summary>
            MAV_CMD_NAV_SET_YAW_SPEED = 213,
            /// <summary> Mission command to set camera trigger interval for this flight. If triggering is enabled, the camera is triggered each time this interval expires. This command can also be used to set the shutter integration time for the camera. </summary>
            MAV_CMD_DO_SET_CAM_TRIGG_INTERVAL = 214,
            /// <summary> Mission command to control a camera or antenna mount, using a quaternion as reference. </summary>
            MAV_CMD_DO_MOUNT_CONTROL_QUAT = 220,
            /// <summary> set id of master controller </summary>
            MAV_CMD_DO_GUIDED_MASTER = 221,
            /// <summary> Set limits for external control </summary>
            MAV_CMD_DO_GUIDED_LIMITS = 222,
            /// <summary> Control vehicle engine. This is interpreted by the vehicles engine controller to change the target engine state. It is intended for vehicles with internal combustion engines </summary>
            MAV_CMD_DO_ENGINE_CONTROL = 223,
            /// <summary> Set the mission item with sequence number seq as current item. This means that the MAV will continue to this mission item on the shortest path (not following the mission items in-between). </summary>
            MAV_CMD_DO_SET_MISSION_CURRENT = 224,
            /// <summary> NOP - This command is only used to mark the upper limit of the DO commands in the enumeration </summary>
            MAV_CMD_DO_LAST = 240,
            /// <summary> Trigger calibration. This command will be only accepted if in pre-flight mode. Except for Temperature Calibration, only one sensor should be set in a single message and all others should be zero. </summary>
            MAV_CMD_PREFLIGHT_CALIBRATION = 241,
            /// <summary> Set sensor offsets. This command will be only accepted if in pre-flight mode. </summary>
            MAV_CMD_PREFLIGHT_SET_SENSOR_OFFSETS = 242,
            /// <summary> Trigger UAVCAN config. This command will be only accepted if in pre-flight mode. </summary>
            MAV_CMD_PREFLIGHT_UAVCAN = 243,
            /// <summary> Request storage of different parameter values and logs. This command will be only accepted if in pre-flight mode. </summary>
            MAV_CMD_PREFLIGHT_STORAGE = 245,
            /// <summary> Request the reboot or shutdown of system components. </summary>
            MAV_CMD_PREFLIGHT_REBOOT_SHUTDOWN = 246,
            /// <summary> Request a target system to start an upgrade of one (or all) of its components. For example, the command might be sent to a companion computer to cause it to upgrade a connected flight controller. The system doing the upgrade will report progress using the normal command protocol sequence for a long running operation. Command protocol information: https://mavlink.io/en/services/command.html. </summary>
            MAV_CMD_DO_UPGRADE = 247,
            /// <summary> Override current mission with command to pause mission, pause mission and move to position, continue/resume mission. When param 1 indicates that the mission is paused (MAV_GOTO_DO_HOLD), param 2 defines whether it holds in place or moves to another position. </summary>
            MAV_CMD_OVERRIDE_GOTO = 252,
            /// <summary> start running a mission </summary>
            MAV_CMD_MISSION_START = 300,
            /// <summary> Arms / Disarms a component </summary>
            MAV_CMD_COMPONENT_ARM_DISARM = 400,
            /// <summary> Turns illuminators ON/OFF. An illuminator is a light source that is used for lighting up dark areas external to the sytstem: e.g. a torch or searchlight (as opposed to a light source for illuminating the system itself, e.g. an indicator light). </summary>
            MAV_CMD_ILLUMINATOR_ON_OFF = 405,
            /// <summary> Request the home position from the vehicle. </summary>
            MAV_CMD_GET_HOME_POSITION = 410,
            /// <summary> Inject artificial failure for testing purposes. Note that autopilots should implement an additional protection before accepting this command such as a specific param setting. </summary>
            MAV_CMD_INJECT_FAILURE = 420,
            /// <summary> Starts receiver pairing. </summary>
            MAV_CMD_START_RX_PAIR = 500,
            /// <summary> Request the interval between messages for a particular MAVLink message ID. The receiver should ACK the command and then emit its response in a MESSAGE_INTERVAL message. </summary>
            MAV_CMD_GET_MESSAGE_INTERVAL = 510,
            /// <summary> Set the interval between messages for a particular MAVLink message ID. This interface replaces REQUEST_DATA_STREAM. </summary>
            MAV_CMD_SET_MESSAGE_INTERVAL = 511,
            /// <summary> Request the target system(s) emit a single instance of a specified message (i.e. a "one-shot" version of MAV_CMD_SET_MESSAGE_INTERVAL). </summary>
            MAV_CMD_REQUEST_MESSAGE = 512,
            /// <summary> Request MAVLink protocol version compatibility. All receivers should ACK the command and then emit their capabilities in an PROTOCOL_VERSION message </summary>
            MAV_CMD_REQUEST_PROTOCOL_VERSION = 519,
            /// <summary> Request autopilot capabilities. The receiver should ACK the command and then emit its capabilities in an AUTOPILOT_VERSION message </summary>
            MAV_CMD_REQUEST_AUTOPILOT_CAPABILITIES = 520,
            /// <summary> Request camera information (CAMERA_INFORMATION). </summary>
            MAV_CMD_REQUEST_CAMERA_INFORMATION = 521,
            /// <summary> Request camera settings (CAMERA_SETTINGS). </summary>
            MAV_CMD_REQUEST_CAMERA_SETTINGS = 522,
            /// <summary> Request storage information (STORAGE_INFORMATION). Use the command's target_component to target a specific component's storage. </summary>
            MAV_CMD_REQUEST_STORAGE_INFORMATION = 525,
            /// <summary> Format a storage medium. Once format is complete, a STORAGE_INFORMATION message is sent. Use the command's target_component to target a specific component's storage. </summary>
            MAV_CMD_STORAGE_FORMAT = 526,
            /// <summary> Request camera capture status (CAMERA_CAPTURE_STATUS) </summary>
            MAV_CMD_REQUEST_CAMERA_CAPTURE_STATUS = 527,
            /// <summary> Request flight information (FLIGHT_INFORMATION) </summary>
            MAV_CMD_REQUEST_FLIGHT_INFORMATION = 528,
            /// <summary> Reset all camera settings to Factory Default </summary>
            MAV_CMD_RESET_CAMERA_SETTINGS = 529,
            /// <summary> Set camera running mode. Use NaN for reserved values. GCS will send a MAV_CMD_REQUEST_VIDEO_STREAM_STATUS command after a mode change if the camera supports video streaming. </summary>
            MAV_CMD_SET_CAMERA_MODE = 530,
            /// <summary> Set camera zoom. Camera must respond with a CAMERA_SETTINGS message (on success). </summary>
            MAV_CMD_SET_CAMERA_ZOOM = 531,
            /// <summary> Set camera focus. Camera must respond with a CAMERA_SETTINGS message (on success). </summary>
            MAV_CMD_SET_CAMERA_FOCUS = 532,
            /// <summary> Tagged jump target. Can be jumped to with MAV_CMD_DO_JUMP_TAG. </summary>
            MAV_CMD_JUMP_TAG = 600,
            /// <summary> Jump to the matching tag in the mission list. Repeat this action for the specified number of times. A mission should contain a single matching tag for each jump. If this is not the case then a jump to a missing tag should complete the mission, and a jump where there are multiple matching tags should always select the one with the lowest mission sequence number. </summary>
            MAV_CMD_DO_JUMP_TAG = 601,
            /// <summary> High level setpoint to be sent to a gimbal manager to set a gimbal attitude. It is possible to set combinations of the values below. E.g. an angle as well as a desired angular rate can be used to get to this angle at a certain angular rate, or an angular rate only will result in continuous turning. NaN is to be used to signal unset. Note: a gimbal is never to react to this command but only the gimbal manager. </summary>
            MAV_CMD_DO_GIMBAL_MANAGER_TILTPAN = 1000,
            /// <summary> If the gimbal manager supports visual tracking (GIMBAL_MANAGER_CAP_FLAGS_HAS_TRACKING_POINT is set), this command allows to initiate the tracking. Such a tracking gimbal manager would usually be an integrated camera/gimbal, or alternatively a companion computer connected to a camera. </summary>
            MAV_CMD_DO_GIMBAL_MANAGER_TRACK_POINT = 1001,
            /// <summary> If the gimbal supports visual tracking (GIMBAL_MANAGER_CAP_FLAGS_HAS_TRACKING_RECTANGLE is set), this command allows to initiate the tracking. Such a tracking gimbal manager would usually be an integrated camera/gimbal, or alternatively a companion computer connected to a camera. </summary>
            MAV_CMD_DO_GIMBAL_MANAGER_TRACK_RECTANGLE = 1002,
            /// <summary> Start image capture sequence. Sends CAMERA_IMAGE_CAPTURED after each capture. Use NaN for reserved values. </summary>
            MAV_CMD_IMAGE_START_CAPTURE = 2000,
            /// <summary> Stop image capture sequence Use NaN for reserved values. </summary>
            MAV_CMD_IMAGE_STOP_CAPTURE = 2001,
            /// <summary> Re-request a CAMERA_IMAGE_CAPTURED message. </summary>
            MAV_CMD_REQUEST_CAMERA_IMAGE_CAPTURE = 2002,
            /// <summary> Enable or disable on-board camera triggering system. </summary>
            MAV_CMD_DO_TRIGGER_CONTROL = 2003,
            /// <summary> Starts video capture (recording). </summary>
            MAV_CMD_VIDEO_START_CAPTURE = 2500,
            /// <summary> Stop the current video capture (recording). </summary>
            MAV_CMD_VIDEO_STOP_CAPTURE = 2501,
            /// <summary> Start video streaming </summary>
            MAV_CMD_VIDEO_START_STREAMING = 2502,
            /// <summary> Stop the given video stream </summary>
            MAV_CMD_VIDEO_STOP_STREAMING = 2503,
            /// <summary> Request video stream information (VIDEO_STREAM_INFORMATION) </summary>
            MAV_CMD_REQUEST_VIDEO_STREAM_INFORMATION = 2504,
            /// <summary> Request video stream status (VIDEO_STREAM_STATUS) </summary>
            MAV_CMD_REQUEST_VIDEO_STREAM_STATUS = 2505,
            /// <summary> Request to start streaming logging data over MAVLink (see also LOGGING_DATA message) </summary>
            MAV_CMD_LOGGING_START = 2510,
            /// <summary> Request to stop streaming log data over MAVLink </summary>
            MAV_CMD_LOGGING_STOP = 2511,
            /// <summary>  </summary>
            MAV_CMD_AIRFRAME_CONFIGURATION = 2520,
            /// <summary> Request to start/stop transmitting over the high latency telemetry </summary>
            MAV_CMD_CONTROL_HIGH_LATENCY = 2600,
            /// <summary> Create a panorama at the current position </summary>
            MAV_CMD_PANORAMA_CREATE = 2800,
            /// <summary> Request VTOL transition </summary>
            MAV_CMD_DO_VTOL_TRANSITION = 3000,
            /// <summary> Request authorization to arm the vehicle to a external entity, the arm authorizer is responsible to request all data that is needs from the vehicle before authorize or deny the request. 
            /// If approved the progress of command_ack message should be set with period of time that this authorization is valid in seconds or in case it was denied it should be set with one of the reasons in ARM_AUTH_DENIED_REASON. </summary>
            MAV_CMD_ARM_AUTHORIZATION_REQUEST = 3001,
            /// <summary> This command sets the submode to standard guided when vehicle is in guided mode. The vehicle holds position and altitude and the user can input the desired velocities along all three axes. </summary>
            MAV_CMD_SET_GUIDED_SUBMODE_STANDARD = 4000,
            /// <summary> This command sets submode circle when vehicle is in guided mode. Vehicle flies along a circle facing the center of the circle. The user can input the velocity along the circle and change the radius. If no input is given the vehicle will hold position. </summary>
            MAV_CMD_SET_GUIDED_SUBMODE_CIRCLE = 4001,
            /// <summary> Delay mission state machine until gate has been reached. </summary>
            MAV_CMD_CONDITION_GATE = 4501,
            /// <summary> Fence return point. There can only be one fence return point. </summary>
            MAV_CMD_NAV_FENCE_RETURN_POINT = 5000,
            /// <summary> Fence vertex for an inclusion polygon (the polygon must not be self-intersecting). The vehicle must stay within this area. Minimum of 3 vertices required. </summary>
            MAV_CMD_NAV_FENCE_POLYGON_VERTEX_INCLUSION = 5001,
            /// <summary> Fence vertex for an exclusion polygon (the polygon must not be self-intersecting). The vehicle must stay outside this area. Minimum of 3 vertices required. </summary>
            MAV_CMD_NAV_FENCE_POLYGON_VERTEX_EXCLUSION = 5002,
            /// <summary> Circular fence area. The vehicle must stay inside this area. </summary>
            MAV_CMD_NAV_FENCE_CIRCLE_INCLUSION = 5003,
            /// <summary> Circular fence area. The vehicle must stay outside this area. </summary>
            MAV_CMD_NAV_FENCE_CIRCLE_EXCLUSION = 5004,
            /// <summary> Rally point. You can have multiple rally points defined. </summary>
            MAV_CMD_NAV_RALLY_POINT = 5100,
            /// <summary> Commands the vehicle to respond with a sequence of messages UAVCAN_NODE_INFO, one message per every UAVCAN node that is online. Note that some of the response messages can be lost, which the receiver can detect easily by checking whether every received UAVCAN_NODE_STATUS has a matching message UAVCAN_NODE_INFO received earlier; if not, this command should be sent again in order to request re-transmission of the node information messages. </summary>
            MAV_CMD_UAVCAN_GET_NODE_INFO = 5200,
            /// <summary> Deploy payload on a Lat / Lon / Alt position. This includes the navigation to reach the required release position and velocity. </summary>
            MAV_CMD_PAYLOAD_PREPARE_DEPLOY = 30001,
            /// <summary> Control the payload deployment. </summary>
            MAV_CMD_PAYLOAD_CONTROL_DEPLOY = 30002,
            /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
            MAV_CMD_WAYPOINT_USER_1 = 31000,
            /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
            MAV_CMD_WAYPOINT_USER_2 = 31001,
            /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
            MAV_CMD_WAYPOINT_USER_3 = 31002,
            /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
            MAV_CMD_WAYPOINT_USER_4 = 31003,
            /// <summary> User defined waypoint item. Ground Station will show the Vehicle as flying through this item. </summary>
            MAV_CMD_WAYPOINT_USER_5 = 31004,
            /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
            MAV_CMD_SPATIAL_USER_1 = 31005,
            /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
            MAV_CMD_SPATIAL_USER_2 = 31006,
            /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
            MAV_CMD_SPATIAL_USER_3 = 31007,
            /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
            MAV_CMD_SPATIAL_USER_4 = 31008,
            /// <summary> User defined spatial item. Ground Station will not show the Vehicle as flying through this item. Example: ROI item. </summary>
            MAV_CMD_SPATIAL_USER_5 = 31009,
            /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
            MAV_CMD_USER_1 = 31010,
            /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
            MAV_CMD_USER_2 = 31011,
            /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
            MAV_CMD_USER_3 = 31012,
            /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
            MAV_CMD_USER_4 = 31013,
            /// <summary> User defined command. Ground Station will not show the Vehicle as flying through this item. Example: MAV_CMD_DO_SET_PARAMETER item. </summary>
            MAV_CMD_USER_5 = 31014,
        }

        /// <summary> A data stream is not a fixed set of messages, but rather a recommendation to the autopilot software.Individual autopilots may or may not obey the recommended messages. </summary>
        public enum MAV_DATA_STREAM
        {
            /// <summary> Enable all data streams </summary>
            MAV_DATA_STREAM_ALL = 0,
            /// <summary> Enable IMU_RAW, GPS_RAW, GPS_STATUS packets. </summary>
            MAV_DATA_STREAM_RAW_SENSORS = 1,
            /// <summary> Enable GPS_STATUS, CONTROL_STATUS, AUX_STATUS </summary>
            MAV_DATA_STREAM_EXTENDED_STATUS = 2,
            /// <summary> Enable RC_CHANNELS_SCALED, RC_CHANNELS_RAW, SERVO_OUTPUT_RAW </summary>
            MAV_DATA_STREAM_RC_CHANNELS = 3,
            /// <summary> Enable ATTITUDE_CONTROLLER_OUTPUT, POSITION_CONTROLLER_OUTPUT, NAV_CONTROLLER_OUTPUT. </summary>
            MAV_DATA_STREAM_RAW_CONTROLLER = 4,
            /// <summary> Enable LOCAL_POSITION, GLOBAL_POSITION/GLOBAL_POSITION_INT messages. </summary>
            MAV_DATA_STREAM_POSITION = 6,
            /// <summary> Dependent on the autopilot </summary>
            MAV_DATA_STREAM_EXTRA1 = 10,
            /// <summary> Dependent on the autopilot </summary>
            MAV_DATA_STREAM_EXTRA2 = 11,
            /// <summary> Dependent on the autopilot </summary>
            MAV_DATA_STREAM_EXTRA3 = 12,
        }
        /// <summary> The ROI (region of interest) for the vehicle. This can be used by the vehicle for camera/vehicle attitude alignment(see MAV_CMD_NAV_ROI). </summary>
        public enum MAV_ROI
        {
            /// <summary> No region of interest. </summary>
            MAV_ROI_NONE = 0,
            /// <summary> Point toward next waypoint, with optional pitch/roll/yaw offset. </summary>
            MAV_ROI_WPNEXT = 1,
            /// <summary> Point toward given waypoint. </summary>
            MAV_ROI_WPINDEX = 2,
            /// <summary> Point toward fixed location. </summary>
            MAV_ROI_LOCATION = 3,
            /// <summary> Point toward of given id. </summary>
            MAV_ROI_TARGET = 4,
        }
        /// <summary> ACK / NACK / ERROR values as a result of MAV_CMDs and for mission item transmission. </summary>
        public enum MAV_CMD_ACK
        {
            /// <summary> Command / mission item is ok. </summary>
            MAV_CMD_ACK_OK,/// <summary> Generic error message if none of the other reasons fails or if no detailed error reporting is implemented. </summary>
            MAV_CMD_ACK_ERR_FAIL,/// <summary> The system is refusing to accept this command from this source / communication partner. </summary>
            MAV_CMD_ACK_ERR_ACCESS_DENIED,/// <summary> Command or mission item is not supported, other commands would be accepted. </summary>
            MAV_CMD_ACK_ERR_NOT_SUPPORTED,/// <summary> The coordinate frame of this command / mission item is not supported. </summary>
            MAV_CMD_ACK_ERR_COORDINATE_FRAME_NOT_SUPPORTED,/// <summary> The coordinate frame of this command is ok, but he coordinate values exceed the safety limits of this system. This is a generic error, please use the more specific error messages below if possible. </summary>
            MAV_CMD_ACK_ERR_COORDINATES_OUT_OF_RANGE,/// <summary> The X or latitude value is out of range. </summary>
            MAV_CMD_ACK_ERR_X_LAT_OUT_OF_RANGE,/// <summary> The Y or longitude value is out of range. </summary>
            MAV_CMD_ACK_ERR_Y_LON_OUT_OF_RANGE,/// <summary> The Z or altitude value is out of range. </summary>
            MAV_CMD_ACK_ERR_Z_ALT_OUT_OF_RANGE,
        }
        /// <summary> Specifies the datatype of a MAVLink parameter. </summary>
        public enum MAV_PARAM_TYPE
        {
            /// <summary> 8-bit unsigned integer </summary>
            MAV_PARAM_TYPE_UINT8 = 1,
            /// <summary> 8-bit signed integer </summary>
            MAV_PARAM_TYPE_INT8 = 2,
            /// <summary> 16-bit unsigned integer </summary>
            MAV_PARAM_TYPE_UINT16 = 3,
            /// <summary> 16-bit signed integer </summary>
            MAV_PARAM_TYPE_INT16 = 4,
            /// <summary> 32-bit unsigned integer </summary>
            MAV_PARAM_TYPE_UINT32 = 5,
            /// <summary> 32-bit signed integer </summary>
            MAV_PARAM_TYPE_INT32 = 6,
            /// <summary> 64-bit unsigned integer </summary>
            MAV_PARAM_TYPE_UINT64 = 7,
            /// <summary> 64-bit signed integer </summary>
            MAV_PARAM_TYPE_INT64 = 8,
            /// <summary> 32-bit floating-point </summary>
            MAV_PARAM_TYPE_REAL32 = 9,
            /// <summary> 64-bit floating-point </summary>
            MAV_PARAM_TYPE_REAL64 = 10,
        }
        /// <summary> Specifies the datatype of a MAVLink extended parameter. </summary>
        public enum MAV_PARAM_EXT_TYPE
        {
            /// <summary> 8-bit unsigned integer </summary>
            MAV_PARAM_EXT_TYPE_UINT8 = 1,
            /// <summary> 8-bit signed integer </summary>
            MAV_PARAM_EXT_TYPE_INT8 = 2,
            /// <summary> 16-bit unsigned integer </summary>
            MAV_PARAM_EXT_TYPE_UINT16 = 3,
            /// <summary> 16-bit signed integer </summary>
            MAV_PARAM_EXT_TYPE_INT16 = 4,
            /// <summary> 32-bit unsigned integer </summary>
            MAV_PARAM_EXT_TYPE_UINT32 = 5,
            /// <summary> 32-bit signed integer </summary>
            MAV_PARAM_EXT_TYPE_INT32 = 6,
            /// <summary> 64-bit unsigned integer </summary>
            MAV_PARAM_EXT_TYPE_UINT64 = 7,
            /// <summary> 64-bit signed integer </summary>
            MAV_PARAM_EXT_TYPE_INT64 = 8,
            /// <summary> 32-bit floating-point </summary>
            MAV_PARAM_EXT_TYPE_REAL32 = 9,
            /// <summary> 64-bit floating-point </summary>
            MAV_PARAM_EXT_TYPE_REAL64 = 10,
            /// <summary> Custom Type </summary>
            MAV_PARAM_EXT_TYPE_CUSTOM = 11,
        }
        /// <summary> Result from a MAVLink command (MAV_CMD) </summary>
        public enum MAV_RESULT
        {
            /// <summary> Command is valid (is supported and has valid parameters), and was executed. </summary>
            MAV_RESULT_ACCEPTED = 0,
            /// <summary> Command is valid, but cannot be executed at this time. This is used to indicate a problem that should be fixed just by waiting (e.g. a state machine is busy, can't arm because have not got GPS lock, etc.). Retrying later should work. </summary>
            MAV_RESULT_TEMPORARILY_REJECTED = 1,
            /// <summary> Command is invalid (is supported but has invalid parameters). Retrying same command and parameters will not work. </summary>
            MAV_RESULT_DENIED = 2,
            /// <summary> Command is not supported (unknown). </summary>
            MAV_RESULT_UNSUPPORTED = 3,
            /// <summary> Command is valid, but execution has failed. This is used to indicate any non-temporary or unexpected problem, i.e. any problem that must be fixed before the command can succeed/be retried. For example, attempting to write a file when out of memory, attempting to arm when sensors are not calibrated, etc. </summary>
            MAV_RESULT_FAILED = 4,
            /// <summary> Command is valid and is being executed. This will be followed by further progress updates, i.e. the component may send further COMMAND_ACK messages with result MAV_RESULT_IN_PROGRESS (at a rate decided by the implementation), and must terminate by sending a COMMAND_ACK message with final result of the operation. The COMMAND_ACK.progress field can be used to indicate the progress of the operation. </summary>
            MAV_RESULT_IN_PROGRESS = 5,
            /// <summary> Command has been cancelled (as a result of receiving a COMMAND_CANCEL message). </summary>
            MAV_RESULT_CANCELLED = 6,
        }
        /// <summary> Result of mission operation (in a MISSION_ACK message). </summary>
        public enum MAV_MISSION_RESULT
        {
            /// <summary> mission accepted OK </summary>
            MAV_MISSION_ACCEPTED = 0,
            /// <summary> Generic error / not accepting mission commands at all right now. </summary>
            MAV_MISSION_ERROR = 1,
            /// <summary> Coordinate frame is not supported. </summary>
            MAV_MISSION_UNSUPPORTED_FRAME = 2,
            /// <summary> Command is not supported. </summary>
            MAV_MISSION_UNSUPPORTED = 3,
            /// <summary> Mission items exceed storage space. </summary>
            MAV_MISSION_NO_SPACE = 4,
            /// <summary> One of the parameters has an invalid value. </summary>
            MAV_MISSION_INVALID = 5,
            /// <summary> param1 has an invalid value. </summary>
            MAV_MISSION_INVALID_PARAM1 = 6,
            /// <summary> param2 has an invalid value. </summary>
            MAV_MISSION_INVALID_PARAM2 = 7,
            /// <summary> param3 has an invalid value. </summary>
            MAV_MISSION_INVALID_PARAM3 = 8,
            /// <summary> param4 has an invalid value. </summary>
            MAV_MISSION_INVALID_PARAM4 = 9,
            /// <summary> x / param5 has an invalid value. </summary>
            MAV_MISSION_INVALID_PARAM5_X = 10,
            /// <summary> y / param6 has an invalid value. </summary>
            MAV_MISSION_INVALID_PARAM6_Y = 11,
            /// <summary> z / param7 has an invalid value. </summary>
            MAV_MISSION_INVALID_PARAM7 = 12,
            /// <summary> Mission item received out of sequence </summary>
            MAV_MISSION_INVALID_SEQUENCE = 13,
            /// <summary> Not accepting any mission commands from this communication partner. </summary>
            MAV_MISSION_DENIED = 14,
            /// <summary> Current mission operation cancelled (e.g. mission upload, mission download). </summary>
            MAV_MISSION_OPERATION_CANCELLED = 15,
        }
        /// <summary> Indicates the severity level, generally used for status messages to indicate their relative urgency. Based on RFC-5424 using expanded definitions at: http://www.kiwisyslog.com/kb/info:-syslog-message-levels/. </summary>
        public enum MAV_SEVERITY
        {
            /// <summary> System is unusable. This is a "panic" condition. </summary>
            MAV_SEVERITY_EMERGENCY = 0,
            /// <summary> Action should be taken immediately. Indicates error in non-critical systems. </summary>
            MAV_SEVERITY_ALERT = 1,
            /// <summary> Action must be taken immediately. Indicates failure in a primary system. </summary>
            MAV_SEVERITY_CRITICAL = 2,
            /// <summary> Indicates an error in secondary/redundant systems. </summary>
            MAV_SEVERITY_ERROR = 3,
            /// <summary> Indicates about a possible future error if this is not resolved within a given timeframe. Example would be a low battery warning. </summary>
            MAV_SEVERITY_WARNING = 4,
            /// <summary> An unusual event has occurred, though not an error condition. This should be investigated for the root cause. </summary>
            MAV_SEVERITY_NOTICE = 5,
            /// <summary> Normal operational messages. Useful for logging. No action is required for these messages. </summary>
            MAV_SEVERITY_INFO = 6,
            /// <summary> Useful non-operational messages that can assist in debugging. These should not occur during normal operation. </summary>
            MAV_SEVERITY_DEBUG = 7,
        }
        /// <summary> Power supply status flags (bitmask) </summary>
        public enum MAV_POWER_STATUS
        {
            /// <summary> main brick power supply valid </summary>
            MAV_POWER_STATUS_BRICK_VALID = 1,
            /// <summary> main servo power supply valid for FMU </summary>
            MAV_POWER_STATUS_SERVO_VALID = 2,
            /// <summary> USB power is connected </summary>
            MAV_POWER_STATUS_USB_CONNECTED = 4,
            /// <summary> peripheral supply is in over-current state </summary>
            MAV_POWER_STATUS_PERIPH_OVERCURRENT = 8,
            /// <summary> hi-power peripheral supply is in over-current state </summary>
            MAV_POWER_STATUS_PERIPH_HIPOWER_OVERCURRENT = 16,
            /// <summary> Power status has changed since boot </summary>
            MAV_POWER_STATUS_CHANGED = 32,
        }
        /// <summary> SERIAL_CONTROL device types </summary>
        public enum SERIAL_CONTROL_DEV
        {
            /// <summary> First telemetry port </summary>
            SERIAL_CONTROL_DEV_TELEM1 = 0,
            /// <summary> Second telemetry port </summary>
            SERIAL_CONTROL_DEV_TELEM2 = 1,
            /// <summary> First GPS port </summary>
            SERIAL_CONTROL_DEV_GPS1 = 2,
            /// <summary> Second GPS port </summary>
            SERIAL_CONTROL_DEV_GPS2 = 3,
            /// <summary> system shell </summary>
            SERIAL_CONTROL_DEV_SHELL = 10,
            /// <summary> SERIAL0 </summary>
            SERIAL_CONTROL_SERIAL0 = 100,
            /// <summary> SERIAL1 </summary>
            SERIAL_CONTROL_SERIAL1 = 101,
            /// <summary> SERIAL2 </summary>
            SERIAL_CONTROL_SERIAL2 = 102,
            /// <summary> SERIAL3 </summary>
            SERIAL_CONTROL_SERIAL3 = 103,
            /// <summary> SERIAL4 </summary>
            SERIAL_CONTROL_SERIAL4 = 104,
            /// <summary> SERIAL5 </summary>
            SERIAL_CONTROL_SERIAL5 = 105,
            /// <summary> SERIAL6 </summary>
            SERIAL_CONTROL_SERIAL6 = 106,
            /// <summary> SERIAL7 </summary>
            SERIAL_CONTROL_SERIAL7 = 107,
            /// <summary> SERIAL8 </summary>
            SERIAL_CONTROL_SERIAL8 = 108,
            /// <summary> SERIAL9 </summary>
            SERIAL_CONTROL_SERIAL9 = 109,
        }
        /// <summary> SERIAL_CONTROL flags (bitmask) </summary>
        public enum SERIAL_CONTROL_FLAG
        {
            /// <summary> Set if this is a reply </summary>
            SERIAL_CONTROL_FLAG_REPLY = 1,
            /// <summary> Set if the sender wants the receiver to send a response as another SERIAL_CONTROL message </summary>
            SERIAL_CONTROL_FLAG_RESPOND = 2,
            /// <summary> Set if access to the serial port should be removed from whatever driver is currently using it, giving exclusive access to the SERIAL_CONTROL protocol. The port can be handed back by sending a request without this flag set </summary>
            SERIAL_CONTROL_FLAG_EXCLUSIVE = 4,
            /// <summary> Block on writes to the serial port </summary>
            SERIAL_CONTROL_FLAG_BLOCKING = 8,
            /// <summary> Send multiple replies until port is drained </summary>
            SERIAL_CONTROL_FLAG_MULTI = 16,
        }
        /// <summary> Enumeration of distance sensor types </summary>
        public enum MAV_DISTANCE_SENSOR
        {
            /// <summary> Laser rangefinder, e.g. LightWare SF02/F or PulsedLight units </summary>
            MAV_DISTANCE_SENSOR_LASER = 0,
            /// <summary> Ultrasound rangefinder, e.g. MaxBotix units </summary>
            MAV_DISTANCE_SENSOR_ULTRASOUND = 1,
            /// <summary> Infrared rangefinder, e.g. Sharp units </summary>
            MAV_DISTANCE_SENSOR_INFRARED = 2,
            /// <summary> Radar type, e.g. uLanding units </summary>
            MAV_DISTANCE_SENSOR_RADAR = 3,
            /// <summary> Broken or unknown type, e.g. analog units </summary>
            MAV_DISTANCE_SENSOR_UNKNOWN = 4,
        }
        /// <summary> Enumeration of sensor orientation, according to its rotations </summary>
        public enum MAV_SENSOR_ORIENTATION
        {
            /// <summary> Roll: 0, Pitch: 0, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_NONE = 0,
            /// <summary> Roll: 0, Pitch: 0, Yaw: 45 </summary>
            MAV_SENSOR_ROTATION_YAW_45 = 1,
            /// <summary> Roll: 0, Pitch: 0, Yaw: 90 </summary>
            MAV_SENSOR_ROTATION_YAW_90 = 2,
            /// <summary> Roll: 0, Pitch: 0, Yaw: 135 </summary>
            MAV_SENSOR_ROTATION_YAW_135 = 3,
            /// <summary> Roll: 0, Pitch: 0, Yaw: 180 </summary>
            MAV_SENSOR_ROTATION_YAW_180 = 4,
            /// <summary> Roll: 0, Pitch: 0, Yaw: 225 </summary>
            MAV_SENSOR_ROTATION_YAW_225 = 5,
            /// <summary> Roll: 0, Pitch: 0, Yaw: 270 </summary>
            MAV_SENSOR_ROTATION_YAW_270 = 6,
            /// <summary> Roll: 0, Pitch: 0, Yaw: 315 </summary>
            MAV_SENSOR_ROTATION_YAW_315 = 7,
            /// <summary> Roll: 180, Pitch: 0, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_180 = 8,
            /// <summary> Roll: 180, Pitch: 0, Yaw: 45 </summary>
            MAV_SENSOR_ROTATION_ROLL_180_YAW_45 = 9,
            /// <summary> Roll: 180, Pitch: 0, Yaw: 90 </summary>
            MAV_SENSOR_ROTATION_ROLL_180_YAW_90 = 10,
            /// <summary> Roll: 180, Pitch: 0, Yaw: 135 </summary>
            MAV_SENSOR_ROTATION_ROLL_180_YAW_135 = 11,
            /// <summary> Roll: 0, Pitch: 180, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_PITCH_180 = 12,
            /// <summary> Roll: 180, Pitch: 0, Yaw: 225 </summary>
            MAV_SENSOR_ROTATION_ROLL_180_YAW_225 = 13,
            /// <summary> Roll: 180, Pitch: 0, Yaw: 270 </summary>
            MAV_SENSOR_ROTATION_ROLL_180_YAW_270 = 14,
            /// <summary> Roll: 180, Pitch: 0, Yaw: 315 </summary>
            MAV_SENSOR_ROTATION_ROLL_180_YAW_315 = 15,
            /// <summary> Roll: 90, Pitch: 0, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_90 = 16,
            /// <summary> Roll: 90, Pitch: 0, Yaw: 45 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_YAW_45 = 17,
            /// <summary> Roll: 90, Pitch: 0, Yaw: 90 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_YAW_90 = 18,
            /// <summary> Roll: 90, Pitch: 0, Yaw: 135 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_YAW_135 = 19,
            /// <summary> Roll: 270, Pitch: 0, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_270 = 20,
            /// <summary> Roll: 270, Pitch: 0, Yaw: 45 </summary>
            MAV_SENSOR_ROTATION_ROLL_270_YAW_45 = 21,
            /// <summary> Roll: 270, Pitch: 0, Yaw: 90 </summary>
            MAV_SENSOR_ROTATION_ROLL_270_YAW_90 = 22,
            /// <summary> Roll: 270, Pitch: 0, Yaw: 135 </summary>
            MAV_SENSOR_ROTATION_ROLL_270_YAW_135 = 23,
            /// <summary> Roll: 0, Pitch: 90, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_PITCH_90 = 24,
            /// <summary> Roll: 0, Pitch: 270, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_PITCH_270 = 25,
            /// <summary> Roll: 0, Pitch: 180, Yaw: 90 </summary>
            MAV_SENSOR_ROTATION_PITCH_180_YAW_90 = 26,
            /// <summary> Roll: 0, Pitch: 180, Yaw: 270 </summary>
            MAV_SENSOR_ROTATION_PITCH_180_YAW_270 = 27,
            /// <summary> Roll: 90, Pitch: 90, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_PITCH_90 = 28,
            /// <summary> Roll: 180, Pitch: 90, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_180_PITCH_90 = 29,
            /// <summary> Roll: 270, Pitch: 90, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_270_PITCH_90 = 30,
            /// <summary> Roll: 90, Pitch: 180, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_PITCH_180 = 31,
            /// <summary> Roll: 270, Pitch: 180, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_270_PITCH_180 = 32,
            /// <summary> Roll: 90, Pitch: 270, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_PITCH_270 = 33,
            /// <summary> Roll: 180, Pitch: 270, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_180_PITCH_270 = 34,
            /// <summary> Roll: 270, Pitch: 270, Yaw: 0 </summary>
            MAV_SENSOR_ROTATION_ROLL_270_PITCH_270 = 35,
            /// <summary> Roll: 90, Pitch: 180, Yaw: 90 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_PITCH_180_YAW_90 = 36,
            /// <summary> Roll: 90, Pitch: 0, Yaw: 270 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_YAW_270 = 37,
            /// <summary> Roll: 90, Pitch: 68, Yaw: 293 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_PITCH_68_YAW_293 = 38,
            /// <summary> Pitch: 315 </summary>
            MAV_SENSOR_ROTATION_PITCH_315 = 39,
            /// <summary> Roll: 90, Pitch: 315 </summary>
            MAV_SENSOR_ROTATION_ROLL_90_PITCH_315 = 40,
            /// <summary> Roll: 270, Yaw: 180 </summary>
            MAV_SENSOR_ROTATION_ROLL_270_YAW_180 = 41,
            /// <summary> Custom orientation </summary>
            MAV_SENSOR_ROTATION_CUSTOM = 100,
        }
        /// <summary> Bitmask of (optional) autopilot capabilities (64 bit). If a bit is set, the autopilot supports this capability. </summary>
        public enum MAV_PROTOCOL_CAPABILITY
        {
            /// <summary> Autopilot supports MISSION float message type. </summary>
            MAV_PROTOCOL_CAPABILITY_MISSION_FLOAT = 1,
            /// <summary> Autopilot supports the new param float message type. </summary>
            MAV_PROTOCOL_CAPABILITY_PARAM_FLOAT = 2,
            /// <summary> Autopilot supports MISSION_ITEM_INT scaled integer message type. </summary>
            MAV_PROTOCOL_CAPABILITY_MISSION_INT = 4,
            /// <summary> Autopilot supports COMMAND_INT scaled integer message type. </summary>
            MAV_PROTOCOL_CAPABILITY_COMMAND_INT = 8,
            /// <summary> Autopilot supports the new param union message type. </summary>
            MAV_PROTOCOL_CAPABILITY_PARAM_UNION = 16,
            /// <summary> Autopilot supports the new FILE_TRANSFER_PROTOCOL message type. </summary>
            MAV_PROTOCOL_CAPABILITY_FTP = 32,
            /// <summary> Autopilot supports commanding attitude offboard. </summary>
            MAV_PROTOCOL_CAPABILITY_SET_ATTITUDE_TARGET = 64,
            /// <summary> Autopilot supports commanding position and velocity targets in local NED frame. </summary>
            MAV_PROTOCOL_CAPABILITY_SET_POSITION_TARGET_LOCAL_NED = 128,
            /// <summary> Autopilot supports commanding position and velocity targets in global scaled integers. </summary>
            MAV_PROTOCOL_CAPABILITY_SET_POSITION_TARGET_GLOBAL_INT = 256,
            /// <summary> Autopilot supports terrain protocol / data handling. </summary>
            MAV_PROTOCOL_CAPABILITY_TERRAIN = 512,
            /// <summary> Autopilot supports direct actuator control. </summary>
            MAV_PROTOCOL_CAPABILITY_SET_ACTUATOR_TARGET = 1024,
            /// <summary> Autopilot supports the flight termination command. </summary>
            MAV_PROTOCOL_CAPABILITY_FLIGHT_TERMINATION = 2048,
            /// <summary> Autopilot supports onboard compass calibration. </summary>
            MAV_PROTOCOL_CAPABILITY_COMPASS_CALIBRATION = 4096,
            /// <summary> Autopilot supports MAVLink version 2. </summary>
            MAV_PROTOCOL_CAPABILITY_MAVLINK2 = 8192,
            /// <summary> Autopilot supports mission fence protocol. </summary>
            MAV_PROTOCOL_CAPABILITY_MISSION_FENCE = 16384,
            /// <summary> Autopilot supports mission rally point protocol. </summary>
            MAV_PROTOCOL_CAPABILITY_MISSION_RALLY = 32768,
            /// <summary> Autopilot supports the flight information protocol. </summary>
            MAV_PROTOCOL_CAPABILITY_FLIGHT_INFORMATION = 65536,
        }
        /// <summary> Type of mission items being requested/sent in mission protocol. </summary>
        public enum MAV_MISSION_TYPE
        {
            /// <summary> Items are mission commands for main mission. </summary>
            MAV_MISSION_TYPE_MISSION = 0,
            /// <summary> Specifies GeoFence area(s). Items are MAV_CMD_NAV_FENCE_ GeoFence items. </summary>
            MAV_MISSION_TYPE_FENCE = 1,
            /// <summary> Specifies the rally points for the vehicle. Rally points are alternative RTL points. Items are MAV_CMD_NAV_RALLY_POINT rally point items. </summary>
            MAV_MISSION_TYPE_RALLY = 2,
            /// <summary> Only used in MISSION_CLEAR_ALL to clear all mission types. </summary>
            MAV_MISSION_TYPE_ALL = 255,
        }
        /// <summary> Enumeration of estimator types </summary>
        public enum MAV_ESTIMATOR_TYPE
        {
            /// <summary> Unknown type of the estimator. </summary>
            MAV_ESTIMATOR_TYPE_UNKNOWN = 0,
            /// <summary> This is a naive estimator without any real covariance feedback. </summary>
            MAV_ESTIMATOR_TYPE_NAIVE = 1,
            /// <summary> Computer vision based estimate. Might be up to scale. </summary>
            MAV_ESTIMATOR_TYPE_VISION = 2,
            /// <summary> Visual-inertial estimate. </summary>
            MAV_ESTIMATOR_TYPE_VIO = 3,
            /// <summary> Plain GPS estimate. </summary>
            MAV_ESTIMATOR_TYPE_GPS = 4,
            /// <summary> Estimator integrating GPS and inertial sensing. </summary>
            MAV_ESTIMATOR_TYPE_GPS_INS = 5,
            /// <summary> Estimate from external motion capturing system. </summary>
            MAV_ESTIMATOR_TYPE_MOCAP = 6,
            /// <summary> Estimator based on lidar sensor input. </summary>
            MAV_ESTIMATOR_TYPE_LIDAR = 7,
            /// <summary> Estimator on autopilot. </summary>
            MAV_ESTIMATOR_TYPE_AUTOPILOT = 8,
        }
        /// <summary> Enumeration of battery types </summary>
        public enum MAV_BATTERY_TYPE
        {
            /// <summary> Not specified. </summary>
            MAV_BATTERY_TYPE_UNKNOWN = 0,
            /// <summary> Lithium polymer battery </summary>
            MAV_BATTERY_TYPE_LIPO = 1,
            /// <summary> Lithium-iron-phosphate battery </summary>
            MAV_BATTERY_TYPE_LIFE = 2,
            /// <summary> Lithium-ION battery </summary>
            MAV_BATTERY_TYPE_LION = 3,
            /// <summary> Nickel metal hydride battery </summary>
            MAV_BATTERY_TYPE_NIMH = 4,
        }
        /// <summary> Enumeration of battery functions </summary>
        public enum MAV_BATTERY_FUNCTION
        {
            /// <summary> Battery function is unknown </summary>
            MAV_BATTERY_FUNCTION_UNKNOWN = 0,
            /// <summary> Battery supports all flight systems </summary>
            MAV_BATTERY_FUNCTION_ALL = 1,
            /// <summary> Battery for the propulsion system </summary>
            MAV_BATTERY_FUNCTION_PROPULSION = 2,
            /// <summary> Avionics battery </summary>
            MAV_BATTERY_FUNCTION_AVIONICS = 3,
            /// <summary> Payload battery </summary>
            MAV_BATTERY_TYPE_PAYLOAD = 4,
        }
        /// <summary> Enumeration for battery charge states. </summary>
        public enum MAV_BATTERY_CHARGE_STATE
        {
            /// <summary> Low battery state is not provided </summary>
            MAV_BATTERY_CHARGE_STATE_UNDEFINED = 0,
            /// <summary> Battery is not in low state. Normal operation. </summary>
            MAV_BATTERY_CHARGE_STATE_OK = 1,
            /// <summary> Battery state is low, warn and monitor close. </summary>
            MAV_BATTERY_CHARGE_STATE_LOW = 2,
            /// <summary> Battery state is critical, return or abort immediately. </summary>
            MAV_BATTERY_CHARGE_STATE_CRITICAL = 3,
            /// <summary> Battery state is too low for ordinary abort sequence. Perform fastest possible emergency stop to prevent damage. </summary>
            MAV_BATTERY_CHARGE_STATE_EMERGENCY = 4,
            /// <summary> Battery failed, damage unavoidable. </summary>
            MAV_BATTERY_CHARGE_STATE_FAILED = 5,
            /// <summary> Battery is diagnosed to be defective or an error occurred, usage is discouraged / prohibited. </summary>
            MAV_BATTERY_CHARGE_STATE_UNHEALTHY = 6,
            /// <summary> Battery is charging. </summary>
            MAV_BATTERY_CHARGE_STATE_CHARGING = 7,
        }
        /// <summary> Smart battery supply status/fault flags (bitmask) for health indication. </summary>
        public enum MAV_SMART_BATTERY_FAULT
        {
            /// <summary> Battery has deep discharged. </summary>
            MAV_SMART_BATTERY_FAULT_DEEP_DISCHARGE = 1,
            /// <summary> Voltage spikes. </summary>
            MAV_SMART_BATTERY_FAULT_SPIKES = 2,
            /// <summary> Single cell has failed. </summary>
            MAV_SMART_BATTERY_FAULT_SINGLE_CELL_FAIL = 4,
            /// <summary> Over-current fault. </summary>
            MAV_SMART_BATTERY_FAULT_OVER_CURRENT = 8,
            /// <summary> Over-temperature fault. </summary>
            MAV_SMART_BATTERY_FAULT_OVER_TEMPERATURE = 16,
            /// <summary> Under-temperature fault. </summary>
            MAV_SMART_BATTERY_FAULT_UNDER_TEMPERATURE = 32,
        }
        /// <summary> Flags to report status/failure cases for a power generator (used in GENERATOR_STATUS). Note that FAULTS are conditions that cause the generator to fail. Warnings are conditions that require attention before the next use (they indicate the system is not operating properly). </summary>
        public enum MAV_GENERATOR_STATUS_FLAG
        {
            /// <summary> Generator is off. </summary>
            MAV_GENERATOR_STATUS_FLAG_OFF = 1,
            /// <summary> Generator is ready to start generating power. </summary>
            MAV_GENERATOR_STATUS_FLAG_READY = 2,
            /// <summary> Generator is generating power. </summary>
            MAV_GENERATOR_STATUS_FLAG_GENERATING = 4,
            /// <summary> Generator is charging the batteries (generating enough power to charge and provide the load). </summary>
            MAV_GENERATOR_STATUS_FLAG_CHARGING = 8,
            /// <summary> Generator is operating at a reduced maximum power. </summary>
            MAV_GENERATOR_STATUS_FLAG_REDUCED_POWER = 16,
            /// <summary> Generator is providing the maximum output. </summary>
            MAV_GENERATOR_STATUS_FLAG_MAXPOWER = 32,
            /// <summary> Generator is near the maximum operating temperature, cooling is insufficient. </summary>
            MAV_GENERATOR_STATUS_FLAG_OVERTEMP_WARNING = 64,
            /// <summary> Generator hit the maximum operating temperature and shutdown. </summary>
            MAV_GENERATOR_STATUS_FLAG_OVERTEMP_FAULT = 128,
            /// <summary> Power electronics are near the maximum operating temperature, cooling is insufficient. </summary>
            MAV_GENERATOR_STATUS_FLAG_ELECTRONICS_OVERTEMP_WARNING = 256,
            /// <summary> Power electronics hit the maximum operating temperature and shutdown. </summary>
            MAV_GENERATOR_STATUS_FLAG_ELECTRONICS_OVERTEMP_FAULT = 512,
            /// <summary> Power electronics experienced a fault and shutdown. </summary>
            MAV_GENERATOR_STATUS_FLAG_ELECTRONICS_FAULT = 1024,
            /// <summary> The power source supplying the generator failed e.g. mechanical generator stopped, tether is no longer providing power, solar cell is in shade, hydrogen reaction no longer happening. </summary>
            MAV_GENERATOR_STATUS_FLAG_POWERSOURCE_FAULT = 2048,
            /// <summary> Generator controller having communication problems. </summary>
            MAV_GENERATOR_STATUS_FLAG_COMMUNICATION_WARNING = 4096,
            /// <summary> Power electronic or generator cooling system error. </summary>
            MAV_GENERATOR_STATUS_FLAG_COOLING_WARNING = 8192,
            /// <summary> Generator controller power rail experienced a fault. </summary>
            MAV_GENERATOR_STATUS_FLAG_POWER_RAIL_FAULT = 16384,
            /// <summary> Generator controller exceeded the overcurrent threshold and shutdown to prevent damage. </summary>
            MAV_GENERATOR_STATUS_FLAG_OVERCURRENT_FAULT = 32768,
            /// <summary> Generator controller detected a high current going into the batteries and shutdown to prevent battery damage. </summary>
            MAV_GENERATOR_STATUS_FLAG_BATTERY_OVERCHARGE_CURRENT_FAULT = 65536,
            /// <summary> Generator controller exceeded it's overvoltage threshold and shutdown to prevent it exceeding the voltage rating. </summary>
            MAV_GENERATOR_STATUS_FLAG_OVERVOLTAGE_FAULT = 131072,
            /// <summary> Batteries are under voltage (generator will not start). </summary>
            MAV_GENERATOR_STATUS_FLAG_BATTERY_UNDERVOLT_FAULT = 262144,
            /// <summary> Generator start is inhibited by e.g. a safety switch. </summary>
            MAV_GENERATOR_STATUS_FLAG_START_INHIBITED = 524288,
            /// <summary> Generator requires maintenance. </summary>
            MAV_GENERATOR_STATUS_FLAG_MAINTENANCE_REQUIRED = 1048576,
            /// <summary> Generator is not ready to generate yet. </summary>
            MAV_GENERATOR_STATUS_FLAG_WARMING_UP = 2097152,
            /// <summary> Generator is idle. </summary>
            MAV_GENERATOR_STATUS_FLAG_IDLE = 4194304,
        }
        /// <summary> Enumeration of VTOL states </summary>
        public enum MAV_VTOL_STATE
        {
            /// <summary> MAV is not configured as VTOL </summary>
            MAV_VTOL_STATE_UNDEFINED = 0,
            /// <summary> VTOL is in transition from multicopter to fixed-wing </summary>
            MAV_VTOL_STATE_TRANSITION_TO_FW = 1,
            /// <summary> VTOL is in transition from fixed-wing to multicopter </summary>
            MAV_VTOL_STATE_TRANSITION_TO_MC = 2,
            /// <summary> VTOL is in multicopter state </summary>
            MAV_VTOL_STATE_MC = 3,
            /// <summary> VTOL is in fixed-wing state </summary>
            MAV_VTOL_STATE_FW = 4,
        }
        /// <summary> Enumeration of landed detector states </summary>
        public enum MAV_LANDED_STATE
        {
            /// <summary> MAV landed state is unknown </summary>
            MAV_LANDED_STATE_UNDEFINED = 0,
            /// <summary> MAV is landed (on ground) </summary>
            MAV_LANDED_STATE_ON_GROUND = 1,
            /// <summary> MAV is in air </summary>
            MAV_LANDED_STATE_IN_AIR = 2,
            /// <summary> MAV currently taking off </summary>
            MAV_LANDED_STATE_TAKEOFF = 3,
            /// <summary> MAV currently landing </summary>
            MAV_LANDED_STATE_LANDING = 4,
        }
        /// <summary> Enumeration of the ADSB altimeter types </summary>
        public enum ADSB_ALTITUDE_TYPE
        {
            /// <summary> Altitude reported from a Baro source using QNH reference </summary>
            ADSB_ALTITUDE_TYPE_PRESSURE_QNH = 0,
            /// <summary> Altitude reported from a GNSS source </summary>
            ADSB_ALTITUDE_TYPE_GEOMETRIC = 1,
        }
        /// <summary> ADSB classification for the type of vehicle emitting the transponder signal </summary>
        public enum ADSB_EMITTER_TYPE
        {
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_NO_INFO = 0,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_LIGHT = 1,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_SMALL = 2,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_LARGE = 3,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_HIGH_VORTEX_LARGE = 4,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_HEAVY = 5,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_HIGHLY_MANUV = 6,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_ROTOCRAFT = 7,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_UNASSIGNED = 8,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_GLIDER = 9,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_LIGHTER_AIR = 10,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_PARACHUTE = 11,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_ULTRA_LIGHT = 12,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_UNASSIGNED2 = 13,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_UAV = 14,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_SPACE = 15,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_UNASSGINED3 = 16,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_EMERGENCY_SURFACE = 17,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_SERVICE_SURFACE = 18,
            /// <summary>  </summary>
            ADSB_EMITTER_TYPE_POINT_OBSTACLE = 19,
        }
        /// <summary> These flags indicate status such as data validity of each data source. Set = data valid </summary>
        public enum ADSB_FLAGS
        {
            /// <summary>  </summary>
            ADSB_FLAGS_VALID_COORDS = 1,
            /// <summary>  </summary>
            ADSB_FLAGS_VALID_ALTITUDE = 2,
            /// <summary>  </summary>
            ADSB_FLAGS_VALID_HEADING = 4,
            /// <summary>  </summary>
            ADSB_FLAGS_VALID_VELOCITY = 8,
            /// <summary>  </summary>
            ADSB_FLAGS_VALID_CALLSIGN = 16,
            /// <summary>  </summary>
            ADSB_FLAGS_VALID_SQUAWK = 32,
            /// <summary>  </summary>
            ADSB_FLAGS_SIMULATED = 64,
            /// <summary>  </summary>
            ADSB_FLAGS_VERTICAL_VELOCITY_VALID = 128,
            /// <summary>  </summary>
            ADSB_FLAGS_BARO_VALID = 256,
            /// <summary>  </summary>
            ADSB_FLAGS_SOURCE_UAT = 32768,
        }
        /// <summary> Bitmap of options for the MAV_CMD_DO_REPOSITION </summary>
        public enum MAV_DO_REPOSITION_FLAGS
        {
            /// <summary> The aircraft should immediately transition into guided. This should not be set for follow me applications </summary>
            MAV_DO_REPOSITION_FLAGS_CHANGE_MODE = 1,
        }
        /// <summary> Flags in ESTIMATOR_STATUS message </summary>
        public enum ESTIMATOR_STATUS_FLAGS
        {
            /// <summary> True if the attitude estimate is good </summary>
            ESTIMATOR_ATTITUDE = 1,
            /// <summary> True if the horizontal velocity estimate is good </summary>
            ESTIMATOR_VELOCITY_HORIZ = 2,
            /// <summary> True if the  vertical velocity estimate is good </summary>
            ESTIMATOR_VELOCITY_VERT = 4,
            /// <summary> True if the horizontal position (relative) estimate is good </summary>
            ESTIMATOR_POS_HORIZ_REL = 8,
            /// <summary> True if the horizontal position (absolute) estimate is good </summary>
            ESTIMATOR_POS_HORIZ_ABS = 16,
            /// <summary> True if the vertical position (absolute) estimate is good </summary>
            ESTIMATOR_POS_VERT_ABS = 32,
            /// <summary> True if the vertical position (above ground) estimate is good </summary>
            ESTIMATOR_POS_VERT_AGL = 64,
            /// <summary> True if the EKF is in a constant position mode and is not using external measurements (eg GPS or optical flow) </summary>
            ESTIMATOR_CONST_POS_MODE = 128,
            /// <summary> True if the EKF has sufficient data to enter a mode that will provide a (relative) position estimate </summary>
            ESTIMATOR_PRED_POS_HORIZ_REL = 256,
            /// <summary> True if the EKF has sufficient data to enter a mode that will provide a (absolute) position estimate </summary>
            ESTIMATOR_PRED_POS_HORIZ_ABS = 512,
            /// <summary> True if the EKF has detected a GPS glitch </summary>
            ESTIMATOR_GPS_GLITCH = 1024,
            /// <summary> True if the EKF has detected bad accelerometer data </summary>
            ESTIMATOR_ACCEL_ERROR = 2048,
        }
        /// <summary>  </summary>
        public enum MOTOR_TEST_ORDER
        {
            /// <summary> default autopilot motor test method </summary>
            MOTOR_TEST_ORDER_DEFAULT = 0,
            /// <summary> motor numbers are specified as their index in a predefined vehicle-specific sequence </summary>
            MOTOR_TEST_ORDER_SEQUENCE = 1,
            /// <summary> motor numbers are specified as the output as labeled on the board </summary>
            MOTOR_TEST_ORDER_BOARD = 2,
        }
        /// <summary>  </summary>
        public enum MOTOR_TEST_THROTTLE_TYPE
        {
            /// <summary> throttle as a percentage from 0 ~ 100 </summary>
            MOTOR_TEST_THROTTLE_PERCENT = 0,
            /// <summary> throttle as an absolute PWM value (normally in range of 1000~2000) </summary>
            MOTOR_TEST_THROTTLE_PWM = 1,
            /// <summary> throttle pass-through from pilot's transmitter </summary>
            MOTOR_TEST_THROTTLE_PILOT = 2,
            /// <summary> per-motor compass calibration test </summary>
            MOTOR_TEST_COMPASS_CAL = 3,
        }
        /// <summary>  </summary>
        public enum GPS_INPUT_IGNORE_FLAGS
        {
            /// <summary> ignore altitude field </summary>
            GPS_INPUT_IGNORE_FLAG_ALT = 1,
            /// <summary> ignore hdop field </summary>
            GPS_INPUT_IGNORE_FLAG_HDOP = 2,
            /// <summary> ignore vdop field </summary>
            GPS_INPUT_IGNORE_FLAG_VDOP = 4,
            /// <summary> ignore horizontal velocity field (vn and ve) </summary>
            GPS_INPUT_IGNORE_FLAG_VEL_HORIZ = 8,
            /// <summary> ignore vertical velocity field (vd) </summary>
            GPS_INPUT_IGNORE_FLAG_VEL_VERT = 16,
            /// <summary> ignore speed accuracy field </summary>
            GPS_INPUT_IGNORE_FLAG_SPEED_ACCURACY = 32,
            /// <summary> ignore horizontal accuracy field </summary>
            GPS_INPUT_IGNORE_FLAG_HORIZONTAL_ACCURACY = 64,
            /// <summary> ignore vertical accuracy field </summary>
            GPS_INPUT_IGNORE_FLAG_VERTICAL_ACCURACY = 128,
        }
        /// <summary> Possible actions an aircraft can take to avoid a collision. </summary>
        public enum MAV_COLLISION_ACTION
        {
            /// <summary> Ignore any potential collisions </summary>
            MAV_COLLISION_ACTION_NONE = 0,
            /// <summary> Report potential collision </summary>
            MAV_COLLISION_ACTION_REPORT = 1,
            /// <summary> Ascend or Descend to avoid threat </summary>
            MAV_COLLISION_ACTION_ASCEND_OR_DESCEND = 2,
            /// <summary> Move horizontally to avoid threat </summary>
            MAV_COLLISION_ACTION_MOVE_HORIZONTALLY = 3,
            /// <summary> Aircraft to move perpendicular to the collision's velocity vector </summary>
            MAV_COLLISION_ACTION_MOVE_PERPENDICULAR = 4,
            /// <summary> Aircraft to fly directly back to its launch point </summary>
            MAV_COLLISION_ACTION_RTL = 5,
            /// <summary> Aircraft to stop in place </summary>
            MAV_COLLISION_ACTION_HOVER = 6,
        }
        /// <summary> Aircraft-rated danger from this threat. </summary>
        public enum MAV_COLLISION_THREAT_LEVEL
        {
            /// <summary> Not a threat </summary>
            MAV_COLLISION_THREAT_LEVEL_NONE = 0,
            /// <summary> Craft is mildly concerned about this threat </summary>
            MAV_COLLISION_THREAT_LEVEL_LOW = 1,
            /// <summary> Craft is panicking, and may take actions to avoid threat </summary>
            MAV_COLLISION_THREAT_LEVEL_HIGH = 2,
        }
        /// <summary> Source of information about this collision. </summary>
        public enum MAV_COLLISION_SRC
        {
            /// <summary> ID field references ADSB_VEHICLE packets </summary>
            MAV_COLLISION_SRC_ADSB = 0,
            /// <summary> ID field references MAVLink SRC ID </summary>
            MAV_COLLISION_SRC_MAVLINK_GPS_GLOBAL_INT = 1,
        }
        /// <summary> Type of GPS fix </summary>
        public enum GPS_FIX_TYPE
        {
            /// <summary> No GPS connected </summary>
            GPS_FIX_TYPE_NO_GPS = 0,
            /// <summary> No position information, GPS is connected </summary>
            GPS_FIX_TYPE_NO_FIX = 1,
            /// <summary> 2D position </summary>
            GPS_FIX_TYPE_2D_FIX = 2,
            /// <summary> 3D position </summary>
            GPS_FIX_TYPE_3D_FIX = 3,
            /// <summary> DGPS/SBAS aided 3D position </summary>
            GPS_FIX_TYPE_DGPS = 4,
            /// <summary> RTK float, 3D position </summary>
            GPS_FIX_TYPE_RTK_FLOAT = 5,
            /// <summary> RTK Fixed, 3D position </summary>
            GPS_FIX_TYPE_RTK_FIXED = 6,
            /// <summary> Static fixed, typically used for base stations </summary>
            GPS_FIX_TYPE_STATIC = 7,
            /// <summary> PPP, 3D position. </summary>
            GPS_FIX_TYPE_PPP = 8,
        }
        /// <summary> RTK GPS baseline coordinate system, used for RTK corrections </summary>
        public enum RTK_BASELINE_COORDINATE_SYSTEM
        {
            /// <summary> Earth-centered, Earth-fixed </summary>
            RTK_BASELINE_COORDINATE_SYSTEM_ECEF = 0,
            /// <summary> RTK basestation centered, north, east, down </summary>
            RTK_BASELINE_COORDINATE_SYSTEM_NED = 1,
        }
        /// <summary> Type of landing target </summary>
        public enum LANDING_TARGET_TYPE
        {
            /// <summary> Landing target signaled by light beacon (ex: IR-LOCK) </summary>
            LANDING_TARGET_TYPE_LIGHT_BEACON = 0,
            /// <summary> Landing target signaled by radio beacon (ex: ILS, NDB) </summary>
            LANDING_TARGET_TYPE_RADIO_BEACON = 1,
            /// <summary> Landing target represented by a fiducial marker (ex: ARTag) </summary>
            LANDING_TARGET_TYPE_VISION_FIDUCIAL = 2,
            /// <summary> Landing target represented by a pre-defined visual shape/feature (ex: X-marker, H-marker, square) </summary>
            LANDING_TARGET_TYPE_VISION_OTHER = 3,
        }
        /// <summary> Direction of VTOL transition </summary>
        public enum VTOL_TRANSITION_HEADING
        {
            /// <summary> Respect the heading configuration of the vehicle. </summary>
            VTOL_TRANSITION_HEADING_VEHICLE_DEFAULT = 0,
            /// <summary> Use the heading pointing towards the next waypoint. </summary>
            VTOL_TRANSITION_HEADING_NEXT_WAYPOINT = 1,
            /// <summary> Use the heading on takeoff (while sitting on the ground). </summary>
            VTOL_TRANSITION_HEADING_TAKEOFF = 2,
            /// <summary> Use the specified heading in parameter 4. </summary>
            VTOL_TRANSITION_HEADING_SPECIFIED = 3,
            /// <summary> Use the current heading when reaching takeoff altitude (potentially facing the wind when weather-vaning is active). </summary>
            VTOL_TRANSITION_HEADING_ANY = 4,
        }
        /// <summary> Camera capability flags (Bitmap) </summary>
        public enum CAMERA_CAP_FLAGS
        {
            /// <summary> Camera is able to record video </summary>
            CAMERA_CAP_FLAGS_CAPTURE_VIDEO = 1,
            /// <summary> Camera is able to capture images </summary>
            CAMERA_CAP_FLAGS_CAPTURE_IMAGE = 2,
            /// <summary> Camera has separate Video and Image/Photo modes (MAV_CMD_SET_CAMERA_MODE) </summary>
            CAMERA_CAP_FLAGS_HAS_MODES = 4,
            /// <summary> Camera can capture images while in video mode </summary>
            CAMERA_CAP_FLAGS_CAN_CAPTURE_IMAGE_IN_VIDEO_MODE = 8,
            /// <summary> Camera can capture videos while in Photo/Image mode </summary>
            CAMERA_CAP_FLAGS_CAN_CAPTURE_VIDEO_IN_IMAGE_MODE = 16,
            /// <summary> Camera has image survey mode (MAV_CMD_SET_CAMERA_MODE) </summary>
            CAMERA_CAP_FLAGS_HAS_IMAGE_SURVEY_MODE = 32,
            /// <summary> Camera has basic zoom control (MAV_CMD_SET_CAMERA_ZOOM) </summary>
            CAMERA_CAP_FLAGS_HAS_BASIC_ZOOM = 64,
            /// <summary> Camera has basic focus control (MAV_CMD_SET_CAMERA_FOCUS) </summary>
            CAMERA_CAP_FLAGS_HAS_BASIC_FOCUS = 128,
            /// <summary> Camera has video streaming capabilities (request VIDEO_STREAM_INFORMATION with MAV_CMD_REQUEST_MESSAGE for video streaming info) </summary>
            CAMERA_CAP_FLAGS_HAS_VIDEO_STREAM = 256,
        }
        /// <summary> Stream status flags (Bitmap) </summary>
        public enum VIDEO_STREAM_STATUS_FLAGS
        {
            /// <summary> Stream is active (running) </summary>
            VIDEO_STREAM_STATUS_FLAGS_RUNNING = 1,
            /// <summary> Stream is thermal imaging </summary>
            VIDEO_STREAM_STATUS_FLAGS_THERMAL = 2,
        }
        /// <summary> Video stream types </summary>
        public enum VIDEO_STREAM_TYPE
        {
            /// <summary> Stream is RTSP </summary>
            VIDEO_STREAM_TYPE_RTSP = 0,
            /// <summary> Stream is RTP UDP (URI gives the port number) </summary>
            VIDEO_STREAM_TYPE_RTPUDP = 1,
            /// <summary> Stream is MPEG on TCP </summary>
            VIDEO_STREAM_TYPE_TCP_MPEG = 2,
            /// <summary> Stream is h.264 on MPEG TS (URI gives the port number) </summary>
            VIDEO_STREAM_TYPE_MPEG_TS_H264 = 3,
        }
        /// <summary> Zoom types for MAV_CMD_SET_CAMERA_ZOOM </summary>
        public enum CAMERA_ZOOM_TYPE
        {
            /// <summary> Zoom one step increment (-1 for wide, 1 for tele) </summary>
            ZOOM_TYPE_STEP = 0,
            /// <summary> Continuous zoom up/down until stopped (-1 for wide, 1 for tele, 0 to stop zooming) </summary>
            ZOOM_TYPE_CONTINUOUS = 1,
            /// <summary> Zoom value as proportion of full camera range (a value between 0.0 and 100.0) </summary>
            ZOOM_TYPE_RANGE = 2,
            /// <summary> Zoom value/variable focal length in milimetres. Note that there is no message to get the valid zoom range of the camera, so this can type can only be used for cameras where the zoom range is known (implying that this cannot reliably be used in a GCS for an arbitrary camera) </summary>
            ZOOM_TYPE_FOCAL_LENGTH = 3,
        }
        /// <summary> Focus types for MAV_CMD_SET_CAMERA_FOCUS </summary>
        public enum SET_FOCUS_TYPE
        {
            /// <summary> Focus one step increment (-1 for focusing in, 1 for focusing out towards infinity). </summary>
            FOCUS_TYPE_STEP = 0,
            /// <summary> Continuous focus up/down until stopped (-1 for focusing in, 1 for focusing out towards infinity, 0 to stop focusing) </summary>
            FOCUS_TYPE_CONTINUOUS = 1,
            /// <summary> Focus value as proportion of full camera focus range (a value between 0.0 and 100.0) </summary>
            FOCUS_TYPE_RANGE = 2,
            /// <summary> Focus value in metres. Note that there is no message to get the valid focus range of the camera, so this can type can only be used for cameras where the range is known (implying that this cannot reliably be used in a GCS for an arbitrary camera). </summary>
            FOCUS_TYPE_METERS = 3,
        }
        /// <summary> Result from PARAM_EXT_SET message (or a PARAM_SET within a transaction). </summary>
        public enum PARAM_ACK
        {
            /// <summary> Parameter value ACCEPTED and SET </summary>
            PARAM_ACK_ACCEPTED = 0,
            /// <summary> Parameter value UNKNOWN/UNSUPPORTED </summary>
            PARAM_ACK_VALUE_UNSUPPORTED = 1,
            /// <summary> Parameter failed to set </summary>
            PARAM_ACK_FAILED = 2,
            /// <summary> Parameter value received but not yet set/accepted. A subsequent PARAM_ACK_TRANSACTION or PARAM_EXT_ACK with the final result will follow once operation is completed. This is returned immediately for parameters that take longer to set, indicating taht the the parameter was recieved and does not need to be resent. </summary>
            PARAM_ACK_IN_PROGRESS = 3,
        }
        /// <summary> Camera Modes. </summary>
        public enum CAMERA_MODE
        {
            /// <summary> Camera is in image/photo capture mode. </summary>
            CAMERA_MODE_IMAGE = 0,
            /// <summary> Camera is in video capture mode. </summary>
            CAMERA_MODE_VIDEO = 1,
            /// <summary> Camera is in image survey capture mode. It allows for camera controller to do specific settings for surveys. </summary>
            CAMERA_MODE_IMAGE_SURVEY = 2,
        }
        /// <summary>  </summary>
        public enum MAV_ARM_AUTH_DENIED_REASON
        {
            /// <summary> Not a specific reason </summary>
            MAV_ARM_AUTH_DENIED_REASON_GENERIC = 0,
            /// <summary> Authorizer will send the error as string to GCS </summary>
            MAV_ARM_AUTH_DENIED_REASON_NONE = 1,
            /// <summary> At least one waypoint have a invalid value </summary>
            MAV_ARM_AUTH_DENIED_REASON_INVALID_WAYPOINT = 2,
            /// <summary> Timeout in the authorizer process(in case it depends on network) </summary>
            MAV_ARM_AUTH_DENIED_REASON_TIMEOUT = 3,
            /// <summary> Airspace of the mission in use by another vehicle, second result parameter can have the waypoint id that caused it to be denied. </summary>
            MAV_ARM_AUTH_DENIED_REASON_AIRSPACE_IN_USE = 4,
            /// <summary> Weather is not good to fly </summary>
            MAV_ARM_AUTH_DENIED_REASON_BAD_WEATHER = 5,
        }
        /// <summary> RC type </summary>
        public enum RC_TYPE
        {
            /// <summary> Spektrum DSM2 </summary>
            RC_TYPE_SPEKTRUM_DSM2 = 0,
            /// <summary> Spektrum DSMX </summary>
            RC_TYPE_SPEKTRUM_DSMX = 1,
        }
        /// <summary> Bitmap to indicate which dimensions should be ignored by the vehicle: a value of 0b0000000000000000 or 0b0000001000000000 indicates that none of the setpoint dimensions should be ignored. If bit 9 is set the floats afx afy afz should be interpreted as force instead of acceleration. </summary>
        public enum POSITION_TARGET_TYPEMASK
        {
            /// <summary> Ignore position x </summary>
            POSITION_TARGET_TYPEMASK_X_IGNORE = 1,
            /// <summary> Ignore position y </summary>
            POSITION_TARGET_TYPEMASK_Y_IGNORE = 2,
            /// <summary> Ignore position z </summary>
            POSITION_TARGET_TYPEMASK_Z_IGNORE = 4,
            /// <summary> Ignore velocity x </summary>
            POSITION_TARGET_TYPEMASK_VX_IGNORE = 8,
            /// <summary> Ignore velocity y </summary>
            POSITION_TARGET_TYPEMASK_VY_IGNORE = 16,
            /// <summary> Ignore velocity z </summary>
            POSITION_TARGET_TYPEMASK_VZ_IGNORE = 32,
            /// <summary> Ignore acceleration x </summary>
            POSITION_TARGET_TYPEMASK_AX_IGNORE = 64,
            /// <summary> Ignore acceleration y </summary>
            POSITION_TARGET_TYPEMASK_AY_IGNORE = 128,
            /// <summary> Ignore acceleration z </summary>
            POSITION_TARGET_TYPEMASK_AZ_IGNORE = 256,
            /// <summary> Use force instead of acceleration </summary>
            POSITION_TARGET_TYPEMASK_FORCE_SET = 512,
            /// <summary> Ignore yaw </summary>
            POSITION_TARGET_TYPEMASK_YAW_IGNORE = 1024,
            /// <summary> Ignore yaw rate </summary>
            POSITION_TARGET_TYPEMASK_YAW_RATE_IGNORE = 2048,
        }
        /// <summary> Airborne status of UAS. </summary>
        public enum UTM_FLIGHT_STATE
        {
            /// <summary> The flight state can't be determined. </summary>
            UTM_FLIGHT_STATE_UNKNOWN = 1,
            /// <summary> UAS on ground. </summary>
            UTM_FLIGHT_STATE_GROUND = 2,
            /// <summary> UAS airborne. </summary>
            UTM_FLIGHT_STATE_AIRBORNE = 3,
            /// <summary> UAS is in an emergency flight state. </summary>
            UTM_FLIGHT_STATE_EMERGENCY = 16,
            /// <summary> UAS has no active controls. </summary>
            UTM_FLIGHT_STATE_NOCTRL = 32,
        }
        /// <summary> Flags for the global position report. </summary>
        public enum UTM_DATA_AVAIL_FLAGS
        {
            /// <summary> The field time contains valid data. </summary>
            UTM_DATA_AVAIL_FLAGS_TIME_VALID = 1,
            /// <summary> The field uas_id contains valid data. </summary>
            UTM_DATA_AVAIL_FLAGS_UAS_ID_AVAILABLE = 2,
            /// <summary> The fields lat, lon and h_acc contain valid data. </summary>
            UTM_DATA_AVAIL_FLAGS_POSITION_AVAILABLE = 4,
            /// <summary> The fields alt and v_acc contain valid data. </summary>
            UTM_DATA_AVAIL_FLAGS_ALTITUDE_AVAILABLE = 8,
            /// <summary> The field relative_alt contains valid data. </summary>
            UTM_DATA_AVAIL_FLAGS_RELATIVE_ALTITUDE_AVAILABLE = 16,
            /// <summary> The fields vx and vy contain valid data. </summary>
            UTM_DATA_AVAIL_FLAGS_HORIZONTAL_VELO_AVAILABLE = 32,
            /// <summary> The field vz contains valid data. </summary>
            UTM_DATA_AVAIL_FLAGS_VERTICAL_VELO_AVAILABLE = 64,
            /// <summary> The fields next_lat, next_lon and next_alt contain valid data. </summary>
            UTM_DATA_AVAIL_FLAGS_NEXT_WAYPOINT_AVAILABLE = 128,
        }
        /// <summary> Cellular network radio type </summary>
        public enum CELLULAR_NETWORK_RADIO_TYPE
        {
            /// <summary>  </summary>
            CELLULAR_NETWORK_RADIO_TYPE_NONE = 0,
            /// <summary>  </summary>
            CELLULAR_NETWORK_RADIO_TYPE_GSM = 1,
            /// <summary>  </summary>
            CELLULAR_NETWORK_RADIO_TYPE_CDMA = 2,
            /// <summary>  </summary>
            CELLULAR_NETWORK_RADIO_TYPE_WCDMA = 3,
            /// <summary>  </summary>
            CELLULAR_NETWORK_RADIO_TYPE_LTE = 4,
        }
        /// <summary> These flags encode the cellular network status </summary>
        public enum CELLULAR_STATUS_FLAG
        {
            /// <summary> State unknown or not reportable. </summary>
            CELLULAR_STATUS_FLAG_UNKNOWN = 0,
            /// <summary> Modem is unusable </summary>
            CELLULAR_STATUS_FLAG_FAILED = 1,
            /// <summary> Modem is being initialized </summary>
            CELLULAR_STATUS_FLAG_INITIALIZING = 2,
            /// <summary> Modem is locked </summary>
            CELLULAR_STATUS_FLAG_LOCKED = 3,
            /// <summary> Modem is not enabled and is powered down </summary>
            CELLULAR_STATUS_FLAG_DISABLED = 4,
            /// <summary> Modem is currently transitioning to the CELLULAR_STATUS_FLAG_DISABLED state </summary>
            CELLULAR_STATUS_FLAG_DISABLING = 5,
            /// <summary> Modem is currently transitioning to the CELLULAR_STATUS_FLAG_ENABLED state </summary>
            CELLULAR_STATUS_FLAG_ENABLING = 6,
            /// <summary> Modem is enabled and powered on but not registered with a network provider and not available for data connections </summary>
            CELLULAR_STATUS_FLAG_ENABLED = 7,
            /// <summary> Modem is searching for a network provider to register </summary>
            CELLULAR_STATUS_FLAG_SEARCHING = 8,
            /// <summary> Modem is registered with a network provider, and data connections and messaging may be available for use </summary>
            CELLULAR_STATUS_FLAG_REGISTERED = 9,
            /// <summary> Modem is disconnecting and deactivating the last active packet data bearer. This state will not be entered if more than one packet data bearer is active and one of the active bearers is deactivated </summary>
            CELLULAR_STATUS_FLAG_DISCONNECTING = 10,
            /// <summary> Modem is activating and connecting the first packet data bearer. Subsequent bearer activations when another bearer is already active do not cause this state to be entered </summary>
            CELLULAR_STATUS_FLAG_CONNECTING = 11,
            /// <summary> One or more packet data bearers is active and connected </summary>
            CELLULAR_STATUS_FLAG_CONNECTED = 12,
        }
        /// <summary> These flags are used to diagnose the failure state of CELLULAR_STATUS </summary>
        public enum CELLULAR_NETWORK_FAILED_REASON
        {
            /// <summary> No error </summary>
            CELLULAR_NETWORK_FAILED_REASON_NONE = 0,
            /// <summary> Error state is unknown </summary>
            CELLULAR_NETWORK_FAILED_REASON_UNKNOWN = 1,
            /// <summary> SIM is required for the modem but missing </summary>
            CELLULAR_NETWORK_FAILED_REASON_SIM_MISSING = 2,
            /// <summary> SIM is available, but not usuable for connection </summary>
            CELLULAR_NETWORK_FAILED_REASON_SIM_ERROR = 3,
        }
        /// <summary> Precision land modes (used in MAV_CMD_NAV_LAND). </summary>
        public enum PRECISION_LAND_MODE
        {
            /// <summary> Normal (non-precision) landing. </summary>
            PRECISION_LAND_MODE_DISABLED = 0,
            /// <summary> Use precision landing if beacon detected when land command accepted, otherwise land normally. </summary>
            PRECISION_LAND_MODE_OPPORTUNISTIC = 1,
            /// <summary> Use precision landing, searching for beacon if not found when land command accepted (land normally if beacon cannot be found). </summary>
            PRECISION_LAND_MODE_REQUIRED = 2,
        }
        /// <summary> Parachute actions. Trigger release and enable/disable auto-release. </summary>
        public enum PARACHUTE_ACTION
        {
            /// <summary> Disable auto-release of parachute (i.e. release triggered by crash detectors). </summary>
            PARACHUTE_DISABLE = 0,
            /// <summary> Enable auto-release of parachute. </summary>
            PARACHUTE_ENABLE = 1,
            /// <summary> Release parachute and kill motors. </summary>
            PARACHUTE_RELEASE = 2,
        }
        /// <summary>  </summary>
        public enum MAV_TUNNEL_PAYLOAD_TYPE
        {
            /// <summary> Encoding of payload unknown. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_UNKNOWN = 0,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED0 = 200,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED1 = 201,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED2 = 202,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED3 = 203,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED4 = 204,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED5 = 205,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED6 = 206,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED7 = 207,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED8 = 208,
            /// <summary> Registered for STorM32 gimbal controller. </summary>
            MAV_TUNNEL_PAYLOAD_TYPE_STORM32_RESERVED9 = 209,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_ID_TYPE
        {
            /// <summary> No type defined. </summary>
            MAV_ODID_ID_TYPE_NONE = 0,
            /// <summary> Manufacturer Serial Number (ANSI/CTA-2063 format). </summary>
            MAV_ODID_ID_TYPE_SERIAL_NUMBER = 1,
            /// <summary> CAA (Civil Aviation Authority) registered ID. Format: [ICAO Country Code].[CAA Assigned ID]. </summary>
            MAV_ODID_ID_TYPE_CAA_REGISTRATION_ID = 2,
            /// <summary> UTM (Unmanned Traffic Management) assigned UUID (RFC4122). </summary>
            MAV_ODID_ID_TYPE_UTM_ASSIGNED_UUID = 3,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_UA_TYPE
        {
            /// <summary> No UA (Unmanned Aircraft) type defined. </summary>
            MAV_ODID_UA_TYPE_NONE = 0,
            /// <summary> Aeroplane/Airplane. Fixed wing. </summary>
            MAV_ODID_UA_TYPE_AEROPLANE = 1,
            /// <summary> Helicopter or multirotor. </summary>
            MAV_ODID_UA_TYPE_HELICOPTER_OR_MULTIROTOR = 2,
            /// <summary> Gyroplane. </summary>
            MAV_ODID_UA_TYPE_GYROPLANE = 3,
            /// <summary> VTOL (Vertical Take-Off and Landing). Fixed wing aircraft that can take off vertically. </summary>
            MAV_ODID_UA_TYPE_HYBRID_LIFT = 4,
            /// <summary> Ornithopter. </summary>
            MAV_ODID_UA_TYPE_ORNITHOPTER = 5,
            /// <summary> Glider. </summary>
            MAV_ODID_UA_TYPE_GLIDER = 6,
            /// <summary> Kite. </summary>
            MAV_ODID_UA_TYPE_KITE = 7,
            /// <summary> Free Balloon. </summary>
            MAV_ODID_UA_TYPE_FREE_BALLOON = 8,
            /// <summary> Captive Balloon. </summary>
            MAV_ODID_UA_TYPE_CAPTIVE_BALLOON = 9,
            /// <summary> Airship. E.g. a blimp. </summary>
            MAV_ODID_UA_TYPE_AIRSHIP = 10,
            /// <summary> Free Fall/Parachute (unpowered). </summary>
            MAV_ODID_UA_TYPE_FREE_FALL_PARACHUTE = 11,
            /// <summary> Rocket. </summary>
            MAV_ODID_UA_TYPE_ROCKET = 12,
            /// <summary> Tethered powered aircraft. </summary>
            MAV_ODID_UA_TYPE_TETHERED_POWERED_AIRCRAFT = 13,
            /// <summary> Ground Obstacle. </summary>
            MAV_ODID_UA_TYPE_GROUND_OBSTACLE = 14,
            /// <summary> Other type of aircraft not listed earlier. </summary>
            MAV_ODID_UA_TYPE_OTHER = 15,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_STATUS
        {
            /// <summary> The status of the (UA) Unmanned Aircraft is undefined. </summary>
            MAV_ODID_STATUS_UNDECLARED = 0,
            /// <summary> The UA is on the ground. </summary>
            MAV_ODID_STATUS_GROUND = 1,
            /// <summary> The UA is in the air. </summary>
            MAV_ODID_STATUS_AIRBORNE = 2,
            /// <summary> The UA is having an emergency. </summary>
            MAV_ODID_STATUS_EMERGENCY = 3,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_HEIGHT_REF
        {
            /// <summary> The height field is relative to the take-off location. </summary>
            MAV_ODID_HEIGHT_REF_OVER_TAKEOFF = 0,
            /// <summary> The height field is relative to ground. </summary>
            MAV_ODID_HEIGHT_REF_OVER_GROUND = 1,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_HOR_ACC
        {
            /// <summary> The horizontal accuracy is unknown. </summary>
            MAV_ODID_HOR_ACC_UNKNOWN = 0,
            /// <summary> The horizontal accuracy is smaller than 10 Nautical Miles. 18.52 km. </summary>
            MAV_ODID_HOR_ACC_10NM = 1,
            /// <summary> The horizontal accuracy is smaller than 4 Nautical Miles. 7.408 km. </summary>
            MAV_ODID_HOR_ACC_4NM = 2,
            /// <summary> The horizontal accuracy is smaller than 2 Nautical Miles. 3.704 km. </summary>
            MAV_ODID_HOR_ACC_2NM = 3,
            /// <summary> The horizontal accuracy is smaller than 1 Nautical Miles. 1.852 km. </summary>
            MAV_ODID_HOR_ACC_1NM = 4,
            /// <summary> The horizontal accuracy is smaller than 0.5 Nautical Miles. 926 m. </summary>
            MAV_ODID_HOR_ACC_0_5NM = 5,
            /// <summary> The horizontal accuracy is smaller than 0.3 Nautical Miles. 555.6 m. </summary>
            MAV_ODID_HOR_ACC_0_3NM = 6,
            /// <summary> The horizontal accuracy is smaller than 0.1 Nautical Miles. 185.2 m. </summary>
            MAV_ODID_HOR_ACC_0_1NM = 7,
            /// <summary> The horizontal accuracy is smaller than 0.05 Nautical Miles. 92.6 m. </summary>
            MAV_ODID_HOR_ACC_0_05NM = 8,
            /// <summary> The horizontal accuracy is smaller than 30 meter. </summary>
            MAV_ODID_HOR_ACC_30_METER = 9,
            /// <summary> The horizontal accuracy is smaller than 10 meter. </summary>
            MAV_ODID_HOR_ACC_10_METER = 10,
            /// <summary> The horizontal accuracy is smaller than 3 meter. </summary>
            MAV_ODID_HOR_ACC_3_METER = 11,
            /// <summary> The horizontal accuracy is smaller than 1 meter. </summary>
            MAV_ODID_HOR_ACC_1_METER = 12,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_VER_ACC
        {
            /// <summary> The vertical accuracy is unknown. </summary>
            MAV_ODID_VER_ACC_UNKNOWN = 0,
            /// <summary> The vertical accuracy is smaller than 150 meter. </summary>
            MAV_ODID_VER_ACC_150_METER = 1,
            /// <summary> The vertical accuracy is smaller than 45 meter. </summary>
            MAV_ODID_VER_ACC_45_METER = 2,
            /// <summary> The vertical accuracy is smaller than 25 meter. </summary>
            MAV_ODID_VER_ACC_25_METER = 3,
            /// <summary> The vertical accuracy is smaller than 10 meter. </summary>
            MAV_ODID_VER_ACC_10_METER = 4,
            /// <summary> The vertical accuracy is smaller than 3 meter. </summary>
            MAV_ODID_VER_ACC_3_METER = 5,
            /// <summary> The vertical accuracy is smaller than 1 meter. </summary>
            MAV_ODID_VER_ACC_1_METER = 6,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_SPEED_ACC
        {
            /// <summary> The speed accuracy is unknown. </summary>
            MAV_ODID_SPEED_ACC_UNKNOWN = 0,
            /// <summary> The speed accuracy is smaller than 10 meters per second. </summary>
            MAV_ODID_SPEED_ACC_10_METERS_PER_SECOND = 1,
            /// <summary> The speed accuracy is smaller than 3 meters per second. </summary>
            MAV_ODID_SPEED_ACC_3_METERS_PER_SECOND = 2,
            /// <summary> The speed accuracy is smaller than 1 meters per second. </summary>
            MAV_ODID_SPEED_ACC_1_METERS_PER_SECOND = 3,
            /// <summary> The speed accuracy is smaller than 0.3 meters per second. </summary>
            MAV_ODID_SPEED_ACC_0_3_METERS_PER_SECOND = 4,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_TIME_ACC
        {
            /// <summary> The timestamp accuracy is unknown. </summary>
            MAV_ODID_TIME_ACC_UNKNOWN = 0,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.1 second. </summary>
            MAV_ODID_TIME_ACC_0_1_SECOND = 1,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.2 second. </summary>
            MAV_ODID_TIME_ACC_0_2_SECOND = 2,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.3 second. </summary>
            MAV_ODID_TIME_ACC_0_3_SECOND = 3,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.4 second. </summary>
            MAV_ODID_TIME_ACC_0_4_SECOND = 4,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.5 second. </summary>
            MAV_ODID_TIME_ACC_0_5_SECOND = 5,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.6 second. </summary>
            MAV_ODID_TIME_ACC_0_6_SECOND = 6,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.7 second. </summary>
            MAV_ODID_TIME_ACC_0_7_SECOND = 7,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.8 second. </summary>
            MAV_ODID_TIME_ACC_0_8_SECOND = 8,
            /// <summary> The timestamp accuracy is smaller than or equal to 0.9 second. </summary>
            MAV_ODID_TIME_ACC_0_9_SECOND = 9,
            /// <summary> The timestamp accuracy is smaller than or equal to 1.0 second. </summary>
            MAV_ODID_TIME_ACC_1_0_SECOND = 10,
            /// <summary> The timestamp accuracy is smaller than or equal to 1.1 second. </summary>
            MAV_ODID_TIME_ACC_1_1_SECOND = 11,
            /// <summary> The timestamp accuracy is smaller than or equal to 1.2 second. </summary>
            MAV_ODID_TIME_ACC_1_2_SECOND = 12,
            /// <summary> The timestamp accuracy is smaller than or equal to 1.3 second. </summary>
            MAV_ODID_TIME_ACC_1_3_SECOND = 13,
            /// <summary> The timestamp accuracy is smaller than or equal to 1.4 second. </summary>
            MAV_ODID_TIME_ACC_1_4_SECOND = 14,
            /// <summary> The timestamp accuracy is smaller than or equal to 1.5 second. </summary>
            MAV_ODID_TIME_ACC_1_5_SECOND = 15,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_AUTH_TYPE
        {
            /// <summary> No authentication type is specified. </summary>
            MAV_ODID_AUTH_TYPE_NONE = 0,
            /// <summary> Signature for the UAS (Unmanned Aircraft System) ID. </summary>
            MAV_ODID_AUTH_TYPE_UAS_ID_SIGNATURE = 1,
            /// <summary> Signature for the Operator ID. </summary>
            MAV_ODID_AUTH_TYPE_OPERATOR_ID_SIGNATURE = 2,
            /// <summary> Signature for the entire message set. </summary>
            MAV_ODID_AUTH_TYPE_MESSAGE_SET_SIGNATURE = 3,
            /// <summary> Authentication is provided by Network Remote ID. </summary>
            MAV_ODID_AUTH_TYPE_NETWORK_REMOTE_ID = 4,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_DESC_TYPE
        {
            /// <summary> Free-form text description of the purpose of the flight. </summary>
            MAV_ODID_DESC_TYPE_TEXT = 0,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_OPERATOR_LOCATION_TYPE
        {
            /// <summary> The location of the operator is the same as the take-off location. </summary>
            MAV_ODID_OPERATOR_LOCATION_TYPE_TAKEOFF = 0,
            /// <summary> The location of the operator is based on live GNSS data. </summary>
            MAV_ODID_OPERATOR_LOCATION_TYPE_LIVE_GNSS = 1,
            /// <summary> The location of the operator is a fixed location. </summary>
            MAV_ODID_OPERATOR_LOCATION_TYPE_FIXED = 2,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_CLASSIFICATION_TYPE
        {
            /// <summary> The classification type for the UA is undeclared. </summary>
            MAV_ODID_CLASSIFICATION_TYPE_UNDECLARED = 0,
            /// <summary> The classification type for the UA follows EU (European Union) specifications. </summary>
            MAV_ODID_CLASSIFICATION_TYPE_EU = 1,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_CATEGORY_EU
        {
            /// <summary> The category for the UA, according to the EU specification, is undeclared. </summary>
            MAV_ODID_CATEGORY_EU_UNDECLARED = 0,
            /// <summary> The category for the UA, according to the EU specification, is the Open category. </summary>
            MAV_ODID_CATEGORY_EU_OPEN = 1,
            /// <summary> The category for the UA, according to the EU specification, is the Specific category. </summary>
            MAV_ODID_CATEGORY_EU_SPECIFIC = 2,
            /// <summary> The category for the UA, according to the EU specification, is the Certified category. </summary>
            MAV_ODID_CATEGORY_EU_CERTIFIED = 3,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_CLASS_EU
        {
            /// <summary> The class for the UA, according to the EU specification, is undeclared. </summary>
            MAV_ODID_CLASS_EU_UNDECLARED = 0,
            /// <summary> The class for the UA, according to the EU specification, is Class 0. </summary>
            MAV_ODID_CLASS_EU_CLASS_0 = 1,
            /// <summary> The class for the UA, according to the EU specification, is Class 1. </summary>
            MAV_ODID_CLASS_EU_CLASS_1 = 2,
            /// <summary> The class for the UA, according to the EU specification, is Class 2. </summary>
            MAV_ODID_CLASS_EU_CLASS_2 = 3,
            /// <summary> The class for the UA, according to the EU specification, is Class 3. </summary>
            MAV_ODID_CLASS_EU_CLASS_3 = 4,
            /// <summary> The class for the UA, according to the EU specification, is Class 4. </summary>
            MAV_ODID_CLASS_EU_CLASS_4 = 5,
            /// <summary> The class for the UA, according to the EU specification, is Class 5. </summary>
            MAV_ODID_CLASS_EU_CLASS_5 = 6,
            /// <summary> The class for the UA, according to the EU specification, is Class 6. </summary>
            MAV_ODID_CLASS_EU_CLASS_6 = 7,
        }
        /// <summary>  </summary>
        public enum MAV_ODID_OPERATOR_ID_TYPE
        {
            /// <summary> CAA (Civil Aviation Authority) registered operator ID. </summary>
            MAV_ODID_OPERATOR_ID_TYPE_CAA = 0,
        }
        /// <summary> Tune formats (used for vehicle buzzer/tone generation). </summary>
        public enum TUNE_FORMAT
        {
            /// <summary> Format is QBasic 1.1 Play: https://www.qbasic.net/en/reference/qb11/Statement/PLAY-006.htm. </summary>
            TUNE_FORMAT_QBASIC1_1 = 1,
            /// <summary> Format is Modern Music Markup Language (MML): https://en.wikipedia.org/wiki/Music_Macro_Language#Modern_MML. </summary>
            TUNE_FORMAT_MML_MODERN = 2,
        }
        /// <summary> Component capability flags (Bitmap) </summary>
        public enum COMPONENT_CAP_FLAGS
        {
            /// <summary> Component has parameters, and supports the parameter protocol (PARAM messages). </summary>
            COMPONENT_CAP_FLAGS_PARAM = 1,
            /// <summary> Component has parameters, and supports the extended parameter protocol (PARAM_EXT messages). </summary>
            COMPONENT_CAP_FLAGS_PARAM_EXT = 2,
        }
        /// <summary> Type of AIS vessel, enum duplicated from AIS standard, https://gpsd.gitlab.io/gpsd/AIVDM.html </summary>
        public enum AIS_TYPE
        {
            /// <summary> Not available (default). </summary>
            AIS_TYPE_UNKNOWN = 0,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_1 = 1,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_2 = 2,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_3 = 3,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_4 = 4,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_5 = 5,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_6 = 6,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_7 = 7,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_8 = 8,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_9 = 9,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_10 = 10,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_11 = 11,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_12 = 12,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_13 = 13,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_14 = 14,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_15 = 15,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_16 = 16,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_17 = 17,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_18 = 18,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_19 = 19,
            /// <summary> Wing In Ground effect. </summary>
            AIS_TYPE_WIG = 20,
            /// <summary>  </summary>
            AIS_TYPE_WIG_HAZARDOUS_A = 21,
            /// <summary>  </summary>
            AIS_TYPE_WIG_HAZARDOUS_B = 22,
            /// <summary>  </summary>
            AIS_TYPE_WIG_HAZARDOUS_C = 23,
            /// <summary>  </summary>
            AIS_TYPE_WIG_HAZARDOUS_D = 24,
            /// <summary>  </summary>
            AIS_TYPE_WIG_RESERVED_1 = 25,
            /// <summary>  </summary>
            AIS_TYPE_WIG_RESERVED_2 = 26,
            /// <summary>  </summary>
            AIS_TYPE_WIG_RESERVED_3 = 27,
            /// <summary>  </summary>
            AIS_TYPE_WIG_RESERVED_4 = 28,
            /// <summary>  </summary>
            AIS_TYPE_WIG_RESERVED_5 = 29,
            /// <summary>  </summary>
            AIS_TYPE_FISHING = 30,
            /// <summary>  </summary>
            AIS_TYPE_TOWING = 31,
            /// <summary> Towing: length exceeds 200m or breadth exceeds 25m. </summary>
            AIS_TYPE_TOWING_LARGE = 32,
            /// <summary> Dredging or other underwater ops. </summary>
            AIS_TYPE_DREDGING = 33,
            /// <summary>  </summary>
            AIS_TYPE_DIVING = 34,
            /// <summary>  </summary>
            AIS_TYPE_MILITARY = 35,
            /// <summary>  </summary>
            AIS_TYPE_SAILING = 36,
            /// <summary>  </summary>
            AIS_TYPE_PLEASURE = 37,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_20 = 38,
            /// <summary>  </summary>
            AIS_TYPE_RESERVED_21 = 39,
            /// <summary> High Speed Craft. </summary>
            AIS_TYPE_HSC = 40,
            /// <summary>  </summary>
            AIS_TYPE_HSC_HAZARDOUS_A = 41,
            /// <summary>  </summary>
            AIS_TYPE_HSC_HAZARDOUS_B = 42,
            /// <summary>  </summary>
            AIS_TYPE_HSC_HAZARDOUS_C = 43,
            /// <summary>  </summary>
            AIS_TYPE_HSC_HAZARDOUS_D = 44,
            /// <summary>  </summary>
            AIS_TYPE_HSC_RESERVED_1 = 45,
            /// <summary>  </summary>
            AIS_TYPE_HSC_RESERVED_2 = 46,
            /// <summary>  </summary>
            AIS_TYPE_HSC_RESERVED_3 = 47,
            /// <summary>  </summary>
            AIS_TYPE_HSC_RESERVED_4 = 48,
            /// <summary>  </summary>
            AIS_TYPE_HSC_UNKNOWN = 49,
            /// <summary>  </summary>
            AIS_TYPE_PILOT = 50,
            /// <summary> Search And Rescue vessel. </summary>
            AIS_TYPE_SAR = 51,
            /// <summary>  </summary>
            AIS_TYPE_TUG = 52,
            /// <summary>  </summary>
            AIS_TYPE_PORT_TENDER = 53,
            /// <summary> Anti-pollution equipment. </summary>
            AIS_TYPE_ANTI_POLLUTION = 54,
            /// <summary>  </summary>
            AIS_TYPE_LAW_ENFORCEMENT = 55,
            /// <summary>  </summary>
            AIS_TYPE_SPARE_LOCAL_1 = 56,
            /// <summary>  </summary>
            AIS_TYPE_SPARE_LOCAL_2 = 57,
            /// <summary>  </summary>
            AIS_TYPE_MEDICAL_TRANSPORT = 58,
            /// <summary> Noncombatant ship according to RR Resolution No. 18. </summary>
            AIS_TYPE_NONECOMBATANT = 59,
            /// <summary>  </summary>
            AIS_TYPE_PASSENGER = 60,
            /// <summary>  </summary>
            AIS_TYPE_PASSENGER_HAZARDOUS_A = 61,
            /// <summary>  </summary>
            AIS_TYPE_PASSENGER_HAZARDOUS_B = 62,
            /// <summary>  </summary>
            AIS_TYPE_AIS_TYPE_PASSENGER_HAZARDOUS_C = 63,
            /// <summary>  </summary>
            AIS_TYPE_PASSENGER_HAZARDOUS_D = 64,
            /// <summary>  </summary>
            AIS_TYPE_PASSENGER_RESERVED_1 = 65,
            /// <summary>  </summary>
            AIS_TYPE_PASSENGER_RESERVED_2 = 66,
            /// <summary>  </summary>
            AIS_TYPE_PASSENGER_RESERVED_3 = 67,
            /// <summary>  </summary>
            AIS_TYPE_AIS_TYPE_PASSENGER_RESERVED_4 = 68,
            /// <summary>  </summary>
            AIS_TYPE_PASSENGER_UNKNOWN = 69,
            /// <summary>  </summary>
            AIS_TYPE_CARGO = 70,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_HAZARDOUS_A = 71,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_HAZARDOUS_B = 72,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_HAZARDOUS_C = 73,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_HAZARDOUS_D = 74,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_RESERVED_1 = 75,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_RESERVED_2 = 76,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_RESERVED_3 = 77,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_RESERVED_4 = 78,
            /// <summary>  </summary>
            AIS_TYPE_CARGO_UNKNOWN = 79,
            /// <summary>  </summary>
            AIS_TYPE_TANKER = 80,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_HAZARDOUS_A = 81,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_HAZARDOUS_B = 82,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_HAZARDOUS_C = 83,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_HAZARDOUS_D = 84,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_RESERVED_1 = 85,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_RESERVED_2 = 86,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_RESERVED_3 = 87,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_RESERVED_4 = 88,
            /// <summary>  </summary>
            AIS_TYPE_TANKER_UNKNOWN = 89,
            /// <summary>  </summary>
            AIS_TYPE_OTHER = 90,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_HAZARDOUS_A = 91,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_HAZARDOUS_B = 92,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_HAZARDOUS_C = 93,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_HAZARDOUS_D = 94,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_RESERVED_1 = 95,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_RESERVED_2 = 96,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_RESERVED_3 = 97,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_RESERVED_4 = 98,
            /// <summary>  </summary>
            AIS_TYPE_OTHER_UNKNOWN = 99,
        }
        /// <summary> Navigational status of AIS vessel, enum duplicated from AIS standard, https://gpsd.gitlab.io/gpsd/AIVDM.html </summary>
        public enum AIS_NAV_STATUS
        {
            /// <summary> Under way using engine. </summary>
            UNDER_WAY = 0,
            /// <summary>  </summary>
            AIS_NAV_ANCHORED = 1,
            /// <summary>  </summary>
            AIS_NAV_UN_COMMANDED = 2,
            /// <summary>  </summary>
            AIS_NAV_RESTRICTED_MANOEUVERABILITY = 3,
            /// <summary>  </summary>
            AIS_NAV_DRAUGHT_CONSTRAINED = 4,
            /// <summary>  </summary>
            AIS_NAV_MOORED = 5,
            /// <summary>  </summary>
            AIS_NAV_AGROUND = 6,
            /// <summary>  </summary>
            AIS_NAV_FISHING = 7,
            /// <summary>  </summary>
            AIS_NAV_SAILING = 8,
            /// <summary>  </summary>
            AIS_NAV_RESERVED_HSC = 9,
            /// <summary>  </summary>
            AIS_NAV_RESERVED_WIG = 10,
            /// <summary>  </summary>
            AIS_NAV_RESERVED_1 = 11,
            /// <summary>  </summary>
            AIS_NAV_RESERVED_2 = 12,
            /// <summary>  </summary>
            AIS_NAV_RESERVED_3 = 13,
            /// <summary> Search And Rescue Transponder. </summary>
            AIS_NAV_AIS_SART = 14,
            /// <summary> Not available (default). </summary>
            AIS_NAV_UNKNOWN = 15,
        }
        /// <summary> These flags are used in the AIS_VESSEL.fields bitmask to indicate validity of data in the other message fields. When set, the data is valid. </summary>
        public enum AIS_FLAGS
        {
            /// <summary> 1 = Position accuracy less than 10m, 0 = position accuracy greater than 10m. </summary>
            AIS_FLAGS_POSITION_ACCURACY = 1,
            /// <summary>  </summary>
            AIS_FLAGS_VALID_COG = 2,
            /// <summary>  </summary>
            AIS_FLAGS_VALID_VELOCITY = 4,
            /// <summary> 1 = Velocity over 52.5765m/s (102.2 knots) </summary>
            AIS_FLAGS_HIGH_VELOCITY = 8,
            /// <summary>  </summary>
            AIS_FLAGS_VALID_TURN_RATE = 16,
            /// <summary> Only the sign of the returned turn rate value is valid, either greater than 5deg/30s or less than -5deg/30s </summary>
            AIS_FLAGS_TURN_RATE_SIGN_ONLY = 32,
            /// <summary>  </summary>
            AIS_FLAGS_VALID_DIMENSIONS = 64,
            /// <summary> Distance to bow is larger than 511m </summary>
            AIS_FLAGS_LARGE_BOW_DIMENSION = 128,
            /// <summary> Distance to stern is larger than 511m </summary>
            AIS_FLAGS_LARGE_STERN_DIMENSION = 256,
            /// <summary> Distance to port side is larger than 63m </summary>
            AIS_FLAGS_LARGE_PORT_DIMENSION = 512,
            /// <summary> Distance to starboard side is larger than 63m </summary>
            AIS_FLAGS_LARGE_STARBOARD_DIMENSION = 1024,
            /// <summary>  </summary>
            AIS_FLAGS_VALID_CALLSIGN = 2048,
            /// <summary>  </summary>
            AIS_FLAGS_VALID_NAME = 4096,
        }
        /// <summary> List of possible units where failures can be injected. </summary>
        public enum FAILURE_UNIT
        {
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_GYRO = 0,
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_ACCEL = 1,
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_MAG = 2,
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_BARO = 3,
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_GPS = 4,
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_OPTICAL_FLOW = 5,
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_VIO = 6,
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_DISTANCE_SENSOR = 7,
            /// <summary>  </summary>
            FAILURE_UNIT_SENSOR_AIRSPEED = 8,
            /// <summary>  </summary>
            FAILURE_UNIT_SYSTEM_BATTERY = 100,
            /// <summary>  </summary>
            FAILURE_UNIT_SYSTEM_MOTOR = 101,
            /// <summary>  </summary>
            FAILURE_UNIT_SYSTEM_SERVO = 102,
            /// <summary>  </summary>
            FAILURE_UNIT_SYSTEM_AVOIDANCE = 103,
            /// <summary>  </summary>
            FAILURE_UNIT_SYSTEM_RC_SIGNAL = 104,
            /// <summary>  </summary>
            FAILURE_UNIT_SYSTEM_MAVLINK_SIGNAL = 105,
        }
        /// <summary> List of possible failure type to inject. </summary>
        public enum FAILURE_TYPE
        {
            /// <summary> No failure injected, used to reset a previous failure. </summary>
            FAILURE_TYPE_OK = 0,
            /// <summary> Sets unit off, so completely non-responsive. </summary>
            FAILURE_TYPE_OFF = 1,
            /// <summary> Unit is stuck e.g. keeps reporting the same value. </summary>
            FAILURE_TYPE_STUCK = 2,
            /// <summary> Unit is reporting complete garbage. </summary>
            FAILURE_TYPE_GARBAGE = 3,
            /// <summary> Unit is consistently wrong. </summary>
            FAILURE_TYPE_WRONG = 4,
            /// <summary> Unit is slow, so e.g. reporting at slower than expected rate. </summary>
            FAILURE_TYPE_SLOW = 5,
            /// <summary> Data of unit is delayed in time. </summary>
            FAILURE_TYPE_DELAYED = 6,
            /// <summary> Unit is sometimes working, sometimes not. </summary>
            FAILURE_TYPE_INTERMITTENT = 7,
        }
        /// <summary> Winch status flags used in WINCH_STATUS </summary>
        public enum MAV_WINCH_STATUS_FLAG
        {
            /// <summary> Winch is healthy </summary>
            MAV_WINCH_STATUS_HEALTHY = 1,
            /// <summary> Winch thread is fully retracted </summary>
            MAV_WINCH_STATUS_FULLY_RETRACTED = 2,
            /// <summary> Winch motor is moving </summary>
            MAV_WINCH_STATUS_MOVING = 4,
            /// <summary> Winch clutch is engaged allowing motor to move freely </summary>
            MAV_WINCH_STATUS_CLUTCH_ENGAGED = 8,
        }


    }
}
