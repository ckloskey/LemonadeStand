using System;

namespace Lemonade_Stand
{
    public static class GenerateRandom
    {
        private static Random rnd = new Random();
        public static int GetRandom(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }
}
