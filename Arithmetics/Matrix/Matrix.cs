using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics.Matrix
{

    public class Matrix<T>
    {/// List<List<T>> a = new List<List<T>>();
        public int n, m;
        public T[,] elements;
        public Matrix(int n, int m)
        {
            elements = new T[n, m];
        }

        public Matrix(int n, int m, T[,] a)
        {
            elements = new T[n, m];
            this.n = n;
            this.m = m;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    elements[i, j] = a[i, j];
                }
            }
        }


    }
    
}
