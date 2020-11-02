using System;
using System.Collections.Generic;
using System.IO;
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
        public void SaveSession()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\\LyaMelik");
            if (!dirInfo.Exists) dirInfo.Create();
            //TODO имена будут повторяться, решить это
            File.WriteAllLines(Path.Combine(dirInfo.FullName, Name), CommandStory);
        }

    }
}
