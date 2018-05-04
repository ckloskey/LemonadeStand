using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Day
    {
        private string predictedForecast;
        private int predictedTemperature;
        private string actualForecast;
        private int actualTemperature;
        private Weather predictedWeather;
        private Weather actualWeather;
        List<Customer> customerList = new List<Customer>();
        public Day()
        {
            this.predictedWeather = new Weather();
            this.predictedForecast = this.predictedWeather.GenerateRandomForecast();
            this.predictedTemperature = this.predictedWeather.GenerateRandomTemperature();
            this.actualWeather = new Weather();
            this.actualForecast = actualWeather.GenerateRandomForecast();
            this.actualTemperature = actualWeather.GenerateRandomTemperature((this.predictedTemperature - 8), (this.predictedTemperature + 8));
            this.customerList = GenerateCustomerList();
        }

        public string PredictedForecast { get => predictedForecast; set => predictedForecast = value; }
        public int PredictedTemperature { get => predictedTemperature; set => predictedTemperature = value; }
        public string ActualForecast { get => actualForecast; set => actualForecast = value; }
        public int ActualTemperature { get => actualTemperature; set => actualTemperature = value; }

        private List<Customer> GenerateCustomerList()
        {
            Random randomNumOfCustomers = new Random();
            int min = MinRangeOfCustomersPerDay();
            int max = MaxRangeOfCustomersPerDay();
            int dailyCustomers = randomNumOfCustomers.Next(min, max);
            for (int i = 0; i <= dailyCustomers; i++)
            {
                customerList.Add(new Customer());
            }
            return customerList;
        }

        private int MaxRangeOfCustomersPerDay()
        {
            int maxAmtOfCustomers = 125;
            if (this.ActualForecast == "Rain")
            {
                maxAmtOfCustomers -= 40;
            }
            else if (this.ActualForecast == "Light Rain")
            {
                maxAmtOfCustomers -= 25;
            }
            else if(this.ActualTemperature < 68)
            {
                maxAmtOfCustomers -= 40;
            }
            else
            {
                maxAmtOfCustomers = 125;
            }
            return maxAmtOfCustomers;
        }

        private int MinRangeOfCustomersPerDay()
        {
            int minAmtOfCustomers = 45;
            if (this.ActualTemperature >= 68)
            {
                minAmtOfCustomers += 35;
            }
            else
            {
                minAmtOfCustomers = 45;
            }
            return minAmtOfCustomers;
        }
    }
}
