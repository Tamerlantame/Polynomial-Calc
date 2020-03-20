using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    static class NumberFunctions
    {
        public static int power1(int x, int p, int m)
        {
            if (p % 2 == 0 && p >= 1)
            {
                return power1((x * x) % m, p / 2, m);
            }
            if (p % 2 == 1 && p >= 1)
            {
                return (x * power1((x * x) % m, p / 2, m)) % m;

            }
            else
            {
                return 1;
            }
        }

        public static int ChineseRemainder(int[] residues, int[] modules)
        {
            int M = modules[0];
            for (int i = 1; i < modules.Length; i++)
            {
                if (EuclidFunctions.Euclid(modules[i], M) != 1)
                    return -1;
                M *= modules[i];
            }

            int[] M_obr = new int[modules.Length];
            for (int i = 0; i < M_obr.Length; i++)
            {
                EuclidFunctions.ExtendedEuclid(M / modules[i], modules[i], out int x, out int y);
                M_obr[i] = x % modules[i];
            }
            int result = 0;
            for (int i = 0; i < M_obr.Length; i++)
            {
                result += residues[i] * M_obr[i] * M / modules[i];
            }
            result %= M;
            return result < 0 ? result + M : result;
        }
    }
}
