using System;
using System.Collections.Generic;
using System.Numerics;
using System.IO;
using Arithmetics.Matrix;
using GraphTheory;

namespace GraphTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            
        
             
             int[,] a = new int[4, 4];
            /*        a[0, 0] = 0;
                    a[0, 1] = 0;
                  a[0, 2] = 1;
                  a[0, 3] = 1;
                  a[1, 0] = 0;
                  a[1, 1] = 0;
                  a[1, 2] = 1;
                  a[1, 3] = 1;
                  a[2, 0] = 1;
                  a[2, 1] = 1;
                  a[2, 2] = 0;
                  a[2, 3] = 0;
                  a[3, 0] = 1;
                  a[3,1] = 1;
                  a[3, 2] = 0;
                  a[3, 3] = 0;*/

            a[0, 0] =0;
            a[0, 1] = 1;
            a[0, 2] = 1;
            a[0, 3] = 0;
            a[1, 0] = 0;
            a[1, 1] = 0;
            a[1, 2] = 1;
            a[1, 3] = 1;
            a[2, 0] = 0;
            a[2, 1] = 0;
            a[2, 2] = 0;
            a[2, 3] = 0;
            a[3, 0] = 0;
            a[3, 1] = 0;
            a[3, 2] = 0;
            a[3, 3] = 0;


            IntegerSquareMatrix test = new IntegerSquareMatrix(4, a);
                Console.WriteLine(test);

            Graph testGraph = new Graph(test);
       //     Console.WriteLine(testGraph.IsTwoParted());
         //   Console.WriteLine(testGraph.GraphDiametr(testGraph));
            Console.ReadKey();
          }
        }
    }
