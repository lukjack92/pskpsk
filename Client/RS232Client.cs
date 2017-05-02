using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Client
{
    public class RS232Client
    {
        private string serialPort;
        SerialPort portCOM;
        bool open = true;

        public RS232Client(string serialPort)
        {
            try
            {
                this.serialPort = serialPort;
                portCOM = new SerialPort(serialPort, 9600, Parity.None, 8, StopBits.One);
                portCOM.Open();
            }
            catch (System.UnauthorizedAccessException)
            {
                Console.WriteLine("Serial port " + portCOM.PortName + " is busy, you may be try later!");
                open = false;
            }
        }

        public void QuestionAndAnswer()
        {
            try
            {
               while(open)
               {
                    Console.Write(">> ");
                    string msg = Console.ReadLine();
                    byte[] _msg = new byte[1024];

                    if (msg == "exit")
                        break;

                    portCOM.WriteLine(msg);
                    string pyt = portCOM.ReadLine();
                    Console.WriteLine("RS232 <- " + pyt);
               }
            }
            catch
            {
               Console.WriteLine("Server or COM port is unavailable!");
            }

            portCOM.Close();
            Console.WriteLine("Connection completed! Click ENTER!");
        }
    }
}
