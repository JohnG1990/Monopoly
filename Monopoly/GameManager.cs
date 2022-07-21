using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class GameManager
    {
        public ConsoleKeyInfo UserInput { get; set; }

        private int HouseLimit { get; }
        public int CurrentHouseCount { get; set; }

        private int HotelLimit { get; }
        public int CurrentHotelCount { get; set; }

        public Board board { get; set; }
        
        public List<Player> Players { get; set; }

        public GameManager()
        {
            HotelLimit = 12;
            HouseLimit = 32;
        }

        public bool Init()
        {
            bool result = true;

            //set up needed stuff here
            CurrentHouseCount = 0;
            CurrentHotelCount = 0;

            //board setup
            Board board = new Board();
            board.Init();

            //card setup
            return result;
        }

        public ConsoleKeyInfo DisplayMainMenu()
        {
            Console.Clear();

            //display main menu
            Console.WriteLine("Welcome to Monpoly!");
            Console.WriteLine("Press ENTER to start new game.");
            Console.WriteLine("Press ESC to exit.");

            return Console.ReadKey();
        }

        public ConsoleKeyInfo DisplaySetup()
        {
            Console.Clear();

            Console.WriteLine("New Game");
            Console.WriteLine("Press ESC at any time to exit");

            return ChoosePlayerCount();
        }

        private ConsoleKeyInfo ChoosePlayerCount()
        {
            bool valid = false;
            ConsoleKeyInfo input;

            do
            {
                Console.WriteLine("How many players? (2 - 8 players)");
                input = Console.ReadKey();

                if (Char.IsDigit(input.KeyChar))
                {
                    int players = (int)Char.GetNumericValue(input.KeyChar);
                    valid = (players < 9 && players > 1);
                }

                if (!valid && input.Key != ConsoleKey.Escape)
                {
                    Console.WriteLine("Invalid input! Please pick between 2 - 8 players");
                }

            } while (!valid && input.Key != ConsoleKey.Escape);

            return input;
        }

        public void RunGame()
        {
            bool exit = false;
            bool setupComplete = false;

            //display menu
            do
            {
                UserInput = DisplayMainMenu();
                if (UserInput.Key == ConsoleKey.Escape)
                {
                    exit = true;
                }

            } while (UserInput.Key != ConsoleKey.Enter && !exit);

            while (!setupComplete && !exit)
            {
                int players = 0;
                UserInput = DisplaySetup();

                if (UserInput.Key == ConsoleKey.Escape)
                {
                    exit = true;
                }
                else
                {
                    //setup players
                    players = (int)Char.GetNumericValue(UserInput.KeyChar);

                    for (int i = 0; i < players; i++)
                    { 
                        Players.Add(new Player(false, i)); //passing false for now until AI is set up
                    }

                    setupComplete = true;
                }              
            }

            /***********************************************************************
             *                          MAIN GAME LOOP                             *
             ***********************************************************************/
            while (!exit)
            {
                foreach (Player player in Players)
                {
                    //Display current state
                    DisplayPlayerState(player);
                    //Input
                    player.TakeTurn();
                    //Update
                    //Display new state
                }
            }
        }

        void DisplayPlayerState(Player player)
        {
            Console.WriteLine($"Player {player.PlayerNumber}/tMoney:{player.Money}");
        }
    }
}
