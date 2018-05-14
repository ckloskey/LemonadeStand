using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public class Supply
    {
        protected int dayPurchased;
        protected int expiration;
        public Supply()
        {
            this.dayPurchased = DayPurchased;
            this.expiration = Expiration;
        }

        public int DayPurchased { get; set; }

        public int Expiration { get; set; }
    }
}
