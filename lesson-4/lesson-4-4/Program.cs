using System;

namespace lesson_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Последовательность Фибоначчи
            int n = 30;

            Console.WriteLine($"{n}-е число в последовательности Фибоначчи без рекурсии: {Fibonachi(n)}");
            Console.WriteLine($"{n}-е число в последовательности Фибоначчи с рекурсией: {FibonachiRecursive(n)}");
            Console.WriteLine($"{n}-е число в последовательности Фибоначчи через формулу: {FibonachiFormula(n)}");

            Console.ReadLine();
        }

        static int Fibonachi(int generation)
        {
            int first = 0, second = 1;
            int temp;
            for (int i = 1; i < generation; i++)
            {
                temp = second;
                second += first;
                first = temp;
            }
            return second;
        }

        static int FibonachiRecursive(int generation)
        {
            if (generation == 0)
                return 0;
            else if (generation == 1)
                return 1;
            else
                return FibonachiRecursive(generation - 1) + FibonachiRecursive(generation - 2);
        }

        static int FibonachiFormula(int generation)
        {
            return Convert.ToInt32((Math.Pow((1 + Math.Sqrt(5)) / 2, generation) - Math.Pow((1 - Math.Sqrt(5)) / 2, generation)) / Math.Sqrt(5));
        }
    }
}
