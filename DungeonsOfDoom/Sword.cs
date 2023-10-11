using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Sword : Weapon
    {
  
        private Sword(string name, int attackPower): base(name,"Sword",attackPower)
        {
           
        }

        static public Sword NewSword()
        {
            List<string> swordNames = new List<string>();

            swordNames.Add("Greater Sword");
            swordNames.Add("Funky Sword");
            swordNames.Add("Super Sword");
            swordNames.Add("Strong Sword");

            string name = swordNames[random.Next(swordNames.Count)];
            return new Sword(name, GenerateStats(5,12));

        }
    }
}
