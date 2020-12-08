using System.Windows.Forms;
using WinFormsUI.Sessions;

namespace ConsoleUI.Forms
{
    abstract class LyaMelikTabPage : TabPage
    {
        public Session Session;
        public RichTextBox InputRichTextBox { get; }
        public RichTextBox OutputRichTextBox { get; set; }
        public LyaMelikTabPage(string name) : base(name)//Session ses) : base(ses.Name)
        {
            InputRichTextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(0, 0),
                Margin = new Padding(4),
                Name = name,
                Size = new System.Drawing.Size(1021, 288),
                TabIndex = 0,
                Text = ""
            };
            OutputRichTextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(0, 296),
                Name = "richTextBoxOutput",
                ReadOnly = true,
                Size = new System.Drawing.Size(767, 100),
                Text = "",
            };
            Controls.Add(InputRichTextBox);
            Controls.Add(OutputRichTextBox);
        }
    }
}
