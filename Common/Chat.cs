using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class Chat : IService
    {
        public string Answer(string command)
        {
            string pytanie = command.Split(' ')[1];
            string test = "nie";
            Console.Write(pytanie.Count());
            if (pytanie == "pobierz")
                test = "chat pibierz:)";

            return test;
        }

        public string Question(string command)
        {
            throw new NotImplementedException();
        }
    }
}
