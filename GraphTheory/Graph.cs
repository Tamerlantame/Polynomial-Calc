using System;
using System.Collections.Generic;
using Arithmetics;
using Arithmetics.Matrix;

namespace GraphTheory
{
    class Graph
    {
        public List<GraphNode> AdjNodesList;
        public Graph(IntSquareMatrix matrix)
        {
            AdjNodesList = new List<GraphNode>(matrix.n);
            for (int i = 0; i < matrix.n; i++)
            {
                ///create List of empty Nodes
                GraphNode a = new GraphNode();
                AdjNodesList.Add(a);
                a.Number = i;
            }
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.n; j++)
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

        public void CopyTo(Graph g)
        {
            g = new Graph(AdjNodesList);
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

        private void TopolSortTimes(GraphNode Nod, int time)
        {
            Nod.OpenTime = time++;
            Nod.NodeColor = GraphNode.Colors.Black;
            foreach (GraphNode NodItem in Nod.adjList)
            {
                if (NodItem.OpenTime < 0)
                {
                    Console.WriteLine(NodItem.Number + " " + time);
                    TopolSortTimes(NodItem, time);
                }
                if (NodItem.NodeColor == GraphNode.Colors.Black)
                {
                    Console.WriteLine("Contuor detected");
                    return;
                }
            }
            Nod.CloseTime = time++;
            Nod.NodeColor = GraphNode.Colors.Grey;
        }

        public Graph TopologicalSort()
        {
            GraphNode[] TopSortedList = new GraphNode[AdjNodesList.Count];
            AdjNodesList.CopyTo(TopSortedList);
            //bubble sort
            GraphNode temp;
            for (int i = 0; i < TopSortedList.Length; i++)
            {
                for (int j = i + 1; j < TopSortedList.Length; j++)
                {
                    if (TopSortedList[i].CloseTime < TopSortedList[j].CloseTime)
                    {
                        temp = TopSortedList[i];
                        TopSortedList[i] = TopSortedList[j];
                        TopSortedList[j] = temp;
                    }
                }
            }
            /*int[] Numbers = new int[TopSortedList.Length];
            for (i = 0; i < TopSortedList.Length; i++)
            {
                Numbers[i] = TopSortedList[i].CloseTime;
            }*/
            return new Graph(TopSortedList);
        }

    }

}


