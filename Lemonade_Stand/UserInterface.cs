using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public class UserInterface
    {
        public int AskForDuration()
        {
            Console.WriteLine("How many days will the stand be open: 7, 14, or 21?");
            int duration = Int32.Parse(Console.ReadLine());

            return duration;
        }

        public string DisplayMessage(string promptMessage)
        {
            Console.WriteLine(promptMessage);
            string userInput = Console.ReadLine();
            return userInput;
        }

    }
}
