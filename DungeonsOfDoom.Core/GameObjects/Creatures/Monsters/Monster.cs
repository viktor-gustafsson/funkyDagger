using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.Interfaces;
using DungeonsOfDoom.Core.GameObjects.Items.Weapons;
using DungeonsOfDoom.Core.GameObjects.Items.Consumables.Potion;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Creatures.Monsters
{
   abstract public class Monster : Creature 
    {
        public IPackable Loot { get; protected set; }
        public static int MonsterCounter { get; set; }
        public Monster(string name, int health, int attackPower, string symbol = "M") : base(name,health,attackPower, symbol)
        {
            MonsterCounter++;
            GenerateMonsterLoot();
        }

       public static Monster CreateMonster()
        {
            switch (RandomService.Random(4))
            {
                case 0: return Orc.NewOrc();
                case 1: return Skeleton.NewSkeleton();
                case 2: return GiantBat.NewGiantBat();
                case 3: return Imp.NewImp();

                default: return null;
            }
        }
        public override string Fight(Creature opponent, int hitChance, int critChance, int riposteChance = 0, bool riposte = false)
        {
             if (opponent.Riposted)
                return null;
             else
                return base.Fight(opponent, hitChance, critChance, riposteChance, riposte);
        }
        public virtual void GenerateMonsterLoot()
        {
            BackPack.Add(Dagger.NewDagger());
            BackPack.Add(Sword.NewSword());
            BackPack.Add(HealingPotion.NewHealingPotion());

            if (RandomService.Chance(25))
                Loot = BackPack[RandomService.Random(BackPack.Count)];
            else
                Loot = null;
        }
        public virtual IPackable DropLoot()
        {
            return Loot;
        }
    }
}
