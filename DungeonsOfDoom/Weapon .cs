using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Weapon : Item
    {
        public Weapon(string name, string type, int attackPower) : base(name,type,attackPower,"I")
        {
            

        }
    }

}
