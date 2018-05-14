using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{

    public class Sugar : Supply
    {
        public Sugar()
        {
            this.Expiration = DayPurchased + 3;
        }
    }
}