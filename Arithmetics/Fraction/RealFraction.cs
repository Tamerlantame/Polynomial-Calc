using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    struct RealFraction
    {
        
        public int p, q;
        public RealFraction(int p, int q)
        {
            this.p = p;
            this.q = q;
            if (p > 0 && q > 0||p<0&&q>0) { }
            else if (p > 0 && q < 0||q<0&&p<0)
            {
                this.p = -p;
                this.q = -q;
            }
            
            else if (p==0) { }
            int nod = EuclidFunctions.Euclid(p, q);
            p =p/ nod;
            q =q/ nod;
        }
        public static RealFraction operator +(RealFraction f1, RealFraction f2)
        {
            int p = f1.p*f2.q + f2.p*f1.q;
            int q = f1.q * f2.q;
            int nod = EuclidFunctions.Euclid(p, q);
            p /= nod;
            q /= nod;
            return new RealFraction(p, q);
        }
        public static RealFraction operator -(RealFraction f1, RealFraction f2)
        {
            int p = f1.p * f2.q - f2.p * f1.q;
            int q = f1.q * f2.q;
            int nod = EuclidFunctions.Euclid(p, q);
            p /= nod;
            q /= nod;
            return new RealFraction(p, q);
        }
        public static RealFraction operator *(RealFraction f1, RealFraction f2)
        {
            int p = f1.p * f2.q - f2.p * f1.q;
            int q = f1.q * f2.q;
            int nod = EuclidFunctions.Euclid(p, q);
            p /= nod;
            q /= nod;
            return new RealFraction(p, q);
        }

        public override string ToString()
        {
            return p + "/" + q;
        
        }
    }
}
