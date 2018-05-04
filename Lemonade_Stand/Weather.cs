using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Weather
    {
        //API?
        private Random randomTemp;
        private Random randomForecast;
        private List<string> allForecasts;

        private int minTemp;
        private int maxTemp;

        public Weather()
        {
            this.allForecasts = new List<string> { "Clear", "Rain", "Cloudy", "Humid", "Clear" };
            this.randomTemp = new Random();
            this.randomForecast = new Random();
            this.minTemp = 40;
            this.maxTemp = 105;
        }

        public int GenerateRandomTemperature()
        {
            return randomTemp.Next(minTemp, maxTemp);
        }
        public string GenerateRandomForecast()
        {
            return allForecasts.ElementAt(randomForecast.Next(allForecasts.Count));
        }

        

    }
}
