using PeachModel;
using PeachModel.Interface;
using PeachModel.Mavlink;
using PeachModel.UAVs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PeachController.Controllers
{
    public class InterfaceController
    {
        public static InterfaceController @Instance
        {
            get => SingleTon<InterfaceController>.Instance;
        }

        public ComInterface GetInterface()
        {
            return ComInterface.Instance;
        }

        public List<Tuple<int, int, string, string>> GetConnectedList()
        {
            try
            {
                this.VehicleNullCheck();

                if (GetInterface().Vehicles.Count == 0) return null;

                List<Tuple<int, int, string, string>> list = new List<Tuple<int, int, string, string>>();
                foreach(var v in GetInterface().Vehicles)
                {
                    int sysid = v.Key.Item1;
                    int compid = v.Key.Item2;
                    string auto = v.Value.AutoPilot;
                    string type = v.Value.Type;
                    list.Add(new Tuple<int, int, string, string>(sysid, compid, auto, type));
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Vehicle GetCurrentVehicle()
        {
            return GetInterface().GetCurrnetVehicle();
        }

        // TODO ;
        private void VehicleNullCheck()
        {
            if (this.GetCurrentVehicle() is null) throw new Exception("No vehicle");
        }

        public float GetParameter(string stringId)
        {
            this.VehicleNullCheck();

            try
            {
                return this.GetCurrentVehicle().Parameters[stringId].Value;
            }
            catch (Exception)
            {
                return float.NaN;
            }
        }

        public DataTable GetAllParameters()
        {
            this.VehicleNullCheck();

            try
            {
                return this.GetCurrentVehicle().Parameters.ToTable();
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public void SetParamValue(string paramid, float paramvalue)
        {
            this.VehicleNullCheck();

            try
            {
                bool result = this.GetCurrentVehicle().SetParameter(paramid, paramvalue);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return;
            }
        }

        public void SetDataStream(byte rate = 10, byte req_ = 0, bool isStart = true)
        {
            this.VehicleNullCheck();

            try
            {
                this.GetCurrentVehicle().SetDataStream(rate, req_, isStart);
            }
            catch (Exception e)
            {

                throw;
            }
        }


    }
}
