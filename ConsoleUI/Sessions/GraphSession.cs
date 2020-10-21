using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphTheory;
using WinFormsUI;

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
            
        }
    }
}
