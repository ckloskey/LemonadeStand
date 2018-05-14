
namespace Lemonade_Stand
{
    public class Store
    {
        public Store()
        {
            LemonPrice = .05;
            SugarPrice = .06;
            CupsPrice = .02;
            IceCubePrice = .01;
        }
        public double LemonPrice { get; set; }
        public double SugarPrice { get; set; }
        public double CupsPrice { get; set; }
        public double IceCubePrice { get; set; }

    }
}
