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
        static ToDoList toDoList = new ToDoList();
        const string filename = "tasks.json";
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                CheckTasks();
                CreateMenu();

                string input = Console.ReadLine();

                try
                {
                    if (input[0] == '+')
                        CreateTask(input.Remove(0, 1));
                    else if (input[0] == '-')
                        ClearTasks();
                    else if (input[0] == '~')
                        break;
                    else
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
                using (StreamReader sr = new StreamReader(filename))
                    toDoList = JsonSerializer.Deserialize<ToDoList>(sr.ReadToEnd(), options);

                if (toDoList.Tasks.Count == 0)
                    Console.WriteLine("В данный момент никаких задач нет.");
                else for (int i = 0; i < toDoList.Tasks.Count; i++)
                    {
                        Console.Write($"{i + 1}. ");
                        if (toDoList.Tasks[i].IsDone)
                            Console.Write("[X] ");
                        Console.WriteLine(toDoList.Tasks[i].Title);
                    }
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
            toDoList.Tasks.Add(new ToDo(input));
        }

        static void ClearTasks()
        {
            for (int i = toDoList.Tasks.Count - 1; i >= 0; i--)
                if (toDoList.Tasks[i].IsDone)
                    toDoList.Tasks.RemoveAt(i);
        }

        static void ChangeIsDone(int i)
        {
            if (toDoList.Tasks[i - 1].IsDone)
                toDoList.Tasks[i - 1].IsDone = false;
            else
                toDoList.Tasks[i - 1].IsDone = true;
        }

        static void SaveFile()
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(JsonSerializer.Serialize<ToDoList>(toDoList, options));
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

    class ToDoList
    {
        public List<ToDo> Tasks { get; set; }

        public ToDoList()
        {
            Tasks = new List<ToDo>();
        }
    }
}
