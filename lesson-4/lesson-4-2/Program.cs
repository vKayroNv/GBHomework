using System;

namespace lesson_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Сумма чисел
            string[] input;
            int[] numbers;

            while (true)
                try
                {
                    Console.WriteLine("Введите числа через пробел:");
                    input = Console.ReadLine().Split(' ');

                    numbers = new int[input.Length];
                    for (int i = 0; i < input.Length; i++)
                        numbers[i] = int.Parse(input[i]);

                    break;
                }
                catch (Exception) { Console.WriteLine("Неверный ввод"); }

            Console.WriteLine($"Сумма чисел равна {Sum(numbers)}");
            Console.ReadLine();
        }

        static int Sum(int[] array)
        {
            int sum = 0;
            foreach (int arr in array)
                sum += arr;
            return sum;
        }
    }
}
