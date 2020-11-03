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
            var tokens = parser.Tokenize(reader).ToList().ToArray();
            var stack = new Stack<Token>();
            Token rightOp;
            Token leftOp;
            double result;
            for(int i = 0; i < tokens.Length; i++)
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
                        rightOp = stack.Pop();
                        leftOp = stack.Pop();

                        // если в стеке храняться 2 числа

                        if (leftOp.Type == TokenType.Number && rightOp.Type == TokenType.Number)
                        {
                            switch (tokens[i].Value)
                            {

                                case "^":
                                    result = Math.Pow(Convert.ToDouble(leftOp.Value), Convert.ToDouble(rightOp.Value));
                                    stack.Push(new Token(TokenType.Number, result.ToString()));
                                    break;
                                case "*":
                                    result = Convert.ToDouble(leftOp.Value) * Convert.ToDouble(rightOp.Value);
                                    stack.Push(new Token(TokenType.Number, result.ToString()));
                                    break;
                                case "/":
                                    result = Convert.ToDouble(leftOp.Value) / Convert.ToDouble(rightOp.Value);
                                    stack.Push(new Token(TokenType.Number, result.ToString()));
                                    break;
                                case "+":
                                    result = Convert.ToDouble(leftOp.Value) + Convert.ToDouble(rightOp.Value);
                                    stack.Push(new Token(TokenType.Number, result.ToString()));
                                    break;
                                case "-":
                                    result = Convert.ToDouble(leftOp.Value) - Convert.ToDouble(rightOp.Value);
                                    stack.Push(new Token(TokenType.Number, result.ToString()));
                                    break;
                                default:
                                    break;
                            }
                        }
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
