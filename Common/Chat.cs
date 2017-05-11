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
                        return "Add [nick] and [msg] - {chat send [NickReceiver] [YourNick] [message]}";
                    if (count == 3)
                        return "Add [YourNick] and [msg] - {chat send NickReceiver [YourNick] [message]}";
                    if (count == 4)
                        return "Add [msg] {chat send ReceiverNick YourNick [message]}";

                    string nickRevc = comm[2];
                    string nickSend = comm[3];

                    if (!users.Contains(nickRevc) || !users.Contains(nickSend)) return "Don't existing user [" + nickRevc + "] or [" + nickSend + "]!";

                    SenderAndMessage dane;

                    for (int i = 4; i < comm.Length; i++)
                        msg += comm[i] + " ";

                    dane.Sender = nickRevc;
                    dane.Message = msg;

                    email.Add(nickRevc, new List<SenderAndMessage> {new SenderAndMessage() { Sender = nickRevc, Message = msg}});

                    foreach(SenderAndMessage item in email[nickRevc])
                        Console.Write("ds" + item.Message);

                    return "Message has been sent to [" + nickRevc + "]";

                case "fetch":
                    if (count == 2)
                        return "Add [YourNick] - {chat fetch [YourNick] }";

                    string nick = comm[2];
                    string message = "Message from ";

                    if(email.ContainsKey(nick))
                    {
                        foreach (SenderAndMessage item in email[nick])
                        {
                            message += "["+item.Sender + "] ";
                            message += item.Message;
                        }
                        email.Remove(nick);
                        return message;
                    }else
                    {
                        return "You don't have a message!";
                    }

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
