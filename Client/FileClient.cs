using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class FileClient
    {
        private string directory;
        private string fileName;
        private int commandNumber = 0;
        string readFile;

        public FileClient(string path)
        {
            this.directory = path;
        }

        public void QuestionAndAnswer()
        {
            while(true)
            {
                Console.Write(">> ");
                string msg = Console.ReadLine();

                if (msg == "exit")
                    break;

                fileName = string.Format("{0}Command_{1}_FormClient",directory,commandNumber);

                Console.WriteLine("The command was written to the file: '" + fileName + ".in" + "' command: " + msg);
                File.WriteAllText(fileName + ".in", msg);

                while (!File.Exists(fileName + ".out"))
                    System.Threading.Thread.Sleep(100);

                readFile = File.ReadAllText(fileName + ".out");
                Console.WriteLine(">> " + readFile);


                if (File.Exists(directory + "/archive/Command_" + commandNumber + "_FormClient.out"))
                {
                    File.Delete(directory + "/archive/Command_" + commandNumber + "_FormClient.out");
                    File.Move(directory + "/Command_" + commandNumber + "_FormClient.out", directory + "/archive/Command_" + commandNumber + "_FormClient.out");
                }
                else
                {
                    File.Move(directory + "/Command_" + commandNumber + "_FormClient.out", directory + "/archive/Command_" + commandNumber + "_FormClient.out");
                }

                //File.Move(@"C:\CommunicationFile\Command_" + commandNumber + "_FormClient.out", @"C:\CommunicationFile\archive\Command_" + commandNumber + "_FormClient.out");


                //File.Move(directory + "/Command_" + commandNumber + "_FormClient.out", directory + "/archive/Command_" + commandNumber + "_FormClient.out");

                commandNumber++;
            }

            Console.WriteLine("Connection completed! Click ENTER!");
        }
    }
}
