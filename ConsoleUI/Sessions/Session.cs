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
            inputRichTextBox.KeyDown += new KeyEventHandler(Execute);
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
       
        public void SetOutputBoxText(string text)
        {
            outputRichTextBox.Text = "";
            outputRichTextBox.Text = text;
        }
        public void SetOutputBoxText(string[] text)
        {
            outputRichTextBox.Text = "";
            foreach (string item in text)
            {
                outputRichTextBox.Text = outputRichTextBox.Text + item + "\n";
            }
        }

        /// <summary>
        /// Вычисляет последнюю строчку программы, если нажали Enter. 
        /// После необходимо сделать, чтобы "вычислялась" выделенная пользователем часть программы.
        /// </summary>
        public abstract void Execute(object sender, KeyEventArgs e);
    }
}
