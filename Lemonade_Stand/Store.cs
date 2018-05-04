using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Store
    {
        public Store()
        {
            LemonPrice = .05;
            SugarPrice = .06;
            CupsPrice = .02;
            IceCubePrice = .009;
        }
        public double LemonPrice { get; set; }
        public double SugarPrice { get; set; }
        public double CupsPrice { get; set; }
        public double IceCubePrice { get; set; }

    }
}
