using System;

namespace lesson_2_4
{
    class Program
    {
        [Flags]
        enum Week
        {
            Monday = 0b_1,
            Tuesday = Monday << 1,
            Wednesday = Tuesday << 1,
            Thursday = Wednesday << 1,
            Friday = Thursday << 1,
            Saturday = Friday << 1,
            Sunday = Saturday << 1
        }

        static void Main(string[] args)
        {
            Week office1 = (Week)0b_0011111;
            Week office2 = (Week)0b_0101010;
            Console.WriteLine("График работы первого офиса:");
            CheckDays(office1);
            Console.WriteLine();
            Console.WriteLine("График работы второго офиса:");
            CheckDays(office2);
            Console.ReadLine();
        }

        static void CheckDays(Week office)
        {
            if ((office & Week.Monday) == Week.Monday)
                Console.Write("Понедельник, ");
            if ((office & Week.Tuesday) == Week.Tuesday)
                Console.Write("Вторник, ");
            if ((office & Week.Wednesday) == Week.Wednesday)
                Console.Write("Среда, ");
            if ((office & Week.Thursday) == Week.Thursday)
                Console.Write("Четверг, ");
            if ((office & Week.Friday) == Week.Friday)
                Console.Write("Пятница, ");
            if ((office & Week.Saturday) == Week.Saturday)
                Console.Write("Суббота, ");
            if ((office & Week.Sunday) == Week.Sunday)
                Console.Write("Воскресенье, ");
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            Console.WriteLine("  ");
        }
    }
}
