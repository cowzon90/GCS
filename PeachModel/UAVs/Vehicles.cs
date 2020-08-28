using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.UAVs
{
    public class Vehicles : Dictionary<Tuple<int, int>, Vehicle>
    {
        /// <summary>
        /// return vehicle and it is nullable.
        /// </summary>
        /// <param name="systemid"></param>
        /// <param name="componentid"></param>
        /// <returns></returns>
        public Vehicle Get(int systemid, int componentid)
        {
            Vehicle vehicle;
            this.TryGetValue(new Tuple<int, int>(systemid, componentid), out vehicle);
            return vehicle;
        }


        public void Add(int systemid, int componentid, Vehicle vehicle)
        {
            base.Add(new Tuple<int, int>(systemid, componentid), vehicle);
        }

        /// <summary>
        /// For hiding.
        /// </summary>
        /// <param name="tuple"></param>
        private new void Remove(Tuple<int, int> tuple)
        {
            base.Remove(tuple);
        }

        /// <summary>
        /// Remove vehicle
        /// </summary>
        /// <param name="systemid"></param>
        /// <param name="componentid"></param>
        public void Remove(int systemid, int componentid)
        {
            try
            {
                // TODO 

                this.Remove(new Tuple<int, int>(systemid, componentid));
            }
            catch (Exception)
            {
            }
        }

    }
}
