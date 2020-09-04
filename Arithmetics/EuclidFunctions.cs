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
    public static class EuclidFunctions
    {
        /// <summary>
        /// Classic Euclid's algorithm for the greatest common divisor function
        /// </summary>
        /// <param name="x">first number</param>
        /// <param name="y">second number</param>
        /// <returns>Returns the greatest common divisor of the two integers</returns>
        public static int Euclid(int x, int y)
        {
            x = Math.Abs(x); // Убрать эту ерунду.
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

        /// <summary>
        /// ????????????????
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int Euclid(int[] a)
        {
            int gcd = 0;
            for (int i = 0; i < a.Length; i++)
                gcd = Euclid(gcd, a[i]);
            return gcd;
        }

        /// <summary>
        /// Всё напишите. Посмотрите, что возвращает метод. Должен быть НОД(x,y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
        // (04.09) Точнее, просто всё перепишите. Сделайте так, как мы с вами делали эту задачу прошлой осенью.
        public static int[] LinearDiophantine(int[] a, int b)
        {
            int[] x = new int[a.Length];
            //...
            return x;
        }
    }
}
