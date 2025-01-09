using System.Text.Json;
using System.IO;

namespace SchoolDBProject.Utils
{
    public static class JsonDataStore
    {
        public static List<T> LoadData<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                var emptyList = new List<T>();
                SaveData(filePath, emptyList);
                return emptyList;
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }

        public static void SaveData<T>(string filePath, List<T> data)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(filePath, jsonData);
        }
    }
}
