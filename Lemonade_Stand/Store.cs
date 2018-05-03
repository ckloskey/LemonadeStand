using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Store
    {
        //cups 25, 50, 100
        //lemons 10, 30, 75
        //sugar 8, 20, 48
        //ice cubes 100, 250, 500
        private double lemonPrice;
        private double sugarPrice;
        private double cupsPrice;
        private double iceCubePrice;

        public Store()
        {
            lemonPrice = .06;
            sugarPrice = .08;
            cupsPrice = .04;
            iceCubePrice = .07;
        }
        public double LemonPrice
        {
            get
            {
                return lemonPrice;
            }
            set
            {
                lemonPrice = value;
            }
        }
        public double SugarPrice
        {
            get
            {
                return sugarPrice;
            }
            set
            {
                sugarPrice = value;
            }
        }
        public double CupsPrice
        {
            get
            {
                return cupsPrice;
            }
            set
            {
                cupsPrice = value;
            }
        }
        public double IceCubePrice
        {
            get
            {
                return iceCubePrice;
            }
            set
            {
                iceCubePrice = value;
            }
        }

    }
}
