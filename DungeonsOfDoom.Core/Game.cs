using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.Interfaces;
using DungeonsOfDoom.Core.GameObjects;
using DungeonsOfDoom.Core.GameObjects.Creatures;
using DungeonsOfDoom.Core.GameObjects.Creatures.Monsters;
using DungeonsOfDoom.Core.GameObjects.Items.Weapons;
using DungeonsOfDoom.Core.GameObjects.Items.Armor;
using DungeonsOfDoom.Core.GameObjects.Items.Consumables.Potion;


using ServiceUtils;

namespace DungeonsOfDoom.Core
{
    public class Game
    {
        // class variables

        string infoMessage = "";
        readonly int worldWidth;
        readonly int worldHeight;
        Room[,] rooms;
        Player player;
        ConsoleKeyInfo key;
        string playerName;
        string combatInfo;
        IGamePresenter gamePresenter;

        public Game(int worldHeight, int worldWidth, IGamePresenter gamePresenter)
        {
            // Set class state
            this.worldHeight = worldHeight;
            this.worldWidth = worldWidth;
            this.gamePresenter = gamePresenter;
        }

        public void Start()
        {
            gamePresenter.DisplaySpalshScreen();
          
            CreatePlayer();
            CreateRooms();
            // do while loop to keep the game running while player hp is above 0 and there are more than 0 monsters in the world
            do
            {
                Console.Clear();
                gamePresenter.DisplayInstructions();
                gamePresenter.DisplayMap(worldWidth, worldHeight, player, rooms);
                gamePresenter.DisplayGameInfo(player, infoMessage);
                AskForCommand();
                RoomCheck();
            }
            while (player.Health > 0 && Monster.MonsterCounter - Leprechaun.LeprechaunCounter > 0);
            if (player.Health <= 0)
            {
                gamePresenter.DisplayGameScreen(1, player);
            }
            else if (Monster.MonsterCounter - Leprechaun.LeprechaunCounter == 0)
            {
                 gamePresenter.DisplayGameScreen(2, player);
            }
        }
       
        void AskForCommand()
        {
            // Ask for user input via keyboard arrow keys
            key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                    ValidatePlayerMove(1, 0);
                        break;
                    case ConsoleKey.UpArrow:
                    ValidatePlayerMove(-1,0);
                        break;
                    case ConsoleKey.LeftArrow:
                    ValidatePlayerMove(0,-1);
                        break;
                    case ConsoleKey.RightArrow:
                    ValidatePlayerMove(0,1);
                        break;
                    case ConsoleKey.I:
                    if (player.BackPack.Count == 0)
                        infoMessage = "Your inventory is empty";
                    else
                    {
                        gamePresenter.DisplayInventory(player);
                        infoMessage = player.PickItem(Console.ReadLine());
                    }
                        break;
                    case ConsoleKey.C:
                    gamePresenter.DisplayCharacterInfo(player);
                        break;
            }
        }
        
        void ValidatePlayerMove(int playerMoveY, int playerMoveX)  
        {
            //Checks the players input for item/monster/wall-colision
            if (player.X + playerMoveX > worldWidth - 1 || player.X + playerMoveX < 0 || player.Y + playerMoveY > worldHeight - 1 || player.Y + playerMoveY < 0)
                infoMessage = "You can not pass trough walls...";
            else if (rooms[player.Y + playerMoveY, player.X + playerMoveX].Blocked)
                infoMessage = "This room is blocked, you can't go trough here!";
            else
            {
                player.X += playerMoveX;
                player.Y += playerMoveY;
                infoMessage = "";
            }
        }

