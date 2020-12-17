using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryInterpreter
{
    public class Calculator<T> where T : IComputerAlgebraType, new()
    {
        public Dictionary<string, T> Vars { get; private set; }
        public Calculator()
        {
            Vars = new Dictionary<string, T>();
        }
        public string Execute(string expr)
        {
            return "";
        }
    }
}
