using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using PeachController.Controllers;
using PeachView.Components.HeadUpDisplay;
using System.Runtime.CompilerServices;

namespace PeachView.Ucs.Monitors
{
    public partial class UcHud : UserControl
    {
        public UcHud()
        {
            InitializeComponent();
        }

        protected Timer Timer { get; set; }

        protected HudLeft HudLeft { get; set; }
        protected HudRight HudRight { get; set; }

        public void Track()
        {
            this.Timer.Start();

        }

        public void UnTrack()
        {
            this.Timer.Stop();
        }

        #region Init UI

        private void InitUI_UcHud_Timer()
        {
            this.Timer = new Timer();
            this.Timer.Interval = 250;
            this.Timer.Tick += Timer_Tick;
        }

        private void InitUI_UcHud_Label()
        {
            this.HudLeft = new HudLeft()
            {
                Dock = DockStyle.Fill
            };
            this.LabelLeft.Controls.Add(this.HudLeft);

            this.HudRight = new HudRight()
            {
                Dock = DockStyle.Fill
            };
            this.LabelRight.Controls.Add(this.HudRight);


            this.LabelLeft.Text = "";
            this.LabelRight.Text = "";
        }
        

        private void InitUI_UcHud()
        {
            this.InitUI_UcHud_Timer();

            this.InitUI_UcHud_Label();
        }

        #endregion

        #region Events

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invoke((Action)delegate
            {
                if (InterfaceController.Instance.GetCurrentVehicle() == null)
                {
                    // not connected.
                    return;
                }

                this.HudRight.Degree = (int)InterfaceController.Instance.GetCurrentVehicle().yaw;
                this.HudLeft.Pitch = (int)InterfaceController.Instance.GetCurrentVehicle().pitch;
                this.HudLeft.Roll = (int)InterfaceController.Instance.GetCurrentVehicle().roll;
            });
        }

        private void UcHud__Load(object sender, EventArgs e)
        {
            this.InitUI_UcHud();
        }

        #endregion

        private void UcHud__Resize(object sender, EventArgs e)
        {
            int width = this.Size.Width / 2;
            int height = this.Size.Height;

            this.LabelLeft.Size = new Size(width, height);

        }

        private void hudLeft1_Click(object sender, EventArgs e)
        {

        }
    }
}
