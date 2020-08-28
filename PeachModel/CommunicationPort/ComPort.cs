using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeachModel.CommunicationPort
{
    public class ComPort : SerialPort
    {
        #region Subscribe
        
        public Subscribe Subscribe { get; private set; }
        
        /// <summary>
        /// Run Subscribe.
        /// </summary>
        /// <returns></returns>
        public bool RunSubscribe()
        {
            try
            {
                if(this.Subscribe != null)
                {
                    if (!this.Subscribe.IsThreadAlive)
                    {
                        // re-run.
                        this.Subscribe.StartReader();
                    }

                    // already running.
                    return true;
                }

                this.Subscribe = new Subscribe(this);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}");
                return false;
            }
        }
        
        #endregion

        #region Constructors
        public ComPort(string name) : base(name)
        {
            this.PortName = name;
        }

        public ComPort(string name, int baudRate) : this(name)
        {
            this.PortName = name;
            this.BaudRate = baudRate;
        }

        ~ComPort()
        {
            this.Close();
        }
        #endregion

        #region Read / Write

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Read Mavlink packet
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> ReadMavlink()
        {
            await _semaphore.WaitAsync();
            try
            {
                if (this.ReadTimeout != 1200)
                {
                    this.ReadTimeout = 1200;
                }

                // delay ReadTimeout.
                DateTime timeout = DateTime.Now.AddMilliseconds(this.ReadTimeout);

                // TODO : memory reading.
                //MemoryStream stream = new MemoryStream();

                while (true)
                {
                    if (DateTime.Now > timeout)
                    {
                        throw new TimeoutException(
                            $"No received packet from {timeout.AddMilliseconds(-ReadTimeout)} " +
                            $"to {timeout}");
                    }

                    int stx = this.ReadByte();
                    // make packet.
                    if (stx == 0xFD | stx == 0xFE)
                    {
                        int packetlen = 0;
                        int len = this.ReadByte();
                        int temp = this.ReadByte();

                        if (stx == 0xFD)
                        {
                            // mavlink 2
                            packetlen += (12 + len);
                            if (temp == 0x01)
                            {
                                packetlen += 13;
                            }
                        }
                        else
                        {
                            // mavlink 1
                            packetlen += (8 + len);
                        }

                        byte[] packet = new byte[packetlen];
                        packet[0] = (byte)stx;
                        packet[1] = (byte)len;
                        packet[2] = (byte)temp;
                        for (int p = 3; p < packetlen; p++)
                        {
                            packet[p] = (byte)this.ReadByte();
                        }
                        return packet;
                    }
                }
            }
            catch (TimeoutException e_timeout)
            {
                // Show something. about timeout.
                Debug.WriteLine(e_timeout.Message);
                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                /// How to throw?
                //throw e;
                return null;
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Read bytes with size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public byte[] ReadBytes(int size)
        {
            DateTime timeout = DateTime.Now.AddMilliseconds(this.ReadTimeout);
            try
            {
                while (true)
                {
                    if (timeout < DateTime.Now)
                    {
                        throw new Exception("Timeout");
                    }

                    if (this.BytesToRead == 0)
                        continue;

                    byte[] result = new byte[size];
                    for (int i = 0; i < size; i++)
                    {
                        result[i] = (byte)this.ReadByte();
                    }
                    return result;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Read bytes with length and return string.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public string Read_string(int length)
        {
            byte[] result = this.ReadBytes(length);

            try
            {
                if (result is null)
                {
                    throw new Exception("receive Null value.");
                }

                return ASCIIEncoding.ASCII.GetString(result);
            }
            catch (Exception e)
            {
                Debug.WriteLine("ComPort Read_string error occured.");
                Debug.WriteLine(e.Message);
                return string.Empty;
            }

        }

        /// <summary>
        /// read byte from port.
        /// </summary>
        /// <returns></returns>
        public int? Read_byte()
        {
            byte[] result = this.ReadBytes(1);

            try
            {
                if (result is null)
                {
                    throw new Exception("receive Null value.");
                }

                int value = result[0];
                return value;
            }
            catch (Exception e)
            {
                Debug.WriteLine("ComPort Read_byte error occured.");
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// read integer from port.
        /// </summary>
        /// <returns></returns>
        public int? Read_int()
        {
            byte[] result = this.ReadBytes(4);

            try
            {
                if (result is null)
                {
                    throw new Exception("receive Null value.");
                }

                int value = BitConverter.ToInt32(result, 0);
                return value;
            }
            catch (Exception e)
            {
                Debug.WriteLine("ComPort Read_int error occured.");
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Write bytes to serial port.
        /// </summary>
        /// <param name="buffer"></param>
        public void WriteBytes(byte[] buffer)
        {
            this.Write(buffer, 0, buffer.Length);
        }
        #endregion

        #region Connection
        /// <summary>
        /// Open Port
        /// </summary>
        public new bool Open()
        {
            try
            {
                if (!this.IsOpen)
                {
                    base.Open();
                    this.WriteTimeout = 500; // 500ms // default wirte timeout as win32
                }

                this.Subscribe = new Subscribe(this);
                this.RunSubscribe();
                
                return true;
            }
            catch (Exception e)
            {
                try
                {
                    base.Close();
                }
                catch (Exception ex)
                {
                }
                return false;
            }
        }

        /// <summary>
        /// Close Port
        /// </summary>
        public new void Close()
        {
            try
            {
                base.Close();
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }

        #endregion

        /// <summary>
        /// Get Communication ports list from device.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDevicePorts(bool isNotDuplicated = false)
        {
            List<string> result = new List<string>();

            foreach(string port in GetPortNames())
            {
                bool isCheck = false;
                if (isNotDuplicated)
                {
                    isCheck = result.Contains(port);
                }

                if (!isCheck)
                {
                    result.Add(port);
                }
            }

            return result;
        }

    }
}
