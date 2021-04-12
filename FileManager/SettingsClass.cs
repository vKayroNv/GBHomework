using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace FileManager
{
    public static class SettingsClass
    {
        public static void Create()
        {
            Settings settings = new Settings() { currentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) };
            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            using (StreamWriter sw = File.CreateText("settings.json"))
                sw.WriteLine(JsonSerializer.Serialize<Settings>(settings, jso));
        }

        public static Settings Load()
        {
            Settings settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText("settings.json")));
            return settings;
        }
    }

    public class Settings
    {
        public string currentDirectory { get; set; }
    }
}
