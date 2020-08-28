using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView
{
    public partial class PeachGS2 : Form
    {
        public PeachGS2()
        {
            InitializeComponent();
            this.Init();
        }

        private List<Button> Buttons { get; set; }
        private List<Panel> Panels { get; set; }

        public void Init()
        {
            Color BackColor = Color.FromArgb(80, 0, 0, 0);

            this.Buttons = new List<Button>()
            {
                this.button1, this.button2, this.button3
            };
            
            foreach(Button button in this.Buttons)
            {
                button.Click += this.Button_Click;
                button.BackColor = BackColor;
            }
            
            this.Panels = new List<Panel>()
            {
                this.PanelButton1, this.PanelButton2, this.PanelButton3
            };

            foreach(Panel panel in this.Panels)
            {
                for(int i = 0; i < 3; i++)
                {
                    Button button = new Button()
                    {
                        BackColor = BackColor,
                        Dock = DockStyle.Top,
                    };
                    panel.Controls.Add(button);
                }
                panel.Visible = false;
                panel.BackColor = BackColor;
                panel.BorderStyle = BorderStyle.None;
            }

        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            int index = this.Buttons.IndexOf(button);

            bool visible = this.Panels[index].Visible;
            this.Panels[index].Visible = !visible;
        }
    }
}
