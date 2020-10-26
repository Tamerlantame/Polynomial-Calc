using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    /// <summary>
    /// Вероятно, совершенно не нужный класс, но удобный для того, чтобы "началась работа".
    /// Ничего в нём нет отличного от <see cref="Arithmetics.Parsers.PolynomialExpressionParser"/>
    /// Сейчас же просто преобразует строку с только одним оператором, создания графа.
    /// </summary>
    public class GraphExpressionParser
    {
        public static GraphExecutionExecutionResult Execute(string expr)
        {
            List<Exception> exceptionsList = new List<Exception>();
            List<Graph> graphsList = new List<Graph>();
            if (expr.Contains("CreateFromFile"))
            {
                try
                {
                    int startIndex = expr.IndexOf("(\"") + 2;
                    int endIndex = expr.IndexOf("\")");
                    string path = expr.Substring(startIndex, endIndex-startIndex);
                    string name = expr.Contains(":=") ? expr.Substring(0, expr.IndexOf(":=")) : "";
                    Arithmetics.Matrix.IntegerSquareMatrix graphMatrix = null;
                    graphMatrix = new Arithmetics.Matrix.IntegerSquareMatrix(path);
                    if (graphMatrix.Columns == 0)
                    {
                        exceptionsList.Add(new FormatException("Incorrect matrix size in file"));
                    }
                    graphsList.Add(new Graph(graphMatrix, name));
                }
                catch(Exception e)
                {
                    exceptionsList.Add(e);
                }
            }
            else
            {
                exceptionsList.Add(new NotImplementedException($"Expression {expr} can not be executed"));
            }
            return new GraphExecutionExecutionResult(exceptionsList, graphsList);
        }
    }

    /// <summary>
    /// Шаблон класса-результата вычисления выражения. 
    /// </summary>
    public class GraphExecutionExecutionResult
    {
        public List<Exception> ExceptionsList { get; private set; }
        public List<Graph> GraphsList { get; private set; }

        public GraphExecutionExecutionResult()
        {
            ExceptionsList = new List<Exception>();
            GraphsList = new List<Graph>();
        }
        public GraphExecutionExecutionResult(List<Exception> exceptions, List<Graph> graphs)
        {
            ExceptionsList = new List<Exception>(exceptions);
            GraphsList = new List<Graph>(graphs);
        }

    }
}
