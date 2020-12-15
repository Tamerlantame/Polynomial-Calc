using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ConsoleUI.Forms;
using WinFormsUI.Sessions;

namespace WinFormsUI.Forms
{

    public partial class UIFormWithTabs : Form
    {
        private int TabNumber;

        public UIFormWithTabs()
        {
            InitializeComponent();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentTabPage = (LyaMelikTabPage)tabControl1.SelectedTab;
            string[] text = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Menu//GraphHelp.txt"));
            currentTabPage.OutputRichTextBox.Text = "";
            foreach (string item in text)
            {
                currentTabPage.OutputRichTextBox.Text = currentTabPage.OutputRichTextBox.Text + item + "\n";
            }
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabNumber++;
            LyaMelikTabPage newTabPage = null;
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (graphToolStripMenuItem.DropDownItems.Contains(menuItem))
            {
                string title = "Graph Session" + TabNumber;
                newTabPage = new GraphLyaMelikTabPage(title);
            }
            else if (polynomialToolStripMenuItem.DropDownItems.Contains(menuItem))
            {
                string title = "Polynomial Session " + TabNumber;
                newTabPage = new PolynomialLyaMelikTabPage(title);
            }
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;
            currentPage.Session.SaveSession();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateToolStripMenuItem_Click(sender, e);
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sessionText = File.ReadAllText(dialog.FileName);
                LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;
                currentPage.InputRichTextBox.Text = sessionText;
            }
        }
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Image CloseImage = ConsoleUI.Properties.Resources.CrossImage;
            Image img = new Bitmap(CloseImage);
            Point ImageLocation = new Point(13, 5);
            Rectangle r = tabControl1.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = Font;
            string title = tabControl1.TabPages[e.Index].Text;

            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (tabControl1.GetTabRect(e.Index).Width - ImageLocation.X), ImageLocation.Y));

        }
        private void TabControl1_Mouse_Click(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            Point ImgHitArea = new Point(13, 2);
            int tabWidth = tabControl1.GetTabRect(tc.SelectedIndex).Width - ImgHitArea.X;
            Rectangle rect = tabControl1.GetTabRect(tc.SelectedIndex);
            rect.Offset(tabWidth, ImgHitArea.Y);
            rect.Width = 100;
            rect.Height = 100;
            {
                if (rect.Contains(e.Location))
                {
                    TabPage TabP = tc.TabPages[tc.SelectedIndex];
                    tc.TabPages.Remove(TabP);
                }
            }
        }
    }
}
