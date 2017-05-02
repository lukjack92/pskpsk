using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Client
{
    public class UDPClient
    {
        private int port;
        private string msg;

        public UDPClient(int port)
        {
            this.port = port;
        }

        public void QuestionAndAnswer()
        {
            while (true)
            {
                Console.Write(">> ");
                this.msg = Console.ReadLine();
                
                if(msg == "exit")
                {
                    break;
                }

                try
                {
                    UdpClient sock = new UdpClient();
                    IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

                    byte[] data = Encoding.ASCII.GetBytes(msg);
                    sock.Send(data, data.Length, iep);
                    data = sock.Receive(ref iep);

                    string question = Encoding.ASCII.GetString(data);
                    Console.WriteLine("UDP <- {0}", question);

                    sock.Close();
                }
                catch (Exception)
                {
                    Console.WriteLine("Server is unavailable!");
                }
            }
            Console.WriteLine("Connection completed! Click ENTER!");
        }
    }
}
