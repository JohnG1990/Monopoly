using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Spaces
{
    class StationSpace : IOwnableSpace
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Rent { get; set; }
        public int Mortgage { get; }

        public void CalculateRent()
        {
            CalculateRent(0);
        }

        public void CalculateRent(int ownedStations)
        {
            if      (ownedStations == 1) { Rent = 25; }
            else if (ownedStations == 2) { Rent = 50; }
            else if (ownedStations == 3) { Rent = 100; }
            else if (ownedStations == 4) { Rent = 200; }
        }
    }
}
