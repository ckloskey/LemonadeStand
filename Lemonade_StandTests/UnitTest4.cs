using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lemonade_Stand;

namespace Lemonade_StandTests
{
    [TestClass]
    public class GenerateRandomTests
    {
        [TestMethod]
        public void GetRandom_MaxValueInputs_Pass()
        {//bad test. means nothing...
            int rnd = GenerateRandom.GetRandom(-Int32.MaxValue, Int32.MaxValue);

            Assert.IsNotNull(rnd);
        }
    }
}
