using PeachModel.Interface;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel
{
    class Program
    {
        public static Interface.ComInterface GetInterface()
        {
            return Interface.ComInterface.Instance;
        }

        static void Main(string[] args)
        {
            string[] ports = SerialPort.GetPortNames();

            GetInterface().ConnectUAV("Com8", 115200);



        }
    }
}
