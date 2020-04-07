using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Arithmetics.Matrix
    {

        abstract class Matrix<T>
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

        class IntegerMatrix : Matrix<int>
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

            public virtual bool IsSymmetrically()
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
        class IntegerSquareMatrix : IntegerMatrix
        {
            public IntegerSquareMatrix() : base()
            {
            }
            public IntegerSquareMatrix(int n) : base(n, n)
            {
            }
            public IntegerSquareMatrix(int n, int[,] coeff) : base(n, n, coeff)
            {
            }

            public IntegerSquareMatrix(IntegerSquareMatrix matrix) : base(matrix)
            {

            }
            public override bool IsSymmetrically()
            {
                return base.IsSymmetrically();
            }
            public static IntegerSquareMatrix operator *(IntegerSquareMatrix factor1, IntegerSquareMatrix factor2)
            {
                IntegerSquareMatrix composition = new IntegerSquareMatrix(factor1.rows);

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
            public IntegerSquareMatrix SubtractionOfLines(int reducedLine, int deductibleline)
            {
                IntegerSquareMatrix newMatrix = new IntegerSquareMatrix(rows, elements);
                for (int i = 0; i < rows; i++)
                {
                    newMatrix.elements[reducedLine, i] -= newMatrix.elements[deductibleline, i];
                }
                return newMatrix;
            }
            public IntegerSquareMatrix AdditionOfLines(int summline, int termline)
            {
                IntegerSquareMatrix newMatrix = new IntegerSquareMatrix(rows, elements);
                for (int i = 0; i < rows; i++)
                {
                    newMatrix.elements[summline, i] += newMatrix.elements[termline, i];
                }
                return newMatrix;
            }
            public IntegerSquareMatrix SwapLine(int line1, int line2)
            {
                IntegerSquareMatrix newMatrix = new IntegerSquareMatrix(rows, elements);
                int temp;
                for (int i = 0; i < rows; i++)
                {
                    temp = newMatrix.elements[line1, i];
                    newMatrix.elements[line1, i] = newMatrix.elements[line2, i];
                    newMatrix.elements[line2, i] = temp;
                }
                return newMatrix;

            }
            public IntegerSquareMatrix ToTopTriangleMatrixModPrime(int prime_number)
            {
                IntegerSquareMatrix triangleMatrix = new IntegerSquareMatrix(rows, elements);
                int sign_of_det = 0;
                for (int i = 0; i < triangleMatrix.rows; i++)
                {
                    for (int j = i; j < triangleMatrix.columns; j++)
                    {
                        if (triangleMatrix.elements[j, i] != 0)
                        {
                            int reverselement = NumberFunctions.revers_element_mod_prime(triangleMatrix.elements[j, i], prime_number);
                            for (int k = j; k < triangleMatrix.columns; k++)
                            {
                                triangleMatrix.elements[j, k] *= reverselement;
                                triangleMatrix.elements[j, k] %= prime_number;
                            }
                            if (i != j)
                            {
                                triangleMatrix = triangleMatrix.SwapLine(j, i);
                                sign_of_det++;
                                sign_of_det %= 2;                                            //ОПРЕДЕЛЯЮ ЗНАК det
                            }
                            for (int k = j + 1; k < triangleMatrix.columns; k++)
                            {
                                while (triangleMatrix.elements[k, j] != 0)
                                {
                                    if (triangleMatrix.elements[k, j] > 0)
                                        triangleMatrix = triangleMatrix.SubtractionOfLines(k, j);
                                    else
                                        triangleMatrix = triangleMatrix.AdditionOfLines(k, j);
                                }
                            }
                        }


                    }
                }
                return triangleMatrix;
            }
            public int DetMod(int prime_number)
            {
                IntegerSquareMatrix triangleMatrix = new IntegerSquareMatrix(rows, elements);
                int signOfDet = 0;
                for (int i = 0; i < triangleMatrix.rows; i++)
                {
                    for (int j = i; j < triangleMatrix.columns; j++)
                    {
                        if (triangleMatrix.elements[j, i] != 0)
                        {
                            int reverselement = NumberFunctions.revers_element_mod_prime(triangleMatrix.elements[j, i], prime_number);
                            for (int k = j; k < triangleMatrix.columns; k++)
                            {
                                triangleMatrix.elements[j, k] *= reverselement;
                                triangleMatrix.elements[j, k] %= prime_number;
                            }
                            if (i != j)
                            {
                                triangleMatrix = triangleMatrix.SwapLine(j, i);
                                signOfDet++;
                                signOfDet %= 2;                                            //ОПРЕДЕЛЯЮ ЗНАК det
                            }
                            for (int k = j + 1; k < triangleMatrix.columns; k++)
                            {
                                while (triangleMatrix.elements[k, j] != 0)
                                {
                                    if (triangleMatrix.elements[k, j] > 0)
                                        triangleMatrix = triangleMatrix.SubtractionOfLines(k, j);
                                    else
                                        triangleMatrix = triangleMatrix.AdditionOfLines(k, j);
                                }
                            }
                        }


                    }
                }
                int det = 1;
                for (int i = 0; i < triangleMatrix.columns; i++)
                {
                    det *= triangleMatrix.elements[i, i];
                }
                if (signOfDet == 0)
                    return det;
                else
                    return -1 * det;

            }

            public IntegerSquareMatrix ToTopTriangleMatrixModPrime(int prime_number1, int degree)
            {
                IntegerSquareMatrix triangleMatrix = new IntegerSquareMatrix(rows, elements);
                int sign_of_det = 0;
                int prime_number = NumberFunctions.FastPow(prime_number1, degree);
                for (int i = 0; i < triangleMatrix.rows; i++)
                {
                    for (int j = i; j < triangleMatrix.columns; j++)
                    {
                        if (triangleMatrix.elements[j, i] != 0)
                        {
                            int reverselement = NumberFunctions.revers_element_mod_prime(triangleMatrix.elements[j, i], prime_number);
                            for (int k = j; k < triangleMatrix.columns; k++)
                            {
                                triangleMatrix.elements[j, k] *= reverselement;
                                triangleMatrix.elements[j, k] %= prime_number;
                            }
                            if (i != j)
                            {
                                triangleMatrix = triangleMatrix.SwapLine(j, i);
                                sign_of_det++;
                                sign_of_det %= 2;                                            //ОПРЕДЕЛЯЮ ЗНАК det
                            }
                            for (int k = j + 1; k < triangleMatrix.columns; k++)
                            {
                                while (triangleMatrix.elements[k, j] != 0)
                                {
                                    if (triangleMatrix.elements[k, j] > 0)
                                        triangleMatrix = triangleMatrix.SubtractionOfLines(k, j);
                                    else
                                        triangleMatrix = triangleMatrix.AdditionOfLines(k, j);
                                }
                            }
                        }


                    }
                }
                return triangleMatrix;
            }

            public IntegerSquareMatrix TransposeMatrix()
            {
                IntegerSquareMatrix squareMatrix = new IntegerSquareMatrix(rows, elements);
                int temp;
                for (int i = 0; i < squareMatrix.rows; i++)
                {
                    for (int j = i; j < squareMatrix.columns; j++)
                    {
                        temp = squareMatrix.elements[i, j];
                        squareMatrix.elements[i, j] = squareMatrix.elements[j, i];
                        squareMatrix.elements[j, i] = temp;
                    }
                }

                return squareMatrix;
            }

            public IntegerSquareMatrix AddColomnsAndRows(int[] new_colomns, int[] new_rows)
            {
                int[,] new_elements = new int[rows + 1, columns + 1];
                for (int i = 0; i < rows + 1; i++)
                {
                    for (int j = 0; j < columns + 1; j++)
                    {
                        if ((j != rows) && (i != columns))
                            new_elements[i, j] = elements[i, j];
                        else
                        {
                            if ((j == rows) && (i != columns))
                                new_elements[i, j] = new_colomns[i];
                            else
                            {
                                if ((j != rows) && (i == columns))
                                    new_elements[i, j] = new_rows[j];
                                else
                                    new_elements[i, j] = new_colomns[i] + new_rows[j];
                            }
                        }

                    }
                }
                IntegerSquareMatrix matrix = new IntegerSquareMatrix(rows + 1, new_elements);

                return matrix;
            }

        }
        class IntegerDiagonalMatrix : IntegerSquareMatrix
        {

            public IntegerDiagonalMatrix(int[] diag) : base(diag.Length)
            {

                rows = diag.Length;
                for (int i = 0; i < rows; i++)
                {
                    elements[i, i] = diag[i];

                }

            }
            public override bool IsSymmetrically()
            {
                return true;
            }
        }
    }


