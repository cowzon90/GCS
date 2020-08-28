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
using System.IO;
using System.Diagnostics;

namespace PeachView.Ucs.Configs
{
    public partial class UcParameters : UserControl
    {
        public UcParameters()
        {
            InitializeComponent();
        }

        #region Init UI
        
        private void InitUI_UcParameters()
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null) return;

            this.ButtonSearch.Click += this.ButtonSearch_Click;
            this.TextSearch.TextChanged += this.TextBox_TextChanged;
            this.TextSearch.KeyPress += this.KeyPress_TextBox;

            this.InitUI_Parameters();
        }

        private void InitUI_Parameters()
        {
            // pTreeListView
            this.pTreeListView1.Parameters = InterfaceController.Instance.GetCurrentVehicle().Parameters;
            this.pTreeListView1.Columns.Add("ID");
            this.pTreeListView1.Columns.Add("Value");
            this.pTreeListView1.Columns.Add("Type");
            this.pTreeListView1.Columns.Add("Index");
            this.pTreeListView1.Columns.Add("Description");
        }

        #endregion

        #region Events
        private void UcParameters_Load(object sender, EventArgs e)
        {
            this.InitUI_UcParameters();
        }

        /// <summary>
        /// Sample.
        /// </summary>
        private void DataTableQuery()
        {
            DataTable parameterTable = new DataTable();
            string search = "search";

            var rows = from row in parameterTable.AsEnumerable()
                       where row.Field<string>("Name").ToLower().Contains(search) == true
                       select row;
        }

        private List<int> indices;
        private int current;

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string search = this.TextSearch.Text;

            if (string.Empty == search) return;

            this.indices = this.pTreeListView1.FindAll(search);
            //this.KeyPress_TextBox(null, null);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            this.TextSearch.KeyPress -= this.KeyPress_TextBox;
            this.indices = null;
            this.ButtonSearch.PerformClick();
            this.current = -1;
            this.TextSearch.KeyPress += this.KeyPress_TextBox;
        }

        private void KeyPress_TextBox(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.current++;

                if (current >= this.indices.Count) this.current = 0;

                if (this.indices.Count <= 0) return;

                this.pTreeListView1.SetItemFocus(this.indices[this.current]);

            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                this.indices = null;
                this.current = -1;
            }
            else
            {
            }
        }
        #endregion

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (InterfaceController.Instance.GetCurrentVehicle() is null) return;

            foreach(KeyValuePair<string, Tuple<double, double>> pair in this.pTreeListView1.ChangedList)
            {
                double oldval = pair.Value.Item1;
                double newval = pair.Value.Item2;

                if (oldval == newval) continue;

                var result = InterfaceController.Instance.GetCurrentVehicle().SetParameter(pair.Key, (float)newval);
                Debug.WriteLine($"try to change {pair.Key} from {oldval} to {newval} is {result}");
            }
        }
    }
}
