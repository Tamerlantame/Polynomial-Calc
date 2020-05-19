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
        /// <summary> метод получает матрицу смежности из графа
        public IntegerSquareMatrix ToMatrix(Graph gr)
        {
            int[,] adjArray = new int[gr.AdjNodesList.Count, gr.AdjNodesList.Count];
            for (int i = 0; i < gr.AdjNodesList.Count; i++)
            {
                foreach (GraphNode item in gr.AdjNodesList[i].adjList)
                {
                    adjArray[i, item.Number] = 1;
                }
            }

            IntegerSquareMatrix adjMatrix = new IntegerSquareMatrix(gr.AdjNodesList.Count, adjArray);
            return adjMatrix;

        }
        /// <summary>
        /// транспонирует данный граф
        /// </summary>
        /// <param name="gr"></param>
        /// <returns></returns>
        public Graph Transponse(Graph gr)
        {
            IntegerSquareMatrix a = ToMatrix(gr);
            a = a.TransposeMatrix();
            Graph Transponeded = new Graph(a);
            return Transponeded;
        }
        public void CopyTo(Graph g)
        {
            g = new Graph(AdjNodesList);
        }
        /// <summary>
        /// поиск вершины в графе по ее номеру
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public GraphNode FindNode(Graph gr, int number)
        {

            foreach (GraphNode item in gr.AdjNodesList)
            {
                if (item.Number == number)
                {
                    return item;
                }
            }
            return null;

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
        public override string ToString()
        {
            string s = "";
            foreach (GraphNode item in AdjNodesList)
            {
                s += Convert.ToString(item.Number) + "-->{ ";
                foreach (GraphNode grItem in item.adjList)
                {
                    s += Convert.ToString(grItem.Number) + " ";
                }

                s += "}\n";
            }
            return s;
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
            node.OpenTime = gr.time;
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
            gr.time++;
            node.CloseTime = gr.time;
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
        public List<List<GraphNode>> StrongConectedComponents(Graph graph)
        {
            List<List<GraphNode>> SCC = new List<List<GraphNode>>();
            DFS(graph);//проставили время закрытия/открытия
            Graph transponded = Transponse(graph);
            foreach (GraphNode node in transponded.AdjNodesList)
            {
                node.Color = GraphNode.Colors.White;
            }
            List<int> used = new List<int>();
            int maxTimeNumber;//сюда будем помещать номер вершины-корня очередного обхода в глубину
            while (used.Count != graph.AdjNodesList.Count)//запустим дфс для каждой css
            {
                maxTimeNumber = 0;
                while (used.Contains(maxTimeNumber) == true) maxTimeNumber++;
                foreach (GraphNode item in graph.AdjNodesList)
                {
                    if (used.Contains(item.Number) != true&& graph.AdjNodesList[item.Number].CloseTime > graph.AdjNodesList[maxTimeNumber].CloseTime)
                    {
                            maxTimeNumber = item.Number;//ищем вeршину с максимальным closeTime в graph и берем за корень вершину с тем же номером в transponded
                    }
                }
                foreach (GraphNode node in transponded.AdjNodesList)
                {
                    node.CloseTime = 0;
                    node.OpenTime = 0;
                }
                transponded.time = 0;
                dfsVisit(transponded, transponded.AdjNodesList[maxTimeNumber]);
                List<GraphNode> StrongComponent = new List<GraphNode>();
                foreach (GraphNode item in transponded.AdjNodesList)
                {
                    if (item.CloseTime > 0)
                    {
                        used.Add(item.Number);
                        StrongComponent.Add(item);
                    }
                }
                SCC.Add(StrongComponent);
            }
            return SCC;
        }
    }
}