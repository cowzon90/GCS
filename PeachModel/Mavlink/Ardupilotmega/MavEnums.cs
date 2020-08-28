using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Mavlink.Ardupilotmega
{
    public static class MavEnums
    {
        /// <summary>  </summary>
        public enum ACCELCAL_VEHICLE_POS
        {
            /// <summary>  </summary>
            ACCELCAL_VEHICLE_POS_LEVEL = 1,
            /// <summary>  </summary>
            ACCELCAL_VEHICLE_POS_LEFT = 2,
            /// <summary>  </summary>
            ACCELCAL_VEHICLE_POS_RIGHT = 3,
            /// <summary>  </summary>
            ACCELCAL_VEHICLE_POS_NOSEDOWN = 4,
            /// <summary>  </summary>
            ACCELCAL_VEHICLE_POS_NOSEUP = 5,
            /// <summary>  </summary>
            ACCELCAL_VEHICLE_POS_BACK = 6,
            /// <summary>  </summary>
            ACCELCAL_VEHICLE_POS_SUCCESS = 16777215,
            /// <summary>  </summary>
            ACCELCAL_VEHICLE_POS_FAILED = 16777216,
        }
        /// <summary>  </summary>
        public enum MAV_CMD
        {
            /// <summary> Mission command to operate EPM gripper. </summary>
            MAV_CMD_DO_GRIPPER = 211,
            /// <summary> Enable/disable autotune. </summary>
            MAV_CMD_DO_AUTOTUNE_ENABLE = 212,
            /// <summary> Set the distance to be repeated on mission resume </summary>
            MAV_CMD_DO_SET_RESUME_REPEAT_DIST = 215,
            /// <summary> Mission command to wait for an altitude or downwards vertical speed. This is meant for high altitude balloon launches, allowing the aircraft to be idle until either an altitude is reached or a negative vertical speed is reached (indicating early balloon burst). The wiggle time is how often to wiggle the control surfaces to prevent them seizing up. </summary>
            MAV_CMD_NAV_ALTITUDE_WAIT = 83,
            /// <summary> A system wide power-off event has been initiated. </summary>
            MAV_CMD_POWER_OFF_INITIATED = 42000,
            /// <summary> FLY button has been clicked. </summary>
            MAV_CMD_SOLO_BTN_FLY_CLICK = 42001,
            /// <summary> FLY button has been held for 1.5 seconds. </summary>
            MAV_CMD_SOLO_BTN_FLY_HOLD = 42002,
            /// <summary> PAUSE button has been clicked. </summary>
            MAV_CMD_SOLO_BTN_PAUSE_CLICK = 42003,
            /// <summary> Magnetometer calibration based on fixed position in earth field given by inclination, declination and intensity. </summary>
            MAV_CMD_FIXED_MAG_CAL = 42004,
            /// <summary> Magnetometer calibration based on fixed expected field values in milliGauss. </summary>
            MAV_CMD_FIXED_MAG_CAL_FIELD = 42005,
            /// <summary> Magnetometer calibration based on provided known yaw. This allows for fast calibration using WMM field tables in the vehicle, given only the known yaw of the vehicle. If Latitude and longitude are both zero then use the current vehicle location. </summary>
            MAV_CMD_FIXED_MAG_CAL_YAW = 42006,
            /// <summary> Initiate a magnetometer calibration. </summary>
            MAV_CMD_DO_START_MAG_CAL = 42424,
            /// <summary> Initiate a magnetometer calibration. </summary>
            MAV_CMD_DO_ACCEPT_MAG_CAL = 42425,
            /// <summary> Cancel a running magnetometer calibration. </summary>
            MAV_CMD_DO_CANCEL_MAG_CAL = 42426,
            /// <summary> Used when doing accelerometer calibration. When sent to the GCS tells it what position to put the vehicle in. When sent to the vehicle says what position the vehicle is in. </summary>
            MAV_CMD_ACCELCAL_VEHICLE_POS = 42429,
            /// <summary> Reply with the version banner. </summary>
            MAV_CMD_DO_SEND_BANNER = 42428,
            /// <summary> Command autopilot to get into factory test/diagnostic mode. </summary>
            MAV_CMD_SET_FACTORY_TEST_MODE = 42427,
            /// <summary> Causes the gimbal to reset and boot as if it was just powered on. </summary>
            MAV_CMD_GIMBAL_RESET = 42501,
            /// <summary> Reports progress and success or failure of gimbal axis calibration procedure. </summary>
            MAV_CMD_GIMBAL_AXIS_CALIBRATION_STATUS = 42502,
            /// <summary> Starts commutation calibration on the gimbal. </summary>
            MAV_CMD_GIMBAL_REQUEST_AXIS_CALIBRATION = 42503,
            /// <summary> Erases gimbal application and parameters. </summary>
            MAV_CMD_GIMBAL_FULL_RESET = 42505,
            /// <summary> Command to operate winch. </summary>
            MAV_CMD_DO_WINCH = 42600,
            /// <summary> Update the bootloader </summary>
            MAV_CMD_FLASH_BOOTLOADER = 42650,
            /// <summary> Reset battery capacity for batteries that accumulate consumed battery via integration. </summary>
            MAV_CMD_BATTERY_RESET = 42651,
            /// <summary> Issue a trap signal to the autopilot process, presumably to enter the debugger. </summary>
            MAV_CMD_DEBUG_TRAP = 42700,
            /// <summary> Control onboard scripting. </summary>
            MAV_CMD_SCRIPTING = 42701,
        }
        /// <summary>  </summary>
        public enum SCRIPTING_CMD
        {
            /// <summary> Start a REPL session. </summary>
            SCRIPTING_CMD_REPL_START = 0,
            /// <summary> End a REPL session. </summary>
            SCRIPTING_CMD_REPL_STOP = 1,
        }
        /// <summary>  </summary>
        public enum LIMITS_STATE
        {
            /// <summary> Pre-initialization. </summary>
            LIMITS_INIT = 0,
            /// <summary> Disabled. </summary>
            LIMITS_DISABLED = 1,
            /// <summary> Checking limits. </summary>
            LIMITS_ENABLED = 2,
            /// <summary> A limit has been breached. </summary>
            LIMITS_TRIGGERED = 3,
            /// <summary> Taking action e.g. Return/RTL. </summary>
            LIMITS_RECOVERING = 4,
            /// <summary> We're no longer in breach of a limit. </summary>
            LIMITS_RECOVERED = 5,
        }
        /// <summary>  </summary>
        public enum LIMIT_MODULE
        {
            /// <summary> Pre-initialization. </summary>
            LIMIT_GPSLOCK = 1,
            /// <summary> Disabled. </summary>
            LIMIT_GEOFENCE = 2,
            /// <summary> Checking limits. </summary>
            LIMIT_ALTITUDE = 4,
        }
        /// <summary> Flags in RALLY_POINT message. </summary>
        public enum RALLY_FLAGS
        {
            /// <summary> Flag set when requiring favorable winds for landing. </summary>
            FAVORABLE_WIND = 1,
            /// <summary> Flag set when plane is to immediately descend to break altitude and land without GCS intervention. Flag not set when plane is to loiter at Rally point until commanded to land. </summary>
            LAND_IMMEDIATELY = 2,
        }
        /// <summary> Gripper actions. </summary>
        public enum GRIPPER_ACTIONS
        {
            /// <summary> Gripper release cargo. </summary>
            GRIPPER_ACTION_RELEASE = 0,
            /// <summary> Gripper grab onto cargo. </summary>
            GRIPPER_ACTION_GRAB = 1,
        }
        /// <summary> Winch actions. </summary>
        public enum WINCH_ACTIONS
        {
            /// <summary> Relax winch. </summary>
            WINCH_RELAXED = 0,
            /// <summary> Winch unwinds or winds specified length of cable optionally using specified rate. </summary>
            WINCH_RELATIVE_LENGTH_CONTROL = 1,
            /// <summary> Winch unwinds or winds cable at specified rate in meters/seconds. </summary>
            WINCH_RATE_CONTROL = 2,
        }
        /// <summary>  </summary>
        public enum CAMERA_STATUS_TYPES
        {
            /// <summary> Camera heartbeat, announce camera component ID at 1Hz. </summary>
            CAMERA_STATUS_TYPE_HEARTBEAT = 0,
            /// <summary> Camera image triggered. </summary>
            CAMERA_STATUS_TYPE_TRIGGER = 1,
            /// <summary> Camera connection lost. </summary>
            CAMERA_STATUS_TYPE_DISCONNECT = 2,
            /// <summary> Camera unknown error. </summary>
            CAMERA_STATUS_TYPE_ERROR = 3,
            /// <summary> Camera battery low. Parameter p1 shows reported voltage. </summary>
            CAMERA_STATUS_TYPE_LOWBATT = 4,
            /// <summary> Camera storage low. Parameter p1 shows reported shots remaining. </summary>
            CAMERA_STATUS_TYPE_LOWSTORE = 5,
            /// <summary> Camera storage low. Parameter p1 shows reported video minutes remaining. </summary>
            CAMERA_STATUS_TYPE_LOWSTOREV = 6,
        }
        /// <summary>  </summary>
        public enum CAMERA_FEEDBACK_FLAGS
        {
            /// <summary> Shooting photos, not video. </summary>
            CAMERA_FEEDBACK_PHOTO = 0,
            /// <summary> Shooting video, not stills. </summary>
            CAMERA_FEEDBACK_VIDEO = 1,
            /// <summary> Unable to achieve requested exposure (e.g. shutter speed too low). </summary>
            CAMERA_FEEDBACK_BADEXPOSURE = 2,
            /// <summary> Closed loop feedback from camera, we know for sure it has successfully taken a picture. </summary>
            CAMERA_FEEDBACK_CLOSEDLOOP = 3,
            /// <summary> Open loop camera, an image trigger has been requested but we can't know for sure it has successfully taken a picture. </summary>
            CAMERA_FEEDBACK_OPENLOOP = 4,
        }
        /// <summary>  </summary>
        public enum MAV_MODE_GIMBAL
        {
            /// <summary> Gimbal is powered on but has not started initializing yet. </summary>
            MAV_MODE_GIMBAL_UNINITIALIZED = 0,
            /// <summary> Gimbal is currently running calibration on the pitch axis. </summary>
            MAV_MODE_GIMBAL_CALIBRATING_PITCH = 1,
            /// <summary> Gimbal is currently running calibration on the roll axis. </summary>
            MAV_MODE_GIMBAL_CALIBRATING_ROLL = 2,
            /// <summary> Gimbal is currently running calibration on the yaw axis. </summary>
            MAV_MODE_GIMBAL_CALIBRATING_YAW = 3,
            /// <summary> Gimbal has finished calibrating and initializing, but is relaxed pending reception of first rate command from copter. </summary>
            MAV_MODE_GIMBAL_INITIALIZED = 4,
            /// <summary> Gimbal is actively stabilizing. </summary>
            MAV_MODE_GIMBAL_ACTIVE = 5,
            /// <summary> Gimbal is relaxed because it missed more than 10 expected rate command messages in a row. Gimbal will move back to active mode when it receives a new rate command. </summary>
            MAV_MODE_GIMBAL_RATE_CMD_TIMEOUT = 6,
        }
        /// <summary>  </summary>
        public enum GIMBAL_AXIS
        {
            /// <summary> Gimbal yaw axis. </summary>
            GIMBAL_AXIS_YAW = 0,
            /// <summary> Gimbal pitch axis. </summary>
            GIMBAL_AXIS_PITCH = 1,
            /// <summary> Gimbal roll axis. </summary>
            GIMBAL_AXIS_ROLL = 2,
        }
        /// <summary>  </summary>
        public enum GIMBAL_AXIS_CALIBRATION_STATUS
        {
            /// <summary> Axis calibration is in progress. </summary>
            GIMBAL_AXIS_CALIBRATION_STATUS_IN_PROGRESS = 0,
            /// <summary> Axis calibration succeeded. </summary>
            GIMBAL_AXIS_CALIBRATION_STATUS_SUCCEEDED = 1,
            /// <summary> Axis calibration failed. </summary>
            GIMBAL_AXIS_CALIBRATION_STATUS_FAILED = 2,
        }
        /// <summary>  </summary>
        public enum GIMBAL_AXIS_CALIBRATION_REQUIRED
        {
            /// <summary> Whether or not this axis requires calibration is unknown at this time. </summary>
            GIMBAL_AXIS_CALIBRATION_REQUIRED_UNKNOWN = 0,
            /// <summary> This axis requires calibration. </summary>
            GIMBAL_AXIS_CALIBRATION_REQUIRED_TRUE = 1,
            /// <summary> This axis does not require calibration. </summary>
            GIMBAL_AXIS_CALIBRATION_REQUIRED_FALSE = 2,
        }
        /// <summary>  </summary>
        public enum GOPRO_HEARTBEAT_STATUS
        {
            /// <summary> No GoPro connected. </summary>
            GOPRO_HEARTBEAT_STATUS_DISCONNECTED = 0,
            /// <summary> The detected GoPro is not HeroBus compatible. </summary>
            GOPRO_HEARTBEAT_STATUS_INCOMPATIBLE = 1,
            /// <summary> A HeroBus compatible GoPro is connected. </summary>
            GOPRO_HEARTBEAT_STATUS_CONNECTED = 2,
            /// <summary> An unrecoverable error was encountered with the connected GoPro, it may require a power cycle. </summary>
            GOPRO_HEARTBEAT_STATUS_ERROR = 3,
        }
        /// <summary>  </summary>
        public enum GOPRO_HEARTBEAT_FLAGS
        {
            /// <summary> GoPro is currently recording. </summary>
            GOPRO_FLAG_RECORDING = 1,
        }
        /// <summary>  </summary>
        public enum GOPRO_REQUEST_STATUS
        {
            /// <summary> The write message with ID indicated succeeded. </summary>
            GOPRO_REQUEST_SUCCESS = 0,
            /// <summary> The write message with ID indicated failed. </summary>
            GOPRO_REQUEST_FAILED = 1,
        }
        /// <summary>  </summary>
        public enum GOPRO_COMMAND
        {
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_POWER = 0,
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_CAPTURE_MODE = 1,
            /// <summary> (___/Set). </summary>
            GOPRO_COMMAND_SHUTTER = 2,
            /// <summary> (Get/___). </summary>
            GOPRO_COMMAND_BATTERY = 3,
            /// <summary> (Get/___). </summary>
            GOPRO_COMMAND_MODEL = 4,
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_VIDEO_SETTINGS = 5,
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_LOW_LIGHT = 6,
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_PHOTO_RESOLUTION = 7,
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_PHOTO_BURST_RATE = 8,
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_PROTUNE = 9,
            /// <summary> (Get/Set) Hero 3+ Only. </summary>
            GOPRO_COMMAND_PROTUNE_WHITE_BALANCE = 10,
            /// <summary> (Get/Set) Hero 3+ Only. </summary>
            GOPRO_COMMAND_PROTUNE_COLOUR = 11,
            /// <summary> (Get/Set) Hero 3+ Only. </summary>
            GOPRO_COMMAND_PROTUNE_GAIN = 12,
            /// <summary> (Get/Set) Hero 3+ Only. </summary>
            GOPRO_COMMAND_PROTUNE_SHARPNESS = 13,
            /// <summary> (Get/Set) Hero 3+ Only. </summary>
            GOPRO_COMMAND_PROTUNE_EXPOSURE = 14,
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_TIME = 15,
            /// <summary> (Get/Set). </summary>
            GOPRO_COMMAND_CHARGING = 16,
        }
        /// <summary>  </summary>
        public enum GOPRO_CAPTURE_MODE
        {
            /// <summary> Video mode. </summary>
            GOPRO_CAPTURE_MODE_VIDEO = 0,
            /// <summary> Photo mode. </summary>
            GOPRO_CAPTURE_MODE_PHOTO = 1,
            /// <summary> Burst mode, Hero 3+ only. </summary>
            GOPRO_CAPTURE_MODE_BURST = 2,
            /// <summary> Time lapse mode, Hero 3+ only. </summary>
            GOPRO_CAPTURE_MODE_TIME_LAPSE = 3,
            /// <summary> Multi shot mode, Hero 4 only. </summary>
            GOPRO_CAPTURE_MODE_MULTI_SHOT = 4,
            /// <summary> Playback mode, Hero 4 only, silver only except when LCD or HDMI is connected to black. </summary>
            GOPRO_CAPTURE_MODE_PLAYBACK = 5,
            /// <summary> Playback mode, Hero 4 only. </summary>
            GOPRO_CAPTURE_MODE_SETUP = 6,
            /// <summary> Mode not yet known. </summary>
            GOPRO_CAPTURE_MODE_UNKNOWN = 255,
        }
        /// <summary>  </summary>
        public enum GOPRO_RESOLUTION
        {
            /// <summary> 848 x 480 (480p). </summary>
            GOPRO_RESOLUTION_480p = 0,
            /// <summary> 1280 x 720 (720p). </summary>
            GOPRO_RESOLUTION_720p = 1,
            /// <summary> 1280 x 960 (960p). </summary>
            GOPRO_RESOLUTION_960p = 2,
            /// <summary> 1920 x 1080 (1080p). </summary>
            GOPRO_RESOLUTION_1080p = 3,
            /// <summary> 1920 x 1440 (1440p). </summary>
            GOPRO_RESOLUTION_1440p = 4,
            /// <summary> 2704 x 1440 (2.7k-17:9). </summary>
            GOPRO_RESOLUTION_2_7k_17_9 = 5,
            /// <summary> 2704 x 1524 (2.7k-16:9). </summary>
            GOPRO_RESOLUTION_2_7k_16_9 = 6,
            /// <summary> 2704 x 2028 (2.7k-4:3). </summary>
            GOPRO_RESOLUTION_2_7k_4_3 = 7,
            /// <summary> 3840 x 2160 (4k-16:9). </summary>
            GOPRO_RESOLUTION_4k_16_9 = 8,
            /// <summary> 4096 x 2160 (4k-17:9). </summary>
            GOPRO_RESOLUTION_4k_17_9 = 9,
            /// <summary> 1280 x 720 (720p-SuperView). </summary>
            GOPRO_RESOLUTION_720p_SUPERVIEW = 10,
            /// <summary> 1920 x 1080 (1080p-SuperView). </summary>
            GOPRO_RESOLUTION_1080p_SUPERVIEW = 11,
            /// <summary> 2704 x 1520 (2.7k-SuperView). </summary>
            GOPRO_RESOLUTION_2_7k_SUPERVIEW = 12,
            /// <summary> 3840 x 2160 (4k-SuperView). </summary>
            GOPRO_RESOLUTION_4k_SUPERVIEW = 13,
        }
        /// <summary>  </summary>
        public enum GOPRO_FRAME_RATE
        {
            /// <summary> 12 FPS. </summary>
            GOPRO_FRAME_RATE_12 = 0,
            /// <summary> 15 FPS. </summary>
            GOPRO_FRAME_RATE_15 = 1,
            /// <summary> 24 FPS. </summary>
            GOPRO_FRAME_RATE_24 = 2,
            /// <summary> 25 FPS. </summary>
            GOPRO_FRAME_RATE_25 = 3,
            /// <summary> 30 FPS. </summary>
            GOPRO_FRAME_RATE_30 = 4,
            /// <summary> 48 FPS. </summary>
            GOPRO_FRAME_RATE_48 = 5,
            /// <summary> 50 FPS. </summary>
            GOPRO_FRAME_RATE_50 = 6,
            /// <summary> 60 FPS. </summary>
            GOPRO_FRAME_RATE_60 = 7,
            /// <summary> 80 FPS. </summary>
            GOPRO_FRAME_RATE_80 = 8,
            /// <summary> 90 FPS. </summary>
            GOPRO_FRAME_RATE_90 = 9,
            /// <summary> 100 FPS. </summary>
            GOPRO_FRAME_RATE_100 = 10,
            /// <summary> 120 FPS. </summary>
            GOPRO_FRAME_RATE_120 = 11,
            /// <summary> 240 FPS. </summary>
            GOPRO_FRAME_RATE_240 = 12,
            /// <summary> 12.5 FPS. </summary>
            GOPRO_FRAME_RATE_12_5 = 13,
        }
        /// <summary>  </summary>
        public enum GOPRO_FIELD_OF_VIEW
        {
            /// <summary> 0x00: Wide. </summary>
            GOPRO_FIELD_OF_VIEW_WIDE = 0,
            /// <summary> 0x01: Medium. </summary>
            GOPRO_FIELD_OF_VIEW_MEDIUM = 1,
            /// <summary> 0x02: Narrow. </summary>
            GOPRO_FIELD_OF_VIEW_NARROW = 2,
        }
        /// <summary>  </summary>
        public enum GOPRO_VIDEO_SETTINGS_FLAGS
        {
            /// <summary> 0=NTSC, 1=PAL. </summary>
            GOPRO_VIDEO_SETTINGS_TV_MODE = 1,
        }
        /// <summary>  </summary>
        public enum GOPRO_PHOTO_RESOLUTION
        {
            /// <summary> 5MP Medium. </summary>
            GOPRO_PHOTO_RESOLUTION_5MP_MEDIUM = 0,
            /// <summary> 7MP Medium. </summary>
            GOPRO_PHOTO_RESOLUTION_7MP_MEDIUM = 1,
            /// <summary> 7MP Wide. </summary>
            GOPRO_PHOTO_RESOLUTION_7MP_WIDE = 2,
            /// <summary> 10MP Wide. </summary>
            GOPRO_PHOTO_RESOLUTION_10MP_WIDE = 3,
            /// <summary> 12MP Wide. </summary>
            GOPRO_PHOTO_RESOLUTION_12MP_WIDE = 4,
        }
        /// <summary>  </summary>
        public enum GOPRO_PROTUNE_WHITE_BALANCE
        {
            /// <summary> Auto. </summary>
            GOPRO_PROTUNE_WHITE_BALANCE_AUTO = 0,
            /// <summary> 3000K. </summary>
            GOPRO_PROTUNE_WHITE_BALANCE_3000K = 1,
            /// <summary> 5500K. </summary>
            GOPRO_PROTUNE_WHITE_BALANCE_5500K = 2,
            /// <summary> 6500K. </summary>
            GOPRO_PROTUNE_WHITE_BALANCE_6500K = 3,
            /// <summary> Camera Raw. </summary>
            GOPRO_PROTUNE_WHITE_BALANCE_RAW = 4,
        }
        /// <summary>  </summary>
        public enum GOPRO_PROTUNE_COLOUR
        {
            /// <summary> Auto. </summary>
            GOPRO_PROTUNE_COLOUR_STANDARD = 0,
            /// <summary> Neutral. </summary>
            GOPRO_PROTUNE_COLOUR_NEUTRAL = 1,
        }
        /// <summary>  </summary>
        public enum GOPRO_PROTUNE_GAIN
        {
            /// <summary> ISO 400. </summary>
            GOPRO_PROTUNE_GAIN_400 = 0,
            /// <summary> ISO 800 (Only Hero 4). </summary>
            GOPRO_PROTUNE_GAIN_800 = 1,
            /// <summary> ISO 1600. </summary>
            GOPRO_PROTUNE_GAIN_1600 = 2,
            /// <summary> ISO 3200 (Only Hero 4). </summary>
            GOPRO_PROTUNE_GAIN_3200 = 3,
            /// <summary> ISO 6400. </summary>
            GOPRO_PROTUNE_GAIN_6400 = 4,
        }
        /// <summary>  </summary>
        public enum GOPRO_PROTUNE_SHARPNESS
        {
            /// <summary> Low Sharpness. </summary>
            GOPRO_PROTUNE_SHARPNESS_LOW = 0,
            /// <summary> Medium Sharpness. </summary>
            GOPRO_PROTUNE_SHARPNESS_MEDIUM = 1,
            /// <summary> High Sharpness. </summary>
            GOPRO_PROTUNE_SHARPNESS_HIGH = 2,
        }
        /// <summary>  </summary>
        public enum GOPRO_PROTUNE_EXPOSURE
        {
            /// <summary> -5.0 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_5_0 = 0,
            /// <summary> -4.5 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_4_5 = 1,
            /// <summary> -4.0 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_4_0 = 2,
            /// <summary> -3.5 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_3_5 = 3,
            /// <summary> -3.0 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_3_0 = 4,
            /// <summary> -2.5 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_2_5 = 5,
            /// <summary> -2.0 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_2_0 = 6,
            /// <summary> -1.5 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_1_5 = 7,
            /// <summary> -1.0 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_1_0 = 8,
            /// <summary> -0.5 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_NEG_0_5 = 9,
            /// <summary> 0.0 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_ZERO = 10,
            /// <summary> +0.5 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_0_5 = 11,
            /// <summary> +1.0 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_1_0 = 12,
            /// <summary> +1.5 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_1_5 = 13,
            /// <summary> +2.0 EV. </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_2_0 = 14,
            /// <summary> +2.5 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_2_5 = 15,
            /// <summary> +3.0 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_3_0 = 16,
            /// <summary> +3.5 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_3_5 = 17,
            /// <summary> +4.0 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_4_0 = 18,
            /// <summary> +4.5 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_4_5 = 19,
            /// <summary> +5.0 EV (Hero 3+ Only). </summary>
            GOPRO_PROTUNE_EXPOSURE_POS_5_0 = 20,
        }
        /// <summary>  </summary>
        public enum GOPRO_CHARGING
        {
            /// <summary> Charging disabled. </summary>
            GOPRO_CHARGING_DISABLED = 0,
            /// <summary> Charging enabled. </summary>
            GOPRO_CHARGING_ENABLED = 1,
        }
        /// <summary>  </summary>
        public enum GOPRO_MODEL
        {
            /// <summary> Unknown gopro model. </summary>
            GOPRO_MODEL_UNKNOWN = 0,
            /// <summary> Hero 3+ Silver (HeroBus not supported by GoPro). </summary>
            GOPRO_MODEL_HERO_3_PLUS_SILVER = 1,
            /// <summary> Hero 3+ Black. </summary>
            GOPRO_MODEL_HERO_3_PLUS_BLACK = 2,
            /// <summary> Hero 4 Silver. </summary>
            GOPRO_MODEL_HERO_4_SILVER = 3,
            /// <summary> Hero 4 Black. </summary>
            GOPRO_MODEL_HERO_4_BLACK = 4,
        }
        /// <summary>  </summary>
        public enum GOPRO_BURST_RATE
        {
            /// <summary> 3 Shots / 1 Second. </summary>
            GOPRO_BURST_RATE_3_IN_1_SECOND = 0,
            /// <summary> 5 Shots / 1 Second. </summary>
            GOPRO_BURST_RATE_5_IN_1_SECOND = 1,
            /// <summary> 10 Shots / 1 Second. </summary>
            GOPRO_BURST_RATE_10_IN_1_SECOND = 2,
            /// <summary> 10 Shots / 2 Second. </summary>
            GOPRO_BURST_RATE_10_IN_2_SECOND = 3,
            /// <summary> 10 Shots / 3 Second (Hero 4 Only). </summary>
            GOPRO_BURST_RATE_10_IN_3_SECOND = 4,
            /// <summary> 30 Shots / 1 Second. </summary>
            GOPRO_BURST_RATE_30_IN_1_SECOND = 5,
            /// <summary> 30 Shots / 2 Second. </summary>
            GOPRO_BURST_RATE_30_IN_2_SECOND = 6,
            /// <summary> 30 Shots / 3 Second. </summary>
            GOPRO_BURST_RATE_30_IN_3_SECOND = 7,
            /// <summary> 30 Shots / 6 Second. </summary>
            GOPRO_BURST_RATE_30_IN_6_SECOND = 8,
        }
        /// <summary>  </summary>
        public enum LED_CONTROL_PATTERN
        {
            /// <summary> LED patterns off (return control to regular vehicle control). </summary>
            LED_CONTROL_PATTERN_OFF = 0,
            /// <summary> LEDs show pattern during firmware update. </summary>
            LED_CONTROL_PATTERN_FIRMWAREUPDATE = 1,
            /// <summary> Custom Pattern using custom bytes fields. </summary>
            LED_CONTROL_PATTERN_CUSTOM = 255,
        }
        /// <summary> Flags in EKF_STATUS message. </summary>
        public enum EKF_STATUS_FLAGS
        {
            /// <summary> Set if EKF's attitude estimate is good. </summary>
            EKF_ATTITUDE = 1,
            /// <summary> Set if EKF's horizontal velocity estimate is good. </summary>
            EKF_VELOCITY_HORIZ = 2,
            /// <summary> Set if EKF's vertical velocity estimate is good. </summary>
            EKF_VELOCITY_VERT = 4,
            /// <summary> Set if EKF's horizontal position (relative) estimate is good. </summary>
            EKF_POS_HORIZ_REL = 8,
            /// <summary> Set if EKF's horizontal position (absolute) estimate is good. </summary>
            EKF_POS_HORIZ_ABS = 16,
            /// <summary> Set if EKF's vertical position (absolute) estimate is good. </summary>
            EKF_POS_VERT_ABS = 32,
            /// <summary> Set if EKF's vertical position (above ground) estimate is good. </summary>
            EKF_POS_VERT_AGL = 64,
            /// <summary> EKF is in constant position mode and does not know it's absolute or relative position. </summary>
            EKF_CONST_POS_MODE = 128,
            /// <summary> Set if EKF's predicted horizontal position (relative) estimate is good. </summary>
            EKF_PRED_POS_HORIZ_REL = 256,
            /// <summary> Set if EKF's predicted horizontal position (absolute) estimate is good. </summary>
            EKF_PRED_POS_HORIZ_ABS = 512,
            /// <summary> Set if EKF has never been healthy. </summary>
            EKF_UNINITIALIZED = 1024,
        }
        /// <summary>  </summary>
        public enum PID_TUNING_AXIS
        {
            /// <summary>  </summary>
            PID_TUNING_ROLL = 1,
            /// <summary>  </summary>
            PID_TUNING_PITCH = 2,
            /// <summary>  </summary>
            PID_TUNING_YAW = 3,
            /// <summary>  </summary>
            PID_TUNING_ACCZ = 4,
            /// <summary>  </summary>
            PID_TUNING_STEER = 5,
            /// <summary>  </summary>
            PID_TUNING_LANDING = 6,
        }
        /// <summary>  </summary>
        public enum MAG_CAL_STATUS
        {
            /// <summary>  </summary>
            MAG_CAL_NOT_STARTED = 0,
            /// <summary>  </summary>
            MAG_CAL_WAITING_TO_START = 1,
            /// <summary>  </summary>
            MAG_CAL_RUNNING_STEP_ONE = 2,
            /// <summary>  </summary>
            MAG_CAL_RUNNING_STEP_TWO = 3,
            /// <summary>  </summary>
            MAG_CAL_SUCCESS = 4,
            /// <summary>  </summary>
            MAG_CAL_FAILED = 5,
            /// <summary>  </summary>
            MAG_CAL_BAD_ORIENTATION = 6,
            /// <summary>  </summary>
            MAG_CAL_BAD_RADIUS = 7,
        }
        /// <summary> Special ACK block numbers control activation of dataflash log streaming. </summary>
        public enum MAV_REMOTE_LOG_DATA_BLOCK_COMMANDS
        {
            /// <summary> UAV to stop sending DataFlash blocks. </summary>
            MAV_REMOTE_LOG_DATA_BLOCK_STOP = 2147483645,
            /// <summary> UAV to start sending DataFlash blocks. </summary>
            MAV_REMOTE_LOG_DATA_BLOCK_START = 2147483646,
        }
        /// <summary> Possible remote log data block statuses. </summary>
        public enum MAV_REMOTE_LOG_DATA_BLOCK_STATUSES
        {
            /// <summary> This block has NOT been received. </summary>
            MAV_REMOTE_LOG_DATA_BLOCK_NACK = 0,
            /// <summary> This block has been received. </summary>
            MAV_REMOTE_LOG_DATA_BLOCK_ACK = 1,
        }
        /// <summary> Bus types for device operations. </summary>
        public enum DEVICE_OP_BUSTYPE
        {
            /// <summary> I2C Device operation. </summary>
            DEVICE_OP_BUSTYPE_I2C = 0,
            /// <summary> SPI Device operation. </summary>
            DEVICE_OP_BUSTYPE_SPI = 1,
        }
        /// <summary> Deepstall flight stage. </summary>
        public enum DEEPSTALL_STAGE
        {
            /// <summary> Flying to the landing point. </summary>
            DEEPSTALL_STAGE_FLY_TO_LANDING = 0,
            /// <summary> Building an estimate of the wind. </summary>
            DEEPSTALL_STAGE_ESTIMATE_WIND = 1,
            /// <summary> Waiting to breakout of the loiter to fly the approach. </summary>
            DEEPSTALL_STAGE_WAIT_FOR_BREAKOUT = 2,
            /// <summary> Flying to the first arc point to turn around to the landing point. </summary>
            DEEPSTALL_STAGE_FLY_TO_ARC = 3,
            /// <summary> Turning around back to the deepstall landing point. </summary>
            DEEPSTALL_STAGE_ARC = 4,
            /// <summary> Approaching the landing point. </summary>
            DEEPSTALL_STAGE_APPROACH = 5,
            /// <summary> Stalling and steering towards the land point. </summary>
            DEEPSTALL_STAGE_LAND = 6,
        }
        /// <summary> A mapping of plane flight modes for custom_mode field of heartbeat. </summary>
        public enum PLANE_MODE
        {
            /// <summary>  </summary>
            PLANE_MODE_MANUAL = 0,
            /// <summary>  </summary>
            PLANE_MODE_CIRCLE = 1,
            /// <summary>  </summary>
            PLANE_MODE_STABILIZE = 2,
            /// <summary>  </summary>
            PLANE_MODE_TRAINING = 3,
            /// <summary>  </summary>
            PLANE_MODE_ACRO = 4,
            /// <summary>  </summary>
            PLANE_MODE_FLY_BY_WIRE_A = 5,
            /// <summary>  </summary>
            PLANE_MODE_FLY_BY_WIRE_B = 6,
            /// <summary>  </summary>
            PLANE_MODE_CRUISE = 7,
            /// <summary>  </summary>
            PLANE_MODE_AUTOTUNE = 8,
            /// <summary>  </summary>
            PLANE_MODE_AUTO = 10,
            /// <summary>  </summary>
            PLANE_MODE_RTL = 11,
            /// <summary>  </summary>
            PLANE_MODE_LOITER = 12,
            /// <summary>  </summary>
            PLANE_MODE_TAKEOFF = 13,
            /// <summary>  </summary>
            PLANE_MODE_AVOID_ADSB = 14,
            /// <summary>  </summary>
            PLANE_MODE_GUIDED = 15,
            /// <summary>  </summary>
            PLANE_MODE_INITIALIZING = 16,
            /// <summary>  </summary>
            PLANE_MODE_QSTABILIZE = 17,
            /// <summary>  </summary>
            PLANE_MODE_QHOVER = 18,
            /// <summary>  </summary>
            PLANE_MODE_QLOITER = 19,
            /// <summary>  </summary>
            PLANE_MODE_QLAND = 20,
            /// <summary>  </summary>
            PLANE_MODE_QRTL = 21,
            /// <summary>  </summary>
            PLANE_MODE_QAUTOTUNE = 22,
        }
        /// <summary> A mapping of copter flight modes for custom_mode field of heartbeat. </summary>
        public enum COPTER_MODE
        {
            /// <summary>  </summary>
            COPTER_MODE_STABILIZE = 0,
            /// <summary>  </summary>
            COPTER_MODE_ACRO = 1,
            /// <summary>  </summary>
            COPTER_MODE_ALT_HOLD = 2,
            /// <summary>  </summary>
            COPTER_MODE_AUTO = 3,
            /// <summary>  </summary>
            COPTER_MODE_GUIDED = 4,
            /// <summary>  </summary>
            COPTER_MODE_LOITER = 5,
            /// <summary>  </summary>
            COPTER_MODE_RTL = 6,
            /// <summary>  </summary>
            COPTER_MODE_CIRCLE = 7,
            /// <summary>  </summary>
            COPTER_MODE_LAND = 9,
            /// <summary>  </summary>
            COPTER_MODE_DRIFT = 11,
            /// <summary>  </summary>
            COPTER_MODE_SPORT = 13,
            /// <summary>  </summary>
            COPTER_MODE_FLIP = 14,
            /// <summary>  </summary>
            COPTER_MODE_AUTOTUNE = 15,
            /// <summary>  </summary>
            COPTER_MODE_POSHOLD = 16,
            /// <summary>  </summary>
            COPTER_MODE_BRAKE = 17,
            /// <summary>  </summary>
            COPTER_MODE_THROW = 18,
            /// <summary>  </summary>
            COPTER_MODE_AVOID_ADSB = 19,
            /// <summary>  </summary>
            COPTER_MODE_GUIDED_NOGPS = 20,
            /// <summary>  </summary>
            COPTER_MODE_SMART_RTL = 21,

            // arducopter 4.0.3 parameter
            COPTER_MODE_FLOW_HOLD = 22,
            COPTER_MODE_Follow = 23,
            COPTER_MODE_ZIGZAG = 24,
            COPTER_MODE_SYSTEM_ID = 25,
            COPTER_MODE_HELI_AUTOROTATE = 26,
        }

        /// <summary> A mapping of sub flight modes for custom_mode field of heartbeat. </summary>
        public enum SUB_MODE
        {
            /// <summary>  </summary>
            SUB_MODE_STABILIZE = 0,
            /// <summary>  </summary>
            SUB_MODE_ACRO = 1,
            /// <summary>  </summary>
            SUB_MODE_ALT_HOLD = 2,
            /// <summary>  </summary>
            SUB_MODE_AUTO = 3,
            /// <summary>  </summary>
            SUB_MODE_GUIDED = 4,
            /// <summary>  </summary>
            SUB_MODE_CIRCLE = 7,
            /// <summary>  </summary>
            SUB_MODE_SURFACE = 9,
            /// <summary>  </summary>
            SUB_MODE_POSHOLD = 16,
            /// <summary>  </summary>
            SUB_MODE_MANUAL = 19,
        }
        /// <summary> A mapping of rover flight modes for custom_mode field of heartbeat. </summary>
        public enum ROVER_MODE
        {
            /// <summary>  </summary>
            ROVER_MODE_MANUAL = 0,
            /// <summary>  </summary>
            ROVER_MODE_ACRO = 1,
            /// <summary>  </summary>
            ROVER_MODE_STEERING = 3,
            /// <summary>  </summary>
            ROVER_MODE_HOLD = 4,
            /// <summary>  </summary>
            ROVER_MODE_LOITER = 5,
            /// <summary>  </summary>
            ROVER_MODE_AUTO = 10,
            /// <summary>  </summary>
            ROVER_MODE_RTL = 11,
            /// <summary>  </summary>
            ROVER_MODE_SMART_RTL = 12,
            /// <summary>  </summary>
            ROVER_MODE_GUIDED = 15,
            /// <summary>  </summary>
            ROVER_MODE_INITIALIZING = 16,
        }
        /// <summary> A mapping of antenna tracker flight modes for custom_mode field of heartbeat. </summary>
        public enum TRACKER_MODE
        {
            /// <summary>  </summary>
            TRACKER_MODE_MANUAL = 0,
            /// <summary>  </summary>
            TRACKER_MODE_STOP = 1,
            /// <summary>  </summary>
            TRACKER_MODE_SCAN = 2,
            /// <summary>  </summary>
            TRACKER_MODE_SERVO_TEST = 3,
            /// <summary>  </summary>
            TRACKER_MODE_AUTO = 10,
            /// <summary>  </summary>
            TRACKER_MODE_INITIALIZING = 16,
        }

        public static List<KeyValuePair<string, byte>> GetCopterModes()
        {
            try
            {
                string[] flts = Enum.GetNames(typeof(COPTER_MODE));
                List<KeyValuePair<string, byte>> list = new List<KeyValuePair<string, byte>>();

                foreach (string flt in flts)
                {
                    byte value = Convert.ToByte(Enum.Parse(typeof(COPTER_MODE), flt));
                    string mode = flt.Replace("COPTER_MODE_", "");
                    list.Add(new KeyValuePair<string, byte>(mode, value));
                }
                return list;
            }
            catch (Exception)
            {
                return new List<KeyValuePair<string, byte>>();
            }
        }

    }
}
