using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;


namespace DungeonsOfDoom.Core.GameObjects.Items.Armor
{
    public class IronArmor : Armor 
    {
        private IronArmor(string name, int attackPower): base(name,attackPower)
        {
            
        }
        
        static public IronArmor NewIronArmor()
        {
            List<string> IronArmorNames = new List<string>();

            IronArmorNames.Add("Cheap Iron armor");
            IronArmorNames.Add("Fancy Iron armor");
            IronArmorNames.Add("Funky Iron armor");

            string name = IronArmorNames[RandomService.Random(IronArmorNames.Count)];

            return new IronArmor(name, RandomService.Random(4, 7));
        }
    }
}


    
