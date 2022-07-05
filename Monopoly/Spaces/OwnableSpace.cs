using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Spaces
{
    public interface IOwnableSpace : ISpace
    {
        int Price { get; set; }
        int Rent { get; set; }
        int Mortgage { get; }

        void CalculateRent();
    }
}
