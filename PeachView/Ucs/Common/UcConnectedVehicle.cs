using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;

namespace PeachView.Ucs.Common
{
    public partial class UcConnectedVehicle : UserControl
    {
        private UcConnectedVehicle()
        {
            InitializeComponent();
        }

        public UcConnectedVehicle(int sysid, int compid, string autopilot, string type)// : base()
        {
            this.InitializeComponent();
            this.SystemId = sysid;
            this.ComponentId = compid;
            this.AutoPilot = autopilot;
            this.Type = type;
        }

        public int SystemId { get; private set; }
        public int ComponentId { get; private set; }
        public string AutoPilot { get; private set; }
        public string Type { get; private set; }

        /// <summary>
        /// Image loading : TODO
        /// </summary>
        private void InitUI_UcConnectedVehicle_Image()
        {
        }

        private void InitUI_UcConnectedVehicle_ListBox()
        {
            this.listBox1.Items.Add($"SYS ID : {this.SystemId}");
            this.listBox1.Items.Add($"COMP ID : {this.ComponentId}");
            this.listBox1.Items.Add($"{this.AutoPilot}");
            this.listBox1.Items.Add($"{this.Type}");
        }

        private void UcConnectedVehicle_Load(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                c.MouseEnter += this.this_MouseEnter;
                c.MouseLeave += this.this_MouseLeave;
            }

            this.InitUI_UcConnectedVehicle_Image();

            this.InitUI_UcConnectedVehicle_ListBox();

            this.Prev = this.BackColor;
        }

        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                if (_isSelected) this.BackColor = this.HighLightColor;
                else this.BackColor = this.Prev;
            }
        }

        [Category("Custom Properties")]
        public Color HighLightColor { get; set; } = Color.Yellow;
        public Color Prev { get; private set; }

        private void this_MouseEnter(object sender, EventArgs e)
        {
            if (IsSelected) return;
            this.BackColor = this.HighLightColor;
        }

        private void this_MouseLeave(object sender, EventArgs e)
        {
            if (IsSelected) return;
            this.BackColor = this.Prev;
        }

        private void this_MouseClick(object sender, EventArgs e)
        {

        }

    }
}
