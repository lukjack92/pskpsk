using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class TCPClient
    {
        private int port;
        private TcpClient client;
        private NetworkStream stream;
        private string message;

        public TCPClient(int port)
        {
            try
            {
                this.port = port;
                this.client = new TcpClient("127.0.0.1", port);
                this.stream = client.GetStream();
                Console.WriteLine("Connected to server 127.0.0.1:" + port);
            }
            catch (SocketException)
            {
                Console.WriteLine("Server is unavailable!!");
                //Console.WriteLine("SocketException: {0}", e);
                Console.ReadKey();
            }
        }

        public void QuestionAndAnswer()
        {
            int size = 1024;
            byte[] msg;

            while (true)
            {
                Console.Write(">> ");
                message = Console.ReadLine();

                if (message == "exit")
                {
                    msg = ASCIIEncoding.ASCII.GetBytes(message);
                    stream.Write(msg, 0, msg.Length);
                    break;
                }

                msg = ASCIIEncoding.ASCII.GetBytes(message);
                stream.Write(msg, 0, msg.Length);

                msg = new Byte[size];
                String responseData = String.Empty;

                Int32 bytes = stream.Read(msg, 0, msg.Length);
                responseData = System.Text.Encoding.ASCII.GetString(msg, 0, bytes);
                Console.WriteLine("TCP <- {0}", responseData);
            }

            Console.WriteLine("Connection completed! Click ENTER!");
            Console.ReadKey();
            stream.Close();
            client.Close();
        }
    }
}
