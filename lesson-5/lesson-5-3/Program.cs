using System;
using System.IO;
using System.Linq;

namespace lesson_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запись данных в бинарный файл
            Console.WriteLine("Введите числа (от 0 до 255) через пробел:");
            byte[] array = Console.ReadLine().Split(' ').Select(x => byte.Parse(x)).ToArray();

            using (Stream stream = File.Open("data.bin", FileMode.OpenOrCreate, FileAccess.Write))
                using (BinaryWriter bw = new BinaryWriter(stream))
                    bw.Write(array);

            Console.WriteLine("Данные записаны в файл");
        }
    }
}
