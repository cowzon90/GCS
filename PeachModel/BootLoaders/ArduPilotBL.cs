using Newtonsoft.Json.Linq;
using PeachModel.CommunicationPort;
using PeachModel.Firmwares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.BootLoaders
{
    /// <summary>
    /// https://github.com/ArduPilot/ardupilot/blob/master/Tools/AP_Bootloader/bl_protocol.cpp
    /// </summary>
    public class ArduPilotBL : BootLoader, IDisposable
    {
        //* ardupilot firmware info.

        public int BootLoaderRevision { get; internal set; }
        public int BoardId { get; internal set; }
        public int BoardRevision { get; internal set; }
        public int FirmwareMaxsize { get; internal set; }
        public int Chip { get; internal set; }
        public string ChipDesc { get; internal set; }

        public delegate void ProgressBLHandler(UPLOADSTATE state, string steps);

        public event ProgressBLHandler ProgressEvent;

        private void InvokeProgressEvent(UPLOADSTATE state, string steps)
        {
            ProgressEvent?.Invoke(state, steps);
        }

        public ArduPilotBL(string name) : base(name)
        {
        }

        public void Dispose()
        {
            try
            {
                this.ComPort.Close();
                this.ComPort.Dispose();

            }
            catch (Exception e)
            {
            }
            finally
            {
                this.ComPort = null;
            }
        }


        /// <summary>
        /// Initializing board.
        /// </summary>
        /// <returns></returns>
        public override void Initialize()
        {
            try
            {
                this.ComPort.Open();

                this.ComPort.ReadTimeout = 500;
                this.ComPort.WriteTimeout = 500;

                // clear buffer.
                this.ComPort.DiscardOutBuffer();
                this.ComPort.DiscardInBuffer();

                // get sync
                this.Send_GetSync(500);

                // get infos.
                int result = this.Send_GetDeviceValue(DEVICE_VALUE.PROTO_DEVICE_BL_REV);
                if (result == -1)
                    throw new Exception("error on getting boot loader revision");

                if (result < 2 || result > 10)
                    throw new Exception("error on bootloader protocol mismatch.");

                this.BootLoaderRevision = result;

                result = this.Send_GetDeviceValue(DEVICE_VALUE.PROTO_DEVICE_BOARD_ID);
                if (result == -1)
                    throw new Exception("error on getting board id");
                this.BoardId = result;

                result = this.Send_GetDeviceValue(DEVICE_VALUE.PROTO_DEVICE_BOARD_REV);
                if (result == -1)
                    throw new Exception("error on getting borad revision");
                this.BoardRevision = result;

                result = this.Send_GetDeviceValue(DEVICE_VALUE.PROTO_DEVICE_FW_SIZE);
                if (result == -1)
                    throw new Exception("error on getting firmware maxsize");
                this.FirmwareMaxsize = result;

                if (this.BootLoaderRevision >= 5)
                {
                    this.Chip = this.Send_GetCHIP();
                    this.ChipDesc = this.Send_GetCHIPDES();
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw e;
            }
        }

        public enum UPLOADSTATE
        {
            NONE = 0,
            READY = 1,
            VERSION_CEHCK = 2,
            BOARD_CHECK = 3,
            IMAGE_SIZE_CHECK = 4,
            ERASE = 5,
            UPLOAD = 6,
            VERIFY = 7,
            REBOOT = 8,
            COMPLETE = 9,
        }

        public override void Install(Firmware fw, bool isForce = false)
        {
            // TODO : bootloader reboot ?

            this.ComPort.ReadTimeout = 1000;
            try
            {
                this.InvokeProgressEvent(UPLOADSTATE.READY, string.Empty);
                if (!isForce)
                {
                    this.InvokeProgressEvent(UPLOADSTATE.VERSION_CEHCK, string.Empty);
                    int firmware_crc = this.crc(fw.ImageBytes, this.FirmwareMaxsize);
                    int board_crc = this.Send_GetCRC();

                    if (firmware_crc == board_crc)
                    {
                        // same.
                        this.InvokeProgressEvent(UPLOADSTATE.VERSION_CEHCK, "Same Firmware");
                        throw new Exception("Same firmware.");
                    }
                }

                // check board id
                this.InvokeProgressEvent(UPLOADSTATE.BOARD_CHECK, string.Empty);
                if (fw.BoardId != this.BoardId)
                {
                    this.InvokeProgressEvent(UPLOADSTATE.BOARD_CHECK, "Not correct board ID");
                    throw new Exception("Not correct board ID");
                }

                // check image size.
                this.InvokeProgressEvent(UPLOADSTATE.IMAGE_SIZE_CHECK, string.Empty);
                if (fw.ImageSize > this.FirmwareMaxsize & this.FirmwareMaxsize != 0)
                {
                    this.InvokeProgressEvent(UPLOADSTATE.IMAGE_SIZE_CHECK, "Firmware image is too large.");
                    throw new Exception("Firmware image is too large.");
                }

                // erase
                try
                {
                    this.InvokeProgressEvent(UPLOADSTATE.ERASE, string.Empty);
                    this.Send_Erase();
                }
                catch (Exception)
                {
                    this.InvokeProgressEvent(UPLOADSTATE.ERASE, "Erase Failed");
                    throw new Exception("erase failed.");
                }

                // install.
                try
                {
                    this.InvokeProgressEvent(UPLOADSTATE.UPLOAD, string.Empty);
                    this.Send_Prog(fw.ImageBytes);
                }
                catch (Exception)
                {
                    this.InvokeProgressEvent(UPLOADSTATE.UPLOAD, "Uploading failed");
                    throw new Exception("uploading failed.");
                }
                this.InvokeProgressEvent(UPLOADSTATE.UPLOAD, "Complete");

                // verify
                try
                {
                    this.InvokeProgressEvent(UPLOADSTATE.VERIFY, string.Empty);
                    if (this.BoardRevision == 2)
                    {
                        this.VerifyV2(fw.ImageBytes);
                    }
                    else
                    {
                        this.VerifyV3(fw.ImageBytes, this.FirmwareMaxsize);
                    }
                }
                catch (Exception)
                {
                    this.InvokeProgressEvent(UPLOADSTATE.VERIFY, "Verified failed");
                    throw new Exception("Verifying failed.");
                }


                // reboot
                try
                {
                    this.InvokeProgressEvent(UPLOADSTATE.REBOOT, string.Empty);
                    this.Send_Reboot();
                }
                catch (Exception e)
                {
                    this.InvokeProgressEvent(UPLOADSTATE.REBOOT, e.Message);
                    throw;
                }

                this.InvokeProgressEvent(UPLOADSTATE.COMPLETE, string.Empty);
            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                if(this.ComPort != null)
                {
                    this.ComPort.Close();
                    this.ComPort.Dispose();
                }
            }
            

        }

        private List<byte[]> Split(byte[] bytes, int length)
        {
            List<Byte[]> list = new List<byte[]>();
            for (int a = 0; a < bytes.Length;)
            {
                byte[] ba = new byte[length];
                Array.Copy(bytes, a, ba, 0, length);
                list.Add(ba);
                a += length;
                if ((bytes.Length - a) < length)
                    length = bytes.Length - a;
            }

            return list;
        }

        #region PROTOCOL DEFINED

        /// <summary> The revision of the bootloader protocol. </summary>
        private const byte BL_PROTOCOL_VERSION = 5;
        /// <summary> 'in sync' byte sent before status. </summary>
        private const byte PROTO_INSYNC = 0x12;
        /// <summary> End Of Command. </summary>
        private const byte EOC = 0x20;
        /// <summary> maximum PROG_MULTI size </summary>
        private const byte PROTO_PROG_MULTI_MAX = 64;
        /// <summary> size of the size field </summary>
        private const byte PROTO_READ_MULTI_MAX = 255;

        /// <summary> Reply bytes </summary>
        public enum REPLY : byte
        {
            /// <summary> INSYNC/OK - 'ok' response</summary>
            PROTO_OK = 0x10,
            /// <summary> INSYNC/FAILED  - 'fail' response </summary>
            PROTO_FAILED = 0x11,
            /// <summary> INSYNC/INVALID - 'invalid' response for bad commands </summary>
            PROTO_INVALID = 0x13,
            /// <summary> On the F4 series there is an issue with < Rev 3 silicon </summary>
            PROTO_BAD_SILICON_REV = 0x14,
        }
        /// <summary> Command bytes </summary>
        public enum COMMAND : byte
        {
            /// <summary> NOP for re-establishing sync </summary>
            PROTO_GET_SYNC = 0x21,
            /// <summary> get device ID bytes </summary>
            PROTO_GET_DEVICE = 0x22,
            /// <summary> erase program area and reset program address </summary>
            PROTO_CHIP_ERASE = 0x23,
            /// <summary> verify program on revision 2 only </summary>
            PROTO_CHIP_VERIFY = 0x24,
            /// <summary> write bytes at program address and increment </summary>
            PROTO_PROG_MULTI = 0x27,
            /// <summary> read bytes at address and increment </summary>
            PROTO_READ_MULTI = 0x28,
            /// <summary> compute & return a CRC </summary>
            PROTO_GET_CRC = 0x29,
            /// <summary> read a byte from OTP at the given address </summary>
            PROTO_GET_OTP = 0x2a,
            /// <summary> read a word from UDID area ( Serial)  at the given address </summary>
            PROTO_GET_SN = 0x2b,
            /// <summary> read chip version (MCU IDCODE) </summary>
            PROTO_GET_CHIP = 0x2c,
            /// <summary> set minimum boot delay </summary>
            PROTO_SET_DELAY = 0x2d,
            /// <summary> read chip version In ASCII </summary>
            PROTO_GET_CHIP_DES = 0x2e,
            /// <summary> boot the application </summary>
            PROTO_BOOT = 0x30,
            /// <summary> emit debug information - format not defined </summary>
            PROTO_DEBUG = 0x31,
            /// <summary> baud rate on uart </summary>
            PROTO_SET_BAUD = 0x33,
        }
        /// <summary> argument values for PROTO_GET_DEVICE </summary>
        public enum DEVICE_VALUE : byte
        {
            /// <summary> bootloader revision </summary>
            PROTO_DEVICE_BL_REV = 1,
            /// <summary> board ID </summary>
            PROTO_DEVICE_BOARD_ID = 2,
            /// <summary> board revision </summary>
            PROTO_DEVICE_BOARD_REV = 3,
            /// <summary> size of flashable area </summary>
            PROTO_DEVICE_FW_SIZE = 4,
            /// <summary> contents of reserved vectors 7-10 </summary>
            PROTO_DEVICE_VEC_AREA = 5,

        }

        #endregion

        #region verify
        public void VerifyV3(byte[] imagebytes, int firmwareMaxSize)
        {
            int firmware_crc = this.crc(imagebytes, firmwareMaxSize);

            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_GET_CRC, EOC });
            int? programed_crc = this.ComPort.Read_int();
            if (!programed_crc.HasValue)
            {
                throw new Exception("cannot receive programed crc");
            }
            this.GetSync();

            if (programed_crc.Value != firmware_crc)
            {
                throw new Exception($"different crc : firmware crc - {firmware_crc}, programed crc - {programed_crc}");
            }
            this.InvokeProgressEvent(UPLOADSTATE.VERIFY, $"complete");
        }

        public void VerifyV2(byte[] imagebytes)
        {
            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_CHIP_VERIFY, EOC });
            this.GetSync();

            List<byte[]> split = this.Split(imagebytes, PROTO_READ_MULTI_MAX);

            int i = 1;
            foreach (byte[] bs in split)
            {
                if (!this.verify_multi(bs))
                {
                    /// verify failed.
                    throw new Exception("programed verify failed.");
                }
                this.InvokeProgressEvent(UPLOADSTATE.VERIFY, $"{i++} / {split.Count}");
            }
        }

        private bool verify_multi(byte[] data)
        {
            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_READ_MULTI, (byte)(data.Length), EOC });
            byte[] got = this.ComPort.ReadBytes(data.Length);

            if (got is null)
                // null received.
                return false;

            if (data.Length != got.Length)
                return false;

            foreach (var item in data.Zip(got, Tuple.Create))
            {
                if (item.Item1 != item.Item2)
                    return false;
            }

            this.GetSync();
            return true;
        }
        #endregion

        #region Sends
        /// <summary>
        /// Get sync
        /// </summary>
        /// <param name="readTimout"></param>
        /// <returns></returns>
        public void GetSync(double readTimout = -1)
        {
            if (readTimout == -1)
            {
                readTimout = this.ComPort.ReadTimeout;
            }

            try
            {
                DateTime timeout = DateTime.Now.AddMilliseconds(readTimout);
                this.ComPort.BaseStream.Flush();
                while (true)
                {
                    if (timeout < DateTime.Now)
                        throw new Exception($"Sync timeout on {readTimout} milliseconds.");

                    if (this.ComPort.BytesToRead == 0)
                        continue;

                    byte r = (byte)this.ComPort.ReadByte();
                    if (r != PROTO_INSYNC)
                        continue;

                    // TODO : sync
                    //if (r != PROTO_INSYNC) throw new Exception($"Got {r} instead of INSYNC({PROTO_INSYNC})");

                    // got insync and next step.
                    r = (byte)this.ComPort.ReadByte();
                    switch (r)
                    {
                        case (byte)REPLY.PROTO_OK:
                            //e = "Got OK";
                            return;
                        case (byte)REPLY.PROTO_FAILED:
                            throw new Exception("Got FAILED.");
                        case (byte)REPLY.PROTO_INVALID:
                            throw new Exception("Got INAVLID.");
                        case (byte)REPLY.PROTO_BAD_SILICON_REV:
                            throw new Exception("Got BAD SILICON REV.");
                        default:
                            throw new Exception("Got Unexpected value.");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Send_Reboot()
        {
            try
            {
                this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_BOOT, EOC });
                this.ComPort.DiscardInBuffer();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Send_Prog(byte[] imagebytes)
        {
            List<byte[]> bytes = this.Split(imagebytes, PROTO_PROG_MULTI_MAX);
            int i = 1;
            foreach (byte[] bs in bytes)
            {
                this.InvokeProgressEvent(UPLOADSTATE.UPLOAD, $"{i++} / {bytes.Count}");
                this.Send_ProgramMulti(bs);
            }
        }

        public void Send_ProgramMulti(byte[] data)
        {
            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_PROG_MULTI, (byte)data.Length });
            this.ComPort.WriteBytes(data);
            this.ComPort.WriteBytes(new byte[] { EOC });
            this.GetSync();
        }

        /// <summary>
        ///  send erase firmware.
        /// </summary>
        public void Send_Erase()
        {
            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_CHIP_ERASE, EOC });

            DateTime timeout = DateTime.Now.AddMilliseconds(20 * 1000);
            while (true)
            {
                if (timeout < DateTime.Now)
                    break;

                if (this.ComPort.BytesToRead > 0)
                {
                    //Debug.WriteLine($"erase btr {this.ComPort.BytesToRead}");
                    break;
                }
            }

            this.GetSync();
        }

        /// <summary>
        /// send GET_SYNC Command
        /// </summary>
        public void Send_GetSync(double readTimeout = -1)
        {
            this.ComPort.BaseStream.Flush();
            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_GET_SYNC, EOC });
            this.GetSync(readTimeout);
        }

        /// <summary>
        /// Send GET_CHIP_DES Command to board and get return value.
        /// </summary>
        /// <returns></returns>
        public string Send_GetCHIPDES()
        {
            this.ComPort.Write(new byte[] { (byte)COMMAND.PROTO_GET_CHIP_DES, EOC }, 0, 2);
            int? result = this.ComPort.Read_int();

            if (!result.HasValue)
                throw new Exception("null value in length");
            if (result <= 0)
            {
                this.GetSync();
                return "";
            }

            string t = this.ComPort.Read_string(result.Value);
            this.GetSync();
            return t;
        }

        /// <summary>
        /// Send GET_CHIP Command to board and get return value.
        /// </summary>
        /// <returns></returns>
        public int Send_GetCHIP()
        {
            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_GET_CHIP, EOC });
            int? result = this.ComPort.Read_int();

            if (!result.HasValue)
                throw new Exception("null value.");

            this.GetSync();
            return result.Value;
        }

        /// <summary>
        /// Send GET_DEVICE Command to board and get return value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Send_GetDeviceValue(DEVICE_VALUE value)
        {
            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_GET_DEVICE, (byte)value, EOC });
            int? result = this.ComPort.Read_int();
            if (!result.HasValue)
                throw new Exception("null value");
            this.GetSync();
            return result.Value;
        }

        public int Send_GetCRC()
        {
            this.ComPort.WriteBytes(new byte[] { (byte)COMMAND.PROTO_GET_CRC, EOC });
            int? result = this.ComPort.Read_int();

            if (!result.HasValue)
                throw new Exception("null value");

            this.GetSync();
            return result.Value;
        }

        #endregion
    }


}
