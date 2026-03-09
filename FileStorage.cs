using System.Text.Json;

namespace ToDoManager
{
    class FileStorage
    {
        const string filePath = @"data\Tasks.json";
        public static List<ToDoItem> LoadFile()
        {
            if (!Directory.Exists(@"data"))
            {
                Directory.CreateDirectory(@"data");
            }
            if (!File.Exists(filePath))
            {

                File.WriteAllText(filePath, "[]");
            }
            
            return JsonSerializer.Deserialize<List<ToDoItem>>(File.ReadAllText(filePath));

        }
        public static void SaveFile(List<ToDoItem> tasks)
        {
            File.WriteAllText(@"data\Tasks.json", JsonSerializer.Serialize<List<ToDoItem>>(tasks));   
        }

    }
}