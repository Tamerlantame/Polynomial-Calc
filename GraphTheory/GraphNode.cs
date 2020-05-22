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
        // Ancestor, если я не ошибаюсь, мы нигде не используем. Только что-то присваиваем. И вообще нехорошо. Если так, нужно то удалить.
        //public GraphNode Ancestor;//предшественник данной вершины; вспомогательное поле для некоторых методов
        
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




