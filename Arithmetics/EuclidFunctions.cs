using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    /// <summary>
    /// Static methods for Euclid's algorithm and its generalizations
    /// </summary>
    static class EuclidFunctions
    {
        /// <summary>
        /// Classic Euclid's algorithm for greatest common divisor
        /// </summary>
        /// <param name="x">first number</param>
        /// <param name="y">second number</param>
        /// <returns>Returns the greatest common divisor of the two integers</returns>
        public static int Euclid(int x, int y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
            while (x != 0 && y != 0)
            {
                if (x != 0 && y != 0)
                {
                    if (x > y)
                        x %= y;
                    else
                        y %= x;
                }
            }
            return x + y;
        }

        public static int Euclid(int[] a)
        {
            int gcd = Euclid(a[1], a[0]);
            for (int i = 2; i < a.Length; i++)
            {
                gcd = Euclid(gcd, a[i]);
                gcd = Euclid(gcd, a[i]);
            }
            return gcd;
        }

        public static int ExtendedEuclid(int x, int y, out int a, out int b)
        {
            int q, r;
            a = 1;
            int coeff_a = 0;
            b = 0;
            int coeff_b = 1;
            while (y != 0)
            {
                q = x / y;
                r = x % y;
                x = y;
                y = r;
                r = coeff_a;

                coeff_a = a - q * coeff_a;
                a = r;
                r = coeff_b;
                coeff_b = b - q * coeff_b;
                b = r;
            }
            return y;
        }

        // TODO Яссин, смотрите! Это нужно сделать аккуратнее.
        public static int[] LinearDiophantine(int res, int[] coeffs, int length)
        {

            int[] results = new int[length];
            if (length == 2)
            {
                int nod = Euclid(coeffs[1], coeffs[0]);
                if (Euclid(nod, res) != 1)
                {
                    coeffs[1] = coeffs[1] / Euclid(nod, res);
                    coeffs[0] = coeffs[0] / Euclid(nod, res);

                }
                ExtendedEuclid(coeffs[0], coeffs[1], out results[0], out results[1]);

                results[0] = results[0] * res;
                results[1] = results[1] * res;


                return results;
            }
            else
            {
                int nod = coeffs[0];
                for (int i = 1; i < length - 1; i++)
                    nod = Euclid(nod, coeffs[i]);

                int nod_all = Euclid(nod, coeffs[length - 1]);
                int L = res;
                nod /= nod_all;
                res /= nod_all;
                coeffs[length - 1] = coeffs[length - 1] / nod_all;

                ExtendedEuclid(nod, coeffs[length - 1], out int x, out results[length - 1]);
                results[length - 1] *= res;
                x *= L;
                int[] temp = LinearDiophantine(x, coeffs, length - 1);
                for (int i = 0; i < length - 1; i++)
                {
                    results[i] = temp[i];
                }
                return results;
            }
        }
    }
}
