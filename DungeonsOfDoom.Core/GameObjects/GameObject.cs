using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.GameObjects
{
    abstract public class GameObject
    {
        public string Name { get; set; }
        public string Symbol { get; set; }

        public GameObject(string name, string symbol = "[ ]")
        {

            Symbol = symbol;
            Name = name;
            if(Name == null || Name.Length < 3)
            {
                throw new ArgumentException("The name is too short");
            }
        }

        public GameObject(string symbol = "[ ]")
        {
            Symbol = symbol;
        }
    }
}
