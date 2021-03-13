using System;

namespace lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя: ");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Привет, {name}, сегодня {DateTime.Now.ToLongDateString()}");
            Console.ReadLine();
        }
    }
}
