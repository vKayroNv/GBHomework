using System;
using System.IO;

namespace FileManager
{
    class Program
    {
        static Settings settings;

        static void Main(string[] args)
        {
            if (!File.Exists("settings.json"))
                SettingsClass.Create();
            settings = SettingsClass.Load();
        }
    }
}
