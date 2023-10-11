using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.GameObjects.Items.Weapons;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Creatures.Monsters
{
    public class Giant : Monster
    {
        private Giant(int health, int attackPower) : base("Giant", health, attackPower)
        {
        }
        
        static public Giant NewGiant()
        {
            return new Giant(RandomService.Random(75,100), RandomService.Random(12,20));
        }

        public override void GenerateMonsterLoot()
        {
            if (RandomService.Chance(30))
                Loot = Club.NewClub();
            else
                Loot = null;
        }
    }
}
