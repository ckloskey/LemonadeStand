using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Customer
    {
        //warm weather = likely to buy
        //low price = likely to buy
        //forecast has effect on probability
        //buys or doesnt buy

       private double cheapnessRating;
       private Random random;
       private int randomMinRange;
       private int randomMaxRange;

        public Customer()
        {
            this.random = new Random();
            this.randomMinRange = MinTempRangeForCustomer();
            this.randomMaxRange = MaxTempRangeForCustomer();
            this.cheapnessRating = HowCheapIsThisPerson();
        }
        public int RandomMinRange { get => randomMinRange; set => randomMinRange = value; }
        public int RandomMaxRange { get => randomMaxRange; set => randomMaxRange = value; }
        public double CheapnessRating { get => cheapnessRating; set => cheapnessRating = value; }
        
        private int MinTempRangeForCustomer ()
        {
            randomMinRange = GenerateRandom(40, 60);
            return randomMinRange;
        }
        private int MaxTempRangeForCustomer()
        {
            randomMaxRange = GenerateRandom(61, 116);
            return randomMaxRange;
        }

        private double HowCheapIsThisPerson()
        {
            cheapnessRating = GenerateRandom(1, 90);
            cheapnessRating = (cheapnessRating / 100);
            return cheapnessRating;
        }
        private int GenerateRandom(int min,int max)
        {
            return random.Next(min, max);
        }

    }
}
