using System;
using System.Collections.Generic;
using Arithmetics.Matrix;

namespace GraphTheory
{
    public class Graph
    {
        public List<GraphNode> AdjNodesList;
        public Graph(IntegerSquareMatrix matrix)
        {
            AdjNodesList = new List<GraphNode>(matrix.columns);
            for (int i = 0; i < matrix.columns; i++)
            {
                ///create List of empty Nodes
                GraphNode a = new GraphNode();
                AdjNodesList.Add(a);
                a.Number = i;
            }
            for (int i = 0; i < matrix.columns; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    if (matrix.elements[i, j] != 0)
                    {
                        AdjNodesList[i].adjList.Add(AdjNodesList[j]);
                    }
                }
            }
        }

        public Graph(List<GraphNode> adjList)
        {
            AdjNodesList = new List<GraphNode>(adjList.Count);
            adjList.CopyTo(AdjNodesList.ToArray());
        }
        public bool IsBipartite()
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(AdjNodesList[0]);
            AdjNodesList[0].NodeColor = GraphNode.Colors.Black;
            while (q.Count != 0)
            {
                foreach (GraphNode item in q.Peek().adjList)
                {
                    if (item.NodeColor == q.Peek().NodeColor)
                    {
                        return false;
                    }
                    else if (item.NodeColor == GraphNode.Colors.Grey)
                    {
                        q.Enqueue(item);
                        if (q.Peek().NodeColor == GraphNode.Colors.Black)
                        {
                            item.NodeColor = GraphNode.Colors.White;
                        }
                        else
                        {
                            item.NodeColor = GraphNode.Colors.Black;
                        }
                    }
                }
                q.Dequeue();
            }
            return true;
        }


        public int GraphDiam(Graph Graph)
        {
            int Diam = 0;
            var q = new Queue<ValueTuple<int, GraphNode>>();
            foreach (GraphNode item in Graph.AdjNodesList)
            ///для каждой вершины bfs
            {
                int ItemDiam = 0;
                foreach (GraphNode node in Graph.AdjNodesList)
                {
                    node.NodeColor = GraphNode.Colors.Grey;
                }
                item.NodeColor = GraphNode.Colors.Black;
                q.Enqueue((0, item));
                while (q.Count != 0)
                {
                    foreach (GraphNode Counter in q.Peek().Item2.adjList)
                    {
                        if (Counter.NodeColor == GraphNode.Colors.Grey)
                        {
                            q.Enqueue((q.Peek().Item1 + 1, Counter));
                            ItemDiam = q.Peek().Item1 + 1;
                            Counter.NodeColor = GraphNode.Colors.Black;
                        }
                    }
                    q.Dequeue();
                }
                if (ItemDiam > Diam) { Diam = ItemDiam; }
            }
            return Diam;
        }
        public bool IsEmpty(GraphNode Node)/// вспомогательный mетод для TopolDFS, проверяет веришину на наличие у нее не посещенных соседей
        {
            foreach (GraphNode item in Node.adjList)
            {
                if (item.NodeColor != GraphNode.Colors.Black)
                {
                    return false;
                }
            }
            if (Node.adjList.Count == 0)
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        public GraphNode TopolDFS(GraphNode node, ref Stack<GraphNode> sorted, Stack<GraphNode> visited)
        {
            {
                if (IsEmpty(node) == true)
                {
                    sorted.Push(node);
                    node.NodeColor = GraphNode.Colors.Black;
                    visited.Pop();
                    if (visited.Count != 0)
                    {
                        return TopolDFS(visited.Peek(), ref sorted, visited);
                    }
                    else
                    {
                        return node;
                    }
                }
                else
                {

                    foreach (GraphNode item in node.adjList)
                    {
                        if (visited.Contains(item))
                        {
                            Console.WriteLine("Contur detected");
                            GraphNode a = new GraphNode();
                            a.Number = -1;
                            return a;
                        }
                        if (item.NodeColor == GraphNode.Colors.Black) continue;
                        visited.Push(item);
                    }
                    return TopolDFS(visited.Peek(), ref sorted, visited);
                }
            }
        }
        public List<GraphNode> TopolSort(Graph graph)
        {
            Stack<GraphNode> sorted = new Stack<GraphNode>();

            Stack<GraphNode> visited = new Stack<GraphNode>();
            visited.Push(AdjNodesList[0]);
            TopolDFS(graph.AdjNodesList[0], ref sorted, visited);

            foreach (GraphNode item in sorted)
            {
                Console.WriteLine(item.Number);
            }

            return new List<GraphNode>();
        }
    }

}