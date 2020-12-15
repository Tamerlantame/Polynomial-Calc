using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using Arithmetics.Matrix;
using ElementaryInterpreter;

namespace GraphTheory
{
    public class Graph: IEnumerable<GraphNode>, IComputerAlgebraType
    {
        private List<GraphNode> adjNodesList;

        /// <summary>
        /// наличие циклов в графе
        /// </summary>
        public bool HasCycle
        {
            get;
            private set;
        }
        public int Count => adjNodesList.Count;

        public string Name { get; set; }

        public GraphNode this[int index]
        {
            get
            {
                return this.adjNodesList[index];
            }
        }
        /// <summary>
        /// Graph constructor from adjacency matrix. Calls DFS to complete construction. 
        /// </summary>
        /// <param name="matrix"></param>
        public Graph(IntegerSquareMatrix matrix, string name = "")
        {
            adjNodesList = new List<GraphNode>(matrix.Columns);
            for (int i = 0; i < matrix.Columns; i++)
            {
                ///create List of empty Nodes
                GraphNode a = new GraphNode();
                adjNodesList.Add(a);
                a.Number = i;
            }
            for (int i = 0; i < matrix.Columns; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        this[i].adjList.Add(this[j]);
                    }
                }
            }
            DFS();
            Name = name;
        }
        public Graph(List<GraphNode> adjList, string name = "")
        {
            adjNodesList = adjList;
            Name = name;
        }

        public override string ToString()
        {
            string s = "";
            foreach (GraphNode item in this)
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
            int[,] adjArray = new int[adjNodesList.Count, adjNodesList.Count];
            for (int i = 0; i < adjNodesList.Count; i++)
            {
                foreach (GraphNode item in adjNodesList[i].adjList)
                {
                    adjArray[i, item.Number] = 1;
                }
            }
            return new IntegerSquareMatrix(adjNodesList.Count, adjArray);
        }
        /// <summary>
        /// транспонирует данный граф
        /// </summary>
        /// <param name="gr"></param>
        /// <returns></returns>
       
       public Graph Transponse()
        {
            List < GraphNode > tempList= new List<GraphNode>(this.Count);
            for (int i=0; i<this.Count; i++)
            {
                GraphNode newNode = new GraphNode
                {
                    Number = i
                };
                tempList.Add(newNode);
            }
            foreach (GraphNode item in this)
            {
                foreach (GraphNode nodeitem in item.adjList)
                {

                    tempList[nodeitem.Number].adjList.Add(tempList[item.Number]);  
                }
            }

            return new  Graph(tempList);
        }

        /// <summary>
        /// поиск вершины в графе по ее номеру
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public GraphNode FindNode(int number)
        {

            foreach (GraphNode item in adjNodesList)
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
            if (adjNodesList[begin].adjList.Contains(adjNodesList[end]) == false)
            {
                adjNodesList[begin].adjList.Add(adjNodesList[end]);
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
                NewNode.adjList.Add(adjNodesList[item]);
            }
            NewNode.Number = adjNodesList.Count;
            adjNodesList.Add(NewNode);
            foreach (int item in incoming)
            {
                adjNodesList[item].adjList.Add(adjNodesList[NewNode.Number]);
            }
            return this;
        }
       
        public void SaveGraph(string path)
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
                    if (j != a.Columns - 1) line += " ";
                }

                if (i != a.Rows - 1) line += "\n";
                System.IO.File.AppendAllText(path + "\\AdjMatrix", line);
            }
        }

        /// <summary>
        /// Аналог GetFromFile в <see cref="IntegerMatrix"/>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Graph GetFromFile(string path)
        {
            Arithmetics.Matrix.IntegerSquareMatrix graphMatrix = (IntegerSquareMatrix)IntegerMatrix.GetFromFile(path);
            if (graphMatrix.Columns == 0)
            {
                return null;
            }
            return new Graph(graphMatrix);
        }

        public bool IsBipartite()
        {
            Queue<GraphNode> q = new Queue<GraphNode>();
            Graph graph = new Graph(adjNodesList);
            graph.adjNodesList[0].Color = Colors.Black;
            q.Enqueue(graph.adjNodesList[0]);
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
            foreach (GraphNode node in adjNodesList)
            {
                node.Color = Colors.White;
                //node.Ancestor = null;
            }
            int time = 0;
            foreach (GraphNode node in adjNodesList)
            {
                if (node.Color == Colors.White)
                {
                    DfsVisit(node, ref time);
                }
            }
        }
        /// <summary> метод является рекурсивной частью DFS. Его смысл сводится к проставлению времен вхождения и выхода в вершину 
        public void DfsVisit(GraphNode node, ref int time)
        {
            time++;
            node.OpenTime = time;
            node.Color = Colors.Grey;
            foreach (GraphNode adjNode in node.adjList)
            {
                if (adjNode.Color == Colors.Black)
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


        public IEnumerator<GraphNode> GetEnumerator()
        {
            return adjNodesList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return adjNodesList.GetEnumerator();
        }

        public IComputerAlgebraType ParseExpression(string expr)
        {
            throw new NotImplementedException();
        }
    }
}

