using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lemonade_Stand;
using System.Linq;

namespace Lemonade_StandTests
{
    [TestClass]
    public class DayTests
    {
        [TestMethod]
        public void GenerateCustomerList_CustomerListIsNotNull_IsNotNull()
        {
            Day d = new Day();
            Assert.IsNotNull(d.CustomerList);

        }
        [TestMethod]
        public void GenerateCustomerList_CustomerListHasLengthGreterThanZero_GreaterThanZero()
        {
            Day d = new Day();
            Assert.IsTrue(d.CustomerList.Count() > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateCustomerList_SelectedIndexOutOfRange_ExceptionReturned()
        {
            Day d = new Day();
            d.CustomerList.RemoveAt(index: 1000);
        }
    }
}
