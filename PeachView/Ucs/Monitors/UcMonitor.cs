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
using PeachController.Controllers;
using PeachModel.Mavlink;
using System.Runtime.Remoting.Channels;
using System.Runtime.InteropServices.WindowsRuntime;
using PeachView.Ucs.Common;
using PeachModel.CommunicationPort;

namespace PeachView.Ucs.Monitors
{
    public partial class UcMonitor : UserControl, IUcTops
    {
        public UcMonitor()
        {
            InitializeComponent();
        }

        protected Panel PanelMap { get; private set; }
        protected UcMonitorMap UcMonitorMap { get; private set; }
        protected UcHud UcHud { get; private set; }

        public UcMonitorMap GetUcMonitorMap()
        {
            return this.UcMonitorMap;
        }

        // TODO 
        public void Track()
        {
            MonitorController.Instance.SetMonitoringDataStream();

            this.UcMonitorMap.Track();
            this.UcHud.Track();
        }
        // TODO 
        public void UnTrack()
        {
            this.UcMonitorMap.UnTrack();
            this.UcHud.UnTrack();
        }

        #region Init UI
        /// <summary>
        /// setting for buttons
        /// </summary>
        private void InitUI_UcMonitor_Buttons()
        {
            List<Button> buttons = new List<Button>()
            {
                this.ButtonTakeOff, this.ButtonLand, this.ButtonRTL,
            };

            foreach(Button button in buttons)
            {

                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            }
        }

        protected UcCommandTest UcCommand { get; set; }
        protected bool IsCommandVIsible { get; set; } = false;

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData.Equals(Keys.F3))
            {
                if(this.UcCommand is null)
                {
                    this.UcCommand = new UcCommandTest()
                    {
                        Height = 300,
                        Dock = DockStyle.Bottom,
                    };
                }

                if (IsCommandVIsible)
                {
                    this.Controls.Remove(this.UcCommand);
                }
                else
                {
                    this.Controls.Add(this.UcCommand);
                }
                this.IsCommandVIsible = !this.IsCommandVIsible;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// setting for panels
        /// </summary>
        private void InitUI_UcMonitor_Panels()
        {
            // Panel Map
            this.PanelMap = new Panel();
            this.PanelMap.Dock = DockStyle.Fill;
            this.Controls.Add(this.PanelMap);
            this.UcMonitorMap = new UcMonitorMap()
            {
                Dock = DockStyle.Fill
            };
            this.PanelMap.Controls.Add(this.UcMonitorMap);

            // Huds
            this.UcHud = new UcHud()
            {
                Dock = DockStyle.Fill
            };
            this.LabelHud.Controls.Add(this.UcHud);
            this.LabelHud.Text = "";
            this.UcMonitorMap.SetBottomHud(this.LabelHud);

            this.LabelHud.Location = new Point(this.Width / 2 - this.LabelHud.Width / 2, this.Height - this.LabelHud.Height - 10);

            // Flight plan
            this.LabelFlightPlan.Visible = true;
            Point newPoint = new Point(this.Location.X + this.Size.Width, this.LabelFlightPlan.Location.Y);
            this.LabelFlightPlan.Location = newPoint;

            // Flight plan invoking label
            this.LabelPlanTab.Text = "P\nL\nA\nN";
            this.LabelPlanTab.Visible = false;

        }

        /// <summary>
        /// Init ui for all.
        /// </summary>
        private void InitUI_UcMonitor()
        {

            this.InitUI_UcMonitor_Buttons();
            
            this.InitUI_UcMonitor_Panels();
        }

        #endregion

        #region Events
        
        private void UcMonitor_Load(object sender, EventArgs e)
        {
            this.InitUI_UcMonitor();
        }
        #endregion

        public void SetTops(List<Control> controls)
        {
            this.GetUcMonitorMap().SetTops(controls);
        }

        private void ButtonTakeOff_Click(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null)
            {
                return;
            }

            FormInputText f = new FormInputText(InputType.ALT);

            if (f.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (f.Value == null)
            {
                // invalid value.
                MessageBox.Show("Invalid value");
                return;
            }

            float alt = (float)f.Value;

            if (!InterfaceController.Instance.GetCurrentVehicle().IsArmed)
            {
                // set mode to stabilize for arming.
                var mode = InterfaceController.Instance.GetCurrentVehicle().SetCopterMode(PeachModel.Mavlink.Ardupilotmega.MavEnums.COPTER_MODE.COPTER_MODE_STABILIZE);

                bool arm = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong(400, 1, 21196, 0, 0, 0, 0, 0);
            }

            // set mode to guided for take off.
            var guided = InterfaceController.Instance.GetCurrentVehicle().SetCopterMode(PeachModel.Mavlink.Ardupilotmega.MavEnums.COPTER_MODE.COPTER_MODE_GUIDED);

            bool r = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong(22, 0, 0, 0, 0, 0, 0, alt);
        }

        private void ButtonLand_Click(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null)
            {
                return;
            }

            // set mode to LAND for landing
            var mode = InterfaceController.Instance.GetCurrentVehicle().SetCopterMode(PeachModel.Mavlink.Ardupilotmega.MavEnums.COPTER_MODE.COPTER_MODE_LAND);

            float lat = (float)InterfaceController.Instance.GetCurrentVehicle().Latitude;
            float lon = (float)InterfaceController.Instance.GetCurrentVehicle().Longitude;
            float alt = 0;

            bool r = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong(21, 0, 0, 0, 0, lat, lon, alt);
        }

        private void ButtonRTL_Click(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null)
            {
                return;
            }

            bool r = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong(20, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
