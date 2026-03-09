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
            int id = FindNextID();
            ToDoItem newTask = new ToDoItem(id, Title, Description);
            _tasks.Add(newTask);
            FileStorage.SaveFile(_tasks);
            _tasks = FileStorage.LoadFile();
        }
        public void CompleteTask(int inputtedID)
        {
            int matchCounter = 0;
            foreach(ToDoItem task in _tasks)
            {
                if (task.ID == inputtedID && task.IsCompleted == true)
                {
                    Console.WriteLine("Task is already completed!");
                    matchCounter++;
                    continue;
                }
                else if(task.ID == inputtedID && matchCounter == 0)
                {
                    task.IsCompleted = true;
                    task.CompletedAt = DateTime.Now;
                    matchCounter++;
                    Console.WriteLine($"Task marked as complete with time of {task.CompletedAt}");
                }
            }
            FileStorage.SaveFile(_tasks);
            _tasks = FileStorage.LoadFile();
            if (matchCounter > 1)
            {
                Console.WriteLine("More than one match was found with that id. Only one has been updated.");
            }
            else if (matchCounter < 1)
            {
                Console.WriteLine("No match found");
            }
        }
        public void DeleteTask()
        {
            Console.WriteLine("Delete Tasks");
        }


        private int FindNextID()
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