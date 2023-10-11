using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Creatures.Monsters
{
    public class Skeleton : Monster
    {

        private Skeleton(int health, int attackPower) : base("Skeleton", health, attackPower)
        {

        }
        static public Skeleton NewSkeleton()
        {

        return new Skeleton(RandomService.Random(20,45), RandomService.Random(3,7));
            
        }
    }
}
