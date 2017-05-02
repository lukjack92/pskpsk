using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class Time : IService
    {
        public string Answer(string command)
        {
            DateTime time = DateTime.Now;
            return time.ToString();
        }

        public string Question(string command)
        {
            throw new NotImplementedException();
        }
    }
}
