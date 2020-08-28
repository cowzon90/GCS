using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PeachView.Ucs.Setups.Calibrations
{
    public enum CALIBRATIONSTEP
    {
        ACCEL = 0,
        COMPASS = 1,
        RADIO  = 2,
        ESC = 3,
    }

    public partial class UcCalibration : UserControl
    {
        public UcCalibration()
        {
            InitializeComponent();
        }

        protected CALIBRATIONSTEP CalibrationStep { get; set; }

        public void InitUI_UcCalibration()
        {
            // add event to buttons.
            this.ButtonAccel.Click += this.Calibration_Button_Click;
            this.ButtonCompass.Click += this.Calibration_Button_Click;
            this.ButtonRadio.Click += this.Calibration_Button_Click;
            this.ButtonESC.Click += this.Calibration_Button_Click;

            // init default -> accel.
            this.Calibration_Button_Click(null, null);

        }

        private void Calibration_Button_Click(object sender, EventArgs e)
        {
            string buttonName;
            try
            {
                if (sender is null)
                {
                    throw new Exception("sender is null");
                }
                buttonName = (sender as Button).Text;
                string lower = this.CalibrationStep.ToString().ToLower();
                if (lower.Equals(buttonName.ToLower()))
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                buttonName = string.Empty;
            }

            switch (buttonName)
            {
                case "Accel":
                    this.CalibrationStep = CALIBRATIONSTEP.ACCEL;
                    this.PanelMain.Controls.Clear();
                    this.PanelMain.Controls.Add(new UcCalibration_Accel()
                    {
                        Dock = DockStyle.Fill
                    });
                    break;
                case "Compass":
                    this.CalibrationStep = CALIBRATIONSTEP.COMPASS;
                    this.PanelMain.Controls.Clear();
                    this.PanelMain.Controls.Add(new UcCalibration_Compass()
                    {
                        Dock = DockStyle.Fill
                    });
                    break;
                case "Radio":
                    this.CalibrationStep = CALIBRATIONSTEP.RADIO;
                    this.PanelMain.Controls.Clear();
                    this.PanelMain.Controls.Add(new UcCalibration_Radio()
                    {
                        Dock = DockStyle.Fill
                    });
                    break;
                case "ESC":
                    this.CalibrationStep = CALIBRATIONSTEP.ESC;
                    this.PanelMain.Controls.Clear();
                    this.PanelMain.Controls.Add(new UcCalibration_ESC()
                    {
                        Dock = DockStyle.Fill
                    });
                    break;
                default:
                    this.CalibrationStep = CALIBRATIONSTEP.ACCEL;
                    this.PanelMain.Controls.Clear();
                    this.PanelMain.Controls.Add(new UcCalibration_Accel()
                    {
                        Dock = DockStyle.Fill
                    });
                    break;
            }

        }

        /// <summary>
        /// Load this usercontrol.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcCalibrationMain_Load(object sender, EventArgs e)
        {
            this.InitUI_UcCalibration();
        }
    }
}
