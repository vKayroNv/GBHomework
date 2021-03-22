using System;
using System.Collections.Generic;

namespace lesson_3_4
{
    class Program
    {
        struct Boat
        {
            public int X, Y, Lenght;
            public bool IsVertical;
            public Boat(int x, int y, int lenght, bool isVertical)
            {
                X = x;
                Y = y;
                Lenght = lenght;
                IsVertical = isVertical;
            }
        }
        static List<Boat> boats = new List<Boat>()
        {
            new Boat(2,2,4,true),
            new Boat(5,2,3,false),
            new Boat(4,7,3,true),
            new Boat(0,0,2,false),
            new Boat(7,5,2,true),
            new Boat(9,8,2,true),
            new Boat(9,0,1,false),
            new Boat(4,5,1,false),
            new Boat(1,8,1,false),
            new Boat(6,8,1,false)
        };

        static void Main(string[] args)
        {
            // Морской бой
            Console.WriteLine("  А Б В Г Д Е Ж З И К");
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);
            Console.SetCursorPosition(2, 1);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    Console.Write("\u2592\u2592");
                Console.SetCursorPosition(2, Console.CursorTop + 1);
            }

            foreach(Boat boat in boats)
                DrawBoat(boat);

            Console.ReadLine();
        }

        static void DrawBoat(Boat boat)
        {
            for (int i = 0; i < boat.Lenght; i++)
            {
                if (boat.IsVertical)
                    Console.SetCursorPosition(2 + boat.X * 2, 1 + boat.Y + i);
                else
                    Console.SetCursorPosition(2 + (boat.X + i) * 2, 1 + boat.Y);
                Console.Write("\u2588\u2588");
            }
        }
    }
}
