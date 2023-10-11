using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.GameObjects.Creatures;


namespace DungeonsOfDoom.Core.MessageScreens
{
    static class GameWin
    {
        static string gameWinASCII = @"Messagescreens\GameWinMessage.txt";
        public static string GameWinASCII()
        {
            return DisplayMessage.Message(gameWinASCII);
        }
        public static string GameWinScreen(Creature player)
        {
            return $"{player.Name} you have defeated each monster in the dungeon!\nYou are a true hero!\n\nPress 'Return' to exit the game...";
        }
    }
}
