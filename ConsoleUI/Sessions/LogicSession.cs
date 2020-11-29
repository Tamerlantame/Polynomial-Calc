using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logics;
using WinFormsUI.Sessions;

namespace ConsoleUI.Sessions
{
    class LogicSession : Session
    {
        public LogicSession(RichTextBox input, RichTextBox output) : base(input, output)
        {
            inputRichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(Execute);
        }

        private void Execute(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (inputRichTextBox.SelectedText != "")
                {
                    //Вычисляем выделенную часть программы    
                    //outputRichTextBox.Text += $"{inputRichTextBox.SelectedText}\n";
                }
                else
                {
                    string tempString = inputRichTextBox.Lines.Last();
                    var expression = new BooleanExpression(tempString); // "(~x1\/x2)/\(x1\/~x4)/\(x2\/~x4)/\(x2\/~x5)/\(x3\/x4)"
                    var graph = new LogicGraph(expression.booleanExpression);
                    var answer = graph.TwoCnfSat();
                    outputRichTextBox.Text = "";
                    for (int i = 0; i < answer.Count; i++)
                    {
                        if (answer[i] == true)
                            outputRichTextBox.Text += "x" + (i + 1).ToString() + "=" + 1 + "; ";
                        else
                            outputRichTextBox.Text += "x" + (i + 1).ToString() + "=" + 0 + "; ";
                    }
                }
            }

                
        }
    }
}
