using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Arithmetics.Parsers;
using Arithmetics.Polynomial1;

namespace Arithmetics
{
    public class Сulculator
    {
        //private delegate Token Computation(Token leftOp, Token rightOp);

        public Dictionary<string, Polynomial> PolyVars { get; private set; }
        public Сulculator()
        {
            PolyVars = new Dictionary<string, Polynomial>();
        }

        /// <summary>
        /// Парсит строку в обратную польскую запись
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private string ExpressionToRPN(string expression)
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
        private string RPNtoAnswer(string expression)
        {
            var text = ExpressionToRPN(expression);
            var reader = new StringReader(text);
            var parser = new Parser();
            var tokens = parser.Tokenize(reader).ToArray();
            var stack = new Stack<Token>();
            Token leftOp, rightOp;
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i].Type)
                {
                    case TokenType.Polynomial:
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
                        Polynomial leftPoly = (leftOp.Type == TokenType.Variable) ? PolyVars[leftOp.Value] : new Polynomial(PolynomialParser.Parse(leftOp.Value));
                        Polynomial rightPoly = (rightOp.Type == TokenType.Variable) ? PolyVars[rightOp.Value] : new Polynomial(PolynomialParser.Parse(rightOp.Value));
                        Polynomial result = Operator.GetOperators()[tokens[i].Value].function(leftPoly, rightPoly);
                        //Convert.ToDouble(leftOp.Value), Convert.ToDouble(rightOp.Value));
                        stack.Push(new Token(TokenType.Polynomial, result.ToString()));
                        break;

                    default:
                        throw new Exception("Wrong token");
                }
            }
            text = stack.Pop().Value;

            return text;
        }

        public string Execute(string operation)
        {
            string result;
            // нужен regex
            if (operation.Contains(":="))
            {
                string[] operands = operation.Split(new string[] { ":="}, StringSplitOptions.None);
                result = RPNtoAnswer(operands[1]);
                if (!PolyVars.ContainsKey(operands[0])) PolyVars.Add(operands[0], new Polynomial(PolynomialParser.Parse(result)));
                else PolyVars[operands[0]] = new Polynomial(PolynomialParser.Parse(result));
                result = $"{operands[0]}={result}";
            }
            else
            {
                result = RPNtoAnswer(operation);
            }
            return result;
        }
    }
}
