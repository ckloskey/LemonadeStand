using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public class UserInterface
    {
        List<string> validResponses = new List<string>{ "1", "2", "3", "4", "5" };
        bool validInput = false;
        public int AskForDuration()
        {
            Console.WriteLine("How many days will the stand be open: 7, 14, or 21?");
            int duration = Int32.Parse(Console.ReadLine());

            return duration;
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
            } while (ValidUserInput(purchasing) == false);
            return purchasing;
        }

        public string QualityControlMenu()
        {
            string updateQualityControl;
            do
            {
               updateQualityControl = PromptUserInput("Price/Quality Control\n1: Price Per Cup\n2: Lemons Per Pitcher\n3: Sugar Per Pitcher\n4: Ice cubes Per Cup\n5: Done");
            } while (ValidUserInput(updateQualityControl) == false);
            return updateQualityControl;
        }

        public bool ValidUserInput(string input)
        {
            //validInput = validResponses.Contains(input) ? true : false;
            if (validResponses.Contains(input))
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
