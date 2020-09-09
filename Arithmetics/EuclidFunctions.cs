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
        /// <param name="x">First number</param> 
        /// <param name="y">Second number</param> 
        /// <returns>Returns the greatest common divisor of the two integers</returns> 
        public static int Euclid(int x, int y)
        {
            while (x != 0 && y != 0)
            {
                if (x != 0 && y != 0)
                {
                    if (x > y)
                    {
                        x %= y;
                    }
                    else
                    {
                        y %= x;
                    }
                }
            }
            return x + y;
        }

        /// <summary> 
        /// Get the greatest common divisor of array elements. 
        /// </summary> 
        /// <param name="array">Array of integers</param> 
        /// <returns>The greatest common divisor</returns> 
        public static int Euclid(int[] array)
        {
            int gcd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                gcd = Euclid(gcd, array[i]);
            }
            return gcd;
        }

        /// <summary> 
        /// Get gcd(a, b) and find coeddicientA and coefficientB such that, a * coeddicientA + b * coefficientB = gsd(a, b). 
        /// </summary> 
        /// <param name="a">First unknown value</param> 
        /// <param name="b">Second unknown value</param> 
        /// <param name="coefficientA">Coefficient of first unknown value</param> 
        /// <param name="coefficientB">Coefficient of second unknown value</param> 
        /// <returns>gcd(a, b) —- The greatest common divisor of the two integers</returns> 
        public static int ExtendedEuclid(int a, int b, out int coefficientA, out int coefficientB)
        {
            if (a == 0)
            {
                coefficientA = 0;
                coefficientB = 1;
                return b;
            }
            int x1;
            int y1;
            int gcd = ExtendedEuclid(b % a, a, out x1, out y1);
            coefficientA = y1 - (b / a) * x1;
            coefficientB = x1;
            return gcd;
        }

        /// <summary> 
        /// Delete value from array. 
        /// </summary> 
        /// <param name="array">Array of integers</param> 
        /// <param name="value">Value for delition from array</param> 
        /// <returns></returns> 
        public static int[] DeleteElement(int[] array, int value)
        {
            int[] results = new int[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (i == value)
                {
                    i++;
                }
                results[i] = array[i];
            }
            return results;
        }

        /// <summary> 
        /// Get one solution to an equation. 
        /// </summary> 
        /// <param name="coefficients">Array of coefficients for unknown values</param> 
        /// <param name="value">Free value of equation</param> 
        /// <returns>One solution of equation.</returns> 
        public static int[] LinearDiophantine(int[] coefficients, int value)
        {
            int[] results = new int[coefficients.Length];
            int gcd = Euclid(coefficients);
            if (value % gcd == 0)
            {
                if (coefficients.Length == 2)
                {
                    coefficients[0] /= gcd;
                    coefficients[1] /= gcd;
                    value /= gcd;
                    ExtendedEuclid(coefficients[0], coefficients[1], out results[0], out results[1]);
                    results[0] = results[0] * value;
                    results[1] = results[1] * value;
                    return results;
                }

                gcd = coefficients[0];
                for (int i = 1; i < coefficients.Length - 1; i++)
                {
                    gcd = Euclid(gcd, coefficients[i]);
                }

                int gcdGlobal = Euclid(gcd, coefficients[coefficients.Length - 1]);
                int imaginaryValue = value;
                gcd /= gcdGlobal;
                value /= gcdGlobal;
                coefficients[coefficients.Length - 1] /= gcdGlobal;
                ExtendedEuclid(gcd, coefficients[coefficients.Length - 1], out int temp, out results[coefficients.Length - 1]);
                results[coefficients.Length - 1] *= value;
                temp *= imaginaryValue;
                coefficients = DeleteElement(coefficients, coefficients.Length - 1);
                int[] temp1 = LinearDiophantine(coefficients, temp);

                for (int i = 0; i < results.Length - 1; i++)
                {
                    results[i] = temp1[i];
                }
                return results;
            }
            return null;
        }
    }
}
