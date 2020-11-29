using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logics
{
    public class BooleanExpression
    {
        public List<(string, string)> booleanExpression = new List<(string, string)>();

        public BooleanExpression(string booleanExpression)
        {
            ParserOfBooleanExpression(booleanExpression);
        }

        private void ParserOfBooleanExpression(string booleanExpression)
        {
            for (int i = 0; i < booleanExpression.Length; i++)
            {
                if (booleanExpression[i] == '(')
                {
                    string firstValue;
                    string secondValue;
                    if (booleanExpression[i + 1] == '~')
                    {
                        firstValue = booleanExpression[i + 1].ToString() + booleanExpression[i + 2]
                            + booleanExpression[i + 3];
                        i += 6;
                    }
                    else
                    {
                        firstValue = booleanExpression[i + 1].ToString() + booleanExpression[i + 2];
                        i += 5;
                    }

                    if (booleanExpression[i] == '~')
                    {
                        secondValue = booleanExpression[i].ToString() + booleanExpression[i + 1] 
                            + booleanExpression[i + 2];
                        i += 3;
                    }
                    else
                    {
                        secondValue = booleanExpression[i].ToString() + booleanExpression[i + 1];
                        i += 2;
                    }
                    this.booleanExpression.Add((firstValue, secondValue));
                }
            }
        }
    }
}
