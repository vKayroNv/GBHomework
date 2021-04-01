using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Line("Название", "PID", "Память");

                foreach (Process process in Process.GetProcesses().OrderBy(p => p.ProcessName))
                    Line(process.ProcessName, process.Id.ToString(), process.WorkingSet64.ToString());

                Console.WriteLine("Закрыть процесс (по ID или имени):");
                string input = Console.ReadLine();

                try { Kill(int.Parse(input)); }
                catch { Kill(input); }
            }
        }

        static void Line(string name, string id, string memory)
        {
            if (name.Length < 28)
                Console.Write(name);
            else
                Console.Write(name.ToCharArray(), 0, 28);
            Console.SetCursorPosition(30, Console.CursorTop);
            Console.Write(id);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine(memory);
        }

        static void Kill(string name)
        {
            Process[] ps = Process.GetProcessesByName(name);

            if (ps.Length == 0)
                Console.WriteLine("Процессов с таким именем не найдено");
            else if (ps.Length==1)
                try
                {
                    ps[0].Kill();
                    Console.WriteLine("Процесс успешно закрыт");
                }
                catch { Console.WriteLine("Процесс не был закрыт"); }
            else
            {
                Console.Clear();
                Console.WriteLine("Найдено несколько процессов с таким именем");

                foreach (Process p in ps.OrderBy(p => p.ProcessName))
                    Line(p.ProcessName, p.Id.ToString(), p.WorkingSet64.ToString());

                Console.WriteLine("Введите PID закрываемого процесса или \"*\" для закрытия всех:");
                string input = Console.ReadLine();

                try
                {
                    if (input == "*")
                        foreach (Process p in ps)
                            p.Kill();
                    else
                        Kill(int.Parse(input));
                }
                catch { Console.WriteLine("Процесс не был закрыт"); }
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        static void Kill(int id)
        {
            Console.WriteLine(); 
            try
            {
                Process p = Process.GetProcessById(id);
            
                p.Kill();
                Console.WriteLine("Процесс успешно закрыт");
            }
            catch { Console.WriteLine("Процесс не был закрыт"); }

            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
