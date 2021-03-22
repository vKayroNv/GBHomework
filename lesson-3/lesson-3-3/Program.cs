using System;

namespace lesson_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инверсия введенной строки
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();
            Console.WriteLine("Инвертированая строка:");
            for (int i = input.Length - 1; i >= 0; i--)
                Console.Write(input[i]);

            Console.ReadLine();
        }
    }
}
