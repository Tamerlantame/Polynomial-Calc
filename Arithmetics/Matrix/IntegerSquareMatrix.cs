using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arithmetics.Matrix
{
    public class IntegerSquareMatrix : IntegerMatrix
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
        public IntegerSquareMatrix(string path) : base(path)
        {
        }
        public override bool IsSymmetric()
        {
            return base.IsSymmetric();
        }

        public new IntegerSquareMatrix GetTransposed()
        {
            IntegerSquareMatrix matrix = new IntegerSquareMatrix(rows);
            Transpose(matrix);
            return matrix;
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
}


