using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            //create instance of game manager
            GameManager gameManager = new GameManager();

            //init game manager
            if(gameManager.Init())
            {
                //all ok? then run game
                gameManager.RunGame();
            }
            else
            {
                //log/display error
            }
        }
    }
}
