using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
   static class ItemCollection
    {
        static List<Item> itemList = new List<Item>();

        public static Item RandomItem()
        {
            itemList.Add(Dagger.NewDagger());
            itemList.Add(Sword.NewSword());
            itemList.Add(Club.NewClub());
            itemList.Add(Glove.NewGlove());

            return itemList[RandomUtils.Random(itemList.Count)];

        }



    }
}
