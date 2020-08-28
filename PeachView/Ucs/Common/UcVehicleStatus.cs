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
using System.Reflection;

namespace PeachView.Ucs.Common
{
    public partial class UcVehicleStatus : UserControl
    {
        public UcVehicleStatus()
        {
            InitializeComponent();
        }

        protected Timer Timer { get; set; }

        /// <summary>
        /// Call for Tracking Uav status.
        /// </summary>
        public void Track()
        {
            this.Timer.Start();
        }

        public void UnTrack()
        {
            this.Timer.Stop();
        }

        private void SetData()
        {
            this.Invoke((Action)delegate
            {
                StringBuilder sb = new StringBuilder();

                int sysid = MonitorController.Instance.GetSystemId();
                int compid = MonitorController.Instance.GetComponentId();
                int mavlink = MonitorController.Instance.GetMavlinkVersion();
                sb.AppendLine($"SysId : {sysid},  CompId : {compid}, version : {0 /*mavlink*/}");

                byte basemode = MonitorController.Instance.GetBaseMode();
                bool armed = (basemode & 128) == 128;
                sb.AppendLine($"Armed : {armed}");
                sb.AppendLine($"system state : {MonitorController.Instance.GetSystemStatus()}");


                //object current_battery = InterfaceController.GetInterface().VehicleData.current_battery;
                //object rssi = InterfaceController.GetInterface().VehicleData.Rssi;
                //sb.AppendLine($"battery : {current_battery}, signal : {rssi}");

                this.richTextBox1.Text = sb.ToString();
            });
        }

        #region Init UI

        private void InitUI_Timer()
        {
            this.Timer = new Timer();
            this.Timer.Interval = 250;
            this.Timer.Tick += Timer_Tick;
        }

        private void InitUI_UcVehicleStatus()
        {

            this.InitUI_Timer();
        }

        #endregion

        #region Events

        private void UcVehicleStatus_Load(object sender, EventArgs e)
        {
            this.InitUI_UcVehicleStatus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null) return;

            //if (InterfaceController.GetInterface().ComPort is null) return;

            //if (!InterfaceController.GetInterface().ComPort.IsOpen) return;

            this.SetData();
        }

        #endregion


    }
}
