using PeachModel.UAVs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace PeachView.Components.TreeListView
{
    public class pTreeListView : ListView
    {
        public pTreeListView() : base()
        {
            this.SetDeafult();
            this.SetEvents();
            this.InitTextBox();
            this.ChangedList = new Dictionary<string, Tuple<double, double>>();
        }

        private void SetDeafult()
        {
            this.View = View.Details;
            this.GridLines = true;
            this.FullRowSelect = true;
            this.MultiSelect = false;

        }

        private void SetEvents()
        {
            this.MouseClick += this.PTreeListView_MouseClick;
            this.MouseDoubleClick += this.PTreeListView_MouseClick;
            this.ItemSelectionChanged += PTreeListView_ItemSelectionChanged;
        }

        private Color highlight = Color.Red;

        private void PTreeListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Type type = sender.GetType();

            if (e.Item.Selected)
            {
                e.Item.BackColor = this.highlight;
                e.Item.ForeColor = this.highlight;
            }
            else
            {
                e.Item.BackColor = this.BackColor;
                e.Item.ForeColor = this.ForeColor;
            }
        }

        #region search



        #endregion

        private ListViewItem selectedListViewItem;
        public ListViewItem SelectedListViewItem
        {
            get => this.selectedListViewItem;
        }

        private ListViewSubItem selectedListViewSubItem;
        public ListViewSubItem SelectedListViewSubItem
        {
            get => this.selectedListViewSubItem;
        }

        private void PTreeListView_MouseClick(object sender, MouseEventArgs e)
        {
            selectedListViewItem = this.GetItemAt(e.X, e.Y);
            if (selectedListViewItem is null) return;

            selectedListViewSubItem = selectedListViewItem.GetSubItemAt(e.X, e.Y);
            if (selectedListViewSubItem is null) return;

            ListViewHitTestInfo t = new ListViewHitTestInfo(selectedListViewItem, selectedListViewSubItem, ListViewHitTestLocations.AboveClientArea);

            int index = selectedListViewItem.SubItems.IndexOf(selectedListViewSubItem);
            if (index != 1) return;

            this.SetTextBoxState(true, selectedListViewSubItem.Bounds);
            this.TextBox.Text = selectedListViewSubItem.Text;
        }

        private Dictionary<string, VehicleParameter> parameters;
        public Dictionary<string, VehicleParameter> Parameters
        {
            get => parameters;
            set
            {
                parameters = value;
                this.SetDataSource(parameters);
            }
        }

        private void SetDataSource(Dictionary<string, VehicleParameter> datasource)
        {
            if (datasource == null) return;


            List<string> keys = datasource.Keys.ToList();
            keys.Sort();

            Dictionary<string, int> match = new Dictionary<string, int>();

            ListViewGroup group = null;
            foreach (string key in keys)
            {
                string tag = key.Split('_')[0];

                if (!match.ContainsKey(tag))
                {
                    group = new ListViewGroup(tag);
                    match.Add(tag, 0);
                    this.Groups.Add(group);
                }

                VehicleParameter p = datasource[key];

                var item = this.TopListViewItem(p);

                group.Items.Add(item);
                this.Items.Add(item);
            }
        }

        private pListViewItem TopListViewItem(VehicleParameter parameter)
        {
            pListViewItem listViewItem = new pListViewItem();

            listViewItem.Text = parameter.StringId;

            // Value -> TextBox
            ListViewSubItem value = new ListViewSubItem(listViewItem, Convert.ToString(parameter.Value));
            listViewItem.SubItems.Add(value);
            //value.InvokeResize(this);

            // Type
            ListViewSubItem type = new ListViewSubItem(listViewItem, Convert.ToString(parameter.Type));
            listViewItem.SubItems.Add(type);

            // Index
            ListViewSubItem index = new ListViewSubItem(listViewItem, Convert.ToString(parameter.Index));
            listViewItem.SubItems.Add(index);

            ListViewSubItem description = new ListViewSubItem(listViewItem, parameter.Description);
            listViewItem.SubItems.Add(description);

            return listViewItem;
        }

        #region TextBox 
        private TextBox TextBox { get; set; }

        private void InitTextBox()
        {
            this.TextBox = new TextBox();
            this.TextBox.Visible = false;
            this.TextBox.Parent = this;
            this.TextBox.MouseLeave += TextBox_MouseLeave;
            //this.TextBox.LostFocus += TextBox_MouseLeave;
        }

        private void SetTextBoxState(bool visible, Rectangle bound = default(Rectangle))
        {
            this.TextBox.Visible = visible;
            int x = bound.X;
            int y = bound.Y;
            int widht = bound.Width;
            int height = bound.Height;
            this.TextBox.SetBounds(x, y, widht, height);
        }

        private void TextBox_MouseLeave(object sender, EventArgs e)
        {
            // TODO : save data to subitem.
            if (this.selectedListViewSubItem == null)
            {
                this.SetTextBoxState(false);
                return;
            }

            double value;
            if (!Double.TryParse(this.TextBox.Text, out value))
            {
                this.SetTextBoxState(false);
                MessageBox.Show("Invalid value.");
                return;
            }

            this.ChangedListCheck(value);

            this.selectedListViewSubItem.Text = this.TextBox.Text;
            this.SetTextBoxState(false);
        }
        #endregion

        public Dictionary<string, Tuple<double, double>> ChangedList { get; set; }

        private void ChangedListCheck(double value)
        {
            double old = Convert.ToDouble(this.selectedListViewSubItem.Text);
            string name = this.selectedListViewItem.Text;

            if (old != value)
            {
                if (this.ChangedList.ContainsKey(name))
                {
                    return;
                }

                this.ChangedList.Add(name, new Tuple<double, double>(old, value));
            }
        }

        public List<int> FindAll(string search)
        {
            string lower = search.ToLower();
            List<int> list = new List<int>();
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Text.ToLower().Contains(lower))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public void SetItemFocus(int index)
        {
            if (index < 0 | index >= this.Items.Count)
            {
                return;
            }

            this.Items[index].Selected = true;
            this.Items[index].EnsureVisible();
        }

    }
}
