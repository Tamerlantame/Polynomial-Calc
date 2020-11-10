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
            Token leftOp, rightOp;//, result;
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
                        //if(Parser.operators.ContainsKey(tokens[i].Value))
                        //Computation computation = new Computation(Add);
                        try
                        {
                            rightOp = stack.Pop();
                            leftOp = stack.Pop();
                        }
                        catch (System.InvalidOperationException)
                        {
                            throw new System.InvalidOperationException();
                        }
                        /*switch (tokens[i].Value)
                        {
                            case "^":
                                computation = Pow;
                                break;
                            case "*":
                                computation = Multiply;
                                break;
                            case "/":
                                computation = Div;
                                break;
                            case "+":
                                computation = Add;
                                break;
                            case "-":
                                computation = Sub;
                                break;
                        }
                        result = computation(leftOp, rightOp);*/
                        double result = Parser.operators[tokens[i].Value].function(Convert.ToDouble(leftOp.Value), Convert.ToDouble(rightOp.Value));
                        stack.Push(new Token(TokenType.Number, result.ToString()));
                        break;

                    default:
                        throw new Exception("Wrong token");
                }
            }
            text = stack.Pop().Value;

            return text;
        }
        private static Token Add(Token leftOp, Token rightOp)
        {
            if (leftOp.Type == TokenType.Number && rightOp.Type == TokenType.Number)
                return new Token(TokenType.Number, Convert.ToString(Convert.ToDouble(leftOp.Value) + Convert.ToDouble(rightOp.Value)));

            return new Token();
        }
        private static Token Sub(Token leftOp, Token rightOp)
        {
            if (leftOp.Type == TokenType.Number && rightOp.Type == TokenType.Number)
                return new Token(TokenType.Number, Convert.ToString(Convert.ToDouble(leftOp.Value) - Convert.ToDouble(rightOp.Value)));

            return new Token();
        }
        private static Token Multiply(Token leftOp, Token rightOp)
        {
            if (leftOp.Type == TokenType.Number && rightOp.Type == TokenType.Number)
                return new Token(TokenType.Number, Convert.ToString(Convert.ToDouble(leftOp.Value) * Convert.ToDouble(rightOp.Value)));

            return new Token();
        }
        private static Token Div(Token leftOp, Token rightOp)
        {
            if (Convert.ToInt32(rightOp.Value) == 0)
                throw new DivideByZeroException("Деление на 0 не поддерживается");
            if (leftOp.Type == TokenType.Number && rightOp.Type == TokenType.Number)
                return new Token(TokenType.Number, Convert.ToString(Convert.ToDouble(leftOp.Value) / Convert.ToDouble(rightOp.Value)));

            return new Token();
        }
        private static Token Pow(Token leftOp, Token rightOp)
        {
            if (leftOp.Type == TokenType.Number && rightOp.Type == TokenType.Number)
                return new Token(TokenType.Number, Convert.ToString(Math.Pow(Convert.ToDouble(leftOp.Value), Convert.ToDouble(rightOp.Value))));

            return new Token();
        }

    }
}
