using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    class Chat : IService
    {
        public struct SenderAndMessage
        {
            public string Sender;
            public string Message;
        }

        public static List<string> users = new List<string>();
        public static Dictionary<string, List<SenderAndMessage>> email = new Dictionary<string, List<SenderAndMessage>>();

        public string Answer(string command)
        {
            string[] comm = command.Split(' ');
            int count = comm.Count();
            string msg = string.Empty;

            if (count == 1) return "chat options{ add {nick}| list | send {nick} {nick}| fetch {nick}}";

            switch (comm[1])
            {
                case "add":
                    if (count == 2)
                        return "Add nick {chat add [your nick]}";
                    else
                    {
                        if (users.Contains(comm[2]))
                            return "The user " + comm[2] + " exists in the users list!";
                        else
                            users.Add(comm[2]);

                        foreach (var item in users)
                            Console.WriteLine(""+ item);

                        return "Add user to list! Your nick [" + comm[2] + "]";
                    }

                case "list":
                    if (users.Count() == 0)
                        return "No users!";

                    string UserList = string.Join("|",users);
                        return UserList;

                case "send":
                    if (count == 2)
                        return "Add nick and msg {chat send [nick receiver] [your nick] [message]}";
                    if (count == 3)
                        return "Add your nick and msg {chat send NickReceiver [your nick] [message]}";
                    if (count == 4)
                        return "Add msg {chat send NickReceiver YourNick [message]}";

                    SenderAndMessage dane;

                    for (int i = 4; i < comm.Length; i++)
                        msg += comm[i] + " ";

                    dane.Sender = comm[3];
                    dane.Message = msg;

                    email.Add(comm[2], new List<SenderAndMessage> {new SenderAndMessage() { Sender = comm[3], Message = msg}});

                    foreach(SenderAndMessage item in email[comm[2]])
                    {
                        Console.Write(item.Message);
                    }

                    return "Message has been sent to [" + comm[2] + "]";

                case "fetch":
                    return "pobierz msg";

                default:
                    return "chat unknow command";
            }
        }

        public string Question(string command)
        {
            throw new NotImplementedException();
        }
    }
}
