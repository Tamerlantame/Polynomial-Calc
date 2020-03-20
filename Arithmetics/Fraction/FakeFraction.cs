using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    struct FakeFraction
    {
        public int p, q;
        public FakeFraction(int p, int q)
        {
            this.p = p;
            this.q = q;
        }
        public static FakeFraction operator +(FakeFraction f1, FakeFraction f2)
        {
            int p = f1.p + f2.p;
            int q = f1.q + f2.q;
            return new FakeFraction(p, q);
        }
        public override string ToString()
        {
            return p + "/" + q;
        }
    }
}