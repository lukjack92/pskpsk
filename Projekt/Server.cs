using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Common;
using System.IO.Ports;

namespace Projekt
{
    class Server
    {
        static void Main(string[] args)
        {
            Queries.Usluga();
            TCPServer tcp = new TCPServer(12345);
            UDPServer udp = new UDPServer(12346);
            RS232Server rs232 = new RS232Server("COM1");
        }
    }
}
