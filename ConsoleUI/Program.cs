using System;

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

            a[0, 0] = 0;
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


            //  Arithmetics.Matrix.IntegerSquareMatrix test = new Arithmetics.Matrix.IntegerSquareMatrix(4, a);

            /// GraphTheory.Graph testGraph = new GraphTheory.Graph(test);
            //  Console.WriteLine(testGraph.IsBipartite());
            // Console.WriteLine(testGraph.GraphDiam(testGraph));
            ///  testGraph.TopolSort(testGraph);

            //foreach (GraphNode item in testGraph.AdjNodesList)

            Arithmetics.Matrix.IntegerSquareMatrix test = new Arithmetics.Matrix.IntegerSquareMatrix(@"C:\test.txt");
            Console.WriteLine(test);
   
                
            Console.ReadKey();
        }
    }
}