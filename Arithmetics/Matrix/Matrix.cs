using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics.Matrix
{
    public abstract class Matrix<T>
    {
        public T[,] elements;
        public int rows;
        public int columns;
        public Matrix(int n, int m)
        {
            elements = new T[n, m];
            rows = n;
            columns = m;

        }
        public Matrix()
        {
            elements = new T[0, 0];
            rows = 0;
            columns = 0;

        }
        public Matrix(T[,] coeff)
        {
            rows = coeff.GetLength(0);
            columns = coeff.GetLength(1);
            elements = new T[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    elements[i, j] = coeff[i, j];
                }
            }
        }
        public Matrix(Matrix<T> matrix)
        {
            rows = matrix.rows;
            columns = matrix.columns;
            elements = new T[matrix.rows, matrix.columns];
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    elements[i, j] = matrix.elements[i, j];
                }
            }
        }
        public Matrix(int n, int m, T[,] coeff)
        {
            rows = n;
            columns = m;
            elements = new T[n, m];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    elements[i, j] = coeff[i, j];
                }
            }
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    s += Convert.ToString(elements[i, j]) + " ";

                }
                s += "\n";

            }
            return s;
        }
    }
}
