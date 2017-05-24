using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Queries
    {
        private static Dictionary<string, IService> Service { get; set; }

        public static void Usluga()
        {
            Service = new Dictionary<string, IService>
            {
                { "ping", new PingPong() },
                { "time", new Time() },
                { "chat", new Chat() },
                { "file", new Files() },
            };
        }

        //public static string ParseQuestion(string command)
        //{
        //    if (Service.ContainsKey(command))
        //    {
        //        if (command == null)
        //            return command;
        //        else
        //            return Service[command].Question(command);
        //    }
        //    //return "Unknown service.";
        //    return command;
        //}

        public static string ParseAnswer(string command)
        {
            string[] pytanie = command.Split(' ');

            if (Service.ContainsKey(pytanie[0]))
            {
                if (pytanie[0] == null)
                    return command.ToUpper();
                else
                    return Service[pytanie[0]].Answer(command);
            }
            return "The Server does't know this service. Services are { chat | time | ping | file }";
            //return command.ToUpper();
        }
    }
}