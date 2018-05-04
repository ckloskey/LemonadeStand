using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Inventory
    {
        public Inventory()
        {
            this.LemonsInInventory = new List<int>();
            this.SugarInInventory = new List<int>();
            this.CupsInInventory = 0;
            this.IcecubesInInventory = 0;
        }

        public List<int> LemonsInInventory { get; set; }
        public List<int> SugarInInventory { get; set; }
        public int CupsInInventory { get; set; }
        public int IcecubesInInventory { get; set; }
        public int TotalLemonsInInventory
        {
            get
            {
                int total = LemonsInInventory.Sum();
                return total;
            }
        }
        
        public int TotalSugarInInventory
        {
            get
            {
                int total = SugarInInventory.Sum();
                return total;
            }
        }
    }
}
