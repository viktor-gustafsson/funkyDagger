using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Creature
    {
        public List<Item> EquippedItem { get; set; }
        public int X { get; set; }
        
        public int Y { get; set; }

        private Player(string name, int health, int attackPower): 
            base(name, health, attackPower,"@")
        {
            
            EquippedItem = new List<Item>();
        }



        static public Player NewPlayer(string name)
        {
            return new Player(name, 100, GenerateStats(7,12));
        }


        public void EquipItem(Item item, int selection)
        {
            if (EquippedItem.Count == 1)
            {
                AttackPower -= EquippedItem[0].Stats;
                BackPack.Add(EquippedItem[0]);
                EquippedItem.RemoveAt(0);

                EquippedItem.Add(item);
                BackPack.RemoveAt(selection);
                AttackPower += item.Stats;
            }
            else
            {
                EquippedItem.Add(item);
                BackPack.RemoveAt(selection);
                AttackPower += item.Stats;
            }
        }


       

    }
}

