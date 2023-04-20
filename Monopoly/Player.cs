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
        public List<Spaces.IOwnableSpace> OwnedProperties { get; set; }
        public bool AIPlayer { get; set; }
        public int PlayerNumber { get; set; }
        public int DoubleCount { get; set; }

        public Player(bool aiPlayer, int playerNumber)
        {
            PlayerNumber = playerNumber;
            AIPlayer = aiPlayer;
            OwnedProperties = new List<Spaces.IOwnableSpace>();
        }

        public void PayOut(int amount)
        {
            Money -= amount;
        }

        public void PayIn(int amount)
        {
            Money += amount;
        }

        public int RollDice()
        {
            int roll1 = Dice.RollDice();
            int roll2 = Dice.RollDice();
            int totalRoll = roll1 + roll2;

            if (roll1 == roll2)
            {
                DoubleCount++;
            }
            else
            {
                DoubleCount = 0;
            }

            return totalRoll;
        }

        void BuySpace(ref Spaces.IOwnableSpace space)
        {
            PayOut(space.Price);
            OwnedProperties.Add(space);
        }

        void BuyHouse(ref Spaces.PropertySpace space)
        {
            PayOut(space.HousePrice);
            space.AddHouse();
        }
        void BuyHotel(ref Spaces.PropertySpace space)
        {
            PayOut(space.HousePrice);
            space.AddHotel();
        }
        public void MoveToSpace(ISpace space)
        {
            CurrentSpace = space;
        }
        public void GoToJail()
        {
            InJail = true;
        }
        public void MortgageProperty(ref Spaces.PropertySpace space)
        {
            if (!space.HasBuildingsOn() && !space.IsMortgaged)
            {
                space.IsMortgaged = true;
                PayIn(space.Mortgage);
            }
        }
        public void UnMortgageProperty(ref Spaces.PropertySpace space)
        {
            if (space.IsMortgaged)
            {
                int repayAmount = (int)Math.Round((double)space.Mortgage * 1.1);
                if (repayAmount < Money)
                {
                    PayOut(repayAmount);
                    space.IsMortgaged = false;
                }
            }
        }
    }
}
