using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    public interface ISequerence<T>
    {
        T Next();
    }
    public interface ISeries<T> : ISequerence<T>
    {
        void Reset();
        T Prev();
    }
}
