using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using System.IO;

namespace Projekt
{
    public class RS232Server
    {
        SerialPort portCOM;
        private Thread t;
        private string serialPort;

        public RS232Server(string serialPort)
        {
            this.serialPort = serialPort;
            this.t = new Thread(new ThreadStart(ClientForRS232));
            this.t.Start();
        }

        private void ClientForRS232()
        {
            try
            {
                portCOM = new SerialPort(serialPort, 9600, Parity.None, 8, StopBits.One);
                portCOM.Open();
                Console.WriteLine("Server RS232 PortName: " + portCOM.PortName);
                Console.WriteLine("Server RS232 started ... ");
                string str;

                while (true)
                {
                    string message = portCOM.ReadLine();
                    Console.WriteLine("RS232 <- " + message);
                    str = Queries.ParseAnswer(message);
                    portCOM.WriteLine(str);
                    Console.WriteLine("RS232 -> " + str);
                }
                #pragma warning disable
                portCOM.Close();
                Console.WriteLine("Client RS232 - connection completed!");
            }
            catch
            {
                Console.WriteLine("No port RS232 " + portCOM.PortName);
                Console.WriteLine("Server RS232 not started " + portCOM.PortName);
            }
        }
    }
}
