using System;

namespace Arithmetics.Matrix
{
    public class Matrix<T>
    {
        protected T[,] elements;
        protected int rows;
        protected int columns;
        public T this[int index0, int index1]
        {
            get
            {
                if ((elements.GetLength(0) < index0)&& (elements.GetLength(1) < index1))
                {
                    return elements[index0,index1];
                }
                else return default(T);
            }
            set
            {
                elements[index0, index1] = value;
            }
        }
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

        public void Transpose(Matrix<T> matrix)
        {
            T temp;
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = i; j < matrix.columns; j++)
                {
                    temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }
        }

        public Matrix<T> GetTransposed()
        {
            Matrix<T> matrix = new Matrix<T>(rows, columns);
            Transpose(matrix);
            return matrix;
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
