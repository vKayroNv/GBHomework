using System;
using System.IO;

namespace lesson_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сохранение данных в файл
            Console.WriteLine("Введите информацию:");
            string text = Console.ReadLine();
            Console.WriteLine("Введите название файла:");
            using (StreamWriter sw = new StreamWriter(Console.ReadLine() + ".txt"))
                sw.Write(text);
            Console.WriteLine("Файл сохранен");
        }
    }
}
