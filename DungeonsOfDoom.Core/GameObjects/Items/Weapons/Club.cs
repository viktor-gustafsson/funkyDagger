using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Items.Weapons
{
    public class Club : Weapon
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
