using System.Text.Json;

namespace ToDoManager
{
    class FileStorage
    {
        const string filePath = @"data\Tasks.json";
        public static List<ToDoItem> LoadFile()
        {
            List<ToDoItem> loadedTasks = new List<ToDoItem>();
            if (!Directory.Exists(@"data"))
            {
                Directory.CreateDirectory(@"data");
            }
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
            try
            {
                loadedTasks = JsonSerializer.Deserialize<List<ToDoItem>>(File.ReadAllText(filePath));
            }
            catch (JsonException)
            {
                Console.WriteLine("Json exception thrown - invalid JSON in file. Empty list returned");
            }
            if (loadedTasks == null)
            {
                Console.WriteLine("Jnull file. Empty list returned");
            }
            return loadedTasks;

        }
        public static void SaveFile(List<ToDoItem> tasks)
        {
            File.WriteAllText(@"data\Tasks.json", JsonSerializer.Serialize<List<ToDoItem>>(tasks));   
        }

    }
}