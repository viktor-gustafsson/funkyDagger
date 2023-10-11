using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Creatures.Monsters
{
    public class Imp : Monster
    {

        private Imp(int health, int attackPower) : base("Imp", health, attackPower)
        {

        }

        static public Imp NewImp()
        {

        return new Imp(RandomService.Random(15,40), RandomService.Random(7,18));
            
        }
    }
}
