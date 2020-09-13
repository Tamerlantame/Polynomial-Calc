using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics.Polynomial

{
    class InvalidPolynomialStringException : Exception
    {
        public InvalidPolynomialStringException(string massage) : base(massage)
        {

        }
        public InvalidPolynomialStringException() : base()
        {


        }
    }
}
