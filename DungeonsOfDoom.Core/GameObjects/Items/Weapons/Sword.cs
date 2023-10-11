using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Items.Weapons
{
    public class Sword : Weapon
    {
  
        private Sword(string name, int attackPower): base(name,attackPower)
        {
           
        }

        static public Sword NewSword()
        {
            List<string> swordNames = new List<string>();

            swordNames.Add("Greater Sword");
            swordNames.Add("Funky Sword");
            swordNames.Add("Super Sword");
            swordNames.Add("Strong Sword");

            string name = swordNames[RandomService.Random(swordNames.Count)];
            return new Sword(name, RandomService.Random(4,9));

        }
    }
}
