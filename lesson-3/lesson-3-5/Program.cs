using System;

namespace lesson_3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Сортировка массива
            int n = 10;
            int[] array = new int[n];

            Console.WriteLine($"Введите массив из {n} целых элементов");

            for (int i = 0; i < n; i++)
                while (true)
                    try
                    {

                        Console.Write($"{i + 1}: ");
                        array[i] = int.Parse(Console.ReadLine());
                        break;

                    }
                    catch (Exception) { Console.WriteLine("Неверный ввод"); }

            Console.Clear();
            Console.WriteLine("Введенный массив:");
            foreach (int i in array)
                Console.Write($"{i}\t");

            Sort(ref array);

            Console.WriteLine("\nОтсортированный массив:");
            foreach (int i in array)
                Console.Write($"{i}\t");

            Console.ReadLine();
        }

        static void Sort(ref int[] array)
        {
            bool fl = true;
            int count = 0;
            while (fl)
            {
                fl = false;
                for (int i = 0; i < array.Length - 1; i++, count++) 
                    if (array[i] > array[i + 1])
                    {
                        int k = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = k;
                        fl = true;
                    }
            }
        }
    }
}
