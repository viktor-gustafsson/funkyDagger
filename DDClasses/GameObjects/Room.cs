using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DungeonsOfDoom
{
    class Room : GameObject
    {
        public IPackable PackableObject { get; set; }
        public Monster Monster { get; set; }
        public bool Blocked { get; set; }
        public string BlockedSymbol { get; private set; } 

        public Room(string symbol = " ") : base(symbol)
        {
            BlockedSymbol = "¤";
        }
    }
}
