using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;


namespace DungeonsOfDoom.Core.GameObjects.Items.Armor
{
    public class ChainArmor : Armor 
    {
        private ChainArmor(string name, int attackPower): base(name,attackPower)
        {
            
        }
        
        static public ChainArmor NewChainArmor()
        {
            List<string> ChainArmorNames = new List<string>();

            ChainArmorNames.Add("Cheap Chain armor");
            ChainArmorNames.Add("Fancy Chain armor");
            ChainArmorNames.Add("Funky Chain armor");

            string name = ChainArmorNames[RandomService.Random(ChainArmorNames.Count)];

            return new ChainArmor(name, RandomService.Random(3, 6));
        }
    }
}


    
