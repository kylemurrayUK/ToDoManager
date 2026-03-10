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

        public void Run()
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
                        string userTitle = GetNotNullString("Input Title: ");
                        string userDescription = GetNotNullString("Input Description: ");
                        _toDoService.AddTask(userTitle, userDescription);
                        break;
                    case 3:
                        int selectedID = GetInt();
                        _toDoService.CompleteTask(selectedID);
                        break;
                    case 4:
                        selectedID = GetInt();
                        _toDoService.DeleteTask(selectedID);
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


        private string GetNotNullString(string prompt)
        {
            bool isStringNull = true;
            string? userInput = ""; 
            while (isStringNull)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Input cannot be null");
                    continue;
                }
                isStringNull = false;
            }
            return userInput;
        }

        private int GetInt()
        {
            bool isValidInt = false;
            string? userInput = "";
            while (!isValidInt)
            {
                Console.WriteLine("Input ID: ");
                userInput = Console.ReadLine();
                if (userInput == "")
                {
                    Console.WriteLine("Input cannot be null");
                    continue;
                }
                else if (!int.TryParse(userInput, out _))
                {
                    Console.WriteLine("Input has to be an integer");
                    continue;
                }
                isValidInt = true;
            }
            return int.Parse(userInput);
        }
    }
}