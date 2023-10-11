using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class HealingPotion : Potion
    {
  
        private HealingPotion(string name, int healing): base(name,"Healing Potion",healing)
        {
           
        }

        static public HealingPotion NewHealingPotion()
        {
            return new HealingPotion("Healing Potion", GenerateStats(25,70));

        }
    }
}
