using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Game
    {
        UserInterface userInterface;
        Weather weather;
        Store store;
        Inventory inventory;
        List<int> temperatureForGamePlay;
        List<string> forecastForGamePlay;

        public int duration;
        public Game()
        {
            this.weather = new Weather();
            this.userInterface = new UserInterface();
            this.store = new Store();
            this.inventory = new Inventory();
        }

        public void RunGame()
        {
            duration = userInterface.AskForDuration();
            for (int i = 0; i < duration; i++)
            {
                temperatureForGamePlay = weather.GenerateRandomTemperature(duration);
                forecastForGamePlay = weather.GenerateRandomForecast(duration);
                DisplayNextDayWeather(temperatureForGamePlay, forecastForGamePlay, i);

                //while !5
                PurchasingFromStore();
            }
        }

        public void DisplayNextDayWeather(List<int> weeklyTemperature, List<string> weeklyForecast, int day)
        {
            int NextDayTemp = weeklyTemperature[day + 1];
            string NextDayForecast = weeklyForecast[day + 1];
            Console.WriteLine("Tomorrow's Weather Forecast: " + NextDayTemp + " & " + NextDayForecast);
        }

        public void PurchasingFromStore()
        {
            string purchasing = userInterface.DisplayMessage("Purchase\n1: Lemons\n2: Sugar\n3: Cups\n4: Ice cubes/n5: Done");
            int purchaseQuantity = Int32.Parse(userInterface.DisplayMessage("How many?"));
            if (purchasing == "1")
            {
                CalculateCost(purchaseQuantity, store.LemonPrice);
                inventory.LemonsInInventory = purchaseQuantity;
            }
        }

        public void CalculateCost(int quantity, double itemPrice)
        {
            double cost;
            cost = (quantity * store.LemonPrice);
        }

        //select what to purchase
        //select how much to purchase
        //add purchased crap to inventory
        //subtract cost from total player money

        //3 Purchase
        //4 Price/Quality control
        //5 Start Selling to customers
        //6 calculate EOD profits
        //repeat 3 to 6 until day = numOfDays
    }
}
