using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
   static class MonsterCollection
    {

        static List<Monster> monsterList = new List<Monster>();

        public static Monster RandomMonster()
        {
            monsterList.Add(Giant.NewGiant());
            monsterList.Add(Orc.NewOrc());
            monsterList.Add(Skeleton.NewSkeleton());

            return monsterList[RandomUtils.Random(monsterList.Count-1)];

        }




    }
}
