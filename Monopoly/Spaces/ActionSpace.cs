using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Spaces
{
    class ActionSpace : IUnownableSpace
    {
        public enum Action
        {
            PASS_GO = 0,
            CHANCE_CARD,
            COMM_CHEST,
            GO_TO_JAIL,
            TAX,
            FREE_PARKING,
            JAIL
        }

        public string Name { get; set; }
        public Action SpaceAction { get; set; }

        public ActionSpace(string name, Action action)
        {
            Name = name;
            SpaceAction = action;
        }

        public void DoAction()
        {
            switch (SpaceAction)
            {
                case Action.PASS_GO:
                    //player.money += 200;
                    break;
                case Action.CHANCE_CARD:
                    //pick up chance card
                    break;
                case Action.COMM_CHEST:
                    //pick up comm chest card
                    break;
                case Action.GO_TO_JAIL:
                    //player.GoToJail()
                    break;
                case Action.TAX:
                    //player.money -= space.name == income tax ? 200 : 100
                    break;
                case Action.FREE_PARKING:
                    /* FALLTHROUGH */
                case Action.JAIL:
                    //do nothing
                    break;
                default:
                    break;
            }
        }
    }
}
