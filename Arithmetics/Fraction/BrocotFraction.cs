using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    struct BrocotFraction
    {
        public Fraction current;
        public Fraction left;
        public Fraction right;

        public BrocotFraction(Fraction Current, Fraction Left, Fraction Right)
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
