using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 GO
 BROWN      -   Old Kent Road
                Comm Chest
 BROWN      -   Whitechapel Road
                Income Tax
 STATION    -   Kings Cross
 LBLUE      -   The Angel Islington
                Chance
 LBLUE      -   Euston Road
 LBLUE      -   Pentonville Road
                Jail
 PINK       -   Pall Mall
 UTILITY    -   Electric Company
 PINK       -   Whitehall
 PINK       -   Northumberland Avenue
 STATION    -   Marylebone Station
 ORANGE     -   Bow Street
                Comm Chest
 ORANGE     -   Marlborough Street
 ORANGE     -   Vine Street
                Free Parking
 RED        -   The Strand
                Chance
 RED        -   Fleet Street
 RED        -   Trafalgar Square
 STATION    -   Fenchurch St Station
 YELLOW     -   Leicester Square
 YELLOW     -   Coventry Street
 UTILITY    -   Water Works
 YELLOW     -   Piccadilly
                Go To Jail
 GREEN      -   Regent Street
 GREEN      -   Oxford Street
                Comm Chest
 GREEN      -   Bond Street
 STATION    -   Liverpool Street Station
                Chance
 DARKBLUE   -   Park Lane
                Super Tax
 DARKBLUE   -   Mayfair
     */
namespace Monopoly
{
    class Board
    {
        List<ISpace> board;

        public Board() {}
        public void Init()
        {
            board = new List<ISpace>();
            CreateBoard();
        }

        public void CreateBoard()
        {
            //SIDE 1
            board.Add(new Spaces.ActionSpace("Go", Spaces.ActionSpace.Action.PASS_GO));
            board.Add(new Spaces.PropertySpace("Old Kent Road", 60, Spaces.PropertySpace.PropertyColour.BROWN));
            board.Add(new Spaces.ActionSpace("Community Chest", Spaces.ActionSpace.Action.COMM_CHEST));
            board.Add(new Spaces.PropertySpace("WhiteChapel Road", 60, Spaces.PropertySpace.PropertyColour.BROWN));
            board.Add(new Spaces.ActionSpace("Income Tax", Spaces.ActionSpace.Action.TAX));
            board.Add(new Spaces.StationSpace("Kings Cross Station", 200));
            board.Add(new Spaces.PropertySpace("The Angel Islington", 100, Spaces.PropertySpace.PropertyColour.LIGHT_BLUE));
            board.Add(new Spaces.ActionSpace("Chance", Spaces.ActionSpace.Action.CHANCE_CARD));
            board.Add(new Spaces.PropertySpace("Euston Road", 100, Spaces.PropertySpace.PropertyColour.LIGHT_BLUE));
            board.Add(new Spaces.PropertySpace("Pentonville Road", 120, Spaces.PropertySpace.PropertyColour.LIGHT_BLUE));
            
            //SIDE 2
            board.Add(new Spaces.ActionSpace("Jail", Spaces.ActionSpace.Action.JAIL));
            board.Add(new Spaces.PropertySpace("Pall Mall", 140, Spaces.PropertySpace.PropertyColour.PINK));
            board.Add(new Spaces.UtilitySpace("Electric Company", 150));
            board.Add(new Spaces.PropertySpace("Whitehall", 140, Spaces.PropertySpace.PropertyColour.PINK));
            board.Add(new Spaces.PropertySpace("Northumberland Avenue", 160, Spaces.PropertySpace.PropertyColour.PINK));
            board.Add(new Spaces.StationSpace("Marylebone Station", 200));
            board.Add(new Spaces.PropertySpace("Bow Street", 180, Spaces.PropertySpace.PropertyColour.ORANGE));
            board.Add(new Spaces.ActionSpace("Community Chest", Spaces.ActionSpace.Action.COMM_CHEST));
            board.Add(new Spaces.PropertySpace("Marlborough Street", 180, Spaces.PropertySpace.PropertyColour.ORANGE));
            board.Add(new Spaces.PropertySpace("Vine Street", 200, Spaces.PropertySpace.PropertyColour.ORANGE));

            //SIDE 3
            board.Add(new Spaces.ActionSpace("Free Parking", Spaces.ActionSpace.Action.FREE_PARKING));
            board.Add(new Spaces.PropertySpace("The Strand", 220, Spaces.PropertySpace.PropertyColour.RED));
            board.Add(new Spaces.ActionSpace("Chance", Spaces.ActionSpace.Action.CHANCE_CARD));
            board.Add(new Spaces.PropertySpace("Fleet Street", 220, Spaces.PropertySpace.PropertyColour.RED));
            board.Add(new Spaces.PropertySpace("Trafalgar Square", 240, Spaces.PropertySpace.PropertyColour.RED));
            board.Add(new Spaces.StationSpace("Fenchurch St Station", 200));
            board.Add(new Spaces.PropertySpace("Leicester Square", 260, Spaces.PropertySpace.PropertyColour.YELLOW));
            board.Add(new Spaces.PropertySpace("Coventry Street", 260, Spaces.PropertySpace.PropertyColour.YELLOW));
            board.Add(new Spaces.UtilitySpace("Water Works", 150));
            board.Add(new Spaces.PropertySpace("Picadilly", 280, Spaces.PropertySpace.PropertyColour.YELLOW));

            //SIDE 4
            board.Add(new Spaces.ActionSpace("Go To Jail", Spaces.ActionSpace.Action.GO_TO_JAIL));
            board.Add(new Spaces.PropertySpace("Regent Street", 300, Spaces.PropertySpace.PropertyColour.GREEN));
            board.Add(new Spaces.PropertySpace("Oxford Street", 300, Spaces.PropertySpace.PropertyColour.GREEN));
            board.Add(new Spaces.ActionSpace("Community Chest", Spaces.ActionSpace.Action.COMM_CHEST));
            board.Add(new Spaces.PropertySpace("Bond Street", 320, Spaces.PropertySpace.PropertyColour.GREEN));
            board.Add(new Spaces.StationSpace("Liverpool Street Station", 200));
            board.Add(new Spaces.ActionSpace("Chance", Spaces.ActionSpace.Action.CHANCE_CARD));
            board.Add(new Spaces.PropertySpace("Park Lane", 350, Spaces.PropertySpace.PropertyColour.DARK_BLUE));
            board.Add(new Spaces.ActionSpace("Super Tax", Spaces.ActionSpace.Action.TAX));
            board.Add(new Spaces.PropertySpace("Mayfair", 400, Spaces.PropertySpace.PropertyColour.DARK_BLUE));
        }
    }
}
