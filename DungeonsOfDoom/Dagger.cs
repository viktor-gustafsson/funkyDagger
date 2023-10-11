using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Dagger : Weapon
    {
        private Dagger(string name, int attackPower): base(name,"Dagger",attackPower)
        {
            
        }
        
        static public Dagger NewDagger()
        {
            List<string> daggerNames = new List<string>();

            daggerNames.Add("Greater Dagger");
            daggerNames.Add("Funky Dagger");
            daggerNames.Add("Super Dagger");
            daggerNames.Add("Strong Dagger");

            string name = daggerNames[random.Next(daggerNames.Count)];

            return new Dagger(name, GenerateStats(3,7));
        }
    }
}


    
