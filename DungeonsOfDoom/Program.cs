using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core;

namespace DungeonsOfDoom
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game(15, 25, GamemodeSelect.SelectGamemode());
                game.Start();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Ooops... {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("Something did not go right...");
            }
        }
    }
}
