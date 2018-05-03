using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.RunGame();

            //1 user determines number of days to play X
            //2 grab weather (weather randomly generated or API) X
            //display next day forecast X
            //3 Purchase X
                //change prices daily
            //4 Price/Quality control - working on
            //5 begin day
                //Start Selling to customers
                //adjust weather and forecast and display
                 //generate customers and probabilty of buying
            //6 calculate EOD profits
            //repeat 3 to 6 until end of duration
        }
    }
}
