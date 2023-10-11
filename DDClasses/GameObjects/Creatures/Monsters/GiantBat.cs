using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class GiantBat : Monster
    {

        private GiantBat(int health, int attackPower) : base("Giant Bat", health, attackPower)
        {

        }
        public override void GenerateMonsterLoot()
        {
            if (RandomService.Chance(20))
                base.Loot = Axe.NewAxe();
            else
                base.Loot = null;
        }
        static public GiantBat NewGiantBat()
        {

        return new GiantBat(RandomService.Random(20,35), RandomService.Random(5,12));
            
        }
    }
}
