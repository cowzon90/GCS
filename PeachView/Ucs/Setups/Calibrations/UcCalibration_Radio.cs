using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeachView.Components;
using PeachController.Controllers;
using PeachModel.Mavlink;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using PeachModel.Mavlink.Ardupilotmega;
using PeachModel.CommunicationPort;

namespace PeachView.Ucs.Setups.Calibrations
{
    public enum FLIGHT_MODE
    {
        NONE = 0,
        FLIGHT_MODE_1 = 1,
        FLIGHT_MODE_2 = 2,
        FLIGHT_MODE_3 = 3,
        FLIGHT_MODE_4 = 4,
        FLIGHT_MODE_5 = 5,
        FLIGHT_MODE_6 = 6,
    }

    public partial class UcCalibration_Radio : UserControl, IDisposable
    {
        /// Constructor / De-Constructor / Load
        #region Initialization.
        public UcCalibration_Radio()
        {
            InitializeComponent();
        }

        ~UcCalibration_Radio()
        {
            try
            {
                if(InterfaceController.Instance.GetCurrentVehicle() != null)
                {
                    InterfaceController.Instance.GetCurrentVehicle().AddUnSubscriber(22);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Load Radio Calibration User control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcCalibration_Radio_Load(object sender, EventArgs e)
        {
            this.InitUI_UcCalibration_Radio();
        }

        public new void Dispose()
        {

        }

        #endregion

        private readonly string[] rcmap_names = new string[]
        {
            "RCMAP_ROLL", "RCMAP_PITCH", "RCMAP_THROTTLE", "RCMAP_YAW"
        };

        protected bool IsStart { get; private set; } = false;
        protected Timer TimerCalibration { get; private set; }

        protected List<Label> RCLabels { get; set; }
        protected List<string> RCNames { get; set; }

        protected Dictionary<string, int> RcMaps { get; set; }
        protected Dictionary<int, bool> Reverses { get; set; }
        protected List<DualTrackBar> DualTrackbars { get; set; }

        protected Dictionary<string, float> Mins { get; set; }
        protected Dictionary<string, float> Maxs { get; set; }

        protected List<ComboBox> Combos { get; set; }

        /// <summary>
        ///  TODO : vehicle data set.
        /// </summary>
        /// <returns></returns>
        private bool ReadRadioParameters()
        {
            try
            {
                this.RcMaps = new Dictionary<string, int>();

                foreach(string name in this.rcmap_names)
                {
                    try
                    {
                        int v = (int)InterfaceController.Instance.GetParameter(name);
                        this.RcMaps.Add(name, v);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }

                this.Reverses = new Dictionary<int, bool>();
                // check reverse.
                for(int i = 1; i < 5; i++)
                {
                    string name = $"RC{i}_REVERSED";

                    try
                    {
                        int v = (int)InterfaceController.Instance.GetParameter(name);
                        bool result = v == 0 ? true : false;
                        this.Reverses.Add(i, result);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }

                int t = 0;
                foreach(KeyValuePair<string, int> v in this.RcMaps)
                {
                    string text = this.RCNames[t];
                    text += $" ({v.Value})";
                    string pad = this.Reverses[v.Value] == true ? "" : "R";
                    text += $" {pad}";
                    this.RCLabels[t].Text = text;
                    t++;
                }

                // Flight mode set up.
                object temp = InterfaceController.Instance.GetParameter("FLTMODE_CH");
                if (temp == null)
                {
                    this.FlightModeChannel = 0;
                    this.LabelCurrentChanel.Text = $"Disabled";
                }
                else
                {
                    this.FlightModeChannel = Convert.ToInt32(temp);
                    this.LabelCurrentChanel.Text = $"Channel {this.FlightModeChannel}";
                }

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private FLIGHT_MODE ConvertPWM(ushort pwm)
        {
            if (pwm < 0)
            {
                return FLIGHT_MODE.NONE;
            }
            else if (pwm <= 1230)
            {
                return FLIGHT_MODE.FLIGHT_MODE_1;
            }
            else if (pwm <= 1360)
            {
                return FLIGHT_MODE.FLIGHT_MODE_2;
            }
            else if (pwm <= 1490)
            {
                return FLIGHT_MODE.FLIGHT_MODE_3;
            }
            else if (pwm <= 1620)
            {
                return FLIGHT_MODE.FLIGHT_MODE_4;
            }
            else if (pwm <= 1759)
            {
                return FLIGHT_MODE.FLIGHT_MODE_5;
            }
            else
            {
                return FLIGHT_MODE.FLIGHT_MODE_6;
            }
        }

        private int FlightModeChannel { get; set; }

        #region Init UI

        private void InitUI_UcCalibration_Radio_TrackBars()
        {
            DualTrackbars = new List<DualTrackBar>()
            {
                this.dualTrackBar1, this.dualTrackBar2, this.dualTrackBar3, this.dualTrackBar4,
                this.dualTrackBar5, this.dualTrackBar6, this.dualTrackBar7, this.dualTrackBar8,
            };

            foreach (var bar in DualTrackbars)
            {
                //bar.Value = 1500;
                bar.SetRange(0, 3000);
            }
        }

        private void InitUI_UcCalibration_Radio_RCLabels()
        {
            this.RCLabels = new List<Label>()
            {
                this.LabelRoll, this.LabelPitch, this.LabelThrottle, this.LabelYaw,
                this.LabelAux1, this.LabelAux2, this.LabelAux3, this.LabelAux4
            };
            this.RCNames = new List<string>()
            {
                "ROLL", "PITCH", "THROTTLE", "YAW", "AUX1", "AUX2", "AUX3", "AUX4"
            };

            foreach(var item in this.RCLabels.Zip(this.RCNames, Tuple.Create))
            {
                Label label = item.Item1;
                label.Text = item.Item2;
            }

        }

        private void InitUI_UcCalibration_Radio_Timer()
        {
            this.TimerCalibration = new Timer();
            this.TimerCalibration.Interval = 50;
            this.TimerCalibration.Tick += TimerCalibration_Tick;

        }
        
        private void InitUI_UcCalibration_Radio_Flight_Mode()
        {
            this.LabelCurrentChanel.Text = "";
            this.LabelCurrentFlightMode.Text = "";
            this.LabelCurrentMode.Text = "";

            Combos = new List<ComboBox>()
            {
                this.ComboFlightMode1, this.ComboFlightMode2, this.ComboFlightMode3,
                this.ComboFlightMode4, this.ComboFlightMode5, this.ComboFlightMode6
            };

            List<KeyValuePair<string, byte>> kvp = PeachModel.Mavlink.Ardupilotmega.MavEnums.GetCopterModes();

            foreach(ComboBox combo in Combos)
            {
                combo.Items.Clear();
                combo.DisplayMember = "Key";
                combo.ValueMember = "Value";
                combo.DataSource = PeachModel.Mavlink.Ardupilotmega.MavEnums.GetCopterModes();

            }

            this.LabelCurrentChanel.Text = $"Disabled";
            
        }

        private void InitUI_UcCalibration_Radio()
        {
            this.InitUI_UcCalibration_Radio_TrackBars();

            this.InitUI_UcCalibration_Radio_RCLabels();

            this.InitUI_UcCalibration_Radio_Timer();

            this.InitUI_UcCalibration_Radio_Flight_Mode();
        }

        #endregion

        #region Events

        private void TimerCalibration_Tick(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle().Chan1_raw > 800
                & InterfaceController.Instance.GetCurrentVehicle().Chan1_raw < 2200)
            {
                this.Invoke((Action)delegate
                {
                    this.dualTrackBar1.Value = InterfaceController.Instance.GetCurrentVehicle().Chan1_raw;
                    this.dualTrackBar2.Value = InterfaceController.Instance.GetCurrentVehicle().Chan2_raw;
                    this.dualTrackBar3.Value = InterfaceController.Instance.GetCurrentVehicle().Chan3_raw;
                    this.dualTrackBar4.Value = InterfaceController.Instance.GetCurrentVehicle().Chan4_raw;
                    this.dualTrackBar5.Value = InterfaceController.Instance.GetCurrentVehicle().Chan5_raw;
                    this.dualTrackBar6.Value = InterfaceController.Instance.GetCurrentVehicle().Chan6_raw;
                    this.dualTrackBar7.Value = InterfaceController.Instance.GetCurrentVehicle().Chan7_raw;
                    this.dualTrackBar8.Value = InterfaceController.Instance.GetCurrentVehicle().Chan8_raw;

                    if(this.FlightModeChannel != 0)
                    {
                        // TODO :
                        FLIGHT_MODE mode = this.ConvertPWM(InterfaceController.Instance.GetCurrentVehicle().Chan5_raw);
                        this.LabelCurrentFlightMode.Text = mode.ToString().Replace("_", " ");

                        object v = InterfaceController.Instance.GetParameter($"FLTMODE{Convert.ToByte(mode)}");
                        if(v != null)
                        {
                            byte t = Convert.ToByte(v);
                            this.LabelCurrentMode.Text = Enum.GetName(typeof(PeachModel.Mavlink.Ardupilotmega.MavEnums.COPTER_MODE), t).Replace("COPTER_MODE_", "");
                        }
                    }
                });
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            // when under doing calibration.
            if (IsStart)
            {
                // stop calibration timer
                this.TimerCalibration.Stop();

                IsStart = false;
                this.ButtonStart.Text = "Start";
                // set data.

                int i = 1;
                foreach(DualTrackBar bar in this.DualTrackbars)
                {
                    string rc_min = $"RC{i}_MIN";
                    InterfaceController.Instance.GetCurrentVehicle().SetParameter(rc_min, bar.MinValue);
                    this.Mins.Add(rc_min, InterfaceController.Instance.GetParameter(rc_min));

                    string rc_max = $"RC{i}_MAX";
                    InterfaceController.Instance.GetCurrentVehicle().SetParameter(rc_max, bar.MaxValue);
                    this.Maxs.Add(rc_max, InterfaceController.Instance.GetParameter(rc_max));

                    i++;
                }

                StringBuilder sb = new StringBuilder();
                foreach(var v in this.Mins.Zip(this.Maxs, Tuple.Create))
                {
                    sb.AppendLine($"{v.Item1.Key} : {v.Item1.Value} - {v.Item2.Key} : {v.Item2.Value}");
                }
                MessageBox.Show(sb.ToString());

                return;
            }

            if (!this.ReadRadioParameters())
            {
                // TODO : parameter is not ready.
                return;
            }

            this.Mins = new Dictionary<string, float>();
            this.Maxs = new Dictionary<string, float>();
            this.InitUI_UcCalibration_Radio_TrackBars();
            IsStart = true;
            this.ButtonStart.Text = "Complete";

            // get data stream.
            // enforcing
            InterfaceController.Instance.GetCurrentVehicle().SetDataStream(10, (byte)PeachModel.Mavlink.MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_RC_CHANNELS);

            this.TimerCalibration.Start();
        }

        #endregion

        private void ButtonFLTSet_Click(object sender, EventArgs e)
        {
            if(this.FlightModeChannel == 0)
            {
                return;
            }

            int i = 1;
            foreach(ComboBox combo in this.Combos)
            {
                try
                {
                    byte v = Convert.ToByte(combo.SelectedValue);
                    InterfaceController.Instance.GetCurrentVehicle().SetParameter($"FLTMODE{i++}", v);
                }
                catch (Exception ex)
                {
                }
            }



        }
    }
}
