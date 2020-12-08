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
        private SortedList<string, Graph> Graphs;
        private List<Exception> Exceptions;

        public GraphSession(RichTextBox input, RichTextBox output) : base(input, output) {
            Graphs = new SortedList<string, Graph>();
            Exceptions = new List<Exception>();
        }
        public GraphSession(RichTextBox input, RichTextBox output, SortedList<string, Graph> graphs) : base(input, output)
        {
            this.Graphs = new SortedList<string, Graph>(graphs);
            Exceptions = new List<Exception>();
        }

        public override void Execute(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CommandStory.Add(inputRichTextBox.Text);

                GraphExpressionParser.Execute(inputRichTextBox.Text, Exceptions, Graphs, outputRichTextBox);


                //foreach (Exception exc in Exceptions)
                //{
                //    this.outputRichTextBox.Text += $"{exc.Message}\n";
                //}

                //foreach(Graph g in Graphs)
                //   {
                //   this.outputRichTextBox.Text += $"{g}\n";

            }
        }
    }
}
