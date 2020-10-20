using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphTheory;

namespace ConsoleUI
{
    class FormSession
    {
        private SortedList<string, Graph> graphs;
        public FormSession()
        {
            graphs = new SortedList<string, Graph>();
        }
        public FormSession(SortedList<string, Graph> graphs)
        {
            this.graphs = new SortedList<string, Graph>(graphs);
        }



    }
}
