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
using PeachModel.Mavlink;
using PeachModel.UAVs;
using PeachModel.CommunicationPort;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;

namespace PeachView.Ucs.Common
{
    public partial class UcCommandTest : UserControl
    {
        public UcCommandTest()
        {
            InitializeComponent();

            this.Init_Timer();
        }


        public Timer Timer { get; set; }
        private void Init_Timer()
        {
            this.Timer = new Timer();
            this.Timer.Interval = 250;
            this.Timer.Tick += Timer_Tick;
            this.Timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null)
            {
                this.Invoke((Action)delegate
                {
                    this.richTextBox1.Text = "";
                });
                return;
            }

            this.Invoke((Action)delegate
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{InterfaceController.Instance.GetCurrentVehicle().GetCopterMode()}");

                this.richTextBox1.Text = sb.ToString();
            });
        }

        private void ButtonArm_Click(object sender, EventArgs e)
        {

            if (InterfaceController.Instance.GetCurrentVehicle() is null)
            {
                return;
            }

            float param1 = 0;
            float param2 = 0;
            bool armed = InterfaceController.Instance.GetCurrentVehicle().IsArmed;
            if (!armed)
                param1 = 1;

            try
            {
                if ((sender as Button).Text == "Force Arm") param2 = 21196;
            }
            catch (Exception)
            {

            }

            bool r = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong(400, param1, param2, 0, 0, 0, 0, 0);

        }

        private void ButtonRTL_Click(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null)
            {
                return;
            }

            bool r = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong(20, 0, 0, 0, 0, 0, 0, 0);
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

        private void ButtonTakeOff_Click(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null)
            {
                return;
            }

            FormInputText f = new FormInputText(InputType.ALT);

            if(f.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if(f.Value == null)
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
    }
}
