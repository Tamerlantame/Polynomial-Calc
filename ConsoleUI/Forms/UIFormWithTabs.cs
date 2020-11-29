using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ConsoleUI.Forms;
using ConsoleUI.Sessions;
using WinFormsUI.Sessions;

namespace WinFormsUI.Forms
{

    public partial class UIFormWithTabs : Form

    {
        private Point ImageLocation = new Point(13, 5);
        private Point ImgHitArea = new Point(13, 2);

        Image CloseImage;
        public UIFormWithTabs()
        {
            InitializeComponent();
            CreateGraphSession();
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
            CreateGraphSession();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;

            currentPage.CurrentSession.SaveSession();
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void CreateGraphSession()
        {
            string title = "GraphSession " + (tabControl1.TabCount + 1).ToString();

            RichTextBox newRichTextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(0, 0),
                Name = title,
                Size = richTextBox1.Size,
                Text = ""
            };
            GraphSession newSession = new GraphSession(newRichTextBox, richTextBoxOutput);
            LyaMelikTabPage newTabPage = new LyaMelikTabPage(newSession)
            {
                Name = title
            };
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);
            newTabPage.Controls.Add(newRichTextBox);

            newSession.Start();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sessionText = File.ReadAllText(dialog.FileName);
                LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;
                currentPage.CurrentSession.SetInputBoxText(sessionText);
            }
        }

        private void UIFormWithTabs_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;
            CloseImage = ConsoleUI.Properties.Resources.CrossImage;
            tabControl1.Padding = new Point(10, 3);
        }
        private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            try
            {
                Image img = new Bitmap(CloseImage);
                Rectangle r = e.Bounds;
                r = this.tabControl1.GetTabRect(e.Index);
                r.Offset(2, 2);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;
                string title = this.tabControl1.TabPages[e.Index].Text;

                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));

                if (tabControl1.SelectedIndex >= 1)
                {
                    e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - ImageLocation.X), ImageLocation.Y));
                }
            }
            catch (Exception) { }
        }
        private void TabControl1_Mouse_Click(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            int tabWidth = this.tabControl1.GetTabRect(tc.SelectedIndex).Width - ImgHitArea.X;
            Rectangle rect = this.tabControl1.GetTabRect(tc.SelectedIndex);
            rect.Offset(tabWidth, ImgHitArea.Y);
            rect.Width = 100;
            rect.Height = 100;
            if (tabControl1.SelectedIndex >= 1)
            {
                if (rect.Contains(e.Location))
                {
                    TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                    tc.TabPages.Remove(TabP);
                }
            }

        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            createLogicSession();
        }

        private void createLogicSession()
        {
            string title = "LogicSession " + (tabControl1.TabCount + 1).ToString();

            RichTextBox newRichTextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(0, 0),
                Name = title,
                Size = richTextBox1.Size,
                Text = ""
            };
            LogicSession newSession = new LogicSession(newRichTextBox, richTextBoxOutput);
            LyaMelikTabPage newTabPage = new LyaMelikTabPage(newSession)
            {
                Name = title
            };
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);
            newTabPage.Controls.Add(newRichTextBox);
        }
    }
}
