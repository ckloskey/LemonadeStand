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
            this.CupsPerPitcher = 0;
            this.DailyTotal = 0;
            this.RunningTotal = 0;
        }

        public double StartingMoney { get; set; }
        public double PricePerCup { get; set; }
        public int LemonsPerPitcher { get; set; }
        public int SugarPerPitcher { get; set; }
        public int IcePerCup { get; set; }
        public int CupsPerPitcher { get; set; }
        public double DailyTotal { get; set; }
        public double RunningTotal { get; set; }
        public void CalculateCupsPerPitcher()
        {
            if (this.IcePerCup <= 4)
            {
                this.CupsPerPitcher = 12;
            }else if(this.IcePerCup == 5 || this.IcePerCup == 6)
            {
                this.CupsPerPitcher = 16;
            }
            else
            {
                this.CupsPerPitcher = 20;
            }
        }
    }
}
