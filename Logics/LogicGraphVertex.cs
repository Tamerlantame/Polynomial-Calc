using GraphTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    class LogicGraphVertex : GraphVertex
    {
        // boolean value for the vertex
        public bool IsPositive;
        public LogicGraphVertex(int number, bool isMoreZero) : base(number)
        {
            adjacencyList = new List<GraphVertex>();
            Color = Colors.Grey;
            OpenTime = 0;
            CloseTime = 0;
            this.IsPositive = isMoreZero;
        }
    }
}
