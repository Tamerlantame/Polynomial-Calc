using System.Collections.Generic;

namespace GraphTheory
{
    public enum Colors
    {
        Grey, Black, White
    }
    public class GraphVertex
    {
        public List<GraphVertex> adjacencyList;
        public Colors Color;
        public int Number;
        public int OpenTime;
        public int CloseTime;

        public bool isMoreZero;

        // TODO Здесь у меня вопрос. Не удобнее ли сделать White, 0, 0?
        public GraphVertex()
        {
            adjacencyList = new List<GraphVertex>();
            Color = Colors.Grey;
            OpenTime = 0;
            CloseTime = 0;
        }
    }

}