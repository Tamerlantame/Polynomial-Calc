using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    public static class NumberFunctions
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

            public static int ModPow(int number, int deg, int mod)
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

        // TODO избавиться от WriteLine и выбрасывать исключения, если вход неверный.
        public static int ChineseRemainderTheorem(int[] res, int[] mod)
        {
            try
            { 
            int composition_of_moduls = mod[0];
            int inverse_element;
            int temp;
            for (int i = 1; i < mod.Length; i++)
            {
                try
                {
                        temp = 1 / (EuclidFunctions.Euclid(composition_of_moduls, mod[i]) - 1);
                        throw new Exception("may have no answer");
                }
                catch
                {
                     
                        composition_of_moduls *= mod[i];
                }
        //если числа не взаимно простые, решений может не быть.
               
            }
        //реализация китайской теоремы об остатках
            int result = 0;
            for (int i = 0; i < mod.Length; i++)
            {
                EuclidFunctions.ExtendedEuclid(composition_of_moduls / mod[i], mod[i], out inverse_element, out temp);
                result += res[i] * (composition_of_moduls / mod[i]) * inverse_element;
            }
            if (result < 0)
            {
                result %= composition_of_moduls;
                result += composition_of_moduls;
            }
            return result;
            }
            catch
            {
                throw new Exception("error input");
            }
        }

        public static int revers_element_mod_prime(int element, int prime_number)
        {
            int reverselement = 0;
            reverselement = ModPow(element, prime_number - 2, prime_number);//по малой теореме ферма
            return reverselement;
        }

    }
}

