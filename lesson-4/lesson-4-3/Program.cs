using System;
using System.Collections.Generic;

namespace lesson_4_3
{
    class Program
    {
        [Flags]
        enum Seasons
        {
            Winter = 0b_100000000011,
            Spring = 0b_11100,
            Summer = Spring << 3,
            Autumn = Summer << 3
        }

        [Flags]
        enum Months
        {
            January = 0b_1,
            February = January << 1,
            March = February << 1,
            April = March << 1,
            May = April << 1,
            June = May << 1,
            July = June << 1,
            August = July << 1,
            September = August << 1,
            October = September << 1,
            November = October << 1,
            December = November << 1
        }
        static Dictionary<Seasons, string> translate = new Dictionary<Seasons, string>()
        {
            { Seasons.Winter, "Зима"},
            { Seasons.Spring, "Весна"},
            { Seasons.Summer, "Лето"},
            { Seasons.Autumn, "Осень"}
        };
        static void Main(string[] args)
        {
            // Время года
            Seasons input;
            while (true) 
                try
                {
                    Console.Write("Введите номер месяца: ");
                    int power = int.Parse(Console.ReadLine());
                    if (power < 1 || power > 12)
                        throw new Exception("Ввод вне диапазона");
                    input = (Seasons)(0b_1 << power - 1);
                    break;
                }
                catch(Exception)
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 12");
                }

            GetSeason(input);

            Console.ReadLine();
        }

        static void GetSeason(Seasons month)
        {
            foreach (Seasons season in Enum.GetValues(typeof(Seasons)))
                if ((season & month) == month)
                {
                    Console.WriteLine(translate[season]);
                    break;
                }
        }
    }
}
