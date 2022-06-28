using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameStates
{
    public interface IGameState
    {
        ConsoleKeyInfo UserInput { get; set; }
        void Display();
    }
}
