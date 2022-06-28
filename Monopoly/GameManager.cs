using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class GameManager
    {
        public GameStates.GameStateManager StateManager { get; set; }

        private int HouseLimit { get; }
        public int CurrentHouseCount { get; set; }

        private int HotelLimit { get; }
        public int CurrentHotelCount { get; set; }

        //board
        //vector players

        public GameManager()
        {
            HotelLimit = 12;
            HouseLimit = 32;
        }

        public bool Init()
        {
            bool result = true;
            StateManager = new GameStates.GameStateManager();

            //set up needed stuff here
            CurrentHouseCount = 0;
            CurrentHotelCount = 0;

            //board setup
            //card setup
            return result;
        }

        public void RunGame()
        {
            bool exit = false;
            bool setupComplete = false;

            do
            {
                //display menu
                StateManager.CurrentState.Display();

                if (StateManager.CurrentState is GameStates.Setup)
                {
                    //check player count
                    int players = (int)Char.GetNumericValue(StateManager.GetUserInput().KeyChar);
                    //create players
                }

                if (StateManager.GetUserInput().Key == ConsoleKey.Enter)
                {
                    //move on to game set up
                    //transistion to game setup if choice has been made
                    StateManager.TransitionState(new GameStates.Setup());
                }
                else if (StateManager.GetUserInput().Key == ConsoleKey.Escape)
                {
                    setupComplete = true;
                    exit = true;
                }

            } while (!setupComplete);

            if (StateManager.GetUserInput().Key == ConsoleKey.Escape)
            {
                //EXIT
                exit = true;
            }
            else if (StateManager.GetUserInput().Key == ConsoleKey.Enter)
            {
                //set up game
                StateManager.CurrentState.Display();
                StateManager.GetUserInput();

            }

            while (!exit)
            {
                //Input
                //Update
                //Display
            }

            //use settings provided to set up game
        }
    }
}
