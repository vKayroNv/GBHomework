using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FileManager
{
    public static class SettingsClass
    {
        static JsonSerializerOptions jso = new JsonSerializerOptions() { WriteIndented = true };

        public static void Create()
        {
            Settings settings = new Settings()
            {
                currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                width = 200,
                height = 50
            };
            using (StreamWriter sw = File.CreateText("settings.json"))
                sw.WriteLine(JsonSerializer.Serialize<Settings>(settings, jso));
        }

        public static Settings Load()
        {
            Settings settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText("settings.json"));

            if (settings.currentDirectory == "")
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (settings.width == 0)
                settings.width = 200;
            if (settings.height == 0)
                settings.height = 50;
            using (StreamWriter sw = File.CreateText("settings.json"))
                sw.WriteLine(JsonSerializer.Serialize<Settings>(settings, jso));

            return settings;
        }
    }

    public class Settings
    {
        public string currentDirectory { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
