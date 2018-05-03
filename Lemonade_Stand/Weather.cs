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
        //hotter weather, increases customer buying probability
        //rain, cold weather, decreases probability
        private Random randomTemp;
        private Random randomForecast;
        private List<string> allForecasts;
        private List<int> temperature;
        private int minTemp;
        private int maxTemp;
        //from 45-105 degrees
        private List<string> forecast;

        //clear, cloudy, rain, humid, clear,
        public Weather()
        {
            this.temperature = new List<int>();
            this.forecast = new List<string>();
            this.allForecasts = new List<string> { "Clear", "Rain", "Cloudy", "Humid", "Clear" };
            this.randomTemp = new Random();
            this.randomForecast = new Random();
            this.minTemp = 40;
            this.maxTemp = 105;
        }

        public List<int> GenerateRandomTemperature(int duration)
        {
            int i;
            for (i = 0; i < duration; i++)
            {
                temperature.Add(randomTemp.Next(minTemp, maxTemp));
            }

            return temperature;
        }
        public List<string> GenerateRandomForecast(int duration)
        {
            int i;
            for (i = 0; i < duration; i++)
            {
                forecast.Add((allForecasts.ElementAt(randomForecast.Next(allForecasts.Count))));
            }
            return forecast;
        }

    }
}
