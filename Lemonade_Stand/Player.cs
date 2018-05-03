using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand
{
    class Player
    {
        private double startingMoney;
        private double pricePerCup;
        private int lemonsPerPitcher;
        private int sugarPerPitcher;
        private int icePerCup;
        public Player()
        {
            this.startingMoney = 20;
            this.pricePerCup = 0;
            this.lemonsPerPitcher = 0;
            this.sugarPerPitcher = 0;
            this.icePerCup = 0;
        }

        public double StartingMoney
        {
            get
            {
                return startingMoney;
            }
            set
            {
                startingMoney = value;
            }
        }
        public double PricePerCup
        {
            get
            {
                return pricePerCup;
            }
            set
            {
                pricePerCup = value;
            }
        }

        public int LemonsPerPitcher
        {
            get
            {
                return lemonsPerPitcher;
            }
            set
            {
                lemonsPerPitcher = value;
            }
        }
            public int SugarPerPitcher
        {
            get
            {
                return sugarPerPitcher;
            }
            set
            {
                sugarPerPitcher = value;
            }
        }

        public int IcePerCup
        {
            get
            {
                return icePerCup;
            }
            set
            {
                icePerCup = value;
            }
        }
    }
}
