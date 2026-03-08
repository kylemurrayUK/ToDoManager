namespace ToDoManager
{
    class Menu
    {   
        string[] menuChoices = {"View Tasks", "Add Task", "Complete Task", "Delete Task", "Exit"};
        private ToDoService _toDoService;
        public Menu(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public void DirectUser()
        {
            bool shouldProgramKeepGoing = true;
            int userChoice;
            while (shouldProgramKeepGoing)
            {
                userChoice = GetUserChoice();
                switch (userChoice)
                {
                    case 1:
                        _toDoService.ListTasks();
                        break;
                    case 2:
                        _toDoService.AddTask();
                        break;
                    case 3:
                        _toDoService.CompleteTask();
                        break;
                    case 4:
                        _toDoService.DeleteTask();
                        break;
                    case 5:
                        shouldProgramKeepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Error with user input");
                        break;
                }
            }
        }


        private int GetUserChoice()
        {
            PrintChoices(menuChoices);
            return ReturnValidMenuUserChoice(menuChoices);
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
        private int ReturnValidMenuUserChoice(string[] listOfValidChoices)
        {
            int validatedUserReponse;
            bool isUserChoicevalid = false;
            do 
            {
                    Console.WriteLine("Input: ");
                    string? userChoice = Console.ReadLine();
                    var validationResponse = ValidationUtils.ValidMenuInput(userChoice, listOfValidChoices);
                    isUserChoicevalid = validationResponse.validResponse;
                    validatedUserReponse = validationResponse.userChoice;
            } while (isUserChoicevalid == false);

            return validatedUserReponse;
        }
    }
}