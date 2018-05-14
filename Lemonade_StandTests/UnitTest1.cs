using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lemonade_Stand;

namespace Lemonade_StandTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GetFromStore_FirstExitWithCorrectInput_Pass()
        {
            Game g = new Game();
            Store s = new Store();
            double outcome = g.GetFromStore("1", 1);
            Assert.AreEqual(outcome, s.LemonPrice);
        }

        [TestMethod]
        public void GetFromStore_SecondExitWithCorrectInput_Pass()
        {
            Game g = new Game();
            Store s = new Store();
            double outcome = g.GetFromStore("2", 1);
            Assert.AreEqual(outcome, s.SugarPrice);
        }

        [TestMethod]
        public void GetFromStore_ThirdExitWithCorrectInput_Pass()
        {
            Game g = new Game();
            Store s = new Store();
            double outcome = g.GetFromStore("3", 1);
            Assert.AreEqual(outcome, s.CupsPrice);
        }
        [TestMethod]
        public void GetFromStore_FourthExitWithCorrectInput_Pass()
        {
            Game g = new Game();
            Store s = new Store();
            double outcome = g.GetFromStore("4", 1);
            Assert.AreEqual(outcome, s.IceCubePrice);
        }
        [TestMethod]
        public void GetFromStore_ElseStatementExecutedWithNoInput_LastExitPathTaken()
        {//method should not get executed with typo due to validation check loop.
            Game g = new Game();
            Store s = new Store();
            double outcome = g.GetFromStore("", 1);
            Assert.AreEqual(outcome, 0);
        }

        [TestMethod]
        public void GetFromStore_ElseStatementExecutedWithTypo_LastExitPathTaken()
        {//method should not get executed with typo due to validation check loop.
            Game g = new Game();
            Store s = new Store();
            double outcome = g.GetFromStore("a4", 1);
            Assert.AreEqual(outcome, 0);
        }

        [TestMethod]
        public void CalculateCost_PositiveNumbers_NoException()
        {
            Game g = new Game();
            double result = g.CalculateCost(1, 1);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void CalculateCost_NegativeInt_NegativeResultReturned()
        {
            Game g = new Game();
            double result = g.CalculateCost(1, -1);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void SetInInventory_OneAsInputPositiveInt_ListCountEqualsPositiveInt()
        {
            Game g = new Game();
            Human h = new Human();
            g.SetInInventory("1", 1, h);
            int listTotal = h.inventory.TotalLemonsInInventory;
            Assert.AreEqual(1, listTotal);
        }
        [TestMethod]
        public void SetInInventory_OneAsInputNegativeInt_ListCountDecreasesByGivenInt()
        {//how do i test simply with no lemons in list
            Game g = new Game();
            Human h = new Human();
            g.SetInInventory("1", -1, h);
            int listTotal = h.inventory.TotalLemonsInInventory;
            Assert.AreEqual(1, listTotal);
        }
        [TestMethod]
        public void SetInInventory_TwoAsInputPositiveInt_ListCountEqualsPositiveInt()
        {
            Game g = new Game();
            Human h = new Human();
            g.SetInInventory("2", 1, h);
            int listTotal = h.inventory.TotalSugarInInventory;
            Assert.AreEqual(1, listTotal);
        }
        

    }
}
