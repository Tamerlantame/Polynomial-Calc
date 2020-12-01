using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arithmetics;
using System.IO;
using System.Diagnostics;

namespace WinFormsUI.Sessions
{
    class PolynomialSession : Session
    {
        private Executor executor;
        public PolynomialSession(RichTextBox input, RichTextBox output) : base(input, output)
        {
            executor = new Executor();
        }

        public override void Execute(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (inputRichTextBox.SelectedText != "")
                {
                    // A:= some expression
                    // A:= A*A;
                    //Вычисляем выделенную часть "кода"
                    var text = inputRichTextBox.SelectedText;
                    outputRichTextBox.Text = executor.Launch(text);
                }
                else
                {
                    try
                    {
                        var text = inputRichTextBox.Text;
                        outputRichTextBox.Text = executor.Launch(text);
                    }
                    finally { }
                }
            }
        }
    }
}
