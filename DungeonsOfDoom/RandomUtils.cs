using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class RandomUtils
    {
       static Random random = new Random();

        public static int Random(int max, int min = 0)
        {
            return random.Next(min, max);
        }

        public static bool RandomSpawn(int value)
        {
            if (value > RandomUtils.Random(101))
                return true;
            else
                return false;
            
        }





    }
}
