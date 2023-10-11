using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Orc : Monster 
    {
        private Orc(int health, int attackPower) : base("Orc", health, attackPower)
        {
        
        }
        static public Orc NewOrc()
        {
            return new Orc(RandomService.Random(65, 80), RandomService.Random(7,10));
        }

        public override string Fight(Creature opponent, int hitChance, int critChance,int riposteChance, bool riposte = false)
        {
            if (opponent.Power < Power * 2)
                return base.Fight(opponent,hitChance,critChance);
            else
                return $"The Orc is too scared to fight!";
        }
    }
}
