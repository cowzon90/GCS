using PeachModel.UAVs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Components.TreeListView
{
    public class pListViewItem : ListViewItem
    {
        public pListViewItem(VehicleParameter parameter) : base()
        {
            this.Parameter = parameter;
        }

        public pListViewItem() : base()
        {

        }

        private VehicleParameter parameter;
        public VehicleParameter Parameter
        {
            get => parameter;
            private set
            {
                parameter = value;
                this.SetListItems(parameter);
            }
        }

        private void SetListItems(VehicleParameter parameter)
        {
            if (parameter is null) return;

            this.Text = parameter.StringId;

            string[] strs = new string[]
            {
                //this.Parameter.ID, 
                Convert.ToString(this.Parameter.Value), Convert.ToString(this.Parameter.Type), Convert.ToString(this.Parameter.Index), this.Parameter.Description,
            };
            foreach (string str in strs)
            {
                this.SubItems.Add(new ListViewSubItem(this, str));
            }
        }
    }
}
