using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.IO;

namespace PeachView.Ucs.Common
{
    public partial class UcRadioSignal : UserControl
    {
        public UcRadioSignal()
        {
            InitializeComponent();
        }

        private readonly string resources = Path.Combine(Application.StartupPath, "Resources", "VehicleStatus");

        protected List<Bitmap> Images { get; set; }
        protected Timer Timer { get; set; }

        private byte _rssi;
        public byte RSSI
        {
            get => _rssi;
            set
            {
                _rssi = value;

                string text = "";
                int index;
                // 0-254 meaning value.
                // 255 -> invalid.

                double percentage = (double)(_rssi * 100 / 254);
                text = $"{percentage}";

                if (_rssi == 255 | percentage == 0)
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

                this.BackgroundImage = this.Images[index];
                this.LabelRssi.Text = text;
            }
        }

        private void InitUI_Images()
        {
            // Radio control signal
            string dir_signalImage = "Signal";
            string[] fn_signalImages = new string[]
            {
                "signal_no.png", "signal_verylow.png", "signal_low.png", "signal_enough.png", "signal_high.png"
            };

            this.Images = new List<Bitmap>();
            foreach (string fn in fn_signalImages)
            {
                Bitmap origin = new Bitmap(Path.Combine(resources, dir_signalImage, fn));
                Size size = new Size(this.Width * 3 / 4, this.Height * 3 / 4);
                origin = new Bitmap(origin, size);
                this.Images.Add(origin);
            }
        }

        private void InitUI_this()
        {
            this.BackgroundImageLayout = ImageLayout.Center;

            this.Timer = new Timer();
            this.Timer.Interval = 250;
            this.Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
        }

        #region Events
        private void UcRadioSignal_Load(object sender, EventArgs e)
        {
            this.InitUI_this();

            this.InitUI_Images();
        }

        private void UcRadioSignal_Resize(object sender, EventArgs e)
        {
            this.InitUI_Images();
        }
        #endregion
    }
}
