using System;
using System.Collections.Generic;
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

        // Сомнительную роль сейчас играет этот метод. Нужно обосновать, когда есть конструктор Graph(List<GraphNode> adjList)
        public void CopyTo(Graph g)
        {
            g.AdjNodesList = new List<GraphNode>();
            AdjNodesList.CopyTo(g.AdjNodesList.ToArray());
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
        // Я пока что сделал работу с копией.
        public bool IsBipartite()
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            Graph graph = new Graph(AdjNodesList);
            q.Enqueue(graph.AdjNodesList[0]);
            graph.AdjNodesList[0].Color = GraphNode.Colors.Black;
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

        /// <summary> обычный dfs, проставляющий времена входа-выхода на вершинах
        public void DFS()
        {
            foreach (GraphNode node in AdjNodesList)
            {
                node.Color = GraphNode.Colors.White;
                node.Ancestor = null;
            }
            int time = 0;
            foreach (GraphNode node in AdjNodesList)
            {
                if (node.Color == GraphNode.Colors.White)
                {
                    DfsVisit(node, ref time);
                }
            }
        }
        /// <summary> метод является рекурсивной частью DFS. Его смысл сводится к проставлению времен вхождения и выхода в вершину 
        private void DfsVisit(GraphNode node, ref int time)
        {
            time++;
            node.Color = GraphNode.Colors.Grey;
            node.OpenTime = time;
            foreach (GraphNode adjNode in node.adjList)
            {
                if (adjNode.Color == GraphNode.Colors.Grey)
                {
                    hasCycle = true;
                }
                if (adjNode.Color == GraphNode.Colors.White)
                {
                    adjNode.Ancestor = node;
                    DfsVisit(adjNode, ref time);
                }
            }
            node.Color = GraphNode.Colors.Black;
            time++;
            node.CloseTime = time;
        }
    }
}