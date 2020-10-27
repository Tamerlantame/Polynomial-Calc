using System;
using System.IO;
using System.Windows.Forms;
using ConsoleUI.Forms;
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

      //!!!!!!!!!!!!!!!!
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string title = "untitled " + (tabControl1.TabCount + 1).ToString();

            RichTextBox newRichTextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(0, 0),
                //  Name = newTabPage.Name,

                Text = ""
            };
            GraphSession newSession = new GraphSession(newRichTextBox, richTextBoxOutput);
           
                LyaMelikTabPage newTabPage = new LyaMelikTabPage(newSession)
                {
                    Name = title
                };
            newRichTextBox.Size = newTabPage.Size;



            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);

            newTabPage.Controls.Add(newRichTextBox);
            newSession.Start();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tabControl1.SelectedTab.Name;
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
