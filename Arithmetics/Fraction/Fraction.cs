using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    struct Fraction
    {
        /// <summary>
        /// numerator
        /// </summary>
        public readonly int p;
        /// <summary>
        /// denominator
        /// </summary>
        public readonly int q;    

        public Fraction(int p, int q)
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
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            int p = f1.p*f2.q + f2.p*f1.q;
            int q = f1.q * f2.q;
            int nod = EuclidFunctions.Euclid(p, q);
            p /= nod;
            q /= nod;
            return new Fraction(p, q);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            int p = f1.p * f2.q - f2.p * f1.q;
            int q = f1.q * f2.q;
            int nod = EuclidFunctions.Euclid(p, q);
            p /= nod;
            q /= nod;
            return new Fraction(p, q);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            int p = f1.p * f2.q - f2.p * f1.q;
            int q = f1.q * f2.q;
            int nod = EuclidFunctions.Euclid(p, q);
            p /= nod;
            q /= nod;
            return new Fraction(p, q);
        }

        public static Fraction Mediant(Fraction f1, Fraction f2)
        {
            int p = f1.p + f2.p;
            int q = f1.q + f2.q;
            return new Fraction(p, q);
        }

        public override string ToString()
        {
            return p + "/" + q;
        
        }
    }
}
