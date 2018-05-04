using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                //generate weather
                temperatureForGamePlay = weather.GenerateRandomTemperature(duration);
                forecastForGamePlay = weather.GenerateRandomForecast(duration);
                DisplayNextDayWeather(temperatureForGamePlay, forecastForGamePlay, i);

                //purchase segment
                string purchasing = null;
                while (purchasing != "5")
                {
                    Console.WriteLine("Money: " + player.StartingMoney);
                    Console.WriteLine("Inventory ==> Lemons: " + inventory.TotalLemonsInInventory + " Sugar: " + inventory.TotalSugarInInventory + " Cups: " + inventory.CupsInInventory + " Ice Cubes :" + inventory.IcecubesInInventory);
                    //PropertyInfo[] myPropertyInfo = inventory.GetType().GetProperties();
                    //Console.WriteLine("Inventory:");
                    //for (int j = 0; j < myPropertyInfo.Length; j++)
                    //{
                    //    Console.WriteLine(myPropertyInfo[j].Name + ": ");
                    //}
                    //PropertyInfo[] PropertyInfos = inventory.GetType().GetProperties();
                    //foreach (var info in PropertyInfos)
                    //{
                    //    var propertyName = info.Name;
                    //    var value = info.GetValue(inventory);
                    //    Console.Write(propertyName + ": " + value);
                    //}
                    purchasing = userInterface.PurchasingMenu();
                    if (purchasing == "5"){ break; }
                    int purchaseQuantity = PurchaseQuantity();
                    double itemCost = GetFromStore(purchasing);
                    SubtractFromPlayerTotal(CalculateCost(itemCost, purchaseQuantity));
                    SetInInventory(purchasing, purchaseQuantity);
                }
               string changeSetting = null;
                while (changeSetting != "5")
                {
                    //price/qualitycontrol segment
                    Console.WriteLine("Price/Quality Control ==> Price/Cup: " + player.PricePerCup + " Lemons/Pitcher: " + player.LemonsPerPitcher + " Sugar/Pitcher: " + player.SugarPerPitcher + " Ice Cubes/Cup :" + player.IcePerCup);
                    changeSetting = userInterface.QualityControlMenu();
                    if (changeSetting == "5") { break; }
                    if (changeSetting == "1")
                    {
                        double newPrice = userInterface.PromptForPrice();
                        player.PricePerCup = newPrice;
                    }
                    else
                    {
                        int newSetting = userInterface.PromptForQuantity();
                        SetPlayerControls(changeSetting, newSetting);
                    }
                }


                Console.WriteLine("Day: " + (i + 1));
            }
        }

        public void DisplayNextDayWeather(List<int> weeklyTemperature, List<string> weeklyForecast, int day)
        {
            int NextDayTemp = weeklyTemperature[day + 1];
            string NextDayForecast = weeklyForecast[day + 1];
            Console.WriteLine("Tomorrow's Weather Forecast: " + NextDayTemp + " & " + NextDayForecast);
        }

        public int PurchaseQuantity()
        {
            int purchaseQuantity = userInterface.PromptForQuantity();
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
                inventory.LemonsInInventory.Add(purchaseQuantity);
            }
            else if (itemPurchased == "2")
            {
                inventory.SugarInInventory.Add(purchaseQuantity);
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
        //get current price/quantities and display
        //select what to change
        //set userInput as property

        public void SetPlayerControls(string settingToChange, int newSetting)
        {
            if (settingToChange == "2")
            {
                player.LemonsPerPitcher = newSetting;
            }
            else if (settingToChange == "3")
            {
                player.SugarPerPitcher = newSetting;
            }
            else if (settingToChange == "4")
            {
                player.IcePerCup = newSetting;
            }
            else
            {

            }
        }

        //4 Price/Quality control
        //5 Start Selling to customers
        //6 calculate EOD profits
    }
}
