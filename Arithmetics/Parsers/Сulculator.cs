using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Arithmetics;
using Arithmetics.Parsers;
using Arithmetics.Polynomial1;

namespace Arithmetics
{
    class Сulculator
    {

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
        private string ExpressionToRPN(string expression, out List<Token> tokens)
        {
            var text = expression;
            var reader = new StringReader(text);
            var parser = new Parser();
            tokens = parser.Tokenize(reader).ToList();
            var rpn = parser.ShuntingYard(tokens);
            var rpnStr = string.Join(" ", rpn.Select(t => t.Value));
            tokens = rpn.ToList();
            return rpnStr;
        }
        /// <summary>
        /// вычисляет выражение, записанное в RPN(обратная польская запись)
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private string RPNToAnswer(string expression)
        {

            var text = ExpressionToRPN(expression, out var tokensList );
            var tokens = tokensList.ToArray();
            var stack = new Stack<Token>();
            Token leftOp, rightOp;
            Polynomial result;
            for (int i = 0; i < tokens.Length; i++)
            {
                switch (tokens[i].Type)
                {
                    case TokenType.Polynomial:
                        stack.Push(tokens[i]);
                        break;
                    case TokenType.Variable:
                        if (PolyVars.ContainsKey(tokens[i].Value.ToString()))
                            stack.Push(new Token(TokenType.Polynomial, PolyVars[tokens[i].Value].ToString()));
                        else
                            stack.Push(tokens[i]);
                        break;
                    case TokenType.Function:
                        if (Function.GetFunctions()[tokens[i].Value].Type==FunctionType.Unary)
                        {
                            try
                            {
                                leftOp = stack.Pop();
                            }
                            catch (System.InvalidOperationException)
                            {
                                throw new System.InvalidOperationException();
                            }
                            result = Function.GetFunctions()[tokens[i].Value].UFunction
                              (
                              new Polynomial(PolynomialParser.Parse(leftOp.Value))
                              );
                            stack.Push(new Token(TokenType.Polynomial, result.ToString()));
                        }
                        else
                        {
                            try
                            {
                                rightOp = stack.Pop();
                                leftOp = stack.Pop();
                            }
                            catch (System.InvalidOperationException)
                            {
                                throw new System.InvalidOperationException();
                            }
                            result = Function.GetFunctions()[tokens[i].Value].BiFunction
                              (
                              new Polynomial(PolynomialParser.Parse(leftOp.Value)),
                              new Polynomial(PolynomialParser.Parse(rightOp.Value))
                              );
                            stack.Push(new Token(TokenType.Polynomial, result.ToString()));
                        }
                        break;
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

                         result = Operator.GetOperators()[tokens[i].Value].BiOperator
                            (
                            new Polynomial(PolynomialParser.Parse(leftOp.Value)),
                            new Polynomial(PolynomialParser.Parse(rightOp.Value))
                            );
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

        public string Execute(string expression)
        {
            return RPNToAnswer(expression);
        }
        
    }
}
