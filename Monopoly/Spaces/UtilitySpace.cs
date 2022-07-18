using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Spaces
{
    class UtilitySpace : IOwnableSpace
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public int Mortgage { get; }

        public UtilitySpace(string name, int price)
        {
            Name = name;
            Price = price;
            Mortgage = Price / 2;
            CalculateRent();
        }

        public void CalculateRent()
        {
            CalculateRent(1);
        }

        public void CalculateRent(int owned)
        {
            if (owned == 1)
            {
                Rent = Price * 4;
            }
            else if (owned == 2)
            {
                Rent = Price * 10;
            }
        }
    }
}
