using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace lesson_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вычисление факториала без рекурсии

            Console.WriteLine("Введите целое число:");
            int number = int.Parse(Console.ReadLine());

            // Счетчик времени
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BigInteger result = 1;

            if (number < 100000)
                Factorial(0, number, ref result);
            else
            { 
                // Наверное мультипоточность. Работает быстрее.
                int turn = number / Environment.ProcessorCount;

                List<Task> tasks = new List<Task>();
                BigInteger[] results = new BigInteger[Environment.ProcessorCount];

                for (int i = 0; i < Environment.ProcessorCount; i++)
                {
                    if (i == Environment.ProcessorCount - 1)
                        tasks.Add(new Task(() => Factorial(i * turn, number, ref results[i])));
                    else
                        tasks.Add(new Task(() => Factorial(i * turn, (i + 1) * turn, ref results[i])));
                    tasks[i].Start();
                    Thread.Sleep(200);
                }

                Task.WaitAll(tasks.ToArray());
                foreach (BigInteger res in results)
                    result *= res;
            }

            stopwatch.Stop();
            Console.WriteLine($"Затрачено времени: {stopwatch.ElapsedMilliseconds} мс");

            Console.WriteLine("Cохранение результата");
            using (StreamWriter sw = new StreamWriter("result.txt"))
                sw.Write(result);
            Console.WriteLine("Результат сохранен в файл result.txt");

            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void Factorial(int lbound, int ubound, ref BigInteger result)
        {
            result = 1;
            for (int i = lbound + 1; i <= ubound; i++)
                result *= i;
        }
    }
}
