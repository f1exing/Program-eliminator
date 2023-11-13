using System;
using System.Diagnostics;
using static System.Console;

namespace f1ex

{
    class Program
    {
        public static void KillById(int number)
        {
            WriteLine("killed id " + "" + number + "");
            var Processes = Process.GetProcesses();
            for (int i = 0; i < Processes.Length; i++)
            {
                if (Processes[i].Id == number)
                {
                    try { Processes[i].Kill(); }
                    catch { WriteLine("Exception found!"); }
                    return;
                }
            }
            WriteLine("Process not found. Something is wrong...");
        }

        public static void KillByName(string name)
        {
            WriteLine("killed name " + "" + name + "");
            var Processes = Process.GetProcesses();
            for (int i = 0; i < Processes.Length; i++)
            {
                if (String.Compare(Processes[i].ProcessName, name) == 0)
                {
                    try { Processes[i].Kill(); }
                    catch { WriteLine("Exception found!"); }
                    return;
                }
            }
            WriteLine("Process not found. Something is wrong...");
        }

        public static void ProcessId(string name)
        {
            WriteLine("process id" + "" + name + "");
            var Processes = Process.GetProcesses();
            bool verif = false;
            for (int i = 0; i < Processes.Length; i++)
            {
                string processName = Processes[i].ProcessName;
                processName = processName.ToLower();
                name = name.ToLower();
                if (processName.StartsWith(name))
                {
                    WriteLine($" {Processes[i].ProcessName,-40}{Processes[i].Id}");
                    verif = true;
                }
            }
            if (false)
                WriteLine("There are no processes with this name");
        }

        public static void TaskList()
        {
            WriteLine("TaskList()");
            var Processes = Process.GetProcesses();
            for (int i = 0; i < Processes.Length; i++)
                WriteLine($" {Processes[i].ProcessName,-40}{Processes[i].Id}");
        }

        public static void Main()
        {
            while (true)
            {
                WriteLine("Enter command number");
                WriteLine("1 => KillById");
                WriteLine("2 => KillByName");
                WriteLine("3 => ProcessId");
                WriteLine("4 => TaskList");
                WriteLine("5 => exit");

                int command = int.Parse(ReadLine());

                switch (command)
                {
                    case 1:
                        WriteLine("Enter process id");
                        int number = int.Parse(ReadLine());
                        KillById(number);
                        break;

                    case 2:
                        WriteLine("Enter process name");
                        string name = ReadLine();
                        KillByName(name);
                        break;
                    case 3:
                        WriteLine("Enter name or part name of process");
                        string _name = ReadLine();
                        ProcessId(_name);
                        break;
                    case 4:
                        TaskList();
                        break;
                    case 5: return;
                    default:
                        WriteLine("Invalid command number");
                        break;
                }
            }
        }
    }
}