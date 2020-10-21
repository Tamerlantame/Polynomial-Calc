using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsUI.Sessions;

namespace WinFormsUI.Forms
{
    public partial class UIFormWithTabs : Form
    {
        public UIFormWithTabs()
        {
            InitializeComponent();
            GraphSession newSession = new GraphSession(richTextBox1, richTextBoxOutput);
            newSession.Start();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxOutput.Text = "";
            string[] text = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Menu//GraphHelp.txt"));
            foreach (string item in text)
            {
                richTextBoxOutput.Text = richTextBoxOutput.Text + item + "\n";
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "untitled " + (tabControl1.TabCount + 1).ToString();
            TabPage newTabPage = new TabPage(title)
            {
                Name = title
            };
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);
            RichTextBox newRichTextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(0, 0),
                Name = newTabPage.Name,
                Size = newTabPage.Size,
                Text = ""
            };
            newTabPage.Controls.Add(newRichTextBox);
            GraphSession newSession = new GraphSession(newRichTextBox, richTextBoxOutput);
            newSession.Start();
        }
    }
}
