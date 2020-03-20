using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    struct BrocotFraction
    {
        public FakeFraction current;
        public FakeFraction left;
        public FakeFraction right;

        public BrocotFraction(FakeFraction Current, FakeFraction Left, FakeFraction Right)
        {
            current = Current;
            left = Left;
            right = Right;

        }
        public override string ToString()
        {

            return "  " + current + " ";
        }
    }
}
