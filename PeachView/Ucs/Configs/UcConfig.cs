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
using PeachView.Ucs.Common;

namespace PeachView.Ucs.Configs
{
    public enum CONFIGSTEP
    {
        PARAMETER = 0,
        GSCONFIG = 1,
    }

    public partial class UcConfig : UserControl, IUcTops
    {
        public UcConfig()
        {
            InitializeComponent();
        }

        protected CONFIGSTEP ConfigStep { get; set; }

        public void SetTops(List<Control> controls)
        {
            foreach (Control c in controls)
            {
                if (!this.PanelTop.Controls.Contains(c))
                {
                    this.PanelTop.Controls.Add(c);
                }
            }
        }

        private void InitUI_UcConfig()
        {
            // buttons
            this.ButtonParameter.Click += this.Button_Clicks;
            this.ButtonGSConfig.Click += this.Button_Clicks;

            // invoke.
            this.Button_Clicks(null, null);

        }

        private void UcConfig_Load(object sender, EventArgs e)
        {
            this.InitUI_UcConfig();
        }

        private void Button_Clicks(object sender, EventArgs e)
        {
            string buttonName;
            try
            {
                if (sender is null)
                {
                    throw new Exception("sender is null");
                }
                buttonName = (sender as Button).Text;
                string lower = this.ConfigStep.ToString().ToLower();
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
                case "Parameter":
                    this.ConfigStep = CONFIGSTEP.PARAMETER;
                    this.PanelMain.Controls.Clear();
                    this.PanelMain.Controls.Add(new UcParameters()
                    {
                        Dock = DockStyle.Fill
                    });
                    break;
                case "GS Config":
                    this.ConfigStep = CONFIGSTEP.GSCONFIG;
                    this.PanelMain.Controls.Clear();
                    this.PanelMain.Controls.Add(new UcGSConfig()
                    {
                        Dock = DockStyle.Fill
                    });
                    break;
                default:
                    this.ConfigStep = CONFIGSTEP.PARAMETER;
                    this.PanelMain.Controls.Clear();
                    this.PanelMain.Controls.Add(new UcParameters()
                    {
                        Dock = DockStyle.Fill
                    });
                    break;
            }
        }


    }
}
