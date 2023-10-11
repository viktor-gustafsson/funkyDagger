using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceUtils
{
    public static class RandomService
    {
        static Random random = new Random();
        public static int Random(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }
        public static int Random(int value)
        {
            return random.Next(value);
        }
        public static bool Chance(int value)
        {
                return (random.Next(1, 101) <= value);
        }
    }
}