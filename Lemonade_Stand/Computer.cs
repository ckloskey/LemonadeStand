
namespace Lemonade_Stand
{
    class Computer : Player
    {
        public override void CalculateCupsPerPitcher(int temperatureForTomorrow)
        {
            if (temperatureForTomorrow < 60)
            {
                this.IcePerCup = 4;
                this.CupsPerPitcher = 12;
            }else if (temperatureForTomorrow < 80)
            {
                this.IcePerCup = 6;
                this.CupsPerPitcher = 16;
            }
            else
            {
                this.IcePerCup = 5;
                this.CupsPerPitcher = 16;
            }
                

        }
    }

}
