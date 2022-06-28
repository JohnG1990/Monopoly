using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameStates
{
    class MainMenu : IGameState
    {
        public ConsoleKeyInfo UserInput { get; set; }

        public void Display()
        {
            Console.Clear();

            //display main menu
            Console.WriteLine("Welcome to Monpoly!");
            Console.WriteLine("Press ENTER to start new game.");
            Console.WriteLine("Press ESC to exit.");

            UserInput = Console.ReadKey();
        }
    }
}
