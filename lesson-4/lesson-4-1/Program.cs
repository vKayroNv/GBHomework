using System;

namespace lesson_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вывод ФИО
            string[,] names = new string[4, 3]
            {
                {"Петр","Петров","Петрович" },
                {"Иван","Иванов","Иванович" },
                {"Сидор","Сидоров","Сидорович" },
                {"Василий","Васин","Васильевич" }
            };

            Console.WriteLine("ФИО:");
            for (int i = 0; i < names.GetLength(0); i++)
                GetFullName(names[i, 0], names[i, 1], names[i, 2]);

            Console.ReadLine();
        }

        static void GetFullName(string firstName, string lastName, string patronymic)
        {
            Console.WriteLine($"{lastName} {firstName} {patronymic}");
        }
    }
}
