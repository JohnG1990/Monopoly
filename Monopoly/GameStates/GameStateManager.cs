using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameStates
{
    class GameStateManager
    {
        public IGameState CurrentState { get; set; }

        public GameStateManager()
        {
            CurrentState = new MainMenu();
        }

        public void TransitionState(IGameState newState)
        {
            if (CurrentState != newState)
            {
                CurrentState = newState;
            }
        }

        public ConsoleKeyInfo GetUserInput()
        {
            return CurrentState.UserInput;
        }
    }
}
