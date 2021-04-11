using System;

namespace lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(app.Default.Greeting);
            if (app.Default.Name == "" || app.Default.Age == -1 || app.Default.Career == "")
            {
                Console.Write("Введите свое имя: ");
                app.Default.Name = Console.ReadLine();

                Console.Write("Сколько вам лет: ");
                while (true) try
                    {
                        app.Default.Age = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch { Console.WriteLine("Неверный ввод"); }

                Console.Write("Кем вы работаете: ");
                app.Default.Career = Console.ReadLine();
                app.Default.Save();
            }
            Console.Clear();
            Console.WriteLine($"Вас зовут {app.Default.Name}, вам {app.Default.Age} лет, вы работаете {app.Default.Career}.");
            Console.Write("Изменить? (Y/N): ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Clear();
                app.Default.Name = "";
                app.Default.Age = -1;
                app.Default.Career = "";
                Main(args);
                app.Default.Save();
            }
        }
    }
}
