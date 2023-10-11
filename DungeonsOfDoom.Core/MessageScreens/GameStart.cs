using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom.Core.MessageScreens
{
    static class GameStart
    {
        static string gameStartASCII = @"MessageScreens\WelcomeMessage.txt";
        public static string GameStartASCII()
        {
            return DisplayMessage.Message(gameStartASCII);
        }
        public static string GameStartScreen()
        {
            return $"You  have been locked into the damp dungeon known only as 'The Dungeon...'\nDefeat all enemies that you encounter and search the dungeon for loot to aid your battle and escape.\nGood luck and remember, in the dungeon no one can hear your scream...\n\n\nPress 'Return' to start...";
        }
    }
}
