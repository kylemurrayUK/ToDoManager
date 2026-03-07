namespace ToDoManager
{
    class ToDoService
    {
        private List<ToDoItem> _tasks;

        public ToDoService(List<ToDoItem> Tasks)
        {
            _tasks = Tasks;
        }
    }
}