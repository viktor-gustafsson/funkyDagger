using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Giant : Monster
    {
        private Giant(int health, int attackPower) : base("Giant", health, attackPower)
        {
            
        }
        
        static public Giant NewGiant()
        {

        return new Giant(GenerateStats(75,100), GenerateStats(12,20));

        }

        public override Item DropLoot()
        {
                return Club.NewClub();
        }
    }
}
