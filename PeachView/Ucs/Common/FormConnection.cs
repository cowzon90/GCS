using PeachController.Controllers;
using PeachModel.CommunicationPort;
using PeachModel.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Ucs.Common
{
    public partial class FormConnection : Form
    {
        private List<string> portNames = new List<string>()
        {
            "AUTO", "TCP", "UDP",
        };

        private List<string> baudrates = new List<string>()
        {
            "4800", "9600", "19200", "38400", "57600", "115200", "460800", "921600", "1500000"
        };

        protected ListUserControl ListUserControl { get; set; }

        public FormConnection()
        {
            InitializeComponent();
        }

        #region Init UI
        private void Init_FormConnection_Comboboxes()
        {
            this.ComboComPort.Items.Clear();
            this.ComboComPort.Items.AddRange(portNames.ToArray());
            List<string> devices = ComPort.GetDevicePorts(true);
            this.ComboComPort.Items.AddRange(devices.ToArray());

            this.ComboBaudrates.Items.Clear();
            this.ComboBaudrates.Items.AddRange(this.baudrates.ToArray());
        }

        private void Init_FormConnection_Connected()
        {
            this.ListUserControl = new ListUserControl()
            {
                Dock = DockStyle.Fill,
            };
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(this.ListUserControl);
            
            List<Tuple<int, int, string, string>> list = InterfaceController.Instance.GetConnectedList();
            //list = new List<Tuple<int, int, string>>();
            //list.Add(new Tuple<int, int, string>(10, 10, "Ardupilot"));
            //list.Add(new Tuple<int, int, string>(15, 15, "PX4"));
            //list.Add(new Tuple<int, int, string>(20, 20, "ARdupilot Copter dfasdfasdfasdfasfdasdfsdfasdfsd"));
            //list.Add(new Tuple<int, int, string>(20, 20, "ARdupilot Copter"));
            //list.Add(new Tuple<int, int, string>(20, 20, "ARdupilot Copter"));


            if (list == null)
            {
                return;
            }

            foreach (Tuple<int, int, string, string> item in list)
            {
                int sys = item.Item1;
                int comp = item.Item2;
                string auto = item.Item3;
                string type = item.Item4;
                this.ListUserControl.AddUserControl(new UcConnectedVehicle(sys, comp, auto, type));
            }
        }

        private void InitUI_FormConnection()
        {
            this.Init_FormConnection_Comboboxes();
            this.Init_FormConnection_Connected();

        }
        #endregion
        #region Events
        private void FormConnection_Load(object sender, EventArgs e)
        {
            this.InitUI_FormConnection();
        }

        private void ComboComPort_MouseClick(object sender, MouseEventArgs e)
        {
            this.Init_FormConnection_Comboboxes();
        }

        /// <summary>
        /// Connect Button Click Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string portName = this.ComboComPort.SelectedItem.ToString();
                string buadrate = this.ComboBaudrates.SelectedItem.ToString();

                switch (portName)
                {
                    case "AUTO":
                        throw new NotImplementedException();
                    case "TCP":
                        throw new NotImplementedException();
                    case "UDP":
                        throw new NotImplementedException();
                    default:
                        break;
                }

                bool result = InterfaceController.Instance.GetInterface().ConnectUAV(portName, int.Parse(buadrate));

                if (result)
                {
                    this.DialogResult = DialogResult.OK;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DisConnect Button Click Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDisConnect_Click(object sender, EventArgs e)
        {

            int index = this.ListUserControl.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("please select connected vehicle");
                return;
            }

            var uc = (UcConnectedVehicle)this.ListUserControl.GetUc(index);
            int sys = uc.SystemId;
            int comp = uc.ComponentId;

            InterfaceController.Instance.GetInterface().DisConnectUAV(sys, comp);
            this.Init_FormConnection_Connected();
        }
        #endregion

    }
        
}
