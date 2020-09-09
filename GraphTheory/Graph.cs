using System;
using System.Collections.Generic;
using System.IO;
using Arithmetics.Matrix;

namespace GraphTheory
{
    public class Graph
    {
        public List<GraphNode> AdjNodesList;

        /// <summary>
        /// наличие циклов в графе
        /// </summary>
        public bool HasCycle
        {
            get;
            private set;
        }
        /// <summary>
        /// Graph constructor from adjacency matrix. Calls DFS to complete construction. 
        /// </summary>
        /// <param name="matrix"></param>
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
            DFS();
        }
        public Graph(List<GraphNode> adjList)
        {
            AdjNodesList = new List<GraphNode>(adjList.Count);
            adjList.CopyTo(AdjNodesList.ToArray());
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

        /// <summary> 
        ///     метод получает матрицу смежности из графа
        /// </summary>
        /// <param name="gr"></param>
        /// <returns></returns>
        public IntegerSquareMatrix ToMatrix()
        {
            int[,] adjArray = new int[AdjNodesList.Count, AdjNodesList.Count];
            for (int i = 0; i < AdjNodesList.Count; i++)
            {
                foreach (GraphNode item in AdjNodesList[i].adjList)
                {
                    adjArray[i, item.Number] = 1;
                }
            }
            return new IntegerSquareMatrix(AdjNodesList.Count, adjArray);
        }
        /// <summary>
        /// транспонирует данный граф
        /// </summary>
        /// <param name="gr"></param>
        /// <returns></returns>
        public Graph Transponse()
        {
            // много лишнего...
            return new Graph(ToMatrix().GetTransposed());
        }

        /// <summary>
        /// поиск вершины в графе по ее номеру
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public GraphNode FindNode(int number)
        {

            foreach (GraphNode item in AdjNodesList)
            {
                if (item.Number == number)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// добавляет ребро, на вход получает граф, номер стартовой вершины и конченой
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Graph AddEdge(int begin, int end)
        {
            if (AdjNodesList[begin].adjList.Contains(AdjNodesList[end]) == false)
            {
                AdjNodesList[begin].adjList.Add(AdjNodesList[end]);
            }
            else
            {
                Console.WriteLine("такое ребро уже есть");
            }

            return this;
        }
        public Graph AddNode(List<int> incoming, List<int> outgoing)
        {
            GraphNode NewNode = new GraphNode();
            foreach (int item in outgoing)
            {
                NewNode.adjList.Add(AdjNodesList[item]);
            }
            NewNode.Number = AdjNodesList.Count;
            AdjNodesList.Add(NewNode);
            foreach (int item in incoming)
            {
                AdjNodesList[item].adjList.Add(AdjNodesList[NewNode.Number]);
            }
            return this;
        }
        public void SaveGraph(string path)
        {
            Directory.CreateDirectory(path);
            IntegerSquareMatrix a = ToMatrix();
            string line = "";
            for (int i = 0; i < a.rows; i++)
            {
                line = "";
                for (int j = 0; j < a.columns; j++)
                {
                    line += Convert.ToString(a.elements[i, j]);
                    if (j != a.columns - 1) line += " ";
                }

                if (i != a.rows - 1) line += "\n";
                System.IO.File.AppendAllText(path + "\\AdjMatrix", line);
            }

        }
        public bool IsBipartite()
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            Graph graph = new Graph(AdjNodesList);
            graph.AdjNodesList[0].Color = Colors.Black;
            q.Enqueue(graph.AdjNodesList[0]);
            while (q.Count != 0)
            {
                foreach (GraphNode item in q.Peek().adjList)
                {
                    if (item.Color == q.Peek().Color)
                    {
                        return false;
                    }
                    else if (item.Color == Colors.White)
                    {
                        if (q.Peek().Color == Colors.Black)
                        {
                            item.Color = Colors.Grey;
                        }
                        else
                        {
                            item.Color = Colors.Black;
                        }
                        q.Enqueue(item);
                    }
                }
                q.Dequeue();
            }
            return true;
        }
        /// <summary> обычный dfs, проставляющий времена входа-выхода на вершинах
        public void DFS()
        {
            foreach (GraphNode node in AdjNodesList)
            {
                node.Color = Colors.White;
                //node.Ancestor = null;
            }
            int time = 0;
            foreach (GraphNode node in AdjNodesList)
            {
                if (node.Color == Colors.White)
                {
                    DfsVisit(node, ref time);
                }
            }
        }
        /// <summary> метод является рекурсивной частью DFS. Его смысл сводится к проставлению времен вхождения и выхода в вершину 
        private void DfsVisit(GraphNode node, ref int time)
        {
            time++;
            node.Color = Colors.Grey;
            node.OpenTime = time;
            foreach (GraphNode adjNode in node.adjList)
            {
                if (adjNode.Color == Colors.Grey)
                {
                    HasCycle = true;
                }
                if (adjNode.Color == Colors.White)
                {

                    DfsVisit(adjNode, ref time);
                }
            }
            node.Color = Colors.Black;
            time++;
            node.CloseTime = time;
        }
    }
}

