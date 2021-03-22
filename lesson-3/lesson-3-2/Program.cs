using System;

namespace lesson_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Телефонный справочник
            string[,] numbers = new string[5, 2] 
            { 
                { "Игорь", "8(905)951-35-48" }, 
                { "Алексей", "alex55@gmail.com" }, 
                { "Сергей", "8(953)456-48-32" }, 
                { "Оксана", "8(903)778-54-63/odfinfo@mail.ru" }, 
                { "Иван", "8(999)454-65-23" } 
            };

            Console.WriteLine("Справочник");
            for (int i = 0; i < 5; i++)
                Console.WriteLine($"{numbers[i, 0]}\t{numbers[i, 1]}");

            Console.ReadLine();
        }
    }
}
