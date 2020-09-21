using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public static class GraphBasicFunctions
    {
        public static int GraphDiam(Graph graph)
        {
            int Diam = 0;
            var q = new Queue<ValueTuple<int, GraphNode>>();
            foreach (GraphNode item in graph)
            ///для каждой вершины bfs
            {
                int ItemDiam = 0;
                foreach (GraphNode node in graph)
                {
                    node.Color = Colors.Grey;
                }
                item.Color = Colors.Black;
                q.Enqueue((0, item));
                while (q.Count != 0)
                {
                    foreach (GraphNode Counter in q.Peek().Item2.adjList)
                    {
                        if (Counter.Color == Colors.Grey)
                        {
                            q.Enqueue((q.Peek().Item1 + 1, Counter));
                            ItemDiam = q.Peek().Item1 + 1;
                            Counter.Color = Colors.Black;
                        }
                    }
                    q.Dequeue();
                }
                if (ItemDiam > Diam) { Diam = ItemDiam; }
            }
            return Diam;
        }

        /// <summary>
        /// Топологическая сортировка вершин графа. Возвращает null, если в графе есть циклы.
        /// </summary>
        /// <param name="graph"></param>
        /// <returns>Отсортированный массив вершин, если в графе нет циклов, иначе возвращает null</returns>
        public static GraphNode[] TopolSort(Graph graph)
        {
            GraphNode[] sorted = null;
            if (!graph.HasCycle)
            {
                sorted = new GraphNode[graph.Count()];
                for (int i = 0; i < graph.Count(); i++)
                {
                    sorted[i] = graph[i];
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
            }
            return sorted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static List<List<GraphNode>> StrongConectedComponents(Graph graph)
        {
            List<List<GraphNode>> SCC = new List<List<GraphNode>>();
            Graph transponded = graph.Transponse();
            foreach (GraphNode node in transponded)
            {
                node.Color = Colors.White;// ??????????
            }
            List<int> visited = new List<int>();
            int maxTimeNumber;//сюда будем помещать номер вершины-корня очередного обхода в глубину
            while (visited.Count != graph.Count())//запустим дфс для каждой css
            {
                maxTimeNumber = 0;
                while (visited.Contains(maxTimeNumber)) maxTimeNumber++;
                foreach (GraphNode item in graph)
                {
                    if (!visited.Contains(item.Number) && graph[item.Number].CloseTime > graph[maxTimeNumber].CloseTime)
                    {
                        maxTimeNumber = item.Number;//ищем вeршину с максимальным closeTime в graph и берем за корень вершину с тем же номером в transponded
                    }
                }
                foreach (GraphNode node in transponded) // ???????????????????/
                {
                    node.CloseTime = 0;
                    node.OpenTime = 0;
                }
                List<GraphNode> StrongComponent = new List<GraphNode>();
                foreach (GraphNode item in transponded)
                {
                    if (item.CloseTime > 0)
                    {
                        visited.Add(item.Number);
                        StrongComponent.Add(item);
                    }
                }
                SCC.Add(StrongComponent);
            }
            return SCC;
        }
    }
}
