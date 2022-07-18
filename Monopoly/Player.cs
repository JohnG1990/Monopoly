using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Player
    {
        public int Money { get; set; } = 1500;
        public bool InJail { get; set; } = false;
        //public Space* CurrentSpace { get; set; }
        //public List<Space*> OwnedProperties { get; set; }

        public Player()
        {
        }

        public void TakeTurn()
        {
            //roll dice
            int diceRoll = Dice.RollDice();
            //move position
            //CurrentSpace = Board
            //action -
                /*
                landed on a property space?
                    YES
                    - owned property?
                        YES
                        - owned by you
                            YES
                            - buy house/hotel
                            NO
                            - pay rent
                        NO
                        - buy space?
                            YES
                            - buySpace()
                            NO
                            - Auction()
                landed on go to jail
                    - gotojail()
                landed on taxspace
                    - pay tax
                landed on freeparking
                    -do nothing...for now      
                */
        }
        /*
	* Paying out
	* Receiving money
	* Rolling dice
	* Buying space/house/hotel
	* Move
	* Collect when passing go
         */
    }
}
