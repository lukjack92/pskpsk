using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class FileServer
    {
        private string directory;
        private string readFile;
        private string recv;

        public FileServer(string path)
        {
            //Console.WriteLine("Server File not started, because path '" + path + "' does not exist");
            Console.WriteLine("Server File Communication started ... ");
            this.directory = path;

            DirectoryInfo di = new DirectoryInfo(@"C:\CommunicationFile\archive\");

            foreach (FileInfo file in di.GetFiles())
                file.Delete();

            while (true)
            {

                DirectoryInfo dir = new DirectoryInfo(directory);
                DirectoryInfo[] _dirs = dir.GetDirectories();
                FileInfo[] _files = dir.GetFiles("*.in");
                //Console.WriteLine("File1 " + _files.Length);

                if (dir == null)
                    System.Threading.Thread.Sleep(100);
                else
                {
                    foreach (var item in _files)
                    {
                        Console.WriteLine("FileName -> " + item.Name);
                        //readFile = File.ReadAllText(directory + "" + item.Name);
                        readFile = ReadCommand(directory + "" + item.Name);
                        Console.WriteLine("FileRead <- " + readFile);
                        recv = Queries.ParseAnswer(readFile);
                        Console.WriteLine("File -> " + recv);
                        File.WriteAllText(Path.ChangeExtension(directory + "" + item.Name, ".out"), recv);
                        //File.WriteAllText(directory + ".out", recv);


                        if (File.Exists(directory + "/archive/" + item.Name))
                        {
                            File.Delete(directory + "/archive/" + item.Name);
                            File.Move(directory + "" + item.Name, directory + "/archive/" + item.Name);
                        }
                        else
                        {
                            File.Move(directory + "" + item.Name, directory + "/archive/" + item.Name);
                        }
                    }
                }

                //fileName = string.Format("{0}Command_{1}_FormClient", directory, commandNumber);

                //while (!File.Exists(fileName + ".in"))
                //    System.Threading.Thread.Sleep(100);

                //readFile = File.ReadAllText(fileName + ".in");
                //Console.WriteLine("File <- " + readFile);
                //recv = Queries.ParseAnswer(readFile);
                //Console.WriteLine("File -> " + recv);

                //File.WriteAllText(fileName + ".out", recv);

                //if (File.Exists(@"C:\CommunicationFile\archive\Command_" + commandNumber + "_FormClient.in"))
                //{
                //    File.Delete(@"C:\CommunicationFile\archive\Command_" + commandNumber + "_FormClient.in");
                //    File.Move(@"C:\CommunicationFile\Command_" + commandNumber + "_FormClient.in", @"C:\CommunicationFile\archive\Command_" + commandNumber + "_FormClient.in");
                //}
                //else
                //{
                //    File.Move(@"C:\CommunicationFile\Command_" + commandNumber + "_FormClient.in", @"C:\CommunicationFile\archive\Command_" + commandNumber + "_FormClient.in");
                //}
                //commandNumber++;
            }
        }
        public string ReadCommand(string f)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    string comm = File.ReadAllText(f);
                    return comm;
                }
                catch
                {
                    System.Threading.Thread.Sleep(100);
                }
            }

            return "Error1";
        }
    }
}