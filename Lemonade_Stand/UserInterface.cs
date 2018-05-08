using System;
using System.Collections.Generic;

namespace Lemonade_Stand
{
    public class UserInterface
    {
        List<string> validDurationOptions = new List<string> { "7", "14", "21" };
        List<string> validResponses = new List<string>{ "1", "2", "3", "4", "5" };
        List<string> validAmountOfPlayers = new List<string> { "1", "2" };
        List<string> validUserTypes = new List<string> { "human","computer" };
        public int AskForDuration()
        {
            string gameOption;
            do
            {
                Console.WriteLine("How many days will the stand be open: 7, 14, or 21?");
                gameOption = Console.ReadLine();
            } while (ValidUserInput(gameOption, validDurationOptions) == false);
            int duration = Int32.Parse(gameOption);
            return duration;
        }
        public string AskForNumberOfPlayers()
        {
            string numOfPlayers;
            do
            {
              numOfPlayers = PromptUserInput("How Many Players are Playing");
            } while (ValidUserInput(numOfPlayers, validAmountOfPlayers) == false);
            return numOfPlayers;
        }

        public string AskForPlayerType()
        { string secondPlayer;
            do {
                secondPlayer = PromptUserInput("Is second player a 'human' or 'computer'?").ToLower();
            } while (ValidUserInput(secondPlayer, validUserTypes) == false);
            return secondPlayer;
        }

        public string PromptUserInput(string promptMessage)
        {
            Console.WriteLine(promptMessage);
            string userInput = Console.ReadLine();
            return userInput;
        }

        public string PurchasingMenu()
        {
            string purchasing;
            do
            {
                purchasing = PromptUserInput("Purchase\n1: Lemons\n2: Sugar\n3: Cups\n4: Ice cubes\n5: Done");
            } while (ValidUserInput(purchasing, validResponses) == false);
            return purchasing;
        }
        public string QualityControlMenu()
        {
            string updateQualityControl;
            do
            {
               updateQualityControl = PromptUserInput("Price/Quality Control\n1: Price Per Cup\n2: Lemons Per Pitcher\n3: Sugar Per Pitcher\n4: Ice cubes Per Cup\n5: Done");
            } while (ValidUserInput(updateQualityControl, validResponses) == false);
            return updateQualityControl;
        }
        
        public int PromptForQuantity()
        {
            int quantity;
            string userInput;
            do
            {
                userInput = PromptUserInput("Quantity? (whole numbers)");
            } while (!CheckForInt(userInput));
            quantity = Int32.Parse(userInput);
            return quantity;
        }

        public bool CheckForInt(string input)
        {
            bool inputGood = int.TryParse(input, out int i);
            return inputGood;
        }

        public double PromptForPrice()
        {
            double quantity = double.Parse(PromptUserInput("Set Price: (No Customer will buy over 90cents, keep it reasonable)"));
            return quantity;
        }

        public bool ValidUserInput(string input, List<string> options)
        {
            if (options.Contains(input))
            {
                return true;
            }
            else
            {
                Console.WriteLine(input + " is not a valid option");
                return false;
            }
        }
    }
}
