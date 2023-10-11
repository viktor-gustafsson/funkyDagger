using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : GameObject
    {
        public string Type { get; set; }
        public int Stats { get; set; }
        public Item(string name, string type, int stats,string symbol):base(symbol,name)
        {
            Type = type;
            Stats = stats;
        }
      
    }
}
