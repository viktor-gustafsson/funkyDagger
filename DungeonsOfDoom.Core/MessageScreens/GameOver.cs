using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.GameObjects.Creatures;


namespace DungeonsOfDoom.Core.MessageScreens
{
    static class GameOver
    {
        static string gameOverASCCIPath = @"MessageScreens\GameOverMessage.txt";
        public static string GameOverASCII()
        {
            return DisplayMessage.Message(gameOverASCCIPath);
        }
        public static string GameOverScreen(Creature player)
        {
            return $"{player.Name} Have been defeated by the evil forces in the dungeon...\nBetter Luck next time...\n\nPress 'Return' to exit the game...";
        }
    }
}
