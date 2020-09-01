using System.Collections.Generic;

namespace GraphTheory
{
    public enum Colors
    {
        Grey, Black, White
    }
    public class GraphNode
    {
        public List<GraphNode> adjList;
        public Colors Color;
        public int Number;
        public int OpenTime;
        public int CloseTime;
        
        // TODO Здесь у меня вопрос. Не удобнее ли сделать White, 0, 0?
        public GraphNode()
        {
            adjList = new List<GraphNode>();
            Color = Colors.Grey;
            OpenTime = -1;
            CloseTime = -1;
        }
    }

}




