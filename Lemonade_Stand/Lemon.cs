using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Lemon : Supply
    {
        public Lemon()
        {
            this.Expiration = DayPurchased + 2;
        }

    }
}
