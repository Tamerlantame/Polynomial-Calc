using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphTheory;
using WinFormsUI;
using System.IO;
using Arithmetics.Parsers;

namespace WinFormsUI.Sessions
{
    class GraphSession : Session
    {
        private SortedList<string, Graph> graphs;

        public GraphSession(RichTextBox input, RichTextBox output) : base(input, output) {
            graphs = new SortedList<string, Graph>();
        }
        public GraphSession(RichTextBox input, RichTextBox output, SortedList<string, Graph> graphs) : base(input, output)
        {
            this.graphs = new SortedList<string, Graph>(graphs);
        }

        public void Start()
        {
            inputRichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(Execute);
            //outputRichTextBox.Text += $"{Name} - session Execution: \n";
        }

        /// <summary>
        /// Вычисляет последнюю строчку программы, если нажали Enter. 
        /// После необходимо сделать, чтобы "вычислялась" выделенная пользователем часть программы.
        /// </summary>
        private void Execute(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(inputRichTextBox.SelectedText != "") {
                    //Вычисляем выделенную часть программы    
                    //outputRichTextBox.Text += $"{inputRichTextBox.SelectedText}\n";
                }
                else
                {
                    var text = inputRichTextBox.Lines.Last();
                    using (var reader = new StringReader(text))
                    {
                        var parser = new Parser();
                        var tokens = parser.Tokenize(reader).ToList();
                        //Console.WriteLine(string.Join("\n", tokens));

                        var rpn = parser.ShuntingYard(tokens);
                        //Console.WriteLine(string.Join(" ", rpn.Select(t => t.Value)));
                        outputRichTextBox.Text = string.Join(" ", rpn.Select(t => t.Value));
                    }
                    //GraphExecutionExecutionResult result = GraphExpressionParser.Execute(inputRichTextBox.Lines.Last());
                    //if (result.ExceptionsList.Count != 0)
                    //{
                    //    foreach (Exception exc in result.ExceptionsList)
                    //    {
                    //        outputRichTextBox.Text += $"{exc.Message}\n";
                    //    }
                    //}
                    //else foreach(Graph g in result.GraphsList)
                    //    {
                    //        outputRichTextBox.Text += $"{g}\n";
                    //    }
                }
            }
            
        }
    }
}
