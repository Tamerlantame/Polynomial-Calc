using System;
using System.Collections.Generic;
using Arithmetics.Matrix;

namespace GraphTheory
{
    public class Graph
    {
        public List<GraphNode> AdjNodesList;
        public int time;//переменная для обходов
        public bool? Cycle;//наличие циклов в графе
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
        public void CopyTo(Graph g)
        {
            g = new Graph(AdjNodesList);
        }
        public bool IsBipartite()
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            q.Enqueue(AdjNodesList[0]);
            AdjNodesList[0].Color = GraphNode.Colors.Black;
            while (q.Count != 0)
            {
                foreach (GraphNode item in q.Peek().adjList)
                {
                    if (item.Color == q.Peek().Color)
                    {
                        return false;
                    }
                    else if (item.Color == GraphNode.Colors.Grey)
                    {
                        q.Enqueue(item);
                        if (q.Peek().Color == GraphNode.Colors.Black)
                        {
                            item.Color = GraphNode.Colors.White;
                        }
                        else
                        {
                            item.Color = GraphNode.Colors.Black;
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
                    node.Color = GraphNode.Colors.Grey;
                }
                item.Color = GraphNode.Colors.Black;
                q.Enqueue((0, item));
                while (q.Count != 0)
                {
                    foreach (GraphNode Counter in q.Peek().Item2.adjList)
                    {
                        if (Counter.Color == GraphNode.Colors.Grey)
                        {
                            q.Enqueue((q.Peek().Item1 + 1, Counter));
                            ItemDiam = q.Peek().Item1 + 1;
                            Counter.Color = GraphNode.Colors.Black;
                        }
                    }
                    q.Dequeue();
                }
                if (ItemDiam > Diam) { Diam = ItemDiam; }
            }
            return Diam;
        }
        /// <summary> обычный dfs, проставляющий времена входа-выхода на вершинах
        public void DFS(Graph gr)
        {
            foreach (GraphNode node in gr.AdjNodesList)
            {
                node.Color = GraphNode.Colors.White;
                node.Ancestor = null;
            }
            gr.time = 0;
            foreach (GraphNode node in gr.AdjNodesList)
            {
                if (node.Color == GraphNode.Colors.White)
                {
                    dfsVisit(gr, node);
                }
            }
        }
        /// <summary> метод является рекурсивной частью DFS. Его смысл сводится к проставлению времен вхождения и выхода в вершину 
        public void dfsVisit(Graph gr, GraphNode node)
        {
            gr.time++;
            node.Color = GraphNode.Colors.Grey;
            node.OpenTime = time;
            foreach (GraphNode adjNode in node.adjList)
            {
                if (adjNode.Color == GraphNode.Colors.Grey)
                {
                    gr.Cycle = true;
                }
                if (adjNode.Color == GraphNode.Colors.White)
                {
                    adjNode.Ancestor = node;
                    dfsVisit(gr, adjNode);
                }
            }

            node.Color = GraphNode.Colors.Black;
            time++;
            node.CloseTime = time;
        }
        public GraphNode[] TopolSort(Graph graph)
        {
            GraphNode[] sorted = new GraphNode[graph.AdjNodesList.Count];

            DFS(graph);

            if (graph.Cycle == true)
            {
                Console.WriteLine("присутствуют циклы");
                return null;
            }
            for (int i = 0; i < graph.AdjNodesList.Count; i++)
            {
                sorted[i] = graph.AdjNodesList[i];
            }
            for (int i = 0; i < sorted.Length; i++)
            {
                for (int j = i; j < sorted.Length; j++)
                {
                    if (sorted[i].CloseTime < sorted[j].CloseTime)
                    {
                        GraphNode a = sorted[i];
                        sorted[i] = sorted[j];
                        sorted[j] = a;
                    }
                }
            }
            return sorted;
        }
    }
}