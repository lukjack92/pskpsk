using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PingPong : IService
    {
        public string Answer(string command)
        {
            return "PINGPONG";
        }

        public string Question(string command)
        {
            return "PINGPONG_ODP";
        }
    }
}
