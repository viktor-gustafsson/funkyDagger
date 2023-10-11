using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class PlateArmor : Armor 
    {
        private PlateArmor(string name, int attackPower): base(name,attackPower)
        {
            
        }
        
        static public PlateArmor NewPlateArmor()
        {
            List<string> PlateArmorNames = new List<string>();

            PlateArmorNames.Add("Cheap plate armor");
            PlateArmorNames.Add("Fancy plate armor");
            PlateArmorNames.Add("Funky plate armor");

            string name = PlateArmorNames[RandomService.Random(PlateArmorNames.Count)];

            return new PlateArmor(name, RandomService.Random(5, 9));
        }
    }
}


    
