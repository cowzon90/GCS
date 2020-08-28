using Ionic.Zlib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel.Firmwares
{
    /// <summary>
    /// ArduPilot Firmware.
    /// </summary>
    public class APFirmware : Firmware
    {
        public string Summary { get; internal set; }
        public int BoardRevision { get; internal set; }
        public string GitIdentity { get; internal set; }
        public string USBID { get; internal set; }
        public string Version { get; internal set; }
        public string Magic { get; internal set; }
        public string Description { get; internal set; }

        public static APFirmware LoadFirmware(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                    throw new Exception($"Not exist file\n" +
                                        $"input : {filename}");

                using (StreamReader reader = new StreamReader(File.OpenRead(filename)))
                {
                    var s = reader.ReadToEnd();
                    JObject json = JObject.Parse(s);

                    APFirmware firmware = new APFirmware();
                    firmware.JsonToFW(json);

                    firmware.WriteImageBytes();

                    return firmware;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// TODO : Zlib license.
        /// </summary>
        private void WriteImageBytes()
        {
            // make imagebytes
            int size = this.ImageSize + (this.ImageSize % 4);
            this.ImageBytes = new byte[size];
            for (int i = 0; i < size; i++)
            {
                this.ImageBytes[i] = 0xff;
            }

            byte[] data = Convert.FromBase64String(this.Image);
            MemoryStream ms = new MemoryStream(data, true);

            ZlibStream decomp = new ZlibStream(ms, CompressionMode.Decompress);

            try
            {
                decomp.Read(this.ImageBytes, 0, this.ImageSize);
            }
            catch (Exception)
            {
                // TODO.
                throw;
            }

        }

        /// <summary>
        /// Parsing // TODO : 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        private void JsonToFW(JObject json)
        {
            Dictionary<string, string> dict = json.ToObject<Dictionary<string, string>>();

            string t_str;
            int t_int;
            if (!dict.TryGetValue("board_id", out t_str))
            {
                t_str = "-1";
            }
            this.BoardId = int.TryParse(t_str, out t_int) ? t_int : -1;

            if (!dict.TryGetValue("USBID", out t_str))
            {
                t_str = string.Empty;
            }
            this.USBID = t_str;

            if (!dict.TryGetValue("version", out t_str))
            {
                t_str = string.Empty;
            }
            this.Version = t_str;

            if (!dict.TryGetValue("magic", out t_str))
            {
                t_str = string.Empty;
            }
            this.Magic = t_str;

            if (!dict.TryGetValue("description", out t_str))
            {
                t_str = string.Empty;
            }
            this.Description = t_str;

            if (!dict.TryGetValue("image_size", out t_str))
            {
                t_str = "-1";
            }
            this.ImageSize = int.TryParse(t_str, out t_int) ? t_int : -1;

            if (!dict.TryGetValue("image", out t_str))
            {
                t_str = string.Empty;
            }
            this.Image = t_str;

            if (!dict.TryGetValue("git_identity", out t_str))
            {
                t_str = string.Empty;
            }
            this.GitIdentity = t_str;

            if (!dict.TryGetValue("board_revision", out t_str))
            {
                t_str = "-1";
            }
            this.BoardRevision = int.TryParse(t_str, out t_int) ? t_int : -1;

            if (!dict.TryGetValue("summary", out t_str))
            {
                t_str = string.Empty;
            }
            this.Summary = t_str;
        }
    }
}
