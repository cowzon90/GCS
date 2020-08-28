using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeachController.Controllers;
using System.IO;
using PeachModel.Mavlink;
using System.Runtime.Remoting.Channels;

namespace PeachView.Ucs.Common
{
    public partial class UcVehicleStatus_ : UserControl
    {
        public UcVehicleStatus_()
        {
            InitializeComponent();
        }

        private readonly string resources = Path.Combine(Application.StartupPath, "Resources", "VehicleStatus");
        protected Timer Timer { get; set; }

        #region RC datas
        protected List<Bitmap> SignalImages { get; set; }

        private void SetRCData()
        {
            this.RCSignal = InterfaceController.Instance.GetCurrentVehicle().Rssi;
        }
        
        private byte _rcsignal;
        public byte RCSignal
        {
            get => _rcsignal;
            private set
            {
                _rcsignal = value;

                string text = "";
                int index;
                // 0-254 meaning value.
                // 255 -> invalid.

                double percentage = (double)(_rcsignal * 100 / 254);
                 text = $"{percentage}";

                if (_rcsignal == 255 | percentage == 0)
                {
                    text = $"No Signal";
                    index = 0;
                }
                else if (percentage <= 25)
                {
                    index = 1;
                }
                else if (percentage <= 50)
                {
                    index = 2;
                }
                else if (percentage <= 75)
                {
                    index = 3;
                }
                else// if (percentage <= 80)
                {
                    index = 4;
                }

                this.LabelRC.Image = this.SignalImages[index];
                this.LabelRC.Text = text;
            }
        }

        #endregion

        #region GPS datas

        private void SetGPSData()
        {
            this.GPSFixType = InterfaceController.Instance.GetCurrentVehicle().FixType;
            this.SatellitesNumber = InterfaceController.Instance.GetCurrentVehicle().SatellitesNum;
            this.HDOP = InterfaceController.Instance.GetCurrentVehicle().HDOP.ToString();
            this.VDOP = InterfaceController.Instance.GetCurrentVehicle().VDOP.ToString();
        }

        protected List<Bitmap> GPSImages { get; set; }

        public string SatellitesNumber { get; private set; }
        public string HDOP { get; private set; }
        public string VDOP { get; private set; }

        private string _GPSFIxType;
        public string GPSFixType
        {
            get => _GPSFIxType;
            private set
            {
                _GPSFIxType = value;
                this.LabelGPS.Text = _GPSFIxType;
                if (_GPSFIxType == "NO GPS")
                {
                    this.LabelGPS.Image = this.GPSImages[0];
                    return;
                }
                this.LabelGPS.Image = this.GPSImages[1];

            }
        }

        private string _gps;
        public string GPS
        {
            get => _gps;
            private set
            {
                _gps = value;
                this.LabelGPS.Text = $"{_gps}";

                if (_gps == "NO GPS")
                {
                    this.LabelGPS.Image = this.GPSImages[0];
                    return;
                }
                this.LabelGPS.Image = this.GPSImages[1];
            }
        }
        #endregion

        #region Battery Datas
        protected List<Bitmap> BatteryImages { get; set; }

        private void SetBatteryData()
        {
            this.Battery = InterfaceController.Instance.GetCurrentVehicle().VoltageBattery;
        }

        private double _battery;
        public double Battery
        {
            get => _battery;
            private set
            {
                _battery = value;

                // -1 means no calculated.
                // 0 ~ 100

                string text = string.Format("{0:0.##}", _battery);
                int index;

                double cal = _battery / 14.8 * 100.0;

                if (cal <= 0)
                {
                    text = $"No battery";
                    index = 0;
                }
                else if (cal <= 25)
                {
                    index = 1;
                }
                else if (cal <= 50)
                {
                    index = 2;
                }
                else if (cal <= 75)
                {
                    index = 3;
                }
                else
                {
                    index = 4;
                }

                this.LabelBattery.Text = text;
                this.LabelBattery.Image = this.BatteryImages[index];
            }
        }

        #endregion

        #region Default datas.

        private void SetDefaultData()
        {
            this.SysId = InterfaceController.Instance.GetCurrentVehicle().SystemId.ToString();
            this.CompId = InterfaceController.Instance.GetCurrentVehicle().ComponentId.ToString();
            this.MavVersion = InterfaceController.Instance.GetCurrentVehicle().IsMavlink2;

            this.Armed = InterfaceController.Instance.GetCurrentVehicle().IsArmed;

            string type = InterfaceController.Instance.GetCurrentVehicle().Type;
            string auto = InterfaceController.Instance.GetCurrentVehicle().AutoPilot;
            this.AutoPilot = $"{auto}_{type}";

        }

