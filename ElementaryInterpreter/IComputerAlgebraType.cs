using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryInterpreter
{
    public interface IComputerAlgebraType
    {
        IComputerAlgebraType ParseExpression(string expr);
    }
}
