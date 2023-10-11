using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface IPackable : IGetMinMax
    {
        string Name { get; set; }
        int Power { get; set; }
        string Symbol { get; set; }
        bool IsWeapon { get; set; }
        bool IsArmor { get; set; }
        bool IsConsumable { get; set; }
        bool IsEquippable { get; set; }

        string ModifyStats(Player player, IPackable item);
    }
}
