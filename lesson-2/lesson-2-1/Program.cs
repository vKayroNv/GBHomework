using System;

namespace lesson_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Нахождение среднесуточной температуры, вывод названия месяца и проверка условия "Дождливая зима"
            float min, max;
            int month;
            while (true)
                try
                {
                    Console.Clear();
                    min = float.Parse(GetInput("Введите минимальную температуру за сутки:"));
                    max = float.Parse(GetInput("Введите максимальную температуру за сутки:"));
                    month = int.Parse(GetInput("Введите номер текущего месяца:"));
                    if (month <= 0 || month > 12)
                        throw new Exception("Ввод вне границ массива");
                    break;
                }
                catch (Exception)
                {
                    Console.Write("\nНеверный ввод\nДля продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                }

            float average = (min + max) / 2;

            Console.WriteLine($"\nСреднесуточная температура равна {average}\nТекущий месяц: {months[month - 1]}");
            if ((month == 12 || month == 1 || month == 2) && average > 0) 
                Console.WriteLine("Дождливая зима");

            Console.ReadLine();
        }

        static string GetInput(string console_text)
        {
            Console.WriteLine(console_text);
            return Console.ReadLine();
        }

        static string[] months = new string[12] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
    }
}
