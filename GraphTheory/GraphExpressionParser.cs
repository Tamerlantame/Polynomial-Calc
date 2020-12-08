using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Arithmetics.Matrix;

namespace GraphTheory
{
    /// <summary>
    /// Вероятно, совершенно не нужный класс, но удобный для того, чтобы "началась работа".
    /// Ничего в нём нет отличного от <see cref="Arithmetics.Parsers.Parser"/>
    /// Сейчас же просто преобразует строку с только одним оператором, создания графа.
    /// </summary>
    public class GraphExpressionParser
    {
        readonly static Dictionary<string, Delegate> Commands = new Dictionary<string, Delegate>
        {
            {"CreateFromFile", new Action<string, List<Exception>, SortedList<string,Graph>, RichTextBox >(CreateFromFile) },
            {"Transponse", new Action<string, List<Exception>, SortedList<string,Graph>, RichTextBox >(Transponse) },
            {"SCC", new Action<string, List<Exception>, SortedList<string,Graph>, RichTextBox >(SCC) }
        };
        public static void Execute(string expr, List<Exception> exceptionsList, SortedList<string, Graph> graphsList, RichTextBox output)
        {
            try
            {
                expr.Replace(" ", "");
                foreach (var item in Commands)
                {
                    if (expr.Contains(item.Key))

                    {
                        object[] parametersArray = new object[] { expr, exceptionsList, graphsList, output };
                        item.Value.DynamicInvoke(parametersArray);
                        return;
                    }
                }

                throw new Exception("syntax error");
            }
            catch (Exception e)
            {
                exceptionsList.Add(e);
                output.Text += e.Message;
            }
        }

        public static void CreateFromFile(string expr, List<Exception> exceptionsList, SortedList<string, Graph> graphsList, RichTextBox output)
        {
            try
            {
                int startIndex = expr.IndexOf("(") + 1;
                int endIndex = expr.IndexOf(")");
                string path = expr.Substring(startIndex, endIndex - startIndex);
                string name = expr.Contains(":=") ? expr.Substring(0, expr.IndexOf(":=")) : "";
                var graphMatrix = new IntegerSquareMatrix(IntegerMatrix.GetFromFile(path));


                if (graphMatrix.Columns == 0)
                {
                    exceptionsList.Add(new FormatException("Incorrect matrix size in file"));

                }

                var graph = new Graph(graphMatrix, name);
                graphsList.Add(name, graph);
                output.Text = graph.ToString();
            }
            catch (Exception e)
            {
                exceptionsList.Add(e);
                output.Text += e.Message;
            }
        }
        public static void Transponse(string expr, List<Exception> exceptionsList, SortedList<string, Graph> graphsList, RichTextBox output)
        {
            try
            {
                int startIndex = expr.IndexOf("(") + 1;
                int endIndex = expr.IndexOf(")");
                string name = expr.Substring(startIndex, endIndex - startIndex);

                if (!graphsList.Keys.Contains(name))
                {
                    throw new Exception("такого графа не существует");
                }
                else
                {
                    graphsList[name] = graphsList[name].Transponse();
                    output.Text = graphsList[name].ToString();
                }
            }
            catch (Exception e)
            {
                exceptionsList.Add(e);
                output.Text += e.Message;
            }
        }
        public static void SCC(string expr, List<Exception> exceptionsList, SortedList<string, Graph> graphsList, RichTextBox output)
        {
            try
            {
                int startIndex = expr.IndexOf("(") + 1;
                int endIndex = expr.IndexOf(")");
                string name = expr.Substring(startIndex, endIndex - startIndex);

                if (!graphsList.Keys.Contains(name))
                {
                    throw new Exception("такого графа не существует");
                }
                else
                {
                    var list = GraphBasicFunctions.StrongConectedComponents(graphsList[name]);
                    foreach (List<GraphNode> item in list)
                    {
                        foreach(GraphNode node in item)
                        {
                            output.Text += node.Number + " ";
                        }
                        output.Text += "/n";
                    }
                    output.Text = graphsList[name].ToString();
                }
            }
            catch (Exception e)
            {
                exceptionsList.Add(e);
                output.Text += e.Message;
            }
        }
    }
    /// <summary>
    /// Шаблон класса-результата вычисления выражения. 
    /// </summary>
    //public class GraphExecutionExecutionResult
    //{
    //    public List<Exception> ExceptionsList { get; private set; }
    //    public SortedList<string, Graph> GraphsList { get; private set; }

    //    public GraphExecutionExecutionResult()
    //    {
    //        ExceptionsList = new List<Exception>();
    //        GraphsList = new SortedList<string, Graph>();
    //    }
    //    public GraphExecutionExecutionResult(List<Exception> exceptions, SortedList<string, Graph> graphs)
    //    {
    //        ExceptionsList = new List<Exception>(exceptions);
    //        GraphsList = new SortedList<string, Graph>(graphs);
    //    }
    //}
}
