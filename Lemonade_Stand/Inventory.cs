using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Inventory
    {
        //what is bought and left over
        //ice melts after every day
        //lemons can spoil
        private int lemonsInInventory;
        private int sugarInInventory;
        private int cupsInInventory;
        private int icecubesInInventory;
        private int setLemonsInInventory;
        private int setSugarInInventory;
        private int setCupsInInventory;
        private int setIceCubesInInventory;

        public Inventory()
        {
            this.lemonsInInventory = 0;
            this.sugarInInventory = 0;
            this.cupsInInventory = 0;
            this.icecubesInInventory = 0;
        }

        public double LemonsInInventory
        {
            get
            {
                return lemonsInInventory;
            }
            set
            {
                lemonsInInventory = setLemonsInInventory;
            }
        }
        public double SugarInInventory
        {
            get
            {
                return sugarInInventory;
            }
            set
            {
                sugarInInventory = setSugarInInventory;
            }
        }
        public double CupsInInventory
        {
            get
            {
                return cupsInInventory;
            }
            set
            {
                cupsInInventory = setCupsInInventory;
            }
        }
        public double IcecubesInInventory
        {
            get
            {
                return icecubesInInventory;
            }
            set
            {
                icecubesInInventory = setIceCubesInInventory;
            }
        }
    }
}
