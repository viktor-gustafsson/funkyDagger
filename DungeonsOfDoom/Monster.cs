using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
   abstract class Monster : Creature
    {
        public Item Loot { get; set; }
        public Monster(string name, int health, int attackPower): 
            base(name,health,attackPower,"M")
        {
            GenerateMonsterLoot();
        }

        public void GenerateMonsterLoot()
        {
            BackPack.Add(Dagger.NewDagger());
            BackPack.Add(Sword.NewSword());

            if (random.Next(0, 101) < 90)
                Loot = BackPack[random.Next(BackPack.Count)];
            else
                Loot = null;
        }

        public static int GenerateHealth(int modifier)
        {
            return 100 - random.Next(0, 30)*modifier;
        }
        
        public virtual Item DropLoot()
        {
                return Loot;
        }
    }
}
