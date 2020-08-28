using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.UAVs
{
    public class VehicleParameters : Dictionary<string, VehicleParameter>
    {
        public DataTable ToTable()
        {
            try
            {
                // schema 
                // index    id      value       type        description
                List<Tuple<string, Type>> columns = new List<Tuple<string, Type>>()
                {
                    new Tuple<string, Type>("Index", typeof(ushort)),
                    new Tuple<string, Type>("Name", typeof(string)),
                    new Tuple<string, Type>("Value", typeof(double)),
                    new Tuple<string, Type>("Type", typeof(byte)),
                    new Tuple<string, Type>("Description", typeof(string))
                };
                
                DataTable dt = new DataTable();
                foreach(Tuple<string, Type> c in columns)
                {
                    dt.Columns.Add(c.Item1, c.Item2);
                }

                foreach(KeyValuePair<string, VehicleParameter> kv in this)
                {
                    VehicleParameter p = kv.Value;

                    dt.Rows.Add(new object[] { p.Index, p.StringId, p.Value, p.Type, p.Description });
                }

                dt.DefaultView.Sort ="Index asc";
                return dt;
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
    }
}
