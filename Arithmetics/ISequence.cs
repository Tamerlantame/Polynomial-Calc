using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics
{
    public interface ISequence<T>
    {
        T Next();
    }
    public interface ISeries<T> : ISequence<T>
    {
        void Reset();
        T Prev();
    }
}
