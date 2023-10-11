using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.Interfaces;
using DungeonsOfDoom.Core.Presenters;

namespace DungeonsOfDoom.Core
{
    public class GamemodeSelect
    {

        public static IGamePresenter SelectGamemode()
        {
            IGamePresenter presenter = null;
            Console.Write("1: StandardPresenter \n2: AltPresenter\n3: DebugPresenter \n\nChose gamemode: ");
            switch (Console.ReadLine())
            {
                case "1": presenter = new StandardGamePresenter(); break;
                case "2": presenter = new AltGamePresenter(); break;
                case "3": presenter = new DebugGamePresenter(); break;
            }
            Console.Clear();
            return presenter;

        }

    }
}
