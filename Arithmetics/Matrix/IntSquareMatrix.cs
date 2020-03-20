using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics.Matrix
{
    
    public class IntSquareMatrix : IntMatrix
    {
        public IntSquareMatrix(int n) : base(n, n)
        {
            //elements = new int[n, n]; 

        }
        public IntSquareMatrix(int n, int[,] a) : base(n, n, a)
        {

        }

        public static IntSquareMatrix operator *(IntSquareMatrix m1, IntSquareMatrix m2)
        {
            IntSquareMatrix m = new IntSquareMatrix(m1.n);
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.n; j++)
                {
                    for (int temp = 0; temp < m1.n; temp++)
                    {
                        m.elements[i, j] += m1.elements[i, temp] * m2.elements[temp, j];

                    }
                }
            }
            return m;
        }
        public static IntSquareMatrix operator %(IntSquareMatrix m1, int p)
        {
            IntSquareMatrix m = new IntSquareMatrix(m1.n);
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.n; j++)
                {

                    m.elements[i, j] = m1.elements[i, j] % p;

                }
            }
            return m;

        }
        public static IntSquareMatrix add_lines(IntSquareMatrix m1)
        {
            int[,] a = new int[m1.n + 1, m1.m + 1];
            for (int i = 0; i < m1.n; i++)
            {
                for (int j = 0; j < m1.n; j++)
                {
                    a[i, j] = m1.elements[i, j];
                }
            }
            IntSquareMatrix m = new IntSquareMatrix(m1.n + 1, a);
            return m;
        }
        public static IntSquareMatrix muliply_lines(IntSquareMatrix mat, int x, int num,int p)
        {
            for (int i = 0; i < mat.n; i++)
            {
                mat.elements[num, i] = mat.elements[num, i] * x;
                while (mat.elements[num,i]<0)
                {
                    mat.elements[num, i] += p;
                }
                mat.elements[num, i] %= p;
            }
            return mat;
        }
        public IntSquareMatrix sum_lines(IntSquareMatrix mat, int x, int y)
        {
            IntSquareMatrix Res_mat = new IntSquareMatrix(mat.n, mat.elements);
            Res_mat = mat;
            for (int i = 0; i < m; i++)
            {
                Res_mat.elements[x, i] = mat.elements[x, i] + mat.elements[y, i];
            }
            return Res_mat;
        }
        public  IntSquareMatrix dif_lines(IntSquareMatrix mat, int x, int y,int num,int p)
        {
            for (int i = 0; i < mat.n; i++)
            {
               mat.elements[x, i] = mat.elements[x, i] - mat.elements[y,i]*mat.elements[x, num];
                while (mat.elements[x,i]<0) { mat.elements[x, i] += p; }
                mat.elements[x, i] %= p;
            }
            

        /////неправильное вычетание    
            return mat;
        }
        public  IntSquareMatrix swap_lines(IntSquareMatrix mat, int x, int y)
        {
            if (x != y)
            {

                for (int i = 0; i < mat.n; i++)
                {
                    int temp = mat.elements[x, i];
                    mat.elements[x, i] = mat.elements[y, i];
                    mat.elements[y, i] = temp;
                }
                return mat;
            }
            else return mat;
        }
        public  IntSquareMatrix With_answers(IntSquareMatrix mat, int[] results)

        {
            int[,] a = new int[mat.n + 1, mat.n + 1];
            for (int i= 0; i<mat.n; i++)
            {
                for (int j=0;j<mat.n; j++)
                {
          //          a[i,j]=mat.
                }
            }
       //     SquareMatrix answer = new SquareMatrix(a);
            

            return null;
        }

        public IntSquareMatrix Gauss(IntSquareMatrix mat, int p, out int det)
        {
            det = 1;
            for (int i = 0; i < mat.n; i++)

            {
                int k = exist_coeff_find(mat, i, i);
                if (k > i)
                {
                    mat.swap_lines(mat, k, i);
                    det = -det;
                    while (det < 0) { det += p; }
                }
                    int reverse, y;
                    EuclidFunctions.ExtendedEuclid(mat.elements[i, i], p, out reverse, out y);
                Console.WriteLine(det);
                    while (reverse < 0) reverse += p;
                Console.WriteLine(mat);

                mat = muliply_lines(mat, reverse, i, p);
                Console.WriteLine(mat);
                    det *= reverse;
                 //   det %= p;
                    for (int t = 0; t < mat.n; t++)
                    {
                        if (t == i) continue;
                      //  mat = dif_lines(mat, t, i, p);
                    }
                }
                Console.WriteLine(det);
                int qw = 0;
                while (qw < 32)
                {
                    if (det * qw % p == 1) { break; }
                    qw++;
                }
                det = qw;
            return mat;
        }
            
        
        public  int exist_coeff_find(IntSquareMatrix m, int num, int strring_num)
        {/// num-nomer stolbca
         ///tut mi ishem nenulevoi coefficient
         ///////strring_num-nomer v stolbce
            int i = strring_num;
            try
            {
                while (m.elements[i, num] == 0 && i < m.n-1)
                {
                    i++;

                }
                return i;
            }
            catch
            {

                return i;
            }
        }
        
        public  double  Adamar (IntSquareMatrix Mat)
        {
            double Adam=1;
            double temp = 0;
            for (int i=0; i<Mat.n; i++)
            {
                for (int j = 0; j < Mat.n; j++) {
                    temp += Mat.elements[j, i] * Mat.elements[j, i];
                }
                temp = Math.Sqrt(temp);
                Adam *= temp;
                
            }
            return Adam;
        }
        public List<int> Simples(double Adam)
        {
            int[] simples = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            int temp = 1;
            int i = 0;
            List<int> x = new List<int>();
            while(temp<Adam)
            {
                temp *= simples[i];
                i++;
                x.Add(simples[i]);
            }
            return x;

        }

        public int  Determinant (IntSquareMatrix mat)
        {
            double Adam = Adamar(mat);
            List<int> simples = Simples(Adam);
            int det;
            int[] modules = simples.ToArray();

            int[] resdues = new int[modules.Length];
            for (int i=0; i<resdues.Length;i++)
            {
                Gauss(mat, simples[i], out int x);
                resdues[i] = x;
            }
            det = NumberFunctions.ChineseRemainder(resdues, modules);


            return det;
        }
    }
} 


