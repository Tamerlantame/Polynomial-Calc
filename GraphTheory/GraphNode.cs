using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetics;

namespace GraphTheory
{
    class GraphNode
    {
        public List<GraphNode> adjList;
        public enum Colors 
        {
            Grey , Black, White
        }
        public Colors NodeColor;
        public int Number;
        public int OpenTime;
        public int CloseTime;
        public GraphNode()
        {
            adjList = new List<GraphNode>();
            NodeColor = Colors.Grey;
        }
    }
   
}
