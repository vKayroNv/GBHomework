using System;

namespace lesson_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Четное или нечетное число
            int input;
            while (true)
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите число:");
                    input = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.Write("\nНеверный ввод\nДля продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                }

            if (input % 2 == 0)
                Console.WriteLine("Число четное");
            else
                Console.WriteLine("Число нечетное");

            Console.ReadLine();
        }
    }
}
