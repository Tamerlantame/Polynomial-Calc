using System;
using System.Collections.Generic;
using GraphTheory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Arithmetics.Matrix.IntegerSquareMatrix test = new Arithmetics.Matrix.IntegerSquareMatrix(@"C:\Users\Backa\source\repos\Homework\lyamelik\Arithmetics\Matrix\Tests\TopologicalSort.txt");
            Console.WriteLine(test);
            Graph testGraph = new Graph(test);
            Console.WriteLine(testGraph);

            GraphNode[] x= GraphBasicFunctions.TopolSort(testGraph);
            foreach (GraphNode item in x) Console.WriteLine(item.Number);
            List<List<GraphNode>> a = GraphBasicFunctions.StrongConectedComponents(testGraph);
            foreach (List<GraphNode> item in a)
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