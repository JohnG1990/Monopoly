using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Spaces
{
    class PropertySpace : IOwnableSpace
    {
        public enum PropertyColour
        {
            BROWN = 0,
            LIGHT_BLUE,
            PINK,
            ORANGE,
            RED,
            YELLOW,
            GREEN,
            DARK_BLUE
        }

        public PropertyColour Colour { get; }
        public string Name { get; }
        public int Price { get; }
        public int Rent { get; set; }
        public int Mortgage { get; }
        public int Houses { get; set; } = 0;
        public bool HasHotel { get; set; } = false;
        public int HousePrice { get; }
        public PropertySpace(string name, int price, PropertyColour colour)
        {
            Name = name;
            Price = price;
            Colour = colour;
            Mortgage = Price / 2;
            CalculateRent();
            HousePrice = SetHousePrice(colour);
        }

        private int SetHousePrice(PropertyColour colour)
        {
            switch (colour)
            {
                case PropertyColour.BROWN:
                    //FALLTHROUGH
                case PropertyColour.LIGHT_BLUE:
                    return 50;
                case PropertyColour.PINK:
                    //FALLTHROUGH
                case PropertyColour.ORANGE:
                    return 100;
                case PropertyColour.RED:
                    //FALLTHROUGH
                case PropertyColour.YELLOW:
                    return 150;
                case PropertyColour.GREEN:
                    //FALLTHROUGH
                case PropertyColour.DARK_BLUE:
                    return 200;
                default:
                    return 0;
            }
        }
        public void CalculateRent()
        {
            if (Houses == 0)
            {
                if (!HasHotel)
                {
                    //site only rent = 10% price - 4
                    //10% of price will always be a whole number
                    Rent = (int)(Price * 0.1) - 4; 
                }
                else if (HasHotel)
                {
                    //hotel = 5 * 1house rent + 600
                    Rent = ((Price / 2) - 20) * 5 + 600;
                }
            }
            else if (Houses == 1)
            {
                //1 house rent = 50% price - 20
                Rent = (Price / 2) - 20;
            }
            else if (Houses == 2)
            {
                //2 house rent = 3* 1house rent except
                Rent = ((Price / 2) - 20) * 3; 
            }
            else if (Houses == 3)
            {
                //3 house rent = 6* 1house rent + 140 rounded to nearest 50
                int newRent = ((Price / 2) - 20) * 6 + 140;
                Rent = ((int)Math.Round((decimal)newRent / 50)) * 50;
            }
            else if (Houses == 4)
            {
                //4 house rent = 7* 1house rent + 210
                Rent = ((Price / 2) - 20) * 7 + 210;
            }
        }

        public void AddHouse()
        {
            if (Houses < 4)
            {
                Houses++;
                CalculateRent();
            }
        }

        public void AddHotel()
        {
            if (Houses == 4)
            {
                Houses = 0;
                HasHotel = true;
                CalculateRent();
            }
        }
    }
}
