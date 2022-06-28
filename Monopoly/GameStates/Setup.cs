using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameStates
{
    class Setup : IGameState
    {
        public ConsoleKeyInfo UserInput { get; set; }

        public void Display()
        {
            Console.Clear();

            Console.WriteLine("New Game");
            Console.WriteLine("Press ESC at any time to exit");
            ChoosePlayerCount();

            //TODO:
            /*
             ADD AI PLAYERS
             ADD DIFFICULTY SETTING
             */
        }

        private void ChoosePlayerCount()
        {
            bool valid = false;

            do
            {
                Console.WriteLine("How many players? (2 - 8 players)");
                UserInput = Console.ReadKey();

                if (Char.IsDigit(UserInput.KeyChar))
                {
                    int players = (int)Char.GetNumericValue(UserInput.KeyChar);
                    valid = (players < 9 && players > 1);
                }

                if (!valid || UserInput.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine("Invalid input! Please pick between 2 - 8 players");
                }

            } while (!valid || UserInput.Key != ConsoleKey.Escape);

        }
    }
}
