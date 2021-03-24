using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ToDo_list
{
    class Program
    {
        static List<ToDo> todoList = new List<ToDo>();
        const string filename = "tasks.json";
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                todoList.Clear();

                CheckTasks();
                CreateMenu();

                string input = Console.ReadLine();

                if (input[0] == '+')
                    CreateTask(input.Remove(0, 1));
                else if (input[0] == '-')
                    ClearTasks();
                else if (input[0] == '~')
                    break;
                else try
                    {
                        ChangeIsDone(int.Parse(input));
                    }
                    catch (Exception)
                    {
                        Console.Write("\nНеверный ввод.\nДля продолжения нажмите любую клавишу...");
                        Console.ReadKey(true);
                    }

                SaveFile();
            }
        }

        static void CheckTasks()
        {

            if (!File.Exists(filename)) 
                Console.WriteLine("В данный момент никаких задач нет.");
            else
            {
                var fs = File.OpenRead(filename);
                if (fs.Length == 0)
                    Console.WriteLine("В данный момент никаких задач нет.");
                else
                {
                    using (StreamReader sr = new StreamReader(filename))
                        while (!sr.EndOfStream)
                            todoList.Add(JsonSerializer.Deserialize<ToDo>(sr.ReadLine(), options));
                    for (int i = 0; i < todoList.Count; i++)
                    {
                        Console.Write($"{i + 1}. ");
                        if (todoList[i].IsDone)
                            Console.Write("[X] ");
                        Console.WriteLine(todoList[i].Title);
                    }
                }
                fs.Close();
            }
        }

        static void CreateMenu()
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write("+<текст> = добавить задачу\n" +
                          "-\t = очистить выполненые задачи\n" +
                          "<число>\t = пометить задачу как выполненную\n" +
                          "~\t = выход\n" +
                          "Ввод: ");
        }

        static void CreateTask(string input)
        {
            todoList.Add(new ToDo(input));
        }

        static void ClearTasks()
        {
            for (int i = todoList.Count - 1; i >= 0; i--)
                if (todoList[i].IsDone)
                    todoList.RemoveAt(i);
        }

        static void ChangeIsDone(int i)
        {
            if (todoList[i - 1].IsDone)
                todoList[i - 1].IsDone = false;
            else
                todoList[i - 1].IsDone = true;
        }

        static void SaveFile()
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (ToDo todo in todoList)
                    sw.WriteLine(JsonSerializer.Serialize<ToDo>(todo, options));
                sw.Close();
            }
        }
    }

    class ToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo() { } // Конструктор без параметров для правильной работы десериализации

        public ToDo(string text)
        {
            Title = text;
            IsDone = false;
        }
    }
}
