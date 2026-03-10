using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

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
                Console.WriteLine($"ID: {task.id}\n" +
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
            int id = FindNextID(_tasks);
            ToDoItem newTask = new ToDoItem(id, Title, Description);
            _tasks.Add(newTask);
            FileStorage.SaveFile(_tasks);
        }
        public void CompleteTask(int inputtedID)
        {
            int matchCounter = 0;
            foreach(ToDoItem task in _tasks)
            {
                if (task.id == inputtedID && task.IsCompleted == true)
                {
                    Console.WriteLine("Task is already completed!");
                    matchCounter++;
                    continue;
                }
                else if(task.id == inputtedID && matchCounter == 0)
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
        public void DeleteTask(int inputtedID)
        {
            // find index save it then delete after loop completed
            int matchCounter = 0;
            int indexCounter = 0;
            int itemForDeletionIndex = 0;
            foreach(ToDoItem task in _tasks)
            {
                if(task.id == inputtedID)
                {
                    if (matchCounter == 0)
                        {itemForDeletionIndex = indexCounter;}
                    matchCounter++;
                }
                indexCounter++;
            }
            if (matchCounter > 1)
            {
                Console.WriteLine("More than one item exists with this ID - no action taken");
            }
            else if (matchCounter == 1)
            {
                _tasks.Remove(_tasks[itemForDeletionIndex]);
                FileStorage.SaveFile(_tasks);
            }
            else
            {
                Console.WriteLine("No match found");
            }
        }


        private int FindNextID(List<ToDoItem> Tasks)
        {
            int id;
            int highestID = 0;
            if (Tasks.Count() == 0)
            {
                id = 0;
            }
            else
            {
                foreach (ToDoItem task in Tasks)
                {
                    if (task.id > highestID)
                    {
                        highestID = task.id;
                    }
                } 
                id = highestID + 1;
            }
            return id;
        }
    }
}