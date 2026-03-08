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
            Console.WriteLine("View Tasks");
        }
        public void AddTask()
        {
            Console.WriteLine("Add Tasks");
        }
        public void CompleteTask()
        {
            Console.WriteLine("Complete Tasks");
        }
        public void DeleteTask()
        {
            Console.WriteLine("Delete Tasks");
        }
    }
}