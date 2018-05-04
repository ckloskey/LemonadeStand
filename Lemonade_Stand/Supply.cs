using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Supply
    {
        private int dayPurchased;
        private int quantityPurchased;
        private int expiration;
        public Supply()
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

        public int Expiration
        {
            get
            {
                return expiration;
            }
            set
            {
                expiration = value;
            }
        }
    }
}
