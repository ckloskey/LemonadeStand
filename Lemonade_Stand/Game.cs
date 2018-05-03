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
        Player player;
        List<int> temperatureForGamePlay;
        List<string> forecastForGamePlay;

        public int duration;
        public Game()
        {
            this.weather = new Weather();
            this.userInterface = new UserInterface();
            this.store = new Store();
            this.inventory = new Inventory();
            this.player = new Player();
        }

        public void RunGame()
        {
            duration = userInterface.AskForDuration();
            for (int i = 0; i < duration; i++)
            {
                temperatureForGamePlay = weather.GenerateRandomTemperature(duration);
                forecastForGamePlay = weather.GenerateRandomForecast(duration);
                DisplayNextDayWeather(temperatureForGamePlay, forecastForGamePlay, i);

                string purchasing = null;
                do
                {
                    Console.WriteLine("Money: " + player.StartingMoney);
                    purchasing = PurchasingFromStore();
                    if (purchasing == "5"){ break; }
                    int purchaseQuantity = PurchaseQuantity();
                    double itemCost = GetFromStore(purchasing);
                    SubtractFromPlayerTotal(CalculateCost(itemCost, purchaseQuantity));
                    SetInInventory(purchasing, purchaseQuantity);
                } while (purchasing != "5") ;

                Console.WriteLine("Day: " + (i + 1));
            }
        }

        public void DisplayNextDayWeather(List<int> weeklyTemperature, List<string> weeklyForecast, int day)
        {
            int NextDayTemp = weeklyTemperature[day + 1];
            string NextDayForecast = weeklyForecast[day + 1];
            Console.WriteLine("Tomorrow's Weather Forecast: " + NextDayTemp + " & " + NextDayForecast);
        }

        public string PurchasingFromStore()
        {
            string purchasing = userInterface.PromptUserInput("Purchase\n1: Lemons\n2: Sugar\n3: Cups\n4: Ice cubes\n5: Done");
            return purchasing;
        }

        public int PurchaseQuantity()
        {
            int purchaseQuantity = Int32.Parse(userInterface.PromptUserInput("How many?"));
            return purchaseQuantity;
        }

        public double GetFromStore(string itemBeingPurchased)
        {
            double cost;
            if (itemBeingPurchased == "1")
            {
                cost = store.LemonPrice;
            }
            else if (itemBeingPurchased == "2")
            {
                cost = store.SugarPrice;
            }
            else if(itemBeingPurchased == "3")
            {
                cost = store.CupsPrice;
            }
            else if (itemBeingPurchased == "4")
            {
                cost = store.IceCubePrice;
            }
            else
            {
                return 0;
            }

            return cost;
        }

        public double CalculateCost(double itemPrice, int purchaseQuantity)
        { 
            double totalItemcost;
            totalItemcost = (purchaseQuantity * itemPrice);
            return totalItemcost;
        }

        public void SubtractFromPlayerTotal(double costOfPurchase)
        {
            if (costOfPurchase > player.StartingMoney)
            {
                Console.WriteLine("Can not purchase that amount. Please reduce quantity");
            }
            else
            {
                player.StartingMoney = (player.StartingMoney - costOfPurchase);
            }
        }

        public void SetInInventory(string itemPurchased, int purchaseQuantity)
        {
            if (itemPurchased == "1")
            {
                inventory.LemonsInInventory = (inventory.LemonsInInventory + purchaseQuantity);
            }
            else if (itemPurchased == "2")
            {
                inventory.SugarInInventory = (inventory.SugarInInventory + purchaseQuantity);
            }
            else if (itemPurchased == "3")
            {
                inventory.CupsInInventory = (inventory.CupsInInventory + purchaseQuantity);
            }
            else if (itemPurchased == "4")
            {
                inventory.IcecubesInInventory = (inventory.IcecubesInInventory + purchaseQuantity);
            }
            else
            {

            }
        }
        //select
        //get cost
        //how many
        //get cost
        //check inventory cash
            //subtract if enough
        //set in inventory

        //3 Purchase
        //4 Price/Quality control
        //5 Start Selling to customers
        //6 calculate EOD profits
        //repeat 3 to 6 until day = numOfDays
    }
}
