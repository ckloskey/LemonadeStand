using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Player
    {

        public Player()
        {
            this.StartingMoney = 20;
            this.PricePerCup = 0;
            this.LemonsPerPitcher = 0;
            this.SugarPerPitcher = 0;
            this.IcePerCup = 0;
        }

        public double StartingMoney { get; set; }
        public double PricePerCup { get; set; }

        public int LemonsPerPitcher { get; set; }
        public int SugarPerPitcher { get; set; }
        public int IcePerCup { get; set; }

        //cups per pitcher
            //if IcePerCup <= 4, then cups/pitcher = 12
            //if IcePerCup > 4, cups/pitcher = 18
    }
}
