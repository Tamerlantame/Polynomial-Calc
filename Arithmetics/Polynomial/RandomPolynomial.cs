using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics.Polynomial
{
    class RandomPolinomial : ISequence<Polinomial>
    {
        private int maxDeg;
        private int minDeg;
        private int maxCoeff;
        private int minCoeff;

        public RandomPolinomial()
        {
            maxDeg = 10;
            minDeg = 0;
            minCoeff = 0;
            maxCoeff = 100;
        }

        public RandomPolinomial(int minDeg, int maxDeg)
            : this()
        {
            this.minDeg = minDeg;
            this.maxDeg = maxDeg;
        }

        public RandomPolinomial(int minDeg, int maxDeg, int minCoeff, int maxCoeff)
            : this(minDeg, maxDeg)
        {
            this.minCoeff = minCoeff;
            this.maxCoeff = maxCoeff;
        }

        public Polinomial Next()
        {
            Random rnd = new Random();
            int SIZE = rnd.Next(minDeg, maxDeg) + 1;
            double[] q = new double[SIZE];
            for (int i = 0; i < q.Length; i++)
            {
                q[i] = rnd.Next(minCoeff, maxCoeff);
            }
            SortedList<int, double> arr = new SortedList<int, double>();
            for (int i = 0; i < SIZE; i++)
            {
                arr.Add(i, q[i]);
            }
            return new Polinomial(arr);
        }
    }
}
