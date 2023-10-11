using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.GameObjects.Creatures;
using DungeonsOfDoom.Core.Interfaces;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Items.Consumables.Potion
{
    public class HealingPotion : Potion
    {
        public int Healing { get; set; }
        private HealingPotion(string name, int healing): base(name,healing)
        {
            
        }

        static public HealingPotion NewHealingPotion()
        {
            return new HealingPotion("Healing Potion", RandomService.Random(25,70));
        }
        override public string ModifyStats(Player player,IPackable item)
        {
            Healing = RandomService.Random(Power / 2, Power);

            if (player.Health + Healing > 100)
            {
                player.ConsumedItem = item;
                player.Health = 100;
                return $"You consumed{Name}, it gave you full health";
            }
            else
            {
                player.ConsumedItem = item;
                player.Health += Healing;
                return $"You consumed{Name} it gave you {Healing} health.";
            }
        }
    }
}
