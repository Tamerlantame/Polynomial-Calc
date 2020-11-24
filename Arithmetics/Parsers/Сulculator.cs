using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Arithmetics.Parsers;

namespace Arithmetics
{
    public class Сulculator
    {
        private delegate Token Computation(Token leftOp, Token rightOp);

        /// <summary>
        /// Парсит строку в обратную польскую запись
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string ExpressionToRPN(string expression)
        {
            var text = expression;
            var reader = new StringReader(text);
            var parser = new Parser();
            var tokens = parser.Tokenize(reader).ToList();
            var rpn = parser.ShuntingYard(tokens);
            var rpnStr = string.Join(" ", rpn.Select(t => t.Value));
            return rpnStr;
        }
        /// <summary>
        /// вычисляет выражение, записанное в RPN(обратная польская запись)
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string RPNtoAnswer(string expression)
        {
            var text = expression;
            var reader = new StringReader(text);
            var parser = new Parser();
            var tokens = parser.Tokenize(reader).ToArray();
            var stack = new Stack<Token>();
            Token leftOp, rightOp;
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i].Type)
                {
                    case TokenType.Number:
                        stack.Push(tokens[i]);
                        break;
                    case TokenType.Variable:
                        stack.Push(tokens[i]);
                        break;
                    //case TokenType.Function:
                    //    stack.Push(tok);
                    //    break;
                    case TokenType.Operator:
                        try
                        {
                            rightOp = stack.Pop();
                            leftOp = stack.Pop();
                        }
                        catch (System.InvalidOperationException)
                        {
                            throw new System.InvalidOperationException();
                        }
                        
                        double result = Operator.GetOperators()[tokens[i].Value].function(Convert.ToDouble(leftOp.Value), Convert.ToDouble(rightOp.Value));
                        stack.Push(new Token(TokenType.Number, result.ToString()));
                        break;

                    default:
                        throw new Exception("Wrong token");
                }
            }
            text = stack.Pop().Value;

            return text;
        }

    }
}
