using System;

namespace lesson_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение:");
            string message = Console.ReadLine();
            Console.WriteLine("Перевернутое сообщение:");
            for (int i = message.Length - 1; i >= 0; i--)
                Console.Write(message[i]);
            Console.ReadLine();
        }
    }
}
