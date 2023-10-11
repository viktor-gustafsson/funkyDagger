using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Club : Weapon
    {
        private Club(string name, int attackPower): base(name,attackPower)
        {
           
        }

        static public Club NewClub()
        {
            return new Club("Great Club", RandomService.Random(8,15));
        }
    }
}
