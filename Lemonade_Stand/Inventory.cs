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
            this.LemonsInInventory = new List<Lemon>();
            this.SugarInInventory = new List<Sugar>();
            this.CupsInInventory = 0;
            this.IcecubesInInventory = 0;
        }

        public List<Lemon> LemonsInInventory { get; set; }
        public List<Sugar> SugarInInventory { get; set; }
        public int CupsInInventory { get; set; }
        public int IcecubesInInventory { get; set; }
        public int TotalLemonsInInventory
        {
            get
            {
                int total = LemonsInInventory.Count();
                return total;
            }
        }
        
        public int TotalSugarInInventory
        {
            get
            {
                int total = SugarInInventory.Count();
                return total;
            }
        }
    }
}
