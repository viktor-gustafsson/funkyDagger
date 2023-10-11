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
    class StandardGamePresenter : IGamePresenter
    {
        public void DisplayGameScreen(int screen, Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            switch (screen)
            {
                case 1:
                    Console.WriteLine(GameOver.GameOverASCII());
                    Console.ResetColor();
                    MarqueeService.Marquee(GameOver.GameOverScreen(player));
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine(GameWin.GameWinASCII());
                    Console.ResetColor();
                    MarqueeService.Marquee(GameWin.GameWinScreen(player));
                    Console.ReadLine();
                    break;
            }
        }

        public void DisplaySpalshScreen()
        {
            MarqueeService.Marquee(GameStart.GameStartScreen());
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GameStart.GameStartASCII());
            Console.ResetColor();
            Console.Write("\n\n\n\nWhat is your name, hero: ");
        }
        public void DisplayNameQuestion()
        {
            Console.WriteLine("Your hero must have a name that's longer than 3 letters.");
            Console.Write("\n\n\n\nWhat is your name, hero: ");
        }

        public void DisplayInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You are the '@', Enemies are 'M', Items are 'I', Potions are 'P', Blocked rooms are '¤'.");
            Console.WriteLine("Access your inventory with 'I' and your character screen with 'C'.");
            Console.WriteLine("You move around the world with the arrow keys");
            Console.ResetColor();
        }

        public void DisplayCharacterInfo(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can leave the character screen by pressing 'Return'.");
            Console.ResetColor();
            Console.WriteLine($"Character Screen!\n");
            if (player.EquippedArmor != null && player.EquippedWeapon != null)
            {
                Console.WriteLine($"Equipped weapon Damage: {player.EquippedWeapon.GetMinMax()}");
                Console.WriteLine($"Damage with equiped weapon: {player.GetMinMax()}");
                Console.WriteLine($"Equipped Armor: {player.EquippedArmor.Power}");
            }
            else if (player.EquippedWeapon != null)
            {
                Console.WriteLine($"Equipped weapon Damage: {player.EquippedWeapon.GetMinMax()}");
                Console.WriteLine($"Damage with equiped weapon: {player.GetMinMax()}");
            }
            else if (player.EquippedArmor != null)
            {
                Console.WriteLine($"Equipped Armor: {player.EquippedArmor.Power}");
            }
            else
            {
                Console.WriteLine($"Damage: {player.GetMinMax()}");
                Console.WriteLine($"Armor: {player.Armor}");
            }

            Console.ReadLine();
        }
        public void DisplayInventoryInfo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You can leave the inventory screen by not selecting an item to equip and press 'Return'.\n");
            Console.ResetColor();
        }

        public void DisplayInventory(Player player)
        {
            DisplayInventoryInfo();
            if (player.EquippedWeapon != null)
                Console.WriteLine($"Currently equipped weapon: {player.EquippedWeapon.Name}. Damage: {player.EquippedWeapon.GetMinMax()}");
            else
                Console.WriteLine($"Currently equipped weapon: None. Attackpower: 0");
            if (player.EquippedArmor != null)
                Console.WriteLine($"Currently equipped armor: {player.EquippedArmor.Name}. Armor: {player.EquippedArmor.Power}");
            else
                Console.WriteLine($"Currently equipped armor: None. Armor: 0");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine("\n\nItems in inventory");
            for (int i = 0; i < player.BackPack.Count; i++)
            {
                if (player.BackPack[i].IsWeapon)
                    Console.Write($"{i + 1} : {player.BackPack[i].Name}. Damage: {player.BackPack[i].GetMinMax()}\n");
                else if (player.BackPack[i].IsConsumable)
                    Console.Write($"{i + 1} : {player.BackPack[i].Name}. Healing Power: {player.BackPack[i].GetMinMax()}\n");
                else if (player.BackPack[i].IsArmor)
                    Console.Write($"{i + 1} : {player.BackPack[i].Name}. Armor: {player.BackPack[i].Power}\n");

                else
                    Console.WriteLine($"{i + 1} : {player.BackPack[i].Name}");


            }
            Console.Write("Item selection: ");
        }

        public void DisplayAbilities(Creature player)
        {
            Console.WriteLine($"\n\n\n[1] Attack the monster with a normal swing (Low misschance, {player.GetMinMax()})");
            Console.WriteLine($"[2] Attack the monster with a normal swing (Low misschance, {player.GetMinMax()})");
            Console.WriteLine($"[3] Attack the monster with powerful blow (High misschance, chance to 2x damage {player.GetMinMax()})");
            Console.WriteLine($"[4] Riposte the monsters attack (Chance to nullify monster attack, 3x damage {player.GetMinMax()})");
        }

        public void DisplayGameInfo(Player player, string infoMessage)
        {
            // general game info
            Console.WriteLine();
            Console.Write($"Info: ");
            MarqueeService.Marquee(infoMessage, 15);
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Damage: {player.GetMinMax()}");
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"[{player.Symbol}]");
                        Console.ResetColor();
                    }
                    else if (item != null)
                    {
                        if(item.IsConsumable)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($"[{item.Symbol}]");
                        Console.ResetColor();
                    }
                    else if (monster != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"[{monster.Symbol}]");
                        Console.ResetColor();
                    }
                    else if (room.Blocked)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write($"[{room.BlockedSymbol}]");
                        Console.ResetColor();
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


        public void DisplayCombatSceneInfo(Creature player, Creature monster, string combatInfo)
        {
            Console.Clear();
            Console.WriteLine($"Monster Name: {monster.Name}");
            Console.WriteLine($"Monster HP: {monster.Health}");
            Console.WriteLine($"Monster Damage: {monster.GetMinMax()}");
            Console.WriteLine($"Monster Armor: {monster.Armor}");
            DisplayHpBar(monster.Health);
            Console.WriteLine($"\n\nPlayer Name: {player.Name}");
            Console.WriteLine($"Player HP: {player.Health}");
            Console.WriteLine($"Player Damage: {player.GetMinMax()}");
            Console.WriteLine($"Player Armor: {player.Armor}");
            Console.WriteLine($"Combat Info: {combatInfo}");

            DisplayHpBar(player.Health);
            DisplayAbilities(player);
        }
    }
}   
