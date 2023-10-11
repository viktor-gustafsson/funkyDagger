using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Orc : Monster 
    {
        public bool Flee { get; private set; }
        private Orc(int health, int attackPower) : base("Orc", health, attackPower)
        {
        
        }

        static public Orc NewOrc()
        {

            return new Orc(GenerateStats(65, 80), GenerateStats(7,10));


        }
        public override string Fight(Creature opponent)
        {
            if (opponent.AttackPower < AttackPower * 2)
                return base.Fight(opponent);
            else
                return $"The Orc is too scared to fight!";
        }

    }
}
