using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsUI.Sessions;

namespace ConsoleUI.Forms
{
    class GraphLyaMelikTabPage : LyaMelikTabPage
    {
        public GraphLyaMelikTabPage(string name) : base(name)
        {
            Session = new GraphSession(InputRichTextBox, OutputRichTextBox);
        }
    }
}
