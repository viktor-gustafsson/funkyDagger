using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.Interfaces;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Items.Consumables.Potion
{
    abstract public class Potion : Item, IPackable
    {
        public Potion(string name, int healing) : base(name,healing,"P")
        {
            IsConsumable = true;
        }
        public static Potion CreatePotion()
        {
            switch (RandomService.Random(1))
            {
                case 0: return HealingPotion.NewHealingPotion();
                default: return null;
            }
        }
    }
}
