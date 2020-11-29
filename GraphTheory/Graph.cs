using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Arithmetics.Matrix;
using Logics;

namespace GraphTheory
{
    public class Graph : IEnumerable<GraphVertex>
    {
        protected List<GraphVertex> adjacencyList;
        private LogicGraphVertex[] adjacencyArray;

        private List<LogicGraphVertex> order;
        private int[] comp;

        /// <summary>
        /// наличие циклов в графе
        /// </summary>
        public bool HasCycle
        {
            get;
            private set;
        }

        public int Count => adjacencyList.Count;

        public string Name { get; set; }

        public GraphVertex this[int index]
        {
            get
            {
                return this.adjacencyList[index];
            }
        }

        private int GetNumber(string value)
        {
            string answer = "";
            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsDigit(value[i]))
                {
                    answer += value[i];
                }
            }
            return Convert.ToInt32(answer);
        }

        public Graph(List<(string, string)> booleanExpression)
        {
            int max = -1;
            foreach (var item in booleanExpression)
            {
                max = Math.Max(max, GetNumber(item.Item1));
                max = Math.Max(max, GetNumber(item.Item2));
            }

            adjacencyArray = new LogicGraphVertex[max * 2];
            for (int i = 0; i < max; i++)
            {
                LogicGraphVertex graphNode1 = new LogicGraphVertex(i + 1,true);
                adjacencyArray[2 * i] = graphNode1;

                LogicGraphVertex graphNode2 = new LogicGraphVertex(i + 1, false);
                adjacencyArray[2 * i + 1] = graphNode2;
            }

            foreach (var item in booleanExpression)
            {
                if (item.Item1[0] != '~' && item.Item2[0] != '~')
                {
                    adjacencyArray[(GetNumber(item.Item1) - 1) * 2 + 1].adjacencyList.
                        Add(adjacencyArray[(GetNumber(item.Item2) - 1) * 2]);
                    adjacencyArray[(GetNumber(item.Item2) - 1) * 2 + 1].adjacencyList.
                        Add(adjacencyArray[(GetNumber(item.Item1) - 1) * 2]);
                }

                else if (item.Item1[0] != '~' && item.Item2[0] == '~')
                {
                    adjacencyArray[(GetNumber(item.Item1) - 1) * 2 + 1].adjacencyList.
                        Add(adjacencyArray[(GetNumber(item.Item2) - 1) * 2 + 1]);
                    adjacencyArray[(GetNumber(item.Item2) - 1) * 2].adjacencyList.
                        Add(adjacencyArray[(GetNumber(item.Item1) - 1) * 2]);
                }

                else if (item.Item1[0] == '~' && item.Item2[0] != '~')
                {
                    adjacencyArray[(GetNumber(item.Item1) - 1) * 2].adjacencyList.
                        Add(adjacencyArray[(GetNumber(item.Item2) - 1) * 2]);
                    adjacencyArray[(GetNumber(item.Item2) - 1) * 2 + 1].adjacencyList.
                        Add(adjacencyArray[(GetNumber(item.Item1) - 1) * 2 + 1]);
                }

                else
                {
                    adjacencyArray[(GetNumber(item.Item1) - 1) * 2].adjacencyList.
                        Add(adjacencyArray[(GetNumber(item.Item2) - 1) * 2 + 1]);
                    adjacencyArray[(GetNumber(item.Item2) - 1) * 2].adjacencyList.
                        Add(adjacencyArray[(GetNumber(item.Item1) - 1) * 2 + 1]);
                }
            }
        }

        private int GetVertexIndex(LogicGraphVertex vertex)
        {
            if (vertex.isMoreZero)
            {
                return (vertex.Number - 1) * 2;
            }
            return (vertex.Number - 1) * 2 + 1;
        }

        private void DfsForTwoCnfSat1(LogicGraphVertex vertex, ref bool[] used)
        {
            var intVertex = GetVertexIndex(vertex);
            used[intVertex] = true;
            foreach (LogicGraphVertex item in adjacencyArray[intVertex].adjacencyList)
            {
                if (!used[GetVertexIndex(item)])
                {
                    DfsForTwoCnfSat1(item, ref used);
                }
            }
            var currentVertex = new List<LogicGraphVertex>();
            currentVertex.Add(vertex);
            order.AddRange(currentVertex);
        }

        private void DfsForTwoCnfSat2(LogicGraphVertex vertex, int connectivityСomponent)
        {
            comp[GetVertexIndex(vertex)] = connectivityСomponent;
            foreach (var item in adjacencyArray)
            {
                if (comp[GetVertexIndex(vertex)] == -1)
                {
                    DfsForTwoCnfSat2(vertex, connectivityСomponent);
                }
            }
        }

        public List<bool> TwoCnfSat()
        {
            bool[] used = new bool[adjacencyArray.Length];
            order = new List<LogicGraphVertex>();
            comp = new int[adjacencyArray.Length];

            for (int i = 0; i < adjacencyArray.Length; i++)
            {
                comp[i] = -1;
                if (!used[i])
                {
                    DfsForTwoCnfSat1(adjacencyArray[i], ref used);
                }
            }

            for (int i = 0, j = 0; i < adjacencyArray.Length; i++)
            {
                LogicGraphVertex vertex = order[adjacencyArray.Length - i - 1];
                if (comp[GetVertexIndex(vertex)] == -1)
                {
                    DfsForTwoCnfSat2(vertex, j++);
                }
            }

            for (int i = 0; i < adjacencyArray.Length; i += 2)
            {
                if (comp[i] == comp[i + 1])
                {
                    return null;
                }
            }

            List<bool> answer = new List<bool>();
            for (int i = 0; i < adjacencyArray.Length; i += 2)
            {
                if (comp[i] > comp[i + 1])
                    answer.Add(true);
                else answer.Add(false);
            }
            return answer;
        }

        public Graph()
        {
            adjacencyList = new List<GraphVertex>();
        }

        /// <summary>
        /// Graph constructor from adjacency matrix. Calls DFS to complete construction. 
        /// </summary>
        /// <param name="matrix"></param>
        public Graph(IntegerSquareMatrix matrix, string name = "")
        {
            adjacencyList = new List<GraphVertex>(matrix.Columns);
            for (int i = 0; i < matrix.Columns; i++)
            {
                ///create List of empty Nodes
                GraphVertex a = new GraphVertex(i);
                adjacencyList.Add(a);
            }
            for (int i = 0; i < matrix.Columns; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        this[i].adjacencyList.Add(this[j]);
                    }
                }
            }
            DFS();
            Name = name;
        }

        public Graph(List<GraphVertex> adjList, string name = "")
        {
            adjacencyList = adjList;
            Name = name;
        }

        public override string ToString()
        {
            string s = "";
            foreach (GraphVertex item in this)
            {
                s += Convert.ToString(item.Number) + "-->{ ";
                foreach (GraphVertex grItem in item.adjacencyList)
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
            int[,] adjArray = new int[adjacencyList.Count, adjacencyList.Count];
            for (int i = 0; i < adjacencyList.Count; i++)
            {
                foreach (GraphVertex item in adjacencyList[i].adjacencyList)
                {
                    adjArray[i, item.Number] = 1;
                }
            }
            return new IntegerSquareMatrix(adjacencyList.Count, adjArray);
        }
        /// <summary>
        /// транспонирует данный граф
        /// </summary>
        /// <param name="gr"></param>
        /// <returns></returns>

        public Graph Transponse()
        {
            List<GraphVertex> tempList = new List<GraphVertex>(this.Count);
            for (int i = 0; i < this.Count; i++)
            {
                GraphVertex newNode = new GraphVertex(i);
                tempList.Add(newNode);
            }
            foreach (GraphVertex item in this)
            {
                foreach (GraphVertex nodeitem in item.adjacencyList)
                {

                    tempList[nodeitem.Number].adjacencyList.Add(tempList[item.Number]);
                }
            }

            return new Graph(tempList);
        }

        /// <summary>
        /// поиск вершины в графе по ее номеру
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public GraphVertex FindNode(int number)
        {

            foreach (GraphVertex item in adjacencyList)
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
            if (adjacencyList[begin].adjacencyList.Contains(adjacencyList[end]) == false)
            {
                adjacencyList[begin].adjacencyList.Add(adjacencyList[end]);
            }
            else
            {
                Console.WriteLine("такое ребро уже есть");
            }

            return this;
        }
        public Graph AddNode(List<int> incoming, List<int> outgoing)
        {
            GraphVertex NewNode = new GraphVertex(adjacencyList.Count);
            foreach (int item in outgoing)
            {
                NewNode.adjacencyList.Add(adjacencyList[item]);
            }
            adjacencyList.Add(NewNode);
            foreach (int item in incoming)
            {
                adjacencyList[item].adjacencyList.Add(adjacencyList[NewNode.Number]);
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
            Queue<GraphVertex> q = new Queue<GraphVertex>();
            Graph graph = new Graph(adjacencyList);
            graph.adjacencyList[0].Color = Colors.Black;
            q.Enqueue(graph.adjacencyList[0]);
            while (q.Count != 0)
            {
                foreach (GraphVertex item in q.Peek().adjacencyList)
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
            foreach (GraphVertex node in adjacencyList)
            {
                node.Color = Colors.White;
                //node.Ancestor = null;
            }
            int time = 0;
            foreach (GraphVertex node in adjacencyList)
            {
                if (node.Color == Colors.White)
                {
                    DfsVisit(node, ref time);
                }
            }
        }
        /// <summary> метод является рекурсивной частью DFS. Его смысл сводится к проставлению времен вхождения и выхода в вершину 
        private void DfsVisit(GraphVertex node, ref int time)
        {
            time++;
            node.Color = Colors.Grey;
            node.OpenTime = time;
            foreach (GraphVertex adjNode in node.adjacencyList)
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


        public IEnumerator<GraphVertex> GetEnumerator()
        {
            return adjacencyList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return adjacencyList.GetEnumerator();
        }
    }
}

