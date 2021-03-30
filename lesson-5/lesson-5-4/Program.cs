using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace lesson_5_4
{
    class Program
    {
        static List<string> paths = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь:");
            string path = Console.ReadLine();

            GetDirectories(path);

            foreach (string s in paths)
                Console.WriteLine(s);

            Console.ReadLine();
        }

        static void GetDirectories(string path)
        {
            GetFiles(path);
            foreach (string s in Directory.GetDirectories(path))
            {
                paths.Add(s);
                GetFiles(s);
                GetDirectories(s);
            }
        }

        static void GetFiles(string path)
        {
            foreach (string s in Directory.GetFiles(path))
                paths.Add(s);
        }
    }
}
