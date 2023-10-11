using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;
using DungeonsOfDoom.Core.Interfaces;

namespace DungeonsOfDoom.Core.GameObjects.Creatures
{
    public class Player : Creature
    {
        int selection;
        public IPackable EquippedWeapon { get; set; }
        public IPackable EquippedArmor { get; set; }
        public IPackable ConsumedItem { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Player(string name, int health, int attackPower) : base(name, health, attackPower, "@")
        {
            
        }
        static public Player NewPlayer(string name)
        {
            return new Player(name, 100, RandomService.Random(7, 12));
        }
        
        public string PickItem(string inSelection)
        {
            string itemReturn = "You currently don't hold an item in that position";
            bool item = Int32.TryParse(inSelection, out selection);
            if (item == false)
            {
                return itemReturn;
            }
            else if (selection > BackPack.Count)
            {
                return itemReturn;
            }

            else if (item)
            {
                return ItemChecker(BackPack[selection - 1]);
            }
            else
            {
                return "You did nothing";
            }
                    
        }

        public string ItemChecker(IPackable item)
        {
            if (item.IsWeapon)
            {
                BackPack.RemoveAt(selection - 1);
                return item.ModifyStats(this, item);
            }
            else if (item.IsArmor)
            {
                BackPack.RemoveAt(selection - 1);
                return item.ModifyStats(this, item);
            }
            else if (item.IsConsumable)
            {
                if(Health == 100)
                    return $"You are att full health, you did not consume any item.";
                else
                {
                    BackPack.RemoveAt(selection - 1);
                    return item.ModifyStats(this, item);
                }
            }
            else if (item.Name == "Leprechaun")
                return $"You can't equipp {item.Name} you sick bastard!";
            else
                return "You did nothing";
        }

        public override string Fight(Creature opponent, int hitChance, int critChance, int riposteChance = 0, bool riposte = false)
        {
            if (riposte)
            {
                if (RandomService.Chance(riposteChance))
                {
                    Riposted = true;
                    opponent.Health -= (Damage) + (Damage * 3);
                    return $"Ripost an attack and counter for 3x damage! ";
                }
                Riposted = false;
                return $"Try to riposte but fail! ";
            }
            else
                return base.Fight(opponent, hitChance, critChance);
        }
    }
}

