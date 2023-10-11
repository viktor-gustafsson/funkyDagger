using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Leprechaun : Monster , IPackable
    {
        public bool IsWeapon { get; set; }
        public bool IsConsumable { get; set; }
        public bool IsArmor { get; set; }
        public bool IsEquippable { get; set; }
        static public int LeprechaunCounter { get; set; }

        private Leprechaun(int health, int attackPower) : base("Leprechaun", health, attackPower, "L")
        {
            IsWeapon = false;
            IsConsumable = false;
            IsArmor = false;
            IsEquippable = false;
            LeprechaunCounter++;
        }
        static public Leprechaun NewLeprechaun()
        {
            return new Leprechaun(RandomService.Random(20, 45), RandomService.Random(2, 5));
        }

        public string ModifyStats(Player Player, IPackable item)
        {
            throw new NotImplementedException();
        }
        public string GetMinMax()
        {
            throw new NotImplementedException();
        }
    }

}

