using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Customer
    {
       private double cheapnessRating;
       private int randomMinRange;
       private int randomMaxRange;

        public Customer()
        {
            this.randomMinRange = MinTempRangeForCustomer();
            this.randomMaxRange = MaxTempRangeForCustomer();
            this.cheapnessRating = HowCheapIsThisPerson();
        }
        public int RandomMinRange { get => randomMinRange; set => randomMinRange = value; }
        public int RandomMaxRange { get => randomMaxRange; set => randomMaxRange = value; }
        public double CheapnessRating { get => cheapnessRating; set => cheapnessRating = value; }

        private int MinTempRangeForCustomer ()
        {
            randomMinRange = GenerateRandom.GetRandom(40, 60);
            return randomMinRange;
        }
        private int MaxTempRangeForCustomer()
        {
            randomMaxRange = GenerateRandom.GetRandom(61, 125);
            return randomMaxRange;
        }

        private double HowCheapIsThisPerson()
        {
            cheapnessRating = GenerateRandom.GetRandom(1, 90);
            cheapnessRating = (cheapnessRating / 100);
            return cheapnessRating;
        }
    }
}
