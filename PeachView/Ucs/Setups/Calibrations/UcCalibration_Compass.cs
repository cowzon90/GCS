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
using System.Diagnostics;
using PeachModel.Interface;
using PeachModel.Mavlink.Ardupilotmega;
using PeachModel.CommunicationPort;

namespace PeachView.Ucs.Setups.Calibrations
{
    public partial class UcCalibration_Compass : UserControl
    {
        public UcCalibration_Compass()
        {
            InitializeComponent();
        }

        ~UcCalibration_Compass()
        {
            try
            {
                if (InterfaceController.Instance.GetCurrentVehicle() != null)
                {
                    InterfaceController.Instance.GetCurrentVehicle().AddUnSubscriber(191);
                    InterfaceController.Instance.GetCurrentVehicle().AddUnSubscriber(192);
                }
            }
            catch (Exception)
            {
            }
        }

        protected List<ProgressBar> ProgressBars { get; set; }
        protected List<bool> ProgressCompletes { get; set; }

        protected Timer TimerComplete { get; set; }

        private bool IsStart { get; set; } = false;

        #region Compass Init

        protected double compass_dec = 0;
        protected double compass_min = 0;
        protected double compass_autodec = 0;
        protected double calift = 0;

        protected List<Compass> Compasses { get; set; }

