using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Creature : GameObject
    {
        public List<Item> BackPack { get; set; }
        public bool IsAlive { get { return Health > 0; } }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public Creature(string name, int health, int attackPower, string symbol): base(symbol,name)
        {
            Health = health;
            AttackPower = attackPower;
            BackPack = new List<Item>();
        }

        public virtual string Fight(Creature opponent)
        {
            if (opponent.Health - AttackPower < 0)
            {
                opponent.AttackPower = 0;
                opponent.Health = 0;
                return null;
            }
            else
            {
                opponent.Health -= AttackPower;
                return $"{Name} Attacked {opponent.Name}!";
            }
        }

        


    }
       
    

}
