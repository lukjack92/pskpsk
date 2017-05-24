using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Files : IService
    {
        public Files()
        {
            Console.WriteLine("usługa files");
        }

        public string Answer(string command)
        {
            string[] comm = command.Split(' ');
            int count = comm.Count();
            string msgF = string.Empty;
            string msgD = string.Empty;
            string msg = string.Empty;

            if (count == 1) return "file options{ dir | mkdir {name_file} | pwd | rm {file} | cd {go to directory}";

            switch (comm[1])
            {
                case "dir":
                    DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

                    FileInfo[] files = dir.GetFiles();
                    DirectoryInfo[] directory = dir.GetDirectories();

                    //string[] fileEntries = Directory.GetFiles(Directory.GetCurrentDirectory());
                    //foreach (string fileName in fileEntries)
                    //    Console.WriteLine(fileName);

                    //string[] direct = Directory.GetDirectories(Directory.GetCurrentDirectory());
                    //foreach (string fileName in direct)
                    //    Console.WriteLine(fileName);

                    foreach (var item in files)
                    {
                        Console.WriteLine("File -> " + item);
                        msgF += "File -> " + item + "\n";
                    }

                    foreach (var item in directory)
                    {
                        Console.WriteLine("Directory -> " + item);
                        msgD += "Directory -> " + item + "\n";
                    }

                    msg = msgF + msgD;

                    return msg;
                case "mkdir":
                    if (count == 2) return "file mkdir {name_file}";
                    Directory.CreateDirectory(comm[2]);
                    return "Create " + Directory.GetCurrentDirectory() + "\\" + comm[2];
                case "rm":
                    if (count == 2) return "file rm {name_file}";
                    //File.Delete(Directory.GetCurrentDirectory() + comm[2]);
                    return "Remove file";
                case "pwd":
                    string path = Directory.GetCurrentDirectory();

                    if (path.Length == 0)
                        return "Directory is empty";
                    else
                        return path;
                case "cd":
                    if (count == 2) return "cd { go to directory}";
                    Directory.SetCurrentDirectory(comm[2]);
                    return Directory.GetCurrentDirectory();
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
