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
        //total amount held here
        //price/quality control?
        //price per cup
        //lemons per pitcher
        //sugar per pitcher
        //ice per cup
        public Player()
        {
            this.startingMoney = 20;
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
    }
}
