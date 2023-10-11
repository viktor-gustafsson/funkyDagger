using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Items.Armor
{
    public class LeatherArmor : Armor 
    {
        private LeatherArmor(string name, int attackPower): base(name,attackPower)
        {
            
        }
        
        static public LeatherArmor NewLeatherArmor()
        {
            List<string> LeatherArmorNames = new List<string>();

            LeatherArmorNames.Add("Cheap leather armor");
            LeatherArmorNames.Add("Fancy leather armor");
            LeatherArmorNames.Add("Funky leather armor");

            string name = LeatherArmorNames[RandomService.Random(LeatherArmorNames.Count)];

            return new LeatherArmor(name, RandomService.Random(2, 5));
        }
    }
}


    
