using System;
using System.Collections.Generic;
using System.IO;
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
        protected List<string> CommandStory; 

        public Session(RichTextBox input, RichTextBox output)
        {
            inputRichTextBox = input;
            outputRichTextBox = output;
            Name = inputRichTextBox.Name;
            CommandStory = new List<string>();
        }
        private void SaveSession()
        {

            foreach (string item in CommandStory)
            {
                string writePath = @"C:\";
                using (StreamWriter sw = new StreamWriter(writePath, true))
                {
                    sw.WriteLine(item);
                }
            }
        }

    }
}
