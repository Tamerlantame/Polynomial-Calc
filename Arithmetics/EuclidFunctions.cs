using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    class EuclidFunctions
    {
        public static int Euclid(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a != 0 && b != 0)
                {
                    if (a > b)
                        a %= b;
                    else
                        b %= a;
                }
            }
            return a + b;
        }

        public static int arr_euclid(int[] a)
        {
            int nod = Euclid(a[1], a[0]);
            for (int i = 2; i < a.Length; i++)
            {
                nod = Euclid(nod, a[i]);
            }
            return nod;
        }

        public static int ExtendedEuclid(int a, int b, out int last_coeff_a, out int last_coeff_b)
        {
            int q, r;
            last_coeff_a = 1;
            int coeff_a = 0;
            last_coeff_b = 0;
            int coeff_b = 1;
            while (b != 0)
            {
                q = a / b;
                r = a % b;
                a = b;
                b = r;
                r = coeff_a;

                coeff_a = last_coeff_a - q * coeff_a;
                last_coeff_a = r;
                r = coeff_b;
                coeff_b = last_coeff_b - q * coeff_b;
                last_coeff_b = r;
            }
            return b;
        }


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