        private string _sysid;
        public string SysId
        {
            get => _sysid;
            set
            {
                _sysid = $"{value}";
                this.LabelSysId.Text = _sysid;
            }
        }

        private string _compid;
        public string CompId
        {
            get => _compid;
            set
            {
                _compid = $"{value}";
                this.LabelCompId.Text = _compid;
            }
        }

        private bool _mavversion;
        public bool MavVersion
        {
            get => _mavversion;
            set
            {
                _mavversion = value;
                if (_mavversion)
                {
                    this.LabelMavVersion.Text = $"v.2";
                    return;
                }
                this.LabelMavVersion.Text = $"v.1";
            }
        }

        private bool _armed;
        public bool Armed
        {
            get => _armed;
            set
            {
                _armed = value;
                if (_armed)
                {
                    this.LabelArmed.Text = "ARMED";
                    return;
                }
                this.LabelArmed.Text = "DIS ARMED";
            }
        }

        private string _autopilot;
        public string AutoPilot
        {
            get => _autopilot;
            set
            {
                _autopilot = value;
                this.LabelAutopilot.Text = _autopilot;
            }
        }

        #endregion

        #region Init UI
        private void InitUI_Timer()
        {
            this.Timer = new Timer();
            this.Timer.Interval = 250;
            this.Timer.Tick += Timer_Tick;
        }

        private void InitUI_Labels()
        {
            // set tooltips

            ToolTip gps = new ToolTip();
            gps.AutoPopDelay = 1000;
            gps.InitialDelay = 1000;
            gps.ReshowDelay = 1000;
            gps.ShowAlways = true;


        }

        private void InitUI_Images()
        {
            // Radio control signal
            string dir_signalImage = "Signal";
            string[] fn_signalImages = new string[]
            {
                "signal_no.png", "signal_verylow.png", "signal_low.png", "signal_enough.png", "signal_high.png"
            };
            int min = Math.Min(this.LabelRC.Width, this.LabelRC.Height);
            Size size_signal = new Size(min, min);
            this.SignalImages = new List<Bitmap>();
            foreach (string fn in fn_signalImages)
            {
                Bitmap origin = new Bitmap(Path.Combine(resources, dir_signalImage, fn));
                origin = new Bitmap(origin, size_signal);
                this.SignalImages.Add(origin);
            }

            // Battery Power
            string dir_batteryImage = "Battery";
            string[] fn_batteryImages = new string[]
            {
                "battery_no.png", "battery_verylow.png", "battery_low.png", "battery_enough.png", "battery_high.png"
            };

            this.BatteryImages = new List<Bitmap>();
            foreach (string fn in fn_batteryImages)
            {
                Bitmap origin = new Bitmap(Path.Combine(resources, dir_batteryImage, fn));
                origin = new Bitmap(origin, size_signal);
                this.BatteryImages.Add(origin);
            }

            // GPS
            string dir_gpsImage = "GPS";
            string[] fn_gpsImgaes = new string[]
            {
                "GPS_no.png", "GPS_on.png"
            };

            this.GPSImages = new List<Bitmap>();
            foreach(string fn in fn_gpsImgaes)
            {
                Bitmap bitmap_gps = new Bitmap(Path.Combine(resources, dir_gpsImage, fn));
                bitmap_gps = new Bitmap(bitmap_gps, size_signal);
                this.GPSImages.Add(bitmap_gps);
            }

            /// TODOs.
            // arming
            // more.

        }

        #endregion

        #region Events
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invoke((Action)delegate
            {
                if(InterfaceController.Instance.GetCurrentVehicle() == null)
                {
                    // not connected.
                    this.RCSignal = 0;
                    this.Battery = 0;
                    this.GPSFixType = "NO GPS";
                    return;
                }

                this.SetGPSData();
                this.SetBatteryData();
                this.SetRCData();
                this.SetDefaultData();
            });
        }

        private void UcVehicleStatus__Load(object sender, EventArgs e)
        {
            this.InitUI_Images();

            this.InitUI_Timer();
            this.Timer.Start(); // TODO
        }

        private void UcVehicleStatus__Resize(object sender, EventArgs e)
        {
            this.InitUI_Images();
        }
        #endregion
    }
}