        void CombatScene()
        {
            Monster monster = rooms[player.Y, player.X].Monster;
            Console.Clear();
            combatInfo = "";
            do
            {
                 gamePresenter.DisplayCombatSceneInfo(player, monster , combatInfo);

                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        //basic attack
                        combatInfo = $"YOU: {player.Fight(monster, 90, 8)} ";
                        combatInfo += $"MONSTER: {monster.Fight(player, 70, 7)}";
                        break;
                    case ConsoleKey.D2:
                        combatInfo = $"YOU: {player.Fight(monster, 35, 30)} ";
                        combatInfo += $"MONSTER: {monster.Fight(player, 30, 20)}";
                        break;
                    case ConsoleKey.D3:
                        //high miss high crit
                        combatInfo = $"YOU: {player.Fight(monster, 50, 70)} ";
                        combatInfo += $"MONSTER: {monster.Fight(player, 65, 5)}";
                        break;
                    case ConsoleKey.D4:
                        //riposte
                        combatInfo = $"YOU: {player.Fight(monster, 0, 0, 35, true)}";
                        combatInfo += $"MONSTER: {monster.Fight(player, 60, 70)}";
                        break;
                }
            }
            while (monster.IsAlive && player.IsAlive);
            CombatOver(monster);
        }
        void CombatOver(Monster monster)
        { 
            if (monster.IsAlive == false && monster.Loot != null)
            {
                infoMessage = $"{monster.Name} dropped {monster.Loot.Name}. ";
                if (monster.Loot.IsConsumable)
                {
                    infoMessage += $"Healing power: {monster.Loot.GetMinMax()}.";
                }
                else if (monster.Loot.IsWeapon)
                {
                    infoMessage += $"Damage: {monster.Loot.GetMinMax()}.";
                }
                    infoMessage += " Do you wish to pick it up? Y/N";
                    AddToBackpack(monster.DropLoot());
            }
                infoMessage = $"You have defeated {rooms[player.Y, player.X].Monster.Name}";
                rooms[player.Y, player.X].Monster = null;
                Monster.MonsterCounter--;
        }

        void RoomCheck()
        {
            // check if room contains an item or monster.
            if (rooms[player.Y, player.X].Monster != null)
                CombatScene();
            // pick up items and put in backpack
            else if (rooms[player.Y, player.X].PackableObject !=null)
            {
                    infoMessage = $"Room contains {rooms[player.Y, player.X].PackableObject.Name}. Pick it up? (Y/N)";
                    AddToBackpack(rooms[player.Y, player.X].PackableObject);
            }
        }
        void AddToBackpack(IPackable item)
        {
            // method for adding items to player backpack.
                Console.Clear();
                gamePresenter.DisplayInstructions();
                gamePresenter.DisplayMap(worldWidth, worldHeight, player, rooms);
                gamePresenter.DisplayGameInfo(player, infoMessage);
                infoMessage = "";
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                {
                    if (item.IsConsumable != false)
                    {
                        infoMessage = $"You picked up {item.Name}. Healing power: {item.GetMinMax()}";
                        player.BackPack.Add(item);
                    }
                    else if (item.IsWeapon != false)
                    {
                        infoMessage = $"You picked up {item.Name}. Damage: {item.GetMinMax()}";
                        player.BackPack.Add(item);
                    }
                    else if (item.IsArmor != false)
                    {
                        infoMessage = $"You picked up {item.Name}. Armor: {item.Power}";
                        player.BackPack.Add(item);
                    }
                    else
                    {
                        infoMessage = $"You picked up {item.Name}.";
                        player.BackPack.Add(item);
                    }
                    rooms[player.Y, player.X].PackableObject = null;
                }
        }
        
        void CreateRooms()
        {
            // Creates 2 dimensional array for rooms
            rooms = new Room[worldHeight, worldWidth];
            // Create rooms

            for (int y = 0; y < worldHeight; y++)
            {
                for (int x = 0; x < worldWidth; x++)
                {
                    rooms[y, x] = new Room();
                    if (RandomService.Chance(7) && rooms[y, x] != rooms[player.Y, player.X])
                        rooms[y, x].PackableObject = Weapon.CreateWeapon();
                    else if (RandomService.Chance(5) && rooms[y, x] != rooms[player.Y, player.X])
                        rooms[y, x].PackableObject = Armor.CreateArmor();
                    else if (RandomService.Chance(15) && rooms[y, x] != rooms[player.Y, player.X])
                        rooms[y, x].Monster = Monster.CreateMonster();
                    else if (RandomService.Chance(3) && rooms[y, x] != rooms[player.Y, player.X])
                        rooms[y, x].Monster = Giant.NewGiant();
                    else if (RandomService.Chance(3) && rooms[y, x] != rooms[player.Y, player.X])
                        rooms[y, x].PackableObject = Leprechaun.NewLeprechaun();
                    else if (RandomService.Chance(8) && rooms[y, x] != rooms[player.Y, player.X])
                        rooms[y, x].PackableObject = Potion.CreatePotion();
                    else if (RandomService.Chance(10) && rooms[y, x] != rooms[player.Y, player.X])
                        rooms[y, x].Blocked = true;
                }
            }
        }
        void CreatePlayer()
        {
            // Generate player and stats for player
            do
            {
                playerName = Console.ReadLine();
                if (playerName.Length < 3)
                {
                    gamePresenter.DisplayNameQuestion();
                }

            } while (playerName.Length < 3);
            player = Player.NewPlayer(playerName);
        }
    }
}
