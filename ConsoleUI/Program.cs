using System;

namespace GraphTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            Arithmetics.Matrix.IntegerSquareMatrix test = new Arithmetics.Matrix.IntegerSquareMatrix(@"C:\test.txt");
            Console.WriteLine(test);
            GraphTheory.Graph testGraph = new GraphTheory.Graph(test);
            /*        testGraph.DFS(testGraph);
                        foreach (GraphNode node in testGraph.AdjNodesList)
                        {
                            Console.WriteLine(node.Number + "  " + node.OpenTime + "  " + node.CloseTime);
                        }
            */
           
            Console.WriteLine(testGraph.Cycle);
            GraphTheory.GraphNode[] topsorted = testGraph.TopolSort(testGraph);
            
           foreach (GraphNode item  in topsorted)
            {
                Console.WriteLine(item.Number + " " + item.CloseTime);
            }           
            Console.ReadKey();
        }
    }
}