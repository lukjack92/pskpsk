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
            Service = new Dictionary<string, IService>();
                
            Service.Add("ping", new PingPong());
            Service.Add("time", new Time());
        }

        public static string ParseQuestion(string command)
        {
            if(Service.ContainsKey(command))
            {
                if (command == null)
                    return command;
                else
                    return Service[command].Question(command);
            }
            //return "Unknown service.";
            return command;
        }

        public static string ParseAnswer(string command)
        {
            if (Service.ContainsKey(command))
            {
                if (command == null)
                    return command.ToUpper();
                else
                    return Service[command].Answer(command);
            }
            //return "Unknown service.";
            return command.ToUpper();
        }
    }
}