using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Items.Weapons
{
    public class Dagger : Weapon
    {
        private Dagger(string name, int attackPower): base(name,attackPower)
        {
            
        }
        
        static public Dagger NewDagger()
        {
            List<string> daggerNames = new List<string>();

            daggerNames.Add("Greater Dagger");
            daggerNames.Add("Funky Dagger");
            daggerNames.Add("Super Dagger");
            daggerNames.Add("Strong Dagger");

            string name = daggerNames[RandomService.Random(daggerNames.Count)];

            return new Dagger(name, RandomService.Random(3, 6));
        }
    }
}


    
