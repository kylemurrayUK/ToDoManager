namespace ToDoManager
{    
        class ValidationUtils{
            public static (int userChoice, bool validResponse) ValidMenuInput(string? unvalidatedUserChoice, string[] menuProgramChoices)
            {
                int userAnswer;
                bool isResponseValid;

                    if (!DoesStringHaveValue(unvalidatedUserChoice))
                    {
                        userAnswer = 0;
                        isResponseValid = false;
                        return (userAnswer, isResponseValid);
                    }
                    else if (!int.TryParse(unvalidatedUserChoice, out userAnswer))
                    {
                        Console.WriteLine("Must be an integer!");
                        userAnswer = 0;
                        isResponseValid = false;
                        return (userAnswer, isResponseValid);
                    }
                    else if (userAnswer > menuProgramChoices.Length || userAnswer < 1)
                    {
                        Console.WriteLine($"Must be between 1 and {menuProgramChoices.Length}!");
                        userAnswer = 0;
                        isResponseValid = false;
                        return (userAnswer, isResponseValid);
                    }
                    else
                    {
                        isResponseValid = true;
                        return (userAnswer, isResponseValid);
                    }
            }
        private static bool DoesStringHaveValue(string? potentialNullValue)
        {
            if (string.IsNullOrWhiteSpace(potentialNullValue))
            {
                Console.WriteLine("Null is not a valid answer");
                return false;
            }
            else
            {
                return true;
            }
        }
        }
}