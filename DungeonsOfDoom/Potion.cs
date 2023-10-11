using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Potion : Item
    {
        public Potion(string name, string type, int healing) : base(name,type,healing,"P")
        {

        }
        public int ModifyStats(Creature player)
        {
            if (player.Health + Stats > 100)
                return player.Health = 100;
            else
                return player.Health += Stats;
        }
    }

}
