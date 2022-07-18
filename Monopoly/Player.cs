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

        public ISpace CurrentSpace { get; set; }
        public List<ISpace> OwnedProperties { get; set; }

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

        bool DoAction()
        {
            bool res = false;

            if (CurrentSpace is Spaces.IOwnableSpace)
            { 
                //owned
                //find owner
                //pay owner
            }
            else if (CurrentSpace is Spaces.IUnownableSpace)
            {
                var currentSpace = CurrentSpace as Spaces.ActionSpace;
                //do action
                switch (currentSpace.SpaceAction)
                {
                    case Spaces.ActionSpace.Action.PASS_GO:
                        res = true;
                        break;
                    case Spaces.ActionSpace.Action.CHANCE_CARD:
                        res = true;
                        //Pickup chance Card
                        break;
                    case Spaces.ActionSpace.Action.COMM_CHEST:
                        res = true;
                        //Pickup community chest
                        break;
                    case Spaces.ActionSpace.Action.GO_TO_JAIL:
                        InJail = true;
                        res = true;
                        //currentspace = jail
                        break;
                    case Spaces.ActionSpace.Action.TAX:
                        if (currentSpace.Name == "Income Tax")
                        {
                            Money -= 200;
                        }
                        else
                        {
                            Money -= 100;
                        }
                        res = true;
                        break;
                    case Spaces.ActionSpace.Action.FREE_PARKING:
                        //**FALLTHROUGH**
                    case Spaces.ActionSpace.Action.JAIL:
                        //DO NOTHING
                        //JUST VISITING
                        res = true;
                        break;
                }
            }

            return res;
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
