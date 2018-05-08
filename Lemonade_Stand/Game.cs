using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

namespace Lemonade_Stand
{
    class Game
    {
        UserInterface userInterface;
        Store store;
        Player player;
        Player playerTwo;
        List<Day> gameDayList;
        List<Player> playerList;

        public int duration;
        public Game()
        {
            this.userInterface = new UserInterface();
            this.store = new Store();
            this.player = new Human();
            this.gameDayList = new List<Day>();
            this.playerList = new List<Player>();
        }

        public void RunGame()
        {
            playerList.Add(player);
            string numberOfPlayers = userInterface.AskForNumberOfPlayers();
            if (numberOfPlayers == "2")
            {
               string secondPlayer = DeterminePlayerType();
               if  (secondPlayer == "computer")
                {
                    playerTwo = new Computer();
                    playerList.Add(playerTwo);
                }
                else
                {
                    playerTwo = new Human();
                    playerList.Add(playerTwo);
                }
            }

            duration = userInterface.AskForDuration();
            gameDayList = GenerateDays(duration);

            //set all properties randomly
            for (int i = 0; i < duration; i++)
            {
                //generate weather
                Day tomorrow = gameDayList[i];
                int temperatureForTomorrow = tomorrow.PredictedTemperature;
                string forecastForTomorrow = tomorrow.PredictedForecast;
                DisplayNextDayWeather("Tomorrow's", temperatureForTomorrow, forecastForTomorrow);

                if (playerTwo != null)
                {
                    if (playerTwo.GetType() == typeof(Computer))
                    {
                        SetComputerInventoryProperties(temperatureForTomorrow, playerTwo);
                        SetComputerProperties(temperatureForTomorrow);
                    }
                }
                
                foreach (Human player in playerList.OfType<Human>())
                { 
                // purchase segment
                string purchasing = null;
                while (purchasing != "5")
                {
                    Console.WriteLine("Money: " + player.StartingMoney);
                    Console.WriteLine("Inventory ==> Lemons: " + player.inventory.TotalLemonsInInventory + " Sugar: " + player.inventory.TotalSugarInInventory + " Cups: " + player.inventory.CupsInInventory + " Ice Cubes: " + player.inventory.IcecubesInInventory);
                    purchasing = userInterface.PurchasingMenu();
                    if (purchasing == "5"){ break; }
                    int purchaseQuantity = PurchaseQuantity();
                    double itemCost = GetFromStore(purchasing, purchaseQuantity);

                    if (PlayerHasEnoughMoney(CalculateCost(itemCost, purchaseQuantity), player) == true)
                    {
                        SetInInventory(purchasing, purchaseQuantity, player);
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
                        player.CalculateCupsPerPitcher(player.IcePerCup);
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
                        SetPlayerControls(changeSetting, newSetting, player);
                    }
                }
                }
                Console.WriteLine("Day: " + (i + 1));
                temperatureForTomorrow = tomorrow.ActualTemperature;
                forecastForTomorrow = tomorrow.ActualForecast;
                DisplayNextDayWeather("Today's", temperatureForTomorrow, forecastForTomorrow);

                int j = 0;
                foreach (Player player in playerList)
                { 
                //Day starts and selling begins
                    int salesCounter = 0;
                    if (SoldOut(player) == false)
                    {
                        foreach (Customer person in tomorrow.CustomerList)
                        {
                            if (SoldCup(person, tomorrow) == true)
                            {
                                SetInInventory("3", -1, player);
                                SetInInventory("4", -(player.IcePerCup), player);
                                salesCounter++;
                                if (salesCounter % player.CupsPerPitcher == 0)
                                {
                                    if (SoldOut(player) == true) { break; }
                                }
                            }
                            if ((player.inventory.IcecubesInInventory <= 0)
                            || (player.inventory.CupsInInventory <= 0)) { break; }
                        }
                    }

                    j++;
                    player.DailyTotal = (salesCounter * player.PricePerCup);
                    player.RunningTotal = (player.RunningTotal + player.DailyTotal);
                    player.StartingMoney = player.StartingMoney + player.DailyTotal;
                    Console.WriteLine("Player " + j +"'s End of Day Report\n");
                    Console.WriteLine("You had " + salesCounter + " customers out of a potential " + tomorrow.CustomerList.Count());
                    Console.WriteLine("Revenue Today: " + player.DailyTotal);
                    Console.WriteLine("New Total: " + player.StartingMoney);
                    FindExpiredLemons(i, player);
                    FindExpiredSugar(i, player);
                    SetInInventory("4", -(player.inventory.IcecubesInInventory), player);
                    Console.WriteLine("The rest of your ice has melted\n");
                    
               }
            }

            foreach (Human player in playerList.OfType<Human>()) { SaveHighScore(player.StartingMoney); }
        }

        public void DisplayNextDayWeather(string todayOrTomorrow, int temp, string forecast)
        {
            Console.WriteLine(todayOrTomorrow + " Weather Forecast: " + temp + " & " + forecast);
        }
        public string DeterminePlayerType()
        {
            string secondPlayer = userInterface.AskForPlayerType();
            return secondPlayer;
        }
        public double CalculateCost(double itemPrice, int purchaseQuantity)
        {
            double totalItemcost;
            totalItemcost = (purchaseQuantity * itemPrice);
            return totalItemcost;
        }

