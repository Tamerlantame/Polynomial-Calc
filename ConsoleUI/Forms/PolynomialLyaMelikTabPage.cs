using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsUI.Sessions;

namespace ConsoleUI.Forms
{
    class PolynomialLyaMelikTabPage : LyaMelikTabPage
    {
        public PolynomialLyaMelikTabPage(string name) : base(name)
        {
            Session = new PolynomialSession(InputRichTextBox, OutputRichTextBox);
        }
    }
}
