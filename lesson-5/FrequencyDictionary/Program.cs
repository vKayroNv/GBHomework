using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrequencyDictionary
{
    class Program
    {
        static string input_path, output_path;
        static StreamReader sr;
        static Dictionary<string, int> freqDict = new Dictionary<string, int>();

        static char[] symbols = { '`', '~', '!', '@', '#', '№', '$', '%', '^', '&', '*', '(', ')', '_', '+', '=', '[', ']',
                                  '{', '}', ';', ':', '\"', '\'', '\\', '|', '/', '?', '.', ',', '<', '>', '\r', '\n', '\t', '-', '–', '—', ' ' };

        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == null || !File.Exists(args[0]) || args[1] == null)
            {
                Console.WriteLine("Используйте FrequencyDictionary.exe <файл с текстом> <файл словаря>");
                return;
            }
            else
            {
                input_path = args[0];
                output_path = args[1];
            }
            FileStream fs = new FileStream(input_path, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);

            Console.WriteLine("Обработка файла");
            Processing();

            Console.WriteLine("Сохранение результата");
            SaveOutput();

            Console.WriteLine("Готово");
            Console.ReadLine();
        }

        static void SaveOutput()
        {
            using (StreamWriter sw = new StreamWriter(output_path))
                foreach (var keyPair in freqDict.OrderBy(pair => pair.Key).OrderByDescending(pair => pair.Value))
                    sw.WriteLine($"{keyPair.Key}, {keyPair.Value}");
        }

        static void Processing()
        {
            string temp;
            while (!sr.EndOfStream)
            {
                temp = sr.ReadLine();
                temp = RemoveSymbols(temp);
                foreach (string word in temp.Split(' '))
                    if (word == "")
                        continue;
                    else if (freqDict.Keys.Contains(word.ToLower()))
                        freqDict[word.ToLower()]++;
                    else
                        freqDict.Add(word.ToLower(), 1);
            }
        }

        static string RemoveSymbols(string text)
        {
            string temp = text;
            foreach (char symbol in symbols)
                temp = temp.Replace(symbol, ' ');
            return temp;
        }
    }
}
