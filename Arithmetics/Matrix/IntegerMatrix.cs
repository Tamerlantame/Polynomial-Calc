using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Arithmetics.Matrix
{
    public class IntegerMatrix : Matrix<int>
    {

        public IntegerMatrix(int n, int m) : base(n, m)
        {
        }

        public IntegerMatrix(Matrix<int> matrix) : base(matrix)
        {
        }

        public IntegerMatrix()
        {
        }

        public IntegerMatrix(int n, int m, int[,] coeff) : base(n, m, coeff)
        {
        }
        ///<summary>  Создание матрицы по ссылке на текстовый файл с матрицей; полагается, что матрица написана правильно
        public IntegerMatrix(string path)
        {

            string[] text = File.ReadAllLines(path);
            string[] RowElemnts = text[0].Split(' ');
            elements = new int[text.Length, RowElemnts.Length];

            for (int i = 0; i < text.Length; i++)
            {
               
                RowElemnts= text[i].Split(' ');
                for (int j=0; j < RowElemnts.Length;j++)
            {
                    elements[i, j] = Convert.ToInt32(RowElemnts[j]);               
            }
                rows = text.Length;
                columns = RowElemnts.Length;
            }

        }

        //TODO Если неправильный вид матрицы, то Exception нужен.
        ///<summary>  Создание матрицы по ссылке на текстовый файл с матрицей; полагается, что матрица написана правильно
        public IntegerMatrix(string path)
        {

            string[] text = File.ReadAllLines(path);
            string[] RowElemnts = text[0].Split(' ');
            elements = new int[text.Length, RowElemnts.Length];

            for (int i = 0; i < text.Length; i++)
            {
                RowElemnts= text[i].Split(' ');
                for (int j=0; j < RowElemnts.Length;j++)
            {
                    elements[i, j] = Convert.ToInt32(RowElemnts[j]);               
            }
                rows = text.Length;
                columns = RowElemnts.Length;
            }

        }

        public virtual bool IsSymmetric()
        {
            if (rows != columns)
                return false;
            else
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (elements[i, j] != elements[j, i])
                            return false;
                    }


                }
                return true;
            }

        }

        public static IntegerMatrix operator *(IntegerMatrix factor1, IntegerMatrix factor2)
        {

            if (factor1.rows != factor2.columns)//factor1.GetLength(1) число столбцов в 1 матрице 
                return null;                                 //factor2.GetLength(0) число строк в 2 матрице

            IntegerMatrix composition = new IntegerMatrix(factor1.rows, factor2.columns);

            for (int i = 0; i < factor1.rows; i++)
            {
                for (int j = 0; j < factor2.columns; j++)
                {
                    for (int k = 0; k < factor2.rows; k++)
                        composition.elements[i, j] += factor1.elements[i, k] * factor2.elements[k, j];

                }
            }
            return composition;
        }

        public static IntegerMatrix operator %(IntegerMatrix divinded, int mod)
        {
            IntegerMatrix result = new IntegerMatrix(divinded);
            for (int i = 0; i < divinded.rows; i++)
            {
                for (int j = 0; j < divinded.columns; j++)
                    result.elements[i, j] = divinded.elements[i, j] % mod;
            }

            return result;
        }
        public static IntegerMatrix FastPow(IntegerMatrix matrix, int deg)
        {
            IntegerMatrix CompositionOfMatrixs = new IntegerMatrix(matrix.rows, matrix.columns);
            IntegerMatrix Neutral = new IntegerMatrix(matrix.rows, matrix.columns);

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    CompositionOfMatrixs.elements[i, j] = matrix.elements[i, j];
                    if (i == j)
                        Neutral.elements[i, j] = 1;
                }
            }
            List<int> binaryNotation = new List<int>();
            while (deg > 0)
            {
                binaryNotation.Add(deg % 2);
                deg /= 2;
            }

            for (int i = 0; i < binaryNotation.Count; i++)
            {
                if (binaryNotation[i] == 1)
                    CompositionOfMatrixs *= matrix;
                matrix *= matrix;

            }
            return CompositionOfMatrixs;
        }
        public static IntegerMatrix FastPowMod(IntegerMatrix matrix, long deg, int mod)
        {
            IntegerMatrix CompositionOfMatrixs = new IntegerMatrix(matrix.rows, matrix.columns);
            IntegerMatrix Neutral = new IntegerMatrix(matrix.rows, matrix.columns);

            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    CompositionOfMatrixs.elements[i, j] = matrix.elements[i, j];
                    if (i == j)
                        Neutral.elements[i, j] = 1;
                }
            }
            List<long> binaryNotation = new List<long>();
            while (deg > 0)
            {
                binaryNotation.Add(deg % 2);
                deg /= 2;
            }

            for (int i = 0; i < binaryNotation.Count; i++)
            {
                if (binaryNotation[i] == 1)
                {
                    CompositionOfMatrixs = ((CompositionOfMatrixs % mod) * (matrix % mod)) % mod;
                }

                matrix = ((matrix % mod) * (matrix % mod)) % mod;

            }
            return CompositionOfMatrixs;
        }

    }
}
