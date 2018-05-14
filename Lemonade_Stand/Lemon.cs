using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    public class Lemon : Supply
    {
        public Lemon()
        {
            this.expiration = DayPurchased + 2;
        }

    }
}
