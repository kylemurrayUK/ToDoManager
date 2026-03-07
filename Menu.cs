namespace ToDoManager
{
    class Menu
    {   
        private ToDoService _toDoService;
        public Menu(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }
    }
}