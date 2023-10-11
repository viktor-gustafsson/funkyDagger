using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;

namespace DungeonsOfDoom.Core.GameObjects.Items.Weapons
{
    public class Axe : Weapon
    {
        private Axe(string name, int attackPower): base(name,attackPower)
        {
            
        }
        
        static public Axe NewAxe()
        {
            List<string> AxeNames = new List<string>();

            AxeNames.Add("Greater Axe");
            AxeNames.Add("Funky Axe");
            AxeNames.Add("Super Axe");
            AxeNames.Add("Strong Axe");

            string name = AxeNames[RandomService.Random(AxeNames.Count)];

            return new Axe(name, RandomService.Random(7, 12));
        }
    }
}


    
