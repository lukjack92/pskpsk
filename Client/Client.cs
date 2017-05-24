using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client Application\n");
            Console.WriteLine("--------MENU--------");
            Console.WriteLine("Connection protocols:");
            Console.WriteLine("1 - TCP");
            Console.WriteLine("2 - UDP");
            Console.WriteLine("3 - RS232");
            Console.WriteLine("4 - FILE");

            Console.Write("Choice: ");
            int protocol = int.Parse(Console.ReadLine());

            switch(protocol)
            {
                case 1:
                    TCPClient clientTCP = new TCPClient(12345);
                    clientTCP.QuestionAndAnswer();
                    break;
                case 2:
                    UDPClient clientUDP = new UDPClient(12346);
                    clientUDP.QuestionAndAnswer();
                    break;
                case 3:
                    RS232Client clientRS232 = new RS232Client("COM2");
                    clientRS232.QuestionAndAnswer();
                    break;
                case 4:
                    FileClient clientFile = new FileClient(@"C:\CommunicationFile\");
                    clientFile.QuestionAndAnswer();
                    break;
                default:
                    Console.WriteLine("Bad choise");
                    break;
            }
            Console.ReadKey();
        }
    }
}
