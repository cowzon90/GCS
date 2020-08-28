using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Ucs.Common
{
    public partial class ListUserControl: UserControl
    {
        public ListUserControl()
        {
            InitializeComponent();
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;

            }
        }

        public void AddRangeUserControl(List<UserControl> ucs)
        {
            foreach(var uc in ucs)
            {
                this.AddUserControl(uc);
            }
        }

        public void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Top;
            uc.MouseClick += this.Item_Click;
            uc.Tag = this.Layout.Controls.Count;
            foreach(Control c in uc.Controls)
            {
                c.MouseClick += this.Item_Click;
                c.Tag = this.Layout.Controls.Count;
            }

            this.Layout.Controls.Add(uc);
        }

        public UserControl GetUc(int index)
        {
            try
            {
                return (UserControl)this.Layout.Controls[index];
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            // sender -> index.
            try
            {
                var uc = (Control)sender;
                this.SelectedIndex = int.Parse(Convert.ToString(uc.Tag));
                foreach(Control c in this.Layout.Controls)
                {
                    var v = (UcConnectedVehicle)c;
                    v.IsSelected = false;
                }
                ((UcConnectedVehicle)this.Layout.Controls[this.SelectedIndex]).IsSelected = true;
            }
            catch (Exception)
            {
                this.SelectedIndex = -1;
            }
        }

        private void ListUserControl_Load(object sender, EventArgs e)
        {
            this.Layout.VerticalScroll.Visible = true;
            this.Layout.AutoScroll = true;
            this.AutoScroll = true;
            this.HScroll = false;
            this.VScroll = true;
            
        }
    }
    
}
