﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GraphTheory;

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
            if (e.KeyCode == Keys.F5)
            {
                CommandStory.Add(inputRichTextBox.Text);

                GraphExpressionParser.Execute(inputRichTextBox.Lines.Last(), Exceptions, Graphs, outputRichTextBox);
                //GraphExpressionParser.Execute(inputRichTextBox.Text, Exceptions, Graphs, outputRichTextBox);


            }
        }
    }
}
