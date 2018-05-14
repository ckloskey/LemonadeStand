using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lemonade_Stand;

namespace Lemonade_StandTests
{
    [TestClass]
    public class WeatherTests
    {
        [TestMethod]
        public void GenerateRandomTemperature_AboveMaximum_PassUnlessParametersChanged  ()
        {
            Weather w = new Weather();
            int minTemp = 45;
            int maxTemp = 106;
            int result = w.GenerateRandomTemperature(minTemp, maxTemp);

            Assert.IsTrue(result < maxTemp);
        }
        [TestMethod]
        public void GenerateRandomTemperature_BelowMinimum_PassUnlessParametersChanged()
        {
            Weather w = new Weather();
            int minTemp = 45;
            int maxTemp = 106;
            int result = w.GenerateRandomTemperature(minTemp, maxTemp);

            Assert.IsTrue(result >= minTemp);
        }
    }
}
