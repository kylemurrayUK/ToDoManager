using System.Globalization;
using System.Text.Json;

namespace ToDoManager
{
    class ToDoService
    {
        private List<ToDoItem> _tasks;

        public ToDoService(List<ToDoItem> Tasks)
        {
            _tasks = Tasks;
        }

        public void ListTasks()
        {
            foreach (ToDoItem task in _tasks)
            {
                Console.WriteLine($"ID: {task.ID}\n" +
                                  $"Title: {task.Title}\n" +
                                  $"Description: {task.Description}\n" +
                                  $"Completed?: {task.IsCompleted}\n" +
                                  $"Created on: {task.CreatedAt}");
                if (task.IsCompleted == true)
                {
                    Console.WriteLine($"Tasks completed at: {task.CompletedAt}\n");
                }
                else
                {
                    Console.WriteLine("\n");
                }
            }
        }
        public void AddTask(string Title, string Description)
        {
            int id = FindID();
            ToDoItem newTask = new ToDoItem(id, Title, Description);
            _tasks.Add(newTask);
            FileStorage.SaveFile(_tasks);
            _tasks = FileStorage.LoadFile();
        }
        public void CompleteTask()
        {
            Console.WriteLine("Complete Tasks");
        }
        public void DeleteTask()
        {
            Console.WriteLine("Delete Tasks");
        }


        private int FindID()
        {
            int id;
            if (_tasks.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = _tasks[_tasks.Count - 1].ID + 1;
            }
            return id;
        }
    }
}