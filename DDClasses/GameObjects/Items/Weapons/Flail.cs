using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Flail : Weapon
    {
        private Flail(string name, int attackPower): base(name,attackPower)
        {
            
        }
        
        static public Flail NewFlail()
        {
            List<string> FlailNames = new List<string>();

            FlailNames.Add("Greater Flail");
            FlailNames.Add("Funky Flail");
            FlailNames.Add("Super Flail");
            FlailNames.Add("Strong Flail");

            string name = FlailNames[RandomService.Random(FlailNames.Count)];

            return new Flail(name, RandomService.Random(5, 13));
        }
    }
}


    
