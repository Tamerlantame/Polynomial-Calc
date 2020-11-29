using System;
using System.Collections.Generic;
using GraphTheory;

namespace Logics
{
    public class LogicGraph : Graph
    {
        private List<LogicGraphVertex> order;
        private int[] comp;
        public LogicGraph(List<(string, string)> booleanExpression)
        {
            int max = -1;
            foreach (var item in booleanExpression)
            {
                max = Math.Max(max, GetNumber(item.Item1));
                max = Math.Max(max, GetNumber(item.Item2));
            }

            adjacencyList = new List<GraphVertex>(max * 2);
            for (int i = 0; i < max; i++)
            {
                LogicGraphVertex graphNode1 = new LogicGraphVertex(i + 1, true);
                adjacencyList.Add(graphNode1);
                //adjacencyList[2 * i] = graphNode1;

                LogicGraphVertex graphNode2 = new LogicGraphVertex(i + 1, false);
                adjacencyList.Add(graphNode1);
                //adjacencyList[2 * i + 1] = graphNode2;
            }

            foreach (var item in booleanExpression)
            {
                if (item.Item1[0] != '~' && item.Item2[0] != '~')
                {
                    adjacencyList[(GetNumber(item.Item1) - 1) * 2 + 1].adjacencyList.
                        Add(adjacencyList[(GetNumber(item.Item2) - 1) * 2]);
                    adjacencyList[(GetNumber(item.Item2) - 1) * 2 + 1].adjacencyList.
                        Add(adjacencyList[(GetNumber(item.Item1) - 1) * 2]);
                }

                else if (item.Item1[0] != '~' && item.Item2[0] == '~')
                {
                    adjacencyList[(GetNumber(item.Item1) - 1) * 2 + 1].adjacencyList.
                        Add(adjacencyList[(GetNumber(item.Item2) - 1) * 2 + 1]);
                    adjacencyList[(GetNumber(item.Item2) - 1) * 2].adjacencyList.
                        Add(adjacencyList[(GetNumber(item.Item1) - 1) * 2]);
                }

                else if (item.Item1[0] == '~' && item.Item2[0] != '~')
                {
                    adjacencyList[(GetNumber(item.Item1) - 1) * 2].adjacencyList.
                        Add(adjacencyList[(GetNumber(item.Item2) - 1) * 2]);
                    adjacencyList[(GetNumber(item.Item2) - 1) * 2 + 1].adjacencyList.
                        Add(adjacencyList[(GetNumber(item.Item1) - 1) * 2 + 1]);
                }

                else
                {
                    adjacencyList[(GetNumber(item.Item1) - 1) * 2].adjacencyList.
                        Add(adjacencyList[(GetNumber(item.Item2) - 1) * 2 + 1]);
                    adjacencyList[(GetNumber(item.Item2) - 1) * 2].adjacencyList.
                        Add(adjacencyList[(GetNumber(item.Item1) - 1) * 2 + 1]);
                }
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

        private int GetVertexIndex(LogicGraphVertex vertex)
        {
            if (vertex.IsPositive)
            {
                return (vertex.Number - 1) * 2;
            }
            return (vertex.Number - 1) * 2 + 1;
        }

        private void DfsForTwoCnfSat1(LogicGraphVertex vertex, ref bool[] used)
        {
            var intVertex = GetVertexIndex(vertex);
            used[intVertex] = true;
            foreach (LogicGraphVertex item in adjacencyList[intVertex].adjacencyList)
            {
                if (!used[GetVertexIndex(item)])
                {
                    DfsForTwoCnfSat1(item, ref used);
                }
            }
            order.Add(vertex);
        }

    public List<bool> TwoCnfSat()
        {
            bool[] used = new bool[adjacencyList.Count];
            order = new List<LogicGraphVertex>();
            comp = new int[adjacencyList.Count];

            for (int i = 0; i < adjacencyList.Count; i++)
            {
                comp[i] = -1;
                if (!used[i])
                {
                    DfsForTwoCnfSat1(adjacencyList[i] as LogicGraphVertex, ref used);
                }
            }

            for (int i = 0, j = 0; i < adjacencyList.Count; i++)
            {
                LogicGraphVertex vertex = order[adjacencyList.Count - i - 1];
                if (comp[GetVertexIndex(vertex)] == -1)
                {
                    comp[GetVertexIndex(vertex)] = j++;
                }
            }

            List<List<GraphVertex>> strongComponents = GraphBasicFunctions.StrongConectedComponents(this);

            int counter = 1;
            foreach (List<GraphVertex> listOfGraphVertex in strongComponents)
            {
                foreach (GraphVertex vertex in listOfGraphVertex)
                    comp[GetVertexIndex((LogicGraphVertex)vertex)] = counter;
                counter++;
            }


            for (int i = 0; i < adjacencyList.Count; i += 2)
            {
                if (comp[i] == comp[i + 1])
                {
                    return null;
                }
            }

            List<bool> answer = new List<bool>();
            for (int i = 0; i < adjacencyList.Count; i += 2)
            {
                if (comp[i] > comp[i + 1])
                    answer.Add(true);
                else answer.Add(false);
            }
            return answer;
        }
    }
}
