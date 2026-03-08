namespace ToDoManager
{
    class Menu
    {   
        string[] menuChoices = {"View Tasks", "Add Task", "Complete Task", "Delete Task"};
        private ToDoService _toDoService;
        public Menu(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public void DirectUser()
        {
            
        }

        private void PrintChoices(string[] menuChoices)
        {
            Console.WriteLine("What action would you like to perform?");
            int i = 1;
            foreach (string menuOption in menuChoices)
                {
                    Console.WriteLine($"{i}.) {menuOption}");
                    i++;        
                }
        }
    }
}