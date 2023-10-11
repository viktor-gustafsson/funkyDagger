using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.GameObjects.Creatures;
using DungeonsOfDoom.Core.GameObjects.Creatures.Monsters;
using DungeonsOfDoom.Core.Interfaces;
using DungeonsOfDoom.Core.GameObjects;
using DungeonsOfDoom.Core.MessageScreens;
using ServiceUtils;

namespace DungeonsOfDoom.Core.Presenters
{
    class AltGamePresenter : IGamePresenter
    {
        public void DisplayConsumableInventory(Player player)
        {

        }
        public  void DisplayGameScreen(int screen, Player player)
        {
            Console.Clear();
            switch (screen)
            {
            
                case 1:
                    Console.WriteLine(GameOver.GameOverASCII());
                    MarqueeService.Marquee(GameOver.GameOverScreen(player));
                    Console.ReadLine();
                    break;
                case 2:
                    
                    Console.WriteLine(GameWin.GameWinASCII());
                    MarqueeService.Marquee(GameWin.GameWinScreen(player));
                    Console.ReadLine();
                    break;
            }

        }

        public void DisplaySpalshScreen()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            MarqueeService.Marquee(GameStart.GameStartScreen());
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine(GameStart.GameStartASCII());
            Console.Write("\n\n\n\nWhat is your name, hero?");
        }
        public void DisplayNameQuestion()
        {
            Console.WriteLine("Your hero must have a name that's longer than 3 letters.");
            Console.Write("\n\n\n\nWhat is your name, hero: ");
        }

        public void DisplayInstructions()
        {
            
            Console.WriteLine($"You are the '@', Enemies are 'M', Items are 'I', Potions are 'P', Blocked rooms are '¤'.");
            Console.WriteLine("Access your inventory with 'I' and your character screen with 'C'.");
            Console.WriteLine("You move around the world with the arrow keys");
            
        }

        public void DisplayCharacterInfo(Player player)
        {
            Console.Clear();
            Console.WriteLine("You can leave the character screen by pressing 'Return'.");
            
            Console.WriteLine($"Character Screen!\n");
            if (player.EquippedWeapon != null)
            {
                Console.WriteLine($"Player base attackpower: {player.Power - player.EquippedWeapon.Power}");
                Console.WriteLine($"Equipped weapon attackpower: {player.EquippedWeapon.Power}");
                Console.WriteLine($"Attackpower with equiped weapon: {player.Power}");
            }
            else
                Console.WriteLine($"Player base attackpower: {player.Power}");
            Console.ReadLine();
        }

        public void DisplayInventory(Player player)
        {
            Console.Clear();
            Console.WriteLine("You can leave the inventory screen by not selecting an item to equip and press 'Return'.\n");
            
            if (player.EquippedWeapon != null)
                Console.WriteLine($"Currently equipped weapon: {player.EquippedWeapon.Name}, Attackpower: {player.EquippedWeapon.Power}");
            else
                Console.WriteLine($"Currently equipped weapon: None, Attackpower: 0");
            Console.WriteLine("\n\nItems in inventory");
            for (int i = 0; i < player.BackPack.Count; i++)
            {
                if (player.BackPack[i] != null)
                    Console.Write($"{i + 1} : {player.BackPack[i].Name} Attack Power: {player.BackPack[i].Power}\n");
            }
            Console.Write("Equip selection: ");
        }

        public void DisplayAbilities(Creature player)
        {
            Console.WriteLine($"\n\n\n[1] Attack the monster with a normal swing (Low misschance, {player.Power / 2}-{player.Power})");
            Console.WriteLine($"[2] Attack the monster with a normal swing (Low misschance, {player.Power / 2}-{player.Power})");
            Console.WriteLine($"[3] Attack the monster with powerful blow (High misschance, chance to 2x damage {player.Power / 2}-{player.Power})");
            Console.WriteLine($"[4] Riposte the monsters attack (Chance to nullify monster attack, 3x damage {player.Power / 2}-{player.Power})");
        }

        public void DisplayGameInfo(Player player, string infoMessage)
        {
            // general game info
            Console.WriteLine();
            Console.Write($"Info: ");
            MarqueeService.Marquee(infoMessage, 15);
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            if (player.EquippedWeapon == null)
                Console.WriteLine($"Equipped weapon: None");
            else
                Console.WriteLine($"Equipped weapon: {player.EquippedWeapon.Name}. Attackpower: {player.EquippedWeapon.Power}");
            Console.Write($"Items in Backpack: {player.BackPack.Count}");
            Console.WriteLine("\nEnter movement:");
        }

        public void DisplayMap(int worldWidth, int worldHeight, Player player, Room[,] rooms)
        {
            // Draw out world map and place correct symbol depending on content of room.
            for (int y = 0; y < worldHeight; y++)
            {
                Console.WriteLine();
                for (int x = 0; x < worldWidth; x++)
                {
                    Room room = rooms[y, x];
                    IPackable item = room.PackableObject;
                    Monster monster = room.Monster;
                    if (player.X == x && player.Y == y)
                    {
                        Console.Write($"[{player.Symbol}]");
                        
                    }
                    else if (item != null)
                    {
                        Console.Write($"[{item.Symbol}]");
                        
                    }
                    else if (monster != null)
                    {
                        Console.Write($"[{monster.Symbol}]");
                        
                    }
                    else if (room.Blocked)
                    {
                        Console.Write($"[{room.BlockedSymbol}]");
                        
                    }
                    else
                        Console.Write($"[{room.Symbol}]");
                }
            }
        }



        public void DisplayHpBar(int hp)
        {
            string[] bars = { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|" };

            for (int i = 0; i < hp / 10; i++)
            {
                Console.Write(bars[i]);
            }
        }


        public void DisplayCombatSceneInfo(Creature player, Creature monster, string combatInfo )
        {
            Console.Clear();
            Console.WriteLine($"Monster Name: {monster.Name}");
            Console.WriteLine($"Monster HP: {monster.Health}");
            Console.WriteLine($"Monster AP: {monster.Power}");
            DisplayHpBar(monster.Health);
            Console.WriteLine($"\n\nPlayer Name: {player.Name}");
            Console.WriteLine($"Player HP: {player.Health}");
            Console.WriteLine($"Player AP: {player.Power}");
            Console.WriteLine($"Combat info: {combatInfo}");

            DisplayHpBar(player.Health);
            DisplayAbilities(player);
        }
    }
}   
