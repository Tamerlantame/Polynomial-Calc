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


namespace WinFormsUI.Sessions
{
    class PolynomialSession : Session
    {
        public PolynomialSession(RichTextBox input, RichTextBox output) : base(input, output)
        {

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
                    //Вычисляем выделенную часть "кода"
                    var text = inputRichTextBox.SelectedText;
                    outputRichTextBox.Text = Сulculator.RPNtoAnswer(Сulculator.ExpressionToRPN(text));
                }
                else
                {
                    var text = inputRichTextBox.Lines.Last();
                    outputRichTextBox.Text = Сulculator.RPNtoAnswer(Сulculator.ExpressionToRPN(text));
                }
            }

        }
    }
}
