using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lemonade_Stand;
namespace Lemonade_StandTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void CalculateCupsPerPitcher_FourOrLessTakesFirstExitPath_CupsPerPitcherSetTo12()
        {//the paremeter in the method call is useless. any paremeter would work because the conditions are based on the property of the class
            Player p = new Player();
            p.IcePerCup = 4;
            p.CalculateCupsPerPitcher(0);
            Assert.AreEqual(p.CupsPerPitcher, 12);
        }

        [TestMethod]
        public void CalculateCupsPerPitcher_FiveTakesSecondExitPath_CupsPerPitcherSetTo16()
        {//the paremeter in the method call is useless. any paremeter would work because the conditions are based on the property of the class
            Player p = new Player();

            p.IcePerCup = 5;
            p.CalculateCupsPerPitcher(0);
            Assert.AreEqual(p.CupsPerPitcher, 16);
        }
        [TestMethod]
        public void CalculateCupsPerPitcher_SixTakesSecondExitPath_CupsPerPitcherSetTo16()
        {//the paremeter in the method call is useless. any paremeter would work because the conditions are based on the property of the class
            Player p = new Player();
            p.IcePerCup = 6;
            p.CalculateCupsPerPitcher(0);
            Assert.AreEqual(p.CupsPerPitcher, 16);
        }
        [TestMethod]
        public void CalculateCupsPerPitcher_GreaterThanSixTakesLastExitPath_CupsPerPitcherSetTo20()
        {//the paremeter in the method call is useless. any paremeter would work because the conditions are based on the property of the class
            Player p = new Player();
            p.IcePerCup = 7;
            p.CalculateCupsPerPitcher(0);
            Assert.AreEqual(p.CupsPerPitcher, 20);
        }


    }
}
