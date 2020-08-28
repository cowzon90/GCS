using PeachModel;
using PeachModel.BootLoaders;
using PeachModel.CommunicationPort;
using PeachModel.Firmwares;
using PeachModel.Mavlink;
using PeachModel.UAVs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeachController.Controllers
{
    public class SetupController
    {
        public static SetupController @Instance
        {
            get => SingleTon<SetupController>.Instance;
        }

        #region Firmware installation

        private APFirmware firmware;

        public bool LoadFirmware(string filepath, out string firmwareInfo)
        {
            try
            {
                firmware = APFirmware.LoadFirmware(filepath);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Board id : {firmware.BoardId}");
                sb.AppendLine($"Board revision : {firmware.BoardRevision}");
                sb.AppendLine($"Summary : {firmware.Summary}");
                sb.AppendLine($"Version : {firmware.Version}");
                firmwareInfo = sb.ToString();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                firmwareInfo = "";
                return false;
            }
        }

        private ArduPilotBL bootloader;

        private async Task<bool> Install_thread(bool isForce = false, ArduPilotBL.ProgressBLHandler progress = null)
        {
            try
            {
                if (progress != null)
                    bootloader.ProgressEvent += progress;

                // TODO : background?
                bootloader.Install(firmware, isForce);

                if (progress != null)
                    bootloader.ProgressEvent -= progress;

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public void InstallFirmware(bool isForce = false, ArduPilotBL.ProgressBLHandler progress = null)
        {
            if(firmware is null)
            {
                return;
            }

            try
            {
                List<string> portnames = ComPort.GetDevicePorts(true);

                // all comport
                foreach (string portname in portnames)
                {
                    try
                    {
                        Debug.WriteLine($"try {portname}");
                        bootloader = new ArduPilotBL(portname);
                        bootloader.Initialize();
                        break;
                    }
                    catch (Exception ex2)
                    {
                        Debug.WriteLine(ex2.Message);
                        try
                        {
                            bootloader.Dispose();
                        }
                        catch (Exception)
                        {
                        }
                        bootloader = null;
                    }
                }

                // Board which able to be installed not exist.
                if(bootloader is null)
                {
                    return;
                }

                bool result = this.Install_thread(isForce, progress).Result;
            
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }
            finally
            {
                if(bootloader != null)
                {
                    bootloader.Dispose();
                }
                bootloader = null;
            }
        }

        #endregion
    }
}
