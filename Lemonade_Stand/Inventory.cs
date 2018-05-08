using System;
using System.Collections.Generic;
using System.Linq;
namespace Lemonade_Stand
{
    class Inventory
    {
        public Inventory()
        {
            LemonsInInventory = new List<Lemon>();
            SugarInInventory = new List<Sugar>();
            CupsInInventory = 0;
            IcecubesInInventory = 0;
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
