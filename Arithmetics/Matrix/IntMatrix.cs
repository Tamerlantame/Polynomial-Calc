using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics.Matrix
{
    public class IntMatrix : Matrix<int>
    {
        public IntMatrix(int n, int m) : base(n, m)
       {
            elements = new int[n, m];
            this.n = n;
            this.m = m;
        }
    public IntMatrix(int n, int m, int[,] a) : base(n, m, a)
    {
        elements = new int[n, m];
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
    public virtual bool isSymmetric()
    {
        int z = 0;
        for (int i = 0; i < n; i++)
        {
            {

                for (int j = 0; j < m; j++)
                {
                    if (elements[i, j] != elements[j, i])
                    {
                        z++;
                    }
                }
            }
        }
        return (z == 0);
    }


    public override string ToString()
    {
        string printed_matrix = "";
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                printed_matrix = printed_matrix + elements[i, j] + "   ";
            }
            printed_matrix = printed_matrix + "\n";
        }
        return printed_matrix;

    }
    public IntMatrix sum_lines(IntMatrix mat, int x, int y)
    {
        IntMatrix Res_mat = new IntMatrix(mat.n, mat.m, mat.elements);
        Res_mat = mat;
        for (int i = 0; i < m; i++)
        {
            Res_mat.elements[x, i] = mat.elements[x, i] + mat.elements[y, i];
        }
        return Res_mat;
    }
    public IntMatrix dif_lines(IntMatrix mat, int x, int y)
    {
        IntMatrix Res_mat = new IntMatrix(mat.n, mat.m, mat.elements);
        Res_mat = mat;
        for (int i = 0; i < m; i++)
        {
            Res_mat.elements[x, i] = mat.elements[x, i] - mat.elements[y, i];
        }
        return Res_mat;
    }
    public static IntMatrix swap_lines(IntMatrix mat, int x, int y)
    {
        int temp;


        for (int i = 0; i < mat.m; i++)
        {
            temp = mat.elements[x, i];
            mat.elements[x, i] = mat.elements[y, i];
            mat.elements[y, i] = temp;
        }
        return mat;
    }
}
}
