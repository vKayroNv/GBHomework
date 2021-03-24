using System;
using System.IO;

namespace lesson_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запись текущего времени в файл
            string filename = "startup.txt";

            using (StreamWriter sw = new StreamWriter(filename))
                sw.WriteLine(DateTime.Now.ToLongTimeString());

            Console.WriteLine($"Время записано в файл {filename}");
        }
    }
}
