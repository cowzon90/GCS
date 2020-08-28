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
using System.IO.Ports;
using System.IO;
using PeachModel.BootLoaders;
using PeachModel.Firmwares;
using PeachController.Controllers;

namespace PeachView.Ucs.Setups
{
    public partial class UcFirmwareInstall : UserControl
    {
        public UcFirmwareInstall()
        {
            InitializeComponent();
        }

        private ArduPilotBL.UPLOADSTATE prevState = ArduPilotBL.UPLOADSTATE.NONE;
        private void Progress(ArduPilotBL.UPLOADSTATE state, string steps)
        {
            this.Invoke((Action)delegate
            {

                this.RichTextProgress.Text = $"{state}  :  {steps}";
                this.Update();
                return;
                /// new line
                if (state != prevState)
                {
                    this.RichTextProgress.Text += "\n" + $"{state.ToString().Replace("_", " ")} {steps}";
                    return;
                }

                // replace last line.
                this.RichTextProgress.Text += $"{state}  :  {steps}";
            });
        }

        private bool IsCustom { get; set; }
        private string defaultPath = Path.Combine(Application.StartupPath, "Resources", "Firmwares");

        private string GetFileName()
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                InitialDirectory = @"C:",
                Title = $"Load Custom Firmware",
            };

            DialogResult result = dialog.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                return dialog.FileName;
            }
            return string.Empty;
        }

        #region Init UI

        private void InitUI_UcFirmwareInstall_Buttons()
        {
            this.RButtonDefault.Click += this.RadioButton_Default_Custom_Click;
            this.RButtonCustom.Click += this.RadioButton_Default_Custom_Click;
            this.RButtonDefault.PerformClick();

            this.RButtonArdupilot.Click += this.RadioButton_ArduPilot_PX4_Click;
            this.RButtonPx4.Click += this.RadioButton_ArduPilot_PX4_Click;
            this.RButtonArdupilot.PerformClick();

            this.ButtonLoadFile.Click += this.ButtonLoadFile_Click;
            this.ButtonUpLoad.Click += ButtonUpLoad_Click;
        }

        private void InitUI_UcFirmwareInstall()
        {
            this.InitUI_UcFirmwareInstall_Buttons();
        }

        #endregion
        ArduPilotBL bl;
        #region Events

        /// <summary>
        /// Custom file load event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoadFile_Click(object sender, EventArgs e)
        {
            string result = this.GetFileName();
            if (result.Equals(string.Empty))
            {
                return;
            }

            this.TextPath.Text = result;
            this.TextFileName.Text = Path.GetFileName(result);
        }

        private void prev()
        {
            // check validation of port.
            string comport = "";
            var item = this.ComBoDefault.SelectedItem;
            if (item is null)
            {
                MessageBox.Show("no Comport");
                return;
            }
            comport = item.ToString();

            string filename_fw = comport;
            if (this.RButtonCustom.Checked)
            {
                filename_fw = comport;
            }

            // firmware binding.
            APFirmware firmware;
            try
            {
                this.RichTextProgress.Text = "Load firmware...";
                firmware = APFirmware.LoadFirmware(filename_fw);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Board id : {firmware.BoardId}");
                sb.AppendLine($"Board revision : {firmware.BoardRevision}");
                sb.AppendLine($"Summary : {firmware.Summary}");
                sb.AppendLine($"Version : {firmware.Version}");
                this.RichTextProgress.Text += "\n" + sb.ToString();

            }
            catch (Exception ex)
            {
                this.RichTextProgress.Text += $"\nInvalid firmware. {ex.Message}";
                return;
            }

            // detect board
            bl = new ArduPilotBL(comport);
            try
            {
                bl.Initialize();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("");
                sb.AppendLine($"BL_REV : {bl.BootLoaderRevision}");
                sb.AppendLine($"BoardId : {bl.BoardId}");
                sb.AppendLine($"BoardRevision : {bl.BoardRevision}");
                sb.AppendLine($"FirmwareMaxsize : {bl.FirmwareMaxsize}");
                sb.AppendLine($"Chip : {bl.Chip}");
                sb.AppendLine($"ChipDesc : {bl.ChipDesc}");
                this.RichTextProgress.Text += sb.ToString();

            }
            catch (Exception ex)
            {
                this.RichTextProgress.Text += $"\n{ex.Message}";
                return;
            }

            try
            {
                this.RichTextProgress.Text += "\nStart installation...";
                bl.ProgressEvent += this.Progress;
                bl.Install(firmware, true);
                bl.ProgressEvent -= this.Progress;
                this.RichTextProgress.Text += "\nComplete...";
            }
            catch (Exception ex)
            {
                this.RichTextProgress.Text += $"\nInstallation failed. {ex.Message}";
                return;
                throw;
            }
        }



        private void ButtonUpLoad_Click(object sender, EventArgs e)
        {
            string filename;
            if (IsCustom)
            {
                filename = this.TextPath.Text;
            }
            else
            {
                string dir = "ArduPilot";
                if (this.RButtonPx4.Checked)
                {
                    dir = "PX4";
                }

                if(this.ComBoDefault.SelectedItem == null)
                {
                    MessageBox.Show("Please select firmware in combobox.");
                    return;
                }
                //string name = this.ComBoDefault.SelectedItem.ToString();
                filename = Path.Combine(this.defaultPath, dir, this.ComBoDefault.SelectedItem.ToString());
            }

            if (!File.Exists(filename))
            {
                // no file.
                return;
            }

            try
            {
                this.RichTextProgress.Text = "Load firmware...";
                string result;
                bool isComplete = SetupController.Instance.LoadFirmware(filename, out result);

                if (!isComplete)
                {
                    this.RichTextProgress.Text += $"\nInvalid firmware.";
                    return;
                }

                this.RichTextProgress.Text += "\n" + result;
            }
            catch (Exception ex)
            {
                return;
            }

            try
            {
                SetupController.Instance.InstallFirmware(this.IsCustom, this.Progress);
            }
            catch (Exception)
            {
                return;
            }

        }

        /// <summary>
        /// RadioButton Ardupilot and PX4 click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_ArduPilot_PX4_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = "ArduPilot";
                if (this.RButtonPx4.Checked)
                    dir = "PX4";

                string path = Path.Combine(this.defaultPath, dir);


                this.ComBoDefault.Items.Clear();
                foreach (string name in Directory.GetFiles(path))
                {
                    this.ComBoDefault.Items.Add(Path.GetFileName(name));
                }

            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// RadioButton Default and Custom click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Default_Custom_Click(object sender, EventArgs e)
        {
            try
            {
                this.PanelDefault.Enabled = this.RButtonDefault.Checked;
                this.PanelCustom.Enabled = !this.RButtonDefault.Checked;
                this.IsCustom = !this.RButtonDefault.Checked;
            }
            catch (Exception)
            {
            }
        }

        private void UcFirmwareInstall_Load(object sender, EventArgs e)
        {
            this.InitUI_UcFirmwareInstall();
        }

        #endregion

    }
}
