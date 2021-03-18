using System;

namespace lesson_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Отрисовка чеков в консоли
            Check check1 = new Check(150, new DateTime(2021, 2, 13, 12, 56, 32), "Пятерочка", "Иванов И.И.",
                new Product[] { new Product("Газировка", 86.5f, 2), new Product("Чипсы", 112, 2) }, 500);
            Check check2 = new Check(354, new DateTime(2020, 10, 12, 9, 12, 45), "Магнит", "Петров П.П.",
                new Product[] { new Product("Хлеб", 35.2f, 1), new Product("Молоко", 89, 2), new Product("Колбаса", 423.87f, 1) }, 1000);

            while (true)
            {
                Console.Clear();
                Console.Write("Выберите чек:\n1. Пятерочка\n2. Магнит\n0. Выход\n\nВвод: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        DrawCheck(check1);
                        break;
                    case "2":
                        DrawCheck(check2);
                        break;
                    case "0":
                        return;
                    default:
                        Console.Write("\nНеверный ввод\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void DrawCheck(Check check)
        {
            Console.Clear();
            int column = 30;

            DrawLine(column);
            Console.WriteLine($"Кассовый чек № {check.Number}");
            DrawLine(column);
            Console.WriteLine($"Магазин {check.MagazineName}");
            Console.WriteLine(check.DateTime.ToShortDateString() + " " + check.DateTime.ToLongTimeString());
            Console.WriteLine($"Кассир: {check.Cashier}");
            DrawLine(column);

            foreach (Product product in check.Products)
            {
                Console.WriteLine(product.Name);
                string sub = $"={product.Price.ToString("F2")} * {product.Amount}";
                Console.SetCursorPosition(column - sub.Length, Console.CursorTop);
                Console.WriteLine(sub);
            }
            DrawLine(column);
            Console.Write("ИТОГ");
            Console.SetCursorPosition(column - (check.Total.ToString("F2") + " руб.").Length, Console.CursorTop);
            Console.WriteLine(check.Total.ToString("F2") + " руб.");
            Console.Write("Оплачено");
            Console.SetCursorPosition(column - (check.Payment.ToString("F2") + " руб.").Length, Console.CursorTop);
            Console.WriteLine(check.Payment.ToString("F2") + " руб.");
            Console.Write("Сдача");
            Console.SetCursorPosition(column - (check.OddPayment.ToString("F2") + " руб.").Length, Console.CursorTop);
            Console.WriteLine(check.OddPayment.ToString("F2") + " руб.");
            DrawLine(column);

            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void DrawLine(int count)
        {
            for (int i = 0; i < count; i++)
                Console.Write("-");
            Console.WriteLine();
        }

        struct Check
        {
            public int Number;
            public DateTime DateTime;
            public string MagazineName;
            public string Cashier;
            public Product[] Products;
            public float Total;
            public float Payment;
            public float OddPayment;

            public Check(int _Number, DateTime _DateTime, string _MagazineName, string _Cashier, Product[] _Products, float _Payment)
            {
                Number = _Number;
                DateTime = _DateTime;
                MagazineName = _MagazineName;
                Cashier = _Cashier;
                Products = _Products;
                Total = 0;
                foreach (Product product in Products)
                    Total += product.Price * product.Amount;
                Payment = _Payment;
                OddPayment = Payment - Total;
            }
        }

        struct Product
        {
            public string Name;
            public float Price;
            public int Amount;

            public Product(string _Name, float _Price, int _Amount)
            {
                Name = _Name;
                Price = _Price;
                Amount = _Amount;
            }
        }
    }
}
