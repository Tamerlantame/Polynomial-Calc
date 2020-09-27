using System;
using System.Collections.Generic;
using System.IO;
using Arithmetics.Matrix;

namespace GraphTheory
{
    public class Graph
    {
        public List<GraphNode> AdjNodesList;

        private bool hasCycle;//наличие циклов в графе

        /// <summary>
        /// Graph constructor from adjacency matrix. Calls DFS to complete construction. 
        /// </summary>
        /// <param name="matrix"></param>
        public Graph(IntegerSquareMatrix matrix)
        {
            AdjNodesList = new List<GraphNode>(matrix.Columns);
            for (int i = 0; i < matrix.Columns; i++)
            {
                ///create List of empty Nodes
                GraphNode a = new GraphNode();
                AdjNodesList.Add(a);
                a.Number = i;
            }
            for (int i = 0; i < matrix.Columns; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] != 0)
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

        //TODO Откровенно говоря, огромное количество лишней работы. 
        // Если граф, например, огромный цикл x1->x2->...->x10...0->x1
        /// <summary>
        /// транспонирует данный граф
        /// </summary>
        /// <param name="gr"></param>
        /// <returns></returns>
        public Graph Transponse()
        {
            return new Graph(ToMatrix().GetTransposed());
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

        public bool HasCycles()
        {
            return hasCycle;
        }

        //TODO Этот метод создавался давно, и у меня есть опасения по поводу изменений цветов вершин.
        // Я пока что сделал работу с копией. Хорошо бы его перенести в GraphBasicFunctions, нечего ему здесь делать.
        /// <summary>
        /// добавляет ребро, на вход получает граф, номер стартовой вершины и конченой
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Graph AddEdge(Graph gr, int begin, int end)
        {
            if (gr.AdjNodesList[begin].adjList.Contains(gr.AdjNodesList[end]) == false)
            {
                gr.AdjNodesList[begin].adjList.Add(gr.AdjNodesList[end]);
            }
            else
            {
                Console.WriteLine("такое ребро уже есть");
            }

            return gr;
        }
        public Graph AddNode(Graph gr, List<int> incoming, List<int> outgoing)
        {
            GraphNode NewNode = new GraphNode();
            foreach (int item in outgoing)
            {
                NewNode.adjList.Add(gr.AdjNodesList[item]);
            }
            NewNode.Number = gr.AdjNodesList.Count;
            gr.AdjNodesList.Add(NewNode);
            foreach (int item in incoming)
            {
                gr.AdjNodesList[item].adjList.Add(gr.AdjNodesList[NewNode.Number]);
            }
            return gr;
        }
        public void SaveGraph(string path, Graph gr)
        {
            Directory.CreateDirectory(path);
            IntegerSquareMatrix a = ToMatrix();
            string line = "";
            for (int i = 0; i < a.Rows; i++)
            {
                line = "";
                for (int j = 0; j < a.Columns; j++)
                {
                    line += Convert.ToString(a[i, j]);
                    if (j != a.Columns-1) line += " ";
                }
             
                if (i!=a.Rows-1) line += "\n";
                System.IO.File.AppendAllText(path+"\\AdjMatrix", line);
            }

        }
        public bool IsBipartite()
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            Graph graph = new Graph(AdjNodesList);
            q.Enqueue(graph.AdjNodesList[0]);
            graph.AdjNodesList[0].Color = Colors.Black;
            while (q.Count != 0)
            {
                foreach (GraphNode item in q.Peek().adjList)
                {
                    if (item.Color == q.Peek().Color)
                    {
                        return false;
                    }
                    else if (item.Color == Colors.Grey)
                    {
                        q.Enqueue(item);
                        if (q.Peek().Color == Colors.Black)
                        {
                            item.Color = Colors.White;
                        }
                        else
                        {
                            item.Color = Colors.Black;
                        }
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
                    hasCycle = true;
                }
                if (adjNode.Color == Colors.White)
                {
                    //adjNode.Ancestor = node;
                    DfsVisit(adjNode, ref time);
                }
            }
            node.Color = Colors.Black;
            time++;
            node.CloseTime = time;
        }
    }
}