using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arithmetics.Polynomial1;
using Arithmetics.Parsers;
using Arithmetics;
using System.IO;
using System.Diagnostics;

namespace WinFormsUI.Sessions
{
    class PolynomialSession : Session
    {

        private Сulculator calculator;
        public PolynomialSession(RichTextBox input, RichTextBox output) : base(input, output)
        {
            calculator = new Сulculator();
        }
        public void Start()
        {
            inputRichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(Execute);
            //outputRichTextBox.Text += $"{Name} - session Execution: \n";
        }
        /// <summary>
        /// Вычисляет последнюю строчку программы, если нажали Enter. 
        /// </summary>
        private void Execute(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (inputRichTextBox.SelectedText != "")
                {
                    // A:= some expression
                    // A:= A*A;
                    //Вычисляем выделенную часть "кода"
                    var text = inputRichTextBox.SelectedText;
                    outputRichTextBox.Text = calculator.Execute(text);
                }
                else
                {
                    var text = inputRichTextBox.Lines.Last();
                    outputRichTextBox.Text = calculator.Execute(text);
                }
            }

        }
    }
}