        private bool CompassParameterSetting()
        {
            try
            {
                object temp_dec = InterfaceController.Instance.GetParameter("COMPASS_DEC");
                if (temp_dec != null)
                {
                    this.compass_dec = (float)temp_dec;
                    this.compass_min = (this.compass_dec - (int)this.compass_dec) * 60;
                    this.compass_dec = Math.Floor(this.compass_dec);
                }

                object temp_autodec = InterfaceController.Instance.GetParameter("COMPASS_AUTODEC");
                if (temp_autodec != null)
                {
                    this.compass_autodec = (float)temp_autodec;
                }

                object temp_calfit = InterfaceController.Instance.GetParameter("COMPASS_CAL_FIT");
                if (temp_calfit != null)
                {
                    this.calift = (float)temp_calfit;
                }

                Compasses = new List<Compass>();
                for (int i = 1; i < 4; i++)
                {
                    Compass compass = this.SetCompass(i);
                    if (compass is null)
                    {
                        continue;
                    }
                    Compasses.Add(compass);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private Compass SetCompass(int index)
        {
            string a = index.ToString();
            string external = $"COMPASS_EXTERN{index}";
            if (a == "1")
            {
                a = "";
                external = "COMPASS_EXTERNAL";
            }

            List<string> queries = new List<string>()
            {
                $"COMPASS_USE{a}", external, $"COMPASS_ORIENT{a}",
                $"COMPASS_OFS{a}_X", $"COMPASS_OFS{a}_Y", $"COMPASS_OFS{a}_Z",
                $"COMPASS_MOT{a}_X", $"COMPASS_MOT{a}_Y", $"COMPASS_MOT{a}_Z"
            };

            List<float> datas = new List<float>();
            foreach (string query in queries)
            {
                object temp = InterfaceController.Instance.GetParameter(query);
                if (temp == null)
                {
                    return null;
                }

                datas.Add((float)temp);
            }

            Compass compass = new Compass()
            {
                CompassUse = datas[0],
                CompassExternal = datas[1],
                CompassOrient = datas[2],
                CompassOFSX = datas[3],
                CompassOFSY = datas[4],
                CompassOFSZ = datas[5],
                CompassMOTX = datas[6],
                CompassMOTY = datas[7],
                CompassMOTZ = datas[8]
            };
            return compass;
        }
        #endregion

        #region TODO : 
        protected List<RichTextBox> TestRichs { get; set; }
        private void WriteRich(int index, string text)
        {
            this.Invoke((Action)delegate
            {
                try
                {
                    RichTextBox rich = this.TestRichs[index];

                    rich.Text = text;

                }
                catch (Exception e)
                {

                }
            });
        }

        private void ShowRich()
        {
            this.richTextBox1.Visible = !this.richTextBox1.Visible;
            this.richTextBox6.Visible = !this.richTextBox6.Visible;
            this.richTextBox2.Visible = !this.richTextBox2.Visible;
            this.richTextBox5.Visible = !this.richTextBox5.Visible;
            this.richTextBox3.Visible = !this.richTextBox3.Visible;
            this.richTextBox4.Visible = !this.richTextBox4.Visible;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F3:
                    this.ShowRich();
                    break;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Receiver
       
        private Dictionary<int, int> Rec { get; set; }

        private object Receive_Mag_cal_progress(Packet packet)
        {
            if (packet is null)
            {
                return false;
            }

            var message = (Message_MAG_CAL_PROGRESS)packet.Message;
            if (message.IsValid)
            {
                try
                {
                    int compassId = message.compass_id;

                    lock (this.Rec)
                    {
                        if (!this.Rec.ContainsKey(compassId))
                        {
                            this.Rec.Add(compassId, compassId);
                        }
                    }

                    // TODO ;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("received MAG_CAL_PROGRESS");
                    sb.AppendLine($"id : {message.compass_id}, direction xyz : {message.direction_x}, {message.direction_y}, {message.direction_z}");
                    sb.AppendLine($"attempt : {message.attempt}, cal_mask : {message.cal_mask}, " +
                        $"cal_status : {((PeachModel.Mavlink.Ardupilotmega.MavEnums.MAG_CAL_STATUS)message.cal_status).ToString()}");
                    sb.AppendLine($"completion_pct : {message.completion_pct}");
                    this.WriteRich(compassId, sb.ToString());
                    // TODO :


                    this.Invoke((Action)delegate
                    {
                        if(message.attempt >= 3)
                        {
                            this.Stop_Calibration(isUser:false);
                        }

                        if (!this.ProgressCompletes[compassId])
                        {
                            this.ProgressBars[compassId].Value = message.completion_pct;
                        }

                        for(int i = 0; i < 3; i++)
                        {
                            if (this.ProgressCompletes[i])
                            {
                                this.ProgressBars[i].Value = 100;
                            }
                        }
                    });

                }
                catch (Exception e)
                {

                    throw;
                }
            }

            return false;
        }

        private object Receive_Mag_cal_report(Packet packet)
        {
            if (packet is null)
            {
                return false;
            }

            var message = (Message_MAG_CAL_REPORT)packet.Message;
            //Debug.WriteLine($"{message.IsValid}");
            if (message.IsValid)
            {
                // TODO : 
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("received MAG_CAL_REPORT");
                sb.AppendLine($"id : {message.compass_id}, fitness : {message.fitness}");
                sb.AppendLine($"offset xyz : {message.ofs_x}, {message.ofs_y}, {message.ofs_z}");
                sb.AppendLine($"diagonal xyz : {message.diag_x}, {message.diag_y}, {message.diag_z}");
                sb.AppendLine($"offset diagonal xyz : {message.offdiag_x}, {message.offdiag_y}, {message.offdiag_z}");
                sb.AppendLine($"cal_mask : {message.cal_mask}, cal_status : {message.cal_status}");
                sb.AppendLine($"autosaved : {message.autosaved}");
                sb.AppendLine($"orientation_confidence : {message.orientation_confidence}");
                sb.AppendLine($"old_orientation : {message.old_orientation}, new_orientation : {message.new_orientation}");
                sb.AppendLine($"scale_factor : {message.scale_factor}");

                this.WriteRich(message.compass_id + 3, sb.ToString());

                // TODO : 

                if (message.cal_status == 4)
                {
                    this.Invoke((Action)delegate
                    {
                        this.ProgressCompletes[message.compass_id] = true;
                    });
                }

                //Debug.WriteLine($"Mag cal report - {message.cal_status}");
            }


            return false;
        }
        #endregion

        #region Init UI

        private void InitUI_UcCalibration_Compass_ProgressBar()
        {
            this.ProgressCompletes = new List<bool>()
            {
                false, false, false
            };

            this.ProgressBars = new List<ProgressBar>()
            {
                this.ProgressBarMag1, this.ProgressBarMag2, this.ProgressBarMag3
            };

            foreach (ProgressBar bar in this.ProgressBars)
            {
                bar.Value = 0;
                bar.Style = ProgressBarStyle.Continuous;
            }

            //this.ProgressBarMag1.Value = 50;
        }

        private void InitUI_UcCalibration_Compass_Timer()
        {
            this.TimerComplete = new Timer();
            this.TimerComplete.Interval = 500;
            this.TimerComplete.Tick += TimerComplete_Tick;
        }

        private void TimerComplete_Tick(object sender, EventArgs e)
        {
            bool isCompleted = true;
            foreach (KeyValuePair<int, int> kv in this.Rec)
            {
                isCompleted &= this.ProgressCompletes[kv.Key];
            }

            if (isCompleted)
            {
                this.TimerComplete.Stop();
                this.Invoke((Action)delegate
                {
                    this.LabelMessage.Text = "Compass Calibration Complete";
                });
                this.Stop_Calibration();

            }

        }

        private void InitUI_UcCalibration_Compass()
        {
            this.TestRichs = new List<RichTextBox>()
            {
                this.richTextBox1, this.richTextBox2, this.richTextBox3,
                this.richTextBox6, this.richTextBox5, this.richTextBox4
            };

            InitUI_UcCalibration_Compass_ProgressBar();

            this.InitUI_UcCalibration_Compass_Timer();
        }

        #endregion

        #region Events

        private void UcCalibration_Compass_Load(object sender, EventArgs e)
        {
            this.InitUI_UcCalibration_Compass();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (this.IsStart)
            {
                // stop 
                this.Stop_Calibration();
                return;
            }

            this.Start_Calibration();
        }
        #endregion

        private void Start_Calibration()
        {
            this.LabelMessage.Text = "";

            if (!this.CompassParameterSetting())
            {
                return;
            }

            this.Rec = new Dictionary<int, int>();

            this.ProgressCompletes = new List<bool>();
            foreach (var t in this.Compasses)
            {
                this.ProgressCompletes.Add(false);
            }
            this.TimerComplete.Start();
            this.LabelMessage.Text = "Calibrating";

            // command id 42424
            InterfaceController.Instance.GetCurrentVehicle().SetDataStream(10, (byte)PeachModel.Mavlink.MavEnums.MAV_DATA_STREAM.MAV_DATA_STREAM_EXTRA3);
            bool ack = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong(42424, 0, 1, 1, 0, 0, 0, 0);
            if (!ack)
            {
                // no ack
                this.LabelMessage.Text = "No ack received. try again..";
            }

            InterfaceController.Instance.GetCurrentVehicle().DoSubscribe(191, this.Receive_Mag_cal_progress, PERMANENCY.PERMANENT);
            InterfaceController.Instance.GetCurrentVehicle().DoSubscribe(192, this.Receive_Mag_cal_report, PERMANENCY.PERMANENT);

            this.IsStart = true;
            this.ButtonStart.Text = "Stop";
        }

        private void Stop_Calibration(bool isUser = true)
        {
            string text = "";
            if (!isUser)
                text = $"Please retry...\nYes - Accept current calibration result.\nNo - just Stop";
            else
                text = $"Yes - Accept current calibration result.\nNo - just Stop";

            DialogResult r = MessageBox.Show(text, "", MessageBoxButtons.YesNoCancel);

            bool ack;
            switch (r)
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    // write current value.
                    ack = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong((ushort)PeachModel.Mavlink.Ardupilotmega.MavEnums.MAV_CMD.MAV_CMD_DO_ACCEPT_MAG_CAL, 0, 0, 0, 0, 0, 0, 0);
                    break;
                case DialogResult.No:
                    // just stop.
                    ack = InterfaceController.Instance.GetCurrentVehicle().SendCommandLong((ushort)PeachModel.Mavlink.Ardupilotmega.MavEnums.MAV_CMD.MAV_CMD_DO_CANCEL_MAG_CAL, 0, 0, 0, 0, 0, 0, 0);
                    break;
            }

            InterfaceController.Instance.GetCurrentVehicle().AddUnSubscriber(191);
            InterfaceController.Instance.GetCurrentVehicle().AddUnSubscriber(192);
            this.LabelMessage.Text = "";
            this.IsStart = false;
            this.ButtonStart.Text = "Start";
        }
    }
}
