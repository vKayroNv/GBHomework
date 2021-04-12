using System;
using System.Collections.Generic;
using System.IO;

namespace FileManager
{
    class Program
    {
        static Settings settings; // Класс настроек
        static Dictionary<string, int> indexes = new Dictionary<string, int>(); // Словарь для координат ключевых элементов интерфейса
        static int cursorDirectoryBlockPosition = 0; // Текущее положение курсора
        static string[] currentDirectories, currentFiles; // Массивы для хранения директорий и файлов внутри текущей директории
        static bool CommandMode = false; // Флаг для режима командной строки

        static void Main(string[] args)
        {
            // Загрузка настроек (и их создание при отсутствии)
            if (!File.Exists("settings.json"))
                SettingsClass.Create();
            settings = SettingsClass.Load();

            // Инициализация настроек окна
            InitializeConsoleWindow();
            // Инициализация координат для правильного отображения интерфейса
            InitializeIndexes();

            while (true)
            {
                // Отрисовка интерфейса
                CreateHeader();
                DirectoryBlock();
                Information();
                CreateFooter();

                if (!CommandMode)
                {
                    Console.CursorVisible = false;
                    MoveCursor();
                }
                else
                {
                    Console.CursorVisible = true;
                    Console.SetCursorPosition(9, indexes["footer"] + 1);
                    // TODO: режим командной строки
                }

                // Управление программой
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursorDirectoryBlockPosition != 0)
                            cursorDirectoryBlockPosition--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorDirectoryBlockPosition != currentDirectories.Length + currentFiles.Length - 1) 
                            cursorDirectoryBlockPosition++;
                        break;
                    case ConsoleKey.Enter:
                        ChangeDirectory(cursorDirectoryBlockPosition);
                        break;
                    case ConsoleKey.Backspace:
                        ReturnDirectory();
                        break;
                    case ConsoleKey.C:
                        CommandMode = true;
                        break;
                    case ConsoleKey.Escape:
                        if (CommandMode)
                            CommandMode = false;
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Инициализирует настройки окна
        /// </summary>
        static void InitializeConsoleWindow()
        {
            Console.SetWindowSize(settings.width, settings.height);
            Console.BufferWidth = settings.width;
            Console.BufferHeight = settings.height;
            Externals.BlockResize();
            Console.SetWindowPosition(0, 0);
        }

        /// <summary>
        /// Инициализацирует координаты для правильного отображения интерфейса
        /// </summary>
        static void InitializeIndexes()
        {
            indexes.Add("header", 0);
            indexes.Add("directoryBlock", 3);
            indexes.Add("information", settings.height - 12);
            indexes.Add("footer", settings.height - 2);
        }

        /// <summary>
        /// Рисует горизонтальную линию
        /// </summary>
        /// <param name="symbol">Символ для рисования</param>
        /// <param name="index">Номер строки</param>
        static void DrawLine(char symbol, int index)
        {
            Console.SetCursorPosition(0, index);
            for (int i = 0; i < settings.width; i++)
                Console.Write(symbol);
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Отрисовка верхней части, в которой указывается путь к текущей директории
        /// </summary>
        static void CreateHeader()
        {
            DrawLine('█', indexes["header"]);
            Console.SetCursorPosition(0, indexes["header"] + 1);
            Console.Write($"█ Путь: █ {settings.currentDirectory}");
            Console.SetCursorPosition(settings.width - 1, indexes["header"] + 1);
            Console.Write("█");
            DrawLine('█', indexes["header"] + 2);
        }

        /// <summary>
        /// Отрисовка основного блока, куда выводятся названия директорий и файлов
        /// </summary>
        static void DirectoryBlock()
        {
            Console.SetCursorPosition(0, indexes["directoryBlock"]);

            if (settings.currentDirectory != "MyComputer")
            {
                // Получение директорий и файлов по текущему пути
                currentDirectories = Directory.GetDirectories(settings.currentDirectory);
                currentFiles = Directory.GetFiles(settings.currentDirectory);

                for (int i = 0; i < currentDirectories.Length; i++)
                    Console.WriteLine("  " + currentDirectories[i].Remove(0, currentDirectories[i].LastIndexOf('\\') + 1));
                for (int i = 0; i < currentFiles.Length; i++)
                    Console.WriteLine("  " + currentFiles[i].Remove(0, currentFiles[i].LastIndexOf('\\') + 1));
            }
            else
            {
                // Получение списка дисков
                DriveInfo[] drives = DriveInfo.GetDrives();
                currentDirectories = new string[drives.Length];
                currentFiles = new string[0];

                for (int i = 0; i < drives.Length; i++)
                {
                    currentDirectories[i] = drives[i].Name;
                    Console.WriteLine("  " + currentDirectories[i]);
                }
            }
        }

        /// <summary>
        /// Перемещение курсора для выбора директорий и файлов
        /// </summary>
        static void MoveCursor()
        {
            Console.SetCursorPosition(0, indexes["directoryBlock"] + cursorDirectoryBlockPosition);
            Console.Write(">");
        }

        /// <summary>
        /// Отображение информации о директориях и файлах
        /// </summary>
        static void Information()
        {
            DrawLine('▄', indexes["information"]);
        }

        /// <summary>
        /// Отрисовка нижней части, в которой распологается командная строка
        /// </summary>
        static void CreateFooter()
        {
            DrawLine('█', indexes["footer"]);
            Console.SetCursorPosition(0, indexes["footer"] + 1);
            Console.Write(" (C)MD > ");
        }

        /// <summary>
        /// Переход в следующую директорию
        /// </summary>
        /// <param name="index">Индекс в соответствии с массивом currentDirectories</param>
        static void ChangeDirectory(int index)
        {
            if (index < currentDirectories.Length)
            {
                Console.Clear();
                cursorDirectoryBlockPosition = 0;
                settings.currentDirectory = currentDirectories[index];
            }
        }

        /// <summary>
        /// Переход в предыдущую директорию
        /// </summary>
        static void ReturnDirectory()
        {
            cursorDirectoryBlockPosition = 0;
            if (settings.currentDirectory != "MyComputer")
            {
                Console.Clear();
                if (settings.currentDirectory.Length != 3)
                    settings.currentDirectory = settings.currentDirectory.Remove(settings.currentDirectory.LastIndexOf('\\'));
                else
                    settings.currentDirectory = "MyComputer";
                if (settings.currentDirectory.Length == 2)
                    settings.currentDirectory += '\\';
            }
        }
    }
}
