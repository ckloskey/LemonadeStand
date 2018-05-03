using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Lemon
    {
        private int dayPurchased;
        private int quantityPurchased;
        public Lemon()
        {

        }

        public int DayPurchased
        {
            get 
            {
                return dayPurchased;
            }
            set
            {
                dayPurchased = value;
            }
        }

        public int QuantityPurchased
        {
            get
            {
                return quantityPurchased;
            }
            set
            {
                quantityPurchased = value;
            }
        }
    }
}
