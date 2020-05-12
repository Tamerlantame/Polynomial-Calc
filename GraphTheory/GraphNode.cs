using System.Collections.Generic;

namespace GraphTheory
{
    public class GraphNode
    {
        public List<GraphNode> adjList;
        public enum Colors
        {
            Grey, Black, White
        }
        public Colors Color;
        public int Number;
        public int OpenTime;
        public int CloseTime;
        public GraphNode Ancestor;//предшественник данной вершины; вспомогательное поле для некоторых методов
       
    
        public GraphNode()
        {
            adjList = new List<GraphNode>();
            Color = Colors.Grey;
            OpenTime = -1;
            CloseTime = -1;
        }
        public GraphNode CreateNode(int num, List<GraphNode> list)
        {
            GraphNode a = new GraphNode();
            a.Number = num;
            adjList = list;
            return a;

        }
    }

}




