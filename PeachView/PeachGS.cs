using PeachController.Controllers;
using PeachView.Ucs.Common;
using PeachView.Ucs.Configs;
using PeachView.Ucs.Monitors;
using PeachView.Ucs.Setups;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView
{
    public enum VIEWSTATE
    {
        MONITOR = 0,
        SETUP = 1,
        CONFIG = 2,
    }

    /// <summary>
    /// Main form
    /// </summary>
    public partial class PeachGS : Form
    {
        public PeachGS()
        {
            InitializeComponent();
        }

        protected Dictionary<VIEWSTATE, UserControl> MainUcs { get; set; }
        protected UcVehicleStatus_ UcVehicleStatus { get; set; }
        protected Panel MainPanel { get; set; }
        protected List<Control> Tops { get; set; }
        protected VIEWSTATE ViewState { get; set; }

        private void SetMainPanel(VIEWSTATE viewstate)
        {
            try
            {
                this.MainPanel.Controls.Clear();
                this.MainPanel.Controls.Add(this.MainUcs[viewstate]);

                (this.MainUcs[viewstate] as IUcTops).SetTops(this.Tops);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        #region UI Control settings

        private void InitUI_PeachGS_Labels()
        {
            string resource_path = Path.Combine(Application.StartupPath, "Resources");

            try
            {
                Bitmap bitmap = new Bitmap(Path.Combine(resource_path, "thepeachci.png"));

                Bitmap resize = new Bitmap(bitmap, this.LabelPeachCI.Size);

                this.LabelPeachCI.Image = resize;
                this.LabelPeachCI.ImageAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception e)
            {

                throw;
            }

            // Label vehicle status
            this.LabelVehicleStatus.Text = "";
            this.UcVehicleStatus = new UcVehicleStatus_() { Dock = DockStyle.Fill };
            this.LabelVehicleStatus.Controls.Add(this.UcVehicleStatus);
        }

        private void InitUI_PeachGS_Buttons()
        {
            string resource_path = Path.Combine(Application.StartupPath, "Resources");

            List<Button> buttons = new List<Button>()
            {
                this.ButtonMonitor, this.ButtonSetup, this.ButtonConfig, this.ButtonConnection
            };
            List<string> imagename = new List<string>()
            {
                "monitoring.png", "setup.png", "config.png", "drone_connection.png"
            };

            foreach (var val in buttons.Zip(imagename, Tuple.Create))
            {
                // load image
                Bitmap bitmap = new Bitmap(Path.Combine(resource_path, val.Item2));

                // adapt resized image.
                Button button = val.Item1;
                Bitmap resize = new Bitmap(bitmap, button.Size.Width, button.Size.Height);

                button.BackgroundImage = (Image)resize;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.ForeColor = Color.FromArgb(0, 255, 255, 255);
                button.BackColor = Color.FromArgb(0, 255, 255, 255);

                button.Click += this.ViewButtons_Click;

                // button set
                //button.BackColor = Color.Transparent;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

                // TODO : button -> round with OnPaint

                button.Update();
            }
        }

        private void InitUI_PeachGS_Panels()
        {
            // main user control setting.
            this.MainUcs = new Dictionary<VIEWSTATE, UserControl>();
            this.MainUcs.Add(VIEWSTATE.MONITOR, new UcMonitor() { Dock = DockStyle.Fill });
            this.MainUcs.Add(VIEWSTATE.SETUP, new UcSetup() { Dock = DockStyle.Fill });
            this.MainUcs.Add(VIEWSTATE.CONFIG, new UcConfig() { Dock = DockStyle.Fill });

            // MainPanel
            this.MainPanel = new Panel();
            this.MainPanel.Dock = DockStyle.Fill;
            this.Controls.Add(this.MainPanel);
        }

        private void InitUI_PeachGS()
        {
            this.Tops = new List<Control>()
            {
                this.LabelPeachCI, this.ButtonMonitor, this.ButtonSetup, this.ButtonConfig, this.LabelVehicleStatus, this.ButtonConnection
            };

            this.InitUI_PeachGS_Labels();

            this.InitUI_PeachGS_Buttons();

            this.InitUI_PeachGS_Panels();

            // init map.
            this.ViewButtons_Click(null, null);

        }

        #endregion

        #region Events

        /// <summary>
        /// Peach GS Main View Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PeachGS_Load(object sender, EventArgs e)
        {
            InitUI_PeachGS();
        }

        /// <summary>
        /// Buttons Click events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewButtons_Click(object sender, EventArgs e)
        {
            string buttonName;
            try
            {
                if (sender is null)
                {
                    throw new Exception("sender is null");
                }
                buttonName = (sender as Button).Text;
                string lower = this.ViewState.ToString().ToLower();
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
                case "Monitor":
                    this.ViewState = VIEWSTATE.MONITOR;
                    break;
                case "Setup":
                    this.ViewState = VIEWSTATE.SETUP;
                    break;
                case "Config":
                    this.ViewState = VIEWSTATE.CONFIG;
                    break;
                default:
                    this.ViewState = VIEWSTATE.MONITOR;
                    break;
            }

            this.SetMainPanel(this.ViewState);
        }

        /// <summary>
        /// Connection buttons click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnection_Click(object sender, EventArgs e)
        {
            FormConnection form = new FormConnection();
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                //this.UcVehicleStatus.Track();

                // TODO : Monitor
                UcMonitor ucMonitor = (UcMonitor)this.MainUcs[VIEWSTATE.MONITOR];
                ucMonitor.Track();
                
            }

        }
        #endregion

        private void PeachGS_FormClosed(object sender, FormClosedEventArgs e)
        {
            // release resources.
            try
            {
                InterfaceController.Instance.GetInterface().Dispose();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
