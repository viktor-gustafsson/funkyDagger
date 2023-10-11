using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtils;
using DungeonsOfDoom.Core.GameObjects;
using DungeonsOfDoom.Core.Interfaces;


namespace DungeonsOfDoom.Core.GameObjects.Creatures
{
    abstract public class Creature : GameObject, IGetMinMax
    {
        public List<IPackable> BackPack { get; set; }
        public string MinMaxReturn { get; set; }
        public bool IsAlive { get { return Health > 0; } }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Power { get; set; }
        public int DamageReduction { get; set; }
        public int Damage { get; set; }
        public bool Riposted { get; set; }

        public Creature(string name, int health, int attackPower, string symbol): base(name,symbol)
        {
            Health = health;
            Power = attackPower;
            BackPack = new List<IPackable>();
        }

        public virtual string Fight(Creature opponent, int hitChance, int critChance, int riposteChance = 0, bool riposte = false)
        {
            DamageReduction = RandomService.Random(Armor / 2, Armor);
            Damage = RandomService.Random(Power / 2, Power);
            Riposted = false;
            if (opponent.Health - Power < 0)
            {
                opponent.Power = 0;
                opponent.Health = 0;
                return null;
            }
            else if (RandomService.Chance(hitChance))
            { 
                if (Damage - opponent.DamageReduction <= 0)
                {
                    return $"All damage blocked by armor!";
                }
                else
                opponent.Health -= (Damage - opponent.DamageReduction);
                return $"Attacked for {Damage}! {opponent.DamageReduction} blocked by armor!";
            }
            else if (RandomService.Chance(critChance))
            {
                if (Damage * 2 - opponent.DamageReduction < 0)
                {
                    return $"All damage blocked by armor!";
                }
                else
                opponent.Health -= (Damage * 2 - opponent.DamageReduction);
                return $"Critically hit for {Damage} 2x! {opponent.DamageReduction} blocked by armor!";

            }
            else
                return $"Missed!";
            }

        public string GetMinMax()
        {
            int max = Power;
            int min = Power / 2;
            MinMaxReturn = min.ToString();
            MinMaxReturn += "-" + max.ToString();
            return MinMaxReturn;
        }
    }
}
