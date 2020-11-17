using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsUI.Sessions
{
    abstract class Session
    {
        protected  RichTextBox inputRichTextBox;
        protected  RichTextBox outputRichTextBox;
        public string Name { get; }
        protected List<string> CommandStory;
        public Session(RichTextBox input, RichTextBox output)
        {

            inputRichTextBox = input;
            outputRichTextBox = output;
            Name = inputRichTextBox.Name;
            CommandStory = new List<string>();
        }
        public void SaveSession()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.InitialDirectory;
                File.WriteAllLines(path, CommandStory);
            }
        }
        public void SetInputBoxText(string text)
        {
            inputRichTextBox.Text = text;
        }
    }
}
