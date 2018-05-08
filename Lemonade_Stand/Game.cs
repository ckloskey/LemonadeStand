using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

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
                    Console.WriteLine("Inventory ==> Lemons: " + inventory.TotalLemonsInInventory + " Sugar: " + inventory.TotalSugarInInventory + " Cups: " + inventory.CupsInInventory + " Ice Cubes: " + inventory.IcecubesInInventory);
                    purchasing = userInterface.PurchasingMenu();
                    if (purchasing == "5"){ break; }
                    int purchaseQuantity = PurchaseQuantity();
                    double itemCost = GetFromStore(purchasing, purchaseQuantity);

                    if (PlayerHasEnoughMoney(CalculateCost(itemCost, purchaseQuantity)) == true)
                    {
                        SetInInventory(purchasing, purchaseQuantity);
                    }
                    
                }
                string changeSetting = null;
                while (changeSetting != "5")
                {
                    //price/qualitycontrol segment
                    Console.WriteLine("Price/Quality Control ==> Price/Cup: " + player.PricePerCup + " Lemons/Pitcher: " + player.LemonsPerPitcher + " Sugar/Pitcher: " + player.SugarPerPitcher + " Ice Cubes/Cup: " + player.IcePerCup);
                    changeSetting = userInterface.QualityControlMenu();
                    if (changeSetting == "5")
                    {
                        player.CalculateCupsPerPitcher();
                        break;
                    }
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
                DisplayNextDayWeather("Today's", temperatureForTomorrow, forecastForTomorrow);

                //Day starts and selling begins
                int salesCounter = 0;
                if (SoldOut() == false)
                {
                    foreach (Customer person in tomorrow.CustomerList)
                    {
                        if (SoldCup(person, tomorrow) == true)
                        {
                            SetInInventory("3", -1);
                            SetInInventory("4", -(player.IcePerCup));
                            salesCounter++;
                            if (salesCounter % player.CupsPerPitcher == 0)
                            {
                                if (SoldOut() == true) { break; }
                            }
                        }
                        if ((inventory.IcecubesInInventory <= 0)
                        || (inventory.CupsInInventory <= 0)) { break; }
                    }
                }

                player.DailyTotal = (salesCounter * player.PricePerCup);
                player.RunningTotal = (player.RunningTotal + player.DailyTotal);
                player.StartingMoney = player.StartingMoney + player.DailyTotal;
                Console.WriteLine("End of Day Report");
                Console.WriteLine("You had " + salesCounter + " customers out of a potential " + tomorrow.CustomerList.Count());
                Console.WriteLine("Total revenue: " + player.DailyTotal);
                FindExpiredLemons(i);
                FindExpiredSugar(i);
                SetInInventory("4", -(inventory.IcecubesInInventory));
                Console.WriteLine("The rest of your ice has melted");
            }

            SaveHighScore(player.StartingMoney);
        }

        public void FindExpiredLemons(int day)
        {
            int difference = 0;
            int before = inventory.LemonsInInventory.Count();
            inventory.LemonsInInventory.RemoveAll(i => i.Expiration == day);
            int after = inventory.LemonsInInventory.Count();
            difference = before - after;
            if (difference > 0)
            {
                Console.WriteLine(difference + " of your lemons have spoiled");
            }
        }

        public void FindExpiredSugar(int day)
        {
            int difference = 0;
            int before = inventory.SugarInInventory.Count();
            inventory.SugarInInventory.RemoveAll(i => i.Expiration == day);
            int after = inventory.SugarInInventory.Count();
            difference = before - after;
            if (difference > 0)
            {
                Console.WriteLine(difference + " cups of Sugar have expired");
            }
        }

        public bool SoldCup(Customer person, Day dayInfo)
        {
            if (
                (player.PricePerCup <= person.CheapnessRating ) && 
                ((person.RandomMinRange <= dayInfo.ActualTemperature) && (dayInfo.ActualTemperature <= person.RandomMaxRange))
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
                return isSoldOut;
            }
                
            SetInInventory("1", -(player.LemonsPerPitcher));
            SetInInventory("2", -(player.SugarPerPitcher));
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

        public bool PlayerHasEnoughMoney(double costOfPurchase)
        {
            if (costOfPurchase > player.StartingMoney)
            {
                Console.WriteLine("Can not purchase that amount. Please reduce quantity");
                return false;
            }
            else
            {
                player.StartingMoney = (player.StartingMoney - costOfPurchase);
                return true;
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

            }
        }
        public void SaveHighScore(double score)
        {
            string accessdbPath = Path.GetFullPath("Lemonade_Stand.accdb");
            Console.WriteLine("Write Name for High Score");
            string name = Console.ReadLine();
                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + accessdbPath))
                {
                    using (OleDbCommand command = conn.CreateCommand())
                    {
                    command.Connection = conn;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = @"INSERT INTO high_score(Name,Score) 
                            VALUES(@param1,@param2)";

                    command.Parameters.AddWithValue("@param1", name);
                    command.Parameters.AddWithValue("@param2", score);

                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException e)
                        {
                        Console.WriteLine("Could not open database file");
                        }
                    }
                }
        }
    }
}
