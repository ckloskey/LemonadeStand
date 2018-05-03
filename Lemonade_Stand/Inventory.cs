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

        public Inventory()
        {
            this.lemonsInInventory = 0;
            this.sugarInInventory = 0;
            this.cupsInInventory = 0;
            this.icecubesInInventory = 0;
        }

        public int LemonsInInventory
        {
            get
            {
                return lemonsInInventory;
            }
            set
            {
                lemonsInInventory = value;
            }
        }
        public int SugarInInventory
        {
            get
            {
                return sugarInInventory;
            }
            set
            {
                sugarInInventory = value;
            }
        }
        public int CupsInInventory
        {
            get
            {
                return cupsInInventory;
            }
            set
            {
                cupsInInventory = value;
            }
        }
        public int IcecubesInInventory
        {
            get
            {
                return icecubesInInventory;
            }
            set
            {
                icecubesInInventory = value;
            }
        }
    }
}
