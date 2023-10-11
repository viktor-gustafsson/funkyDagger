using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface IGamePresenter
    {
        void DisplayGameScreen(int screen, Player player);
        void DisplayInstructions();
        void DisplayCharacterInfo(Player player);
        void DisplayInventory(Player player);
        void DisplayAbilities(Creature player);
        void DisplayGameInfo(Player player, string infoMessage);
        void DisplayMap(int worldWidth, int worldHeight, Player player, Room[,] rooms);
        void DisplayHpBar(int hp);
        void DisplayCombatSceneInfo(Creature player, Creature monster, string combatInfo);
        void DisplaySpalshScreen();
        void DisplayNameQuestion();
    }
}
