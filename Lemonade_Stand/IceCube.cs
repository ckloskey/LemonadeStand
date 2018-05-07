using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class IceCube : Supply
    {
        public IceCube()
        {
            this.Expiration = DayPurchased + 0;
        }
    }
}
