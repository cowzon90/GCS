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
using PeachModel.Mavlink;
using PeachController.Controllers;
using System.Diagnostics;
using PeachModel.CommunicationPort;

namespace PeachView.Ucs.Setups.Calibrations
{
    public partial class UcCalibration_Accel : UserControl
    {
        public enum ACCELCALIBRATIONSTEP
        {
            START = 0,
            LEVEL = 1,
            LEFT = 2,
            RIGHT = 3,
            NOSEDOWN = 4,
            NOSEUP = 5,
            BACKSIDE = 6,
        }

        public UcCalibration_Accel()
        {
            InitializeComponent();
        }

        ~UcCalibration_Accel()
        {
            // TODO 
            //SetupController.Instance.AccelCalibration_Clear();
        }

        private void SetLabelMessageText(string text)
        {
            this.Invoke((Action)delegate
            {
                this.LabelMessage.Text = text;
            });
        }
        
        private void SetImageButtons(int index = -1)
        {
            this.Invoke((Action)delegate
            {
                foreach (Button button in this.Buttons)
                {
                    button.Enabled = false;
                    button.ForeColor = Color.Black;
                }
                if (index != -1)
                {
                    this.Buttons[index].Enabled = true;
                    this.Buttons[index].ForeColor = Color.Red;
                }
            });
        }

        private ushort Command_id = 241;
        private int pos = 0;
        private bool isStart = false;

        #region Init UI
        
        protected List<Button> Buttons { get; set; }

        private void InitUI_UcCalibration_Accel_Buttons()
        {
            // set buttons
            this.Buttons = new List<Button>()
            {
                this.button1, this.button2, this.button3,
                this.button4, this.button5, this.button6
            };

            for (int i = 0; i < this.Buttons.Count; i++)
            {
                Button button = this.Buttons[i];
                button.Dock = DockStyle.Fill;

                string filename = Path.Combine(Application.StartupPath, "Resources", "Calibration",
                    $"accel_{((ACCELCALIBRATIONSTEP)i + 1).ToString().ToLower()}.png");
                Bitmap bitmap = new Bitmap(filename);
                Bitmap resize = new Bitmap(bitmap, button.Size.Width, button.Size.Height);

                button.Text = $"{(ACCELCALIBRATIONSTEP)i + 1}";
                button.Click += this.Image_Butttons_click;
                button.Enabled = false;
                button.BackgroundImage = (Image)resize;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.Update();
            }
        }

        private void InitUI_UcCalibration_Accel()
        {
            this.InitUI_UcCalibration_Accel_Buttons();
        }

        #endregion

        #region Events

        private void UcCalibration_Accel_Load(object sender, EventArgs e)
        {
            this.InitUI_UcCalibration_Accel();
        }

        private void Image_Butttons_click(object sender, EventArgs e)
        {
            if (!isStart)
            {
                InterfaceController.Instance.GetCurrentVehicle().DoSubscribe(253, this.Receive_calibration_status_text, PERMANENCY.PERMANENT, -1);
                bool ack = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong(Command_id, 0, 0, 0, 0, 1, 0, 0);

                if (!ack)
                {
                    this.SetLabelMessageText("No ack received.. try again");
                    InterfaceController.Instance.GetCurrentVehicle().AddUnSubscriber(253);
                    return;
                }

                isStart = true;
                this.pos = 0;
                this.SetImageButtons(this.pos);
                this.SetLabelMessageText("Follow bellow images.");

                return;
            }
            
            InterfaceController.Instance.GetCurrentVehicle().SendMessage(new Message_COMMAND_ACK(1, (byte)(pos++)));

            // End all step.
            if (pos >= 6)
                return;

            this.SetImageButtons(this.pos);
        }

        #endregion

        #region Receiver
        private object Receive_calibration_status_text(Packet packet)
        {
            if (packet is null)
            {
                return false;
            }

            Message_STATUSTEXT message = (Message_STATUSTEXT)packet.Message;
            string lower = message.Text.ToLower();

            if (lower.StartsWith("calibration"))
            {
                this.SetLabelMessageText(message.Text);

                this.isStart = false;
                this.SetImageButtons();

                // unsubscribe.
                InterfaceController.Instance.GetCurrentVehicle().AddUnSubscriber(253);

                return true;
            }

            if (lower.Contains("place vehicle"))
            {
                this.SetLabelMessageText(message.Text);
            }

            return false;
        }

        #endregion
    }
}
