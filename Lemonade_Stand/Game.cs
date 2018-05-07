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
        Store store;
        Inventory inventory;
        Player player;
        List<Day> gameDayList;

        public int duration;
        public Game()
        {

            this.userInterface = new UserInterface();
            this.store = new Store();
            this.inventory = new Inventory();
            this.player = new Player();
            this.gameDayList = new List<Day>();
        }

        public void RunGame()
        {
            duration = userInterface.AskForDuration();
            gameDayList = GenerateDays(duration);

            for (int i = 0; i < duration; i++)
            {
                //generate weather
                Day tomorrow = gameDayList[i];
                int temperatureForTomorrow = tomorrow.PredictedTemperature;
                string forecastForTomorrow = tomorrow.PredictedForecast;
                DisplayNextDayWeather("Tomorrow's", temperatureForTomorrow, forecastForTomorrow);

                //purchase segment
                string purchasing = null;
                while (purchasing != "5")
                {
                    Console.WriteLine("Money: " + player.StartingMoney);
                    Console.WriteLine("Inventory ==> Lemons: " + inventory.TotalLemonsInInventory + " Sugar: " + inventory.TotalSugarInInventory + " Cups: " + inventory.CupsInInventory + " Ice Cubes :" + inventory.IcecubesInInventory);
                    purchasing = userInterface.PurchasingMenu();
                    if (purchasing == "5"){ break; }
                    int purchaseQuantity = PurchaseQuantity();
                    double itemCost = GetFromStore(purchasing, purchaseQuantity);
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
                    new Supply().DayPurchased = i;
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
                temperatureForTomorrow = tomorrow.ActualTemperature;
                forecastForTomorrow = tomorrow.ActualForecast;
                DisplayNextDayWeather("Today's",temperatureForTomorrow, forecastForTomorrow);

                int salesCounter = 0;
                foreach (Customer person in tomorrow.CustomerList)
                {
                    if (!SoldOut())
                    {
                        if (salesCounter % player.CupsPerPitcher == 0)
                        {
                            SetInInventory("1", -(player.LemonsPerPitcher));
                            SetInInventory("2", -(player.SugarPerPitcher));
                        }
                    }
                    else
                    {
                        break;
                    }

                    if (SoldCup(person, tomorrow) == true)
                    {
                        SetInInventory("3", -(player.IcePerCup));
                        SetInInventory("4", -1);
                        salesCounter++;
                    }
                }
                    //for every cups/pitcher, subtract ingredients from inventory (X)
                    //if SoldOut == true, end day. (X)
                    //for each customer in day, if (price < cheapnessRating) && (day.actualTemp > customer.MinTemp) then soldCup++ (X)
                    //when (salesCounter % cupsPerPitcher == 0), make new pitcher and subtract from inventory (X)

                    //get number of customers who bought and add to player money
                        //  player.DailyTotal = salesCounter* player.PricePerCup
                    //find lemons and sugar that spoiled
            }
        }

        public bool SoldCup(Customer person, Day dayInfo)
        {
            if (
                (player.PricePerCup < person.CheapnessRating ) && 
                ((person.RandomMinRange < dayInfo.ActualTemperature) && (dayInfo.ActualTemperature <= person.RandomMaxRange))
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SoldOut()
        {
            bool isSoldOut = false;
            if ((player.LemonsPerPitcher > inventory.TotalLemonsInInventory)
                || (player.SugarPerPitcher > inventory.TotalSugarInInventory)
                || (player.IcePerCup > inventory.IcecubesInInventory)
                || (player.CupsPerPitcher > inventory.CupsInInventory))
            {
                isSoldOut = true;
            }
            return isSoldOut;
        }

        public List<Day> GenerateDays(int duration)
        {
            List<Day> daysList = new List<Day>();
            for (int i = 0; i < duration; i++)
            {
                daysList.Add(new Day());
            }
            return daysList;
        }
        public void DisplayNextDayWeather(string todayOrTomorrow, int temp, string forecast)
        {
            Console.WriteLine(todayOrTomorrow + " Weather Forecast: " + temp + " & " + forecast);
        }

        public int PurchaseQuantity()
        {
            int purchaseQuantity = userInterface.PromptForQuantity();
            return purchaseQuantity;
        }

        public double GetFromStore(string itemBeingPurchased, int purchaseQuantity)
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

        public void SetInInventory(string item, int quantity)
        {
            
            if (item == "1")
            {
                if (quantity > 0)
                {
                    for (int i = 1; i <= quantity; i++)
                    {
                        inventory.LemonsInInventory.Add(new Lemon());
                    }
                }
                else
                {
                    for (int i = 1; i <= Math.Abs(quantity); i++)
                    {
                        inventory.LemonsInInventory.RemoveAt(0);
                    }
                }
            }
            else if (item == "2")
            {
                if (quantity > 0)
                {
                    for (int i = 1; i <= quantity; i++)
                    {
                        inventory.SugarInInventory.Add(new Sugar());
                    }
                }
                else
                {
                    for (int i = 1; i <= Math.Abs(quantity); i++)
                    {
                        inventory.SugarInInventory.RemoveAt(0);
                    }
                }
            }
            else if (item == "3")
            {
                inventory.CupsInInventory = (inventory.CupsInInventory + quantity);
            }
            else if (item == "4")
            {
                inventory.IcecubesInInventory = (inventory.IcecubesInInventory + quantity);
            }
            else
            {

            }
        }
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
                player.CalculateCupsPerPitcher();
            }
        }
    }
}
