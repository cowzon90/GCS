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
using PeachModel.CommunicationPort;

namespace PeachView.Ucs.Setups.Calibrations
{
    public enum ESC_STEPS : int
    {
        STEP1 = 0,
        STEP2 = 1,
        STEP3 = 2,
        STEP4 = 3,
        STEP5 = 4,
        STEP6 = 5,
        STEP7 = 6,
    }

    /// <summary>
    /// User Control for ESC Calibration.
    /// </summary>
    public partial class UcCalibration_ESC : UserControl
    {
        public UcCalibration_ESC()
        {
            InitializeComponent();
        }

        protected List<Label> Labels { get; set; }

        private Color GetColor_Completion(bool isCurrent)
        {
            if (isCurrent)
            {
                return Color.Red;
            }
            return Color.Black;
        }

        private ESC_STEPS _currentStep;
        /// <summary>
        /// Current Step value.
        /// </summary>
        protected ESC_STEPS CurrentStep
        {
            get
            {
                return _currentStep;
            }
            set
            {
                this._currentStep = value;
                this.SetCurrentStep();
            }
        }

        /// <summary>
        /// Set image and label state on current step.
        /// </summary>
        private void SetCurrentStep()
        {
            if (this.Labels is null) return;

            foreach(Label label in this.Labels)
            {
                label.ForeColor = this.GetColor_Completion(false);
            }
            
            int index = Convert.ToInt32(this.CurrentStep);
            if(index <= 6)
            {
                this.Labels[index].ForeColor = this.GetColor_Completion(true);
                // Image set.
                this.LabelPicture.Text = $"{this.CurrentStep}";
            }
        }

        #region Init UI
        private void InitUI_UcCalibration_ESC_Buttons()
        {
            this.ButtonNext.Click += this.StepButton_Click;
            this.ButtonPrevious.Click += this.StepButton_Click;
        }

        private void InitUI_UcCalibration_ESC_Labels()
        {
            // step label setting.
            this.Labels = new List<Label>()
            {
                this.label1, this.label2, this.label3, this.label4, this.label5, this.label6, this.label7
            };

            foreach (Label label in this.Labels)
            {
                label.ForeColor = this.GetColor_Completion(false);
                label.Dock = DockStyle.Fill;
            }
        }

        private void InitUI_UcCalibration_ESC()
        {
            // all Buttons setup
            this.InitUI_UcCalibration_ESC_Buttons();

            // all Labels setups
            this.InitUI_UcCalibration_ESC_Labels();

            this.CurrentStep = ESC_STEPS.STEP1;

            // Timer setup.
            this.InitUI_UcCalibration_ESC_Timer();
        }
        #endregion

        #region Events
        /// <summary>
        /// Load this User control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcCalibration_ESC_Load(object sender, EventArgs e)
        {
            this.InitUI_UcCalibration_ESC();
        }

        /// <summary>
        /// Previous and Next buttons click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int step = Convert.ToInt32(this.CurrentStep);
            if (button.Equals(this.ButtonPrevious))
            {
                if (step == 0) return;
                this.CurrentStep = (ESC_STEPS)(step - 1);
            }
            else
            {
                if(step == 6)
                {
                    this.CurrentStep = ESC_STEPS.STEP1;
                    return;
                }
                this.CurrentStep = (ESC_STEPS)(step + 1);
            }
        }

        #endregion

        #region TODO:

        protected Timer Timer { get; private set; }

        protected bool IsStart { get; private set; } = false;

        private void InitUI_UcCalibration_ESC_Timer()
        {
            this.Timer = new Timer();
            this.Timer.Interval = 100;
            this.Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.IsStart)
            {
                this.IsStart = false;
                this.Timer.Stop();
                this.Invoke((Action)delegate
                {
                    this.label8.Text = "Follow steps on below.";
                });
            }
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            this.IsStart = false;

            // TODO 
            // send ESC_CALIBRATION param_set
            //InterfaceController.SetParamValue("ESC_CALIBRATION", 3);
            //InterfaceController.GetInterface().Subscribe.DoSubscribe(1, 1, 22, this.Receive_ESC_CALIBRATION_VALUE, PERMANENCY.DISPOSABLE, 5);
            //this.Timer.Start();

        }

        private object Receive_ESC_CALIBRATION_VALUE(Packet packet)
        {
            if (packet is null)
            {
                return false;
            }

            Message_PARAM_VALUE message = (Message_PARAM_VALUE)packet.Message;
            if (message.IsValid)
            {
                string id = Encoding.ASCII.GetString(message.param_id).TrimEnd('\0');
                if (id == "ESC_CALIBRATION" & message.param_value == 3)
                {
                    this.IsStart = true;
                }
                return true;
            }


            return false;
        }
        #endregion

    }
}
