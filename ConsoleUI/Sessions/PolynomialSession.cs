using System.Windows.Forms;
using Arithmetics.Polynomial1;
using ElementaryInterpreter;

namespace WinFormsUI.Sessions
{
    class PolynomialSession : Session
    {
        private readonly Executor<Polynomial> executor;
        public PolynomialSession(RichTextBox input, RichTextBox output) : base(input, output)
        {
            executor = new Executor<Polynomial>();
        }

        public override void Execute(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                CommandStory.Add(inputRichTextBox.Text);
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
