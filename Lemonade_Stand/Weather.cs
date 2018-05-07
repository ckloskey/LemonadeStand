using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Weather
    {
        private Random randomForecast;
        private List<string> allForecasts;

        public Weather()
        {
            this.allForecasts = new List<string> { "Clear", "Rain", "Cloudy", "Humid", "Clear", "Light Rain" };
            this.randomForecast = new Random();
        }

        public int GenerateRandomTemperature(int minTemp = 45, int maxTemp = 106)
        {
            return GenerateRandom.GetRandom(minTemp, maxTemp);
        }
        public string GenerateRandomForecast()
        {
            return allForecasts.ElementAt(randomForecast.Next(allForecasts.Count));
        }
    }
}
