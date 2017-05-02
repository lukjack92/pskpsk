using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Projekt
{
    public class UDPServer 
    {
        private int port;
        private int size = 1024;
        private Thread ListenThread { get; set; }
        byte[] data;

        public UDPServer(int port)
        {
            this.data = new byte[size];
            this.port = port;
            ListenThread = new Thread(new ThreadStart(ListenerForClient));
            ListenThread.Start();
        }

        private void ListenerForClient()
        {
            UdpClient server = new UdpClient(port);
            IPEndPoint sender = new IPEndPoint(IPAddress.Loopback, 0);
            Console.WriteLine("Server UDP Address - " + IPAddress.Loopback + ":" + port);
            Console.WriteLine("Server UDP started ...");
            byte[] data = new byte[1024];

            while (true)
            {
                data = server.Receive(ref sender);
                Console.WriteLine("UDP <- " + Encoding.ASCII.GetString(data));
                string stringData = Encoding.ASCII.GetString(data, 0, data.Length);
                data = Encoding.ASCII.GetBytes(Queries.ParseAnswer(stringData));
                server.Send(data, data.Length, sender);
                Console.WriteLine("UDP -> " + Encoding.ASCII.GetString(data));
            }
        }
    }
}