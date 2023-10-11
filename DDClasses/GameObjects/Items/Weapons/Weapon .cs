using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Weapon : Item, IPackable
    {
        public Weapon(string name, int attackPower) : base(name, attackPower)
        {
            
            IsWeapon = true;
            IsEquippable = true;
        }
        public static Weapon CreateWeapon()
        {
            switch (RandomService.Random(4))
            {
                case 0: return Sword.NewSword();
                case 1: return Axe.NewAxe();
                case 2: return Dagger.NewDagger();
                case 3: return Flail.NewFlail();
                default: return null;
            }
        }

        override public string ModifyStats(Player player, IPackable item)
        {
            if (player.EquippedWeapon != null)
            {
                player.Power -= player.EquippedWeapon.Power;
                player.BackPack.Add(player.EquippedWeapon);
                player.EquippedWeapon = null;
            }
            player.Power += item.Power;
            player.EquippedWeapon = item;

            return $"You equipped {item.Name}. Damage: {item.GetMinMax()}.";
        }
    }
}
