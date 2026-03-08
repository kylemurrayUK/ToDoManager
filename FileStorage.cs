using System.Text.Json;

namespace ToDoManager
{
    class FileStorage
    {
        public static List<ToDoItem> LoadFile()
        {
            if (!File.Exists(@"data\Tasks.json"))
            {
                File.WriteAllText(@"data\Tasks.json", "[]");
            }
            
            return JsonSerializer.Deserialize<List<ToDoItem>>(File.ReadAllText(@"data\Tasks.json"));

        }
        public static void SaveFile(List<ToDoItem> tasks)
        {
            File.WriteAllText(@"data\Tasks.json", JsonSerializer.Serialize<List<ToDoItem>>(tasks));   
        }

    }
}