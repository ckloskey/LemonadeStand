using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Day
    {
        private string forecast;
        private int temperature;
        private Weather weather;
        List<Customer> customerList = new List<Customer>();
        public Day()
        {
            this.weather = new Weather();
            this.Forecast = this.weather.GenerateRandomForecast();
            this.Temperature = this.weather.GenerateRandomTemperature();
        }

        public string Forecast { get => forecast; set => forecast = value; }
        public int Temperature { get => temperature; set => temperature = value; }

        public List<Customer> GenerateCustomerList()
        {
            Random random = new Random();
            int dailyCustomers = random.Next(25, 125);
            for (int i = 0; i <= dailyCustomers; i++)
            {
                customerList.Add(new Customer());
            }
            return customerList;
        }
        //subtract cups/ingredients per customer
        //total sales

        //EndOfDay Class?
        //find spoiled lemons & sugar
        //calculate profit and total moo-lah
    }
}
