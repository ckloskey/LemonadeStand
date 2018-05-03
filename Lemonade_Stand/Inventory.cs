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
        private List<int> lemonsInInventory;
        private List<int> sugarInInventory;
        private int cupsInInventory;
        private int icecubesInInventory;

        public Inventory()
        {
            this.lemonsInInventory = new List<int>();
            this.sugarInInventory = new List<int>();
            this.cupsInInventory = 0;
            this.icecubesInInventory = 0;
        }

        public List<int> LemonsInInventory
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
        public int TotalLemonsInInventory
        {
            get
            {
                int total = lemonsInInventory.Sum();
                return total;
            }
        }
        public List<int> SugarInInventory
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

        public int TotalSugarInInventory
        {
            get
            {
                int total = sugarInInventory.Sum();
                return total;
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
