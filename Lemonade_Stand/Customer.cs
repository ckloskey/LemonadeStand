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

       private int cheapAssRating;
       private Random random;
       private int randomMinRange;
       private int randomMaxRange;

        public Customer()
        {
            this.random = new Random();
        }

        public int RandomMinRange
        {
            get
            {
                return randomMinRange;
            }
            set
            {
                randomMinRange = GenerateRandom(40, 60);
            }
        }
        public int RandomMaxRange
        {
            get
            {
                return randomMaxRange;
            }
            set
            {
                randomMaxRange = GenerateRandom(61, 115);
            }
        }

        public double CheapAssRating
        {
            get
            {
                return cheapAssRating;
            }
            set
            {
                cheapAssRating = GenerateRandom(1, 60);
                cheapAssRating = (cheapAssRating / 100);
            }
        }

        public int GenerateRandom(int min,int max)
        {
            return random.Next(min, max);
        }

    }
}
