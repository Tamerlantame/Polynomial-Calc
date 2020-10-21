using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsUI.Sessions
{
    abstract class Session
    {
        protected readonly RichTextBox inputRichTextBox;
        protected readonly RichTextBox outputRichTextBox;
        public string Name { get; }

        public Session(RichTextBox input, RichTextBox output)
        {
            inputRichTextBox = input;
            outputRichTextBox = output;
            Name = inputRichTextBox.Name;
        }
    }
}
