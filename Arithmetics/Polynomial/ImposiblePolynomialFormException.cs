using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics.Polynomial

{
    class ImposiblePolynomialFormException : Exception
    {
        public ImposiblePolynomialFormException(string massage) : base(massage)
        {

        }
        public ImposiblePolynomialFormException() : base()
        {


        }
    }
}
