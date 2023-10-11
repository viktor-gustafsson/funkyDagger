using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.GameObjects.Items;
using DungeonsOfDoom.Core.Interfaces;
using DungeonsOfDoom.Core.GameObjects.Creatures;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Items.Armor
{
    abstract public class Armor : Item, IPackable
    {
        public Armor(string name, int power) : base(name, power)
        {
            IsArmor = true;
            IsEquippable = true;
        }
        public static Armor CreateArmor()
        {
            switch (RandomService.Random(4))
            {
                case 0: return PlateArmor.NewPlateArmor();
                case 1: return IronArmor.NewIronArmor();
                case 2: return LeatherArmor.NewLeatherArmor();
                case 3: return ChainArmor.NewChainArmor();
                default: return null;
            }
        }
        override public string ModifyStats(Player player, IPackable item)
        {
            if (player.EquippedArmor != null)
            {
                player.Armor -= player.EquippedArmor.Power;
                player.BackPack.Add(player.EquippedArmor);
                player.EquippedArmor = null;
            }
            player.Armor += item.Power;
            player.EquippedArmor = item;
            return $"You equipped {item.Name}. Armor: {item.Power}.";
        }
    }
}
