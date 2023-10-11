using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.Interfaces;
using DungeonsOfDoom.Core.GameObjects.Creatures;

namespace DungeonsOfDoom.Core.GameObjects.Items
{
    abstract public class Item : GameObject , IPackable
    {
        public int Power { get; set; }
        public bool IsWeapon { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsArmor { get; set; }
        public bool IsEquippable { get; set; }
        public string MinMaxReturn { get; set; }


        public Item(string name, int power,string symbol = "I"):base(name,symbol)
        {
            Power = power;
            IsArmor = false;
            IsWeapon = false;
            IsEquippable = false;
            IsConsumable = false;
        }

        public virtual string ModifyStats(Player player, IPackable item)
        {
            throw new NotImplementedException();
        }
        public virtual string GetMinMax()
        {
                int max = Power;
                int min = Power / 2;
                MinMaxReturn = min.ToString();
                MinMaxReturn += "-"+max.ToString();
                return MinMaxReturn;
        }
    }
}
