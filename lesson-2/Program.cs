using System;

namespace lesson_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инверсия числа
            int number;
            while (true)
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите целое число:");
                    number = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.Write("Неверный ввод\nДля продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                }
            Console.Clear();
            Console.WriteLine($"Введенное число: {number}\nПеревернутое число: {Reverse(number)}");
            Console.ReadLine();
        }

        static int Reverse(int number)
        {
            int reverse_number = 0;
            while (number > 0)
            {
                reverse_number *= 10;
                reverse_number += number % 10;
                number /= 10;
            }
            return reverse_number;
        }
    }
}
