using System;
using System.Collections.Generic;

namespace GraphTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            Arithmetics.Matrix.IntegerSquareMatrix test = new Arithmetics.Matrix.IntegerSquareMatrix(@"C:\Users\Backa\source\repos\Homework\lyamelik\Arithmetics\Matrix\Tests\TopologicalSort.txt");
            Console.WriteLine(test);
            GraphTheory.Graph testGraph = new GraphTheory.Graph(test);
            Console.WriteLine(testGraph);

            GraphTheory.GraphNode[] x= testGraph.TopolSort(testGraph);
            foreach (GraphNode item in x) Console.WriteLine(item.Number);
            List<List<GraphNode>> a = testGraph.StrongConectedComponents(testGraph);
            foreach (List<GraphTheory.GraphNode> item in a)
            {
                foreach (GraphNode item1 in item)
                {
                    Console.WriteLine(item1.Number);
                }
                Console.WriteLine("next");
            }
            Console.ReadKey();
        }
    }
}