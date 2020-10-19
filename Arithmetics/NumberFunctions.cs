using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    public static class NumberFunctions
    {
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
            int compositionOfModuls = mod[0];
            int inverseElement;
            int temp;
            for (int i = 1; i < mod.Length; i++)
            {
                try
                {
                        temp = 1 / (EuclidFunctions.Euclid(compositionOfModuls, mod[i]) - 1);
                        throw new Exception("may have no answer");
                }
                catch
                {
                     
                        compositionOfModuls *= mod[i];
                }
        //если числа не взаимно простые, решений может не быть.
               
            }
        //реализация китайской теоремы об остатках
            int result = 0;
            for (int i = 0; i < mod.Length; i++)
            {
                EuclidFunctions.ExtendedEuclid(compositionOfModuls / mod[i], mod[i], out inverseElement, out temp);
                result += res[i] * (compositionOfModuls / mod[i]) * inverseElement;
            }
            if (result < 0)
            {
                result %= compositionOfModuls;
                result += compositionOfModuls;
            }
            return result;
            }
            catch
            {
                throw new Exception("error input");
            }
        }

        public static int GetMulInverse(int element, int mod)
        {
            EuclidFunctions.ExtendedEuclid(element, mod, out int reversElement,out int reversMod);
            return reversElement;
        }

    }
}

