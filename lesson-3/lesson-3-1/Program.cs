using System;

namespace lesson_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Диагональ двумерного массива
            Console.WriteLine("Введите размер матрицы:");
            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();

            Console.WriteLine("Матрица:");
            int[,] matrix = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(-100, 101);
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Элементы, находящиеся на главной диагонали:");
            for (int i = 0; i < n; i++)
                Console.Write($"{matrix[i, i]}\t");
            Console.WriteLine();
            Console.WriteLine("Элементы, находящиеся на побочной диагонали:");
            for (int i = 0; i < n; i++)
                Console.Write($"{matrix[i, n - 1 - i]}\t");

            Console.ReadLine();
        }
    }
}
