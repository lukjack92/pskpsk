using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Common;

namespace Projekt
{
    public class TCPServer
    {
        int numberOfClients = 0;

        private TcpListener serverTCP;
        private Thread t;
        private int port;
        const int size = 1024;

        public TCPServer(int port)
        {
            this.port = port;
            this.serverTCP = new TcpListener(IPAddress.Loopback, port);
            this.t = new Thread(new ThreadStart(ListenerForClient));
            this.t.Start();
        }

        private void ListenerForClient()
        {
            this.serverTCP.Start();
            Console.WriteLine("Server Application\n");
            Console.WriteLine("Server - lukjack");
            Console.WriteLine("Server TCP Address - " + serverTCP.LocalEndpoint);
            Console.WriteLine("Server TCP started ...");
            
            while (true)
            {
                TcpClient client = this.serverTCP.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(ClientTCPService));
                clientThread.Start(client);
                numberOfClients++;
                Console.WriteLine("Client TCP connected: " + numberOfClients);
            }
        }

        private void ClientTCPService(object clientTCP)
        {
            TcpClient tcpclient = (TcpClient)clientTCP;
            NetworkStream stream = tcpclient.GetStream();

            byte[] message = new byte[size];
            int bytes;
            byte[] buff;
            string data = null;

            while (true)
            {
                bytes = 0;

                try
                {
                    bytes = stream.Read(message, 0, message.Length);
                }
                catch
                {
                    break;
                }

                if (bytes == 0)
                {
                    break;
                }

                data = Encoding.ASCII.GetString(message, 0, bytes);
                Console.WriteLine("TCP <- {0}", data);

                if (data == "exit")
                {
                    break;
                }

                buff = Encoding.ASCII.GetBytes(Queries.ParseAnswer(data));
                stream.Write(buff, 0, buff.Length);
                data = Encoding.ASCII.GetString(buff, 0, buff.Length);
                Console.WriteLine("TCP -> {0}", data);
                stream.Flush();
            }
            numberOfClients--;
            Console.WriteLine("Client TCP connected: " + numberOfClients);
            tcpclient.Close();
        }
    }
}
