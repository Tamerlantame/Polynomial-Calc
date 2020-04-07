using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics

{

    class NumberFunctions
    {
        public static int[] CreateRandomArray(int n)
        {
            Random rnd = new Random();
            int[] randomArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                randomArray[i] = rnd.Next(0, 100);
            }

            return randomArray;
        }
      
        public static int FastPowMod(int number, int deg, int mod)
        {
            int result = 1;
            List<int> binaryNotation = new List<int>();
            while (deg > 0)
            {
                binaryNotation.Add(deg % 2);
                deg /= 2;
            }
            for (int i = 0; i < binaryNotation.Count; i++)
            {
                if (binaryNotation[i] == 1)
                    result = (result * number) % mod;
                number = (number * number) % mod;

            }
            return result;
        }
        public static int FastPow(int number, int deg)
        {
            int result = 1;
            List<int> binaryNotation = new List<int>();
            while (deg > 0)
            {
                binaryNotation.Add(deg % 2);
                deg /= 2;
            }
            for (int i = 0; i < binaryNotation.Count; i++)
            {
                if (binaryNotation[i] == 1)
                    result = (result * number);
                number = (number * number);

            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        public static void PrintMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {

                Console.Write("{0} ", a[i]);

            }
        }
       
        public static int Chinese_remainder_theorem(int[] remainde_array, int[] modul_array)
        {

            if (remainde_array.Length != modul_array.Length)
            {
                Console.WriteLine("wrong input");
                return 0;
            }
            int composition_of_moduls = modul_array[0];
            int inverse_element;
            int temp;
            for (int i = 1; i < modul_array.Length; i++)
            {
                if (EuclidFunctions.Euclid(composition_of_moduls, modul_array[i]) != 1)//если числа не взаимно простые, решений может не быть.
                {
                    Console.WriteLine("may have no answer");
                    return 0;
                }
                composition_of_moduls *= modul_array[i];
            }                                                          //реализация китайской теоремы об остатках
            int result = 0;
            for (int i = 0; i < modul_array.Length; i++)
            {
                EuclidFunctions.ExtendedEuclid(composition_of_moduls / modul_array[i], modul_array[i], out inverse_element, out temp);
                result += remainde_array[i] * (composition_of_moduls / modul_array[i]) * inverse_element;
            }
            if (result < 0)
            {
                result %= composition_of_moduls;
                result += composition_of_moduls;
            }
            return result;
        }

        public static int revers_element_mod_prime(int element, int prime_number)
        {
            int reverselement = 0;
            reverselement = FastPowMod(element, prime_number - 2, prime_number);//по малой теореме ферма
            return reverselement;
        }
        public static int[] DelElement(int[] mass, int number)
        {
            int[] results = new int[mass.Length - 1];
            for (int i = 0; i < mass.Length - 1; i++)
            {
                if (i == number)
                    i++;
                results[i] = mass[i];
            }
            return results;
        }
    }

    class EvenNumbersSeries : ISeries<int>
    {
        int currant;

        public EvenNumbersSeries()
        {
            currant = 0;
        }
        public void Reset()
        {
            currant = 0;
        }

        public int Prev()
        {
            currant -= 2;
            return currant;
        }

        public int Next()
        {
            return currant += 2;

        }
    }
}

