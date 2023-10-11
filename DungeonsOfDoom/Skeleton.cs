using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Skeleton : Monster
    {

        private Skeleton(int health, int attackPower) : base("Skeleton", health, attackPower)
        {

        }

        static public Skeleton NewSkeleton()
        {

        return new Skeleton(GenerateStats(20,45), GenerateStats(3,7));
            
        }
    }
}
