﻿using System;
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
                temperatureForTomorrow = tomorrow.ActualTemperature;
                forecastForTomorrow = tomorrow.ActualForecast;
                DisplayNextDayWeather("Today's",temperatureForTomorrow, forecastForTomorrow);

                while (!SoldOut())
                {
                    SetInInventory("1", -(player.LemonsPerPitcher));
                    SetInInventory("2", -(player.SugarPerPitcher));
                    
                    //for every cups/pitcher, subtract ingredients from inventory
                    //for each customer in day, if (price < cheapnessRating) && (day.actualTemp > customer.MinTemp) then soldCup++
                    //when (soldCup % cups/pitcher == 0), make new pitcher and subtract from inventory


                    //loop until customerList.Count or no more ingredients for pitcher
                    //if no more ingredients, do not sell anymore
                    //get number of customers who bought and add to player money
                    //find lemons and sugar that spoiled
                }
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

        public void SetInInventory(string item, int quantity)
        {
            if (item == "1")
            {
                inventory.LemonsInInventory.Add(quantity);
            }
            else if (item == "2")
            {
                inventory.SugarInInventory.Add(quantity);
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

        //5 Start Selling to customers
        //6 calculate EOD profits
    }
}
