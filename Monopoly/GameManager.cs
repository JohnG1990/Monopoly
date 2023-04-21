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
            //set up needed stuff here
            CurrentHouseCount = 0;
            CurrentHotelCount = 0;

            //board setup
            board = new Board();
            board.Init();

            //card setup
            return true;
        }

        public ConsoleKeyInfo DisplayMainMenu()
        {
            Console.Clear();

            //display main menu
            Console.WriteLine("Welcome to Monopoly!");
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
                    Players = new List<Player>();

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
                    //player.DisplayState();

                    //Any pre go actions buy house etc?

                    TakeTurn(player);

                    //Display new state
                }
            }
        }

        void TakeTurn(Player player)
        {
            int roll = player.RollDice();
            if (player.DoubleCount == 3)
            {
                player.GoToJail();
                player.MoveToSpace(board.GameBoard[10]);
            }
            else
            {
                int currentIndex = board.GameBoard.IndexOf(player.CurrentSpace); //0 based
                int newIndex = currentIndex + roll;
                if (newIndex > (board.GameBoard.Count - 1)) //Count is non 0 based so - 1 to make it so
                {
                    //player passed go
                    player.PayIn(200);
                    newIndex -= currentIndex - 1; // this will ensure you loop back round to 0
                }

                player.MoveToSpace(board.GameBoard[newIndex]);

                //space.Action || buy/auction space || pay rent
                DoAction(ref player);
            }
        }

        void DoAction(ref Player player)
        {
            if (player.CurrentSpace is Spaces.IOwnableSpace)
            {
                Spaces.IOwnableSpace currentSpace = player.CurrentSpace as Spaces.IOwnableSpace;
                bool spaceOwned = false;
                //if not owned by player
                if (!player.OwnedProperties.Contains(currentSpace))
                {
                    //loop players
                    foreach (Player pl in Players)
                    {
                        if (pl != player)
                        {
                            //loop owned properties
                            if(pl.OwnedProperties.Contains(currentSpace))
                            {
                                spaceOwned = true;
                                //if owned pay rent
                                player.PayOut(currentSpace.Rent);
                                pl.PayIn(currentSpace.Rent);
                            }
                        }
                    }
                }
                else { spaceOwned = true; }

                if (!spaceOwned)
                {
                    //buy/auction
                }

            }
            else if (player.CurrentSpace is Spaces.IUnownableSpace)
            {
                var currentSpace = player.CurrentSpace as Spaces.ActionSpace;

                switch (currentSpace.SpaceAction)
                {
                    case Spaces.ActionSpace.Action.PASS_GO:
                        break;
                    case Spaces.ActionSpace.Action.CHANCE_CARD:
                        //pick up chance card
                        break;
                    case Spaces.ActionSpace.Action.COMM_CHEST:
                        //pick up comm chest card
                        break;
                    case Spaces.ActionSpace.Action.GO_TO_JAIL:
                        player.GoToJail();
                        player.MoveToSpace(board.GameBoard[10]);
                        break;
                    case Spaces.ActionSpace.Action.TAX:
                        player.PayOut(currentSpace.Name == "Income Tax" ? 200 : 100);
                        break;
                    case Spaces.ActionSpace.Action.FREE_PARKING:
                        /* FALLTHROUGH */
                    case Spaces.ActionSpace.Action.JAIL:
                        //DO NOTHING
                        //JUST VISITING
                        break;
                }
            }
        }

        void DisplayPlayerState(ref Player player)
        {
            Console.WriteLine($"Player {player.PlayerNumber}\tMoney :{player.Money}");
            Console.WriteLine($"Current Space : {player.CurrentSpace.Name}");
        }
    }
}