        public void FindExpiredLemons(int day, Player player)
        {
            int difference = 0;
            int before = player.inventory.LemonsInInventory.Count();
            player.inventory.LemonsInInventory.RemoveAll(i => i.Expiration == day);
            int after = player.inventory.LemonsInInventory.Count();
            difference = before - after;
            if (difference > 0)
            {
                Console.WriteLine(difference + " of your lemons have spoiled");
            }
        }

        public void FindExpiredSugar(int day, Player player)
        {
            int difference = 0;
            int before = player.inventory.SugarInInventory.Count();
            player.inventory.SugarInInventory.RemoveAll(i => i.Expiration == day);
            int after = player.inventory.SugarInInventory.Count();
            difference = before - after;
            if (difference > 0)
            {
                Console.WriteLine(difference + " cups of Sugar have expired");
            }
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

        public void SetComputerInventoryProperties(int temperatureForTomorrow, Player comp)
        {
            
            if (PlayerHasEnoughMoney(CalculateCost(GetFromStore("4", 150), 150), comp) == true)
            {
                SetInInventory("4", 150, comp);
            }

            if (playerTwo.inventory.CupsInInventory <= 35)
            {
                if (PlayerHasEnoughMoney(CalculateCost(GetFromStore("3", 100), 100), comp) == true)
                {
                    SetInInventory("3", 100, comp);
                }
                    
            }

            if (playerTwo.inventory.TotalLemonsInInventory <= 26)
            {
                if (PlayerHasEnoughMoney(CalculateCost(GetFromStore("1", 45), 45), comp) == true)
                {
                    SetInInventory("1", 45, comp);
                }
            }

            if (playerTwo.inventory.TotalSugarInInventory <= 26)
            {
                if (PlayerHasEnoughMoney(CalculateCost(GetFromStore("1", 45), 45), comp) == true)
                {
                    SetInInventory("2", 45, comp);
                }
                
            }
        }

        public void SetComputerProperties(int temperatureForTomorrow)
        {
           double randomCompPrice = GenerateRandom.GetRandom(10, 55);
           playerTwo.PricePerCup = (randomCompPrice / 100);
           playerTwo.CalculateCupsPerPitcher(temperatureForTomorrow);
           playerTwo.LemonsPerPitcher = (GenerateRandom.GetRandom(3, 7));
           playerTwo.SugarPerPitcher = ((GenerateRandom.GetRandom(3, 7)));
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
        public bool SoldOut(Player player)
        {
            bool isSoldOut = false;
            if ((player.LemonsPerPitcher > player.inventory.TotalLemonsInInventory)
                || (player.SugarPerPitcher > player.inventory.TotalSugarInInventory)
                || (player.IcePerCup > player.inventory.IcecubesInInventory)
                || (player.CupsPerPitcher > player.inventory.CupsInInventory))
            {
                isSoldOut = true;
                return isSoldOut;
            }
                
            SetInInventory("1", -(player.LemonsPerPitcher), player);
            SetInInventory("2", -(player.SugarPerPitcher), player);
            return isSoldOut;
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

        public bool PlayerHasEnoughMoney(double costOfPurchase, Player player)
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

        public void SetInInventory(string item, int quantity, Player playerSetting)
        {
            
            if (item == "1")
            {
                if (quantity > 0)
                {
                    for (int i = 1; i <= quantity; i++)
                    {

                        playerSetting.inventory.LemonsInInventory.Add(new Lemon());
                    }
                }
                else
                {
                    for (int i = 1; i <= Math.Abs(quantity); i++)
                    {
                        playerSetting.inventory.LemonsInInventory.RemoveAt(0);
                    }
                }
            }
            else if (item == "2")
            {
                if (quantity > 0)
                {
                    for (int i = 1; i <= quantity; i++)
                    {
                        playerSetting.inventory.SugarInInventory.Add(new Sugar());
                    }
                }
                else
                {
                    for (int i = 1; i <= Math.Abs(quantity); i++)
                    {
                        playerSetting.inventory.SugarInInventory.RemoveAt(0);
                    }
                }
            }
            else if (item == "3")
            {
                playerSetting.inventory.CupsInInventory = (playerSetting.inventory.CupsInInventory + quantity);
            }
            else if (item == "4")
            {
                playerSetting.inventory.IcecubesInInventory = (playerSetting.inventory.IcecubesInInventory + quantity);
            }
            else
            {

            }
        }
        public void SetPlayerControls(string settingToChange, int newSetting, Player playerSetting)
        {
            if (settingToChange == "2")
            {
                playerSetting.LemonsPerPitcher = newSetting;
            }
            else if (settingToChange == "3")
            {
                playerSetting.SugarPerPitcher = newSetting;
            }
            else if (settingToChange == "4")
            {
                playerSetting.IcePerCup = newSetting;
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
                        catch (SqlException)
                        {
                        Console.WriteLine("Could not open database file");
                        }
                    }
                }
        }
    }
}

