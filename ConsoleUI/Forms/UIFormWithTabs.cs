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
        private Point ImageLocation = new Point(13, 5);
        private Point ImgHitArea = new Point(13, 2);
        private int TabNumber;

        Image CloseImage;
        public UIFormWithTabs()
        {
            InitializeComponent();
            //CreateGraphSession();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentTabPage = (LyaMelikTabPage)tabControl1.SelectedTab;
            string[] text = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Menu//GraphHelp.txt"));
            currentTabPage.OutputRichTextBox.Text = "";
            foreach (string item in text)
            {
                currentTabPage.OutputRichTextBox.Text = currentTabPage.OutputRichTextBox.Text + item + "\n";
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabNumber++;
            string title = "Graph Session" + TabNumber;
            GraphLyaMelikTabPage newTabPage = new GraphLyaMelikTabPage(title);
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;
            // ?
            //currentPage.CurrentSession.SaveSession();
            LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;
            currentPage.Session.SaveSession();
        }
     
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createToolStripMenuItem_Click(sender, e);
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sessionText = File.ReadAllText(dialog.FileName);
                LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;
                currentPage.InputRichTextBox.Text = sessionText;
            }
        }

        private void UIFormWithTabs_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += tabControl1_DrawItem;
            CloseImage = ConsoleUI.Properties.Resources.CrossImage;
            tabControl1.Padding = new Point(10, 3);
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

            Image img = new Bitmap(CloseImage);
            Rectangle r = e.Bounds;
            r = this.tabControl1.GetTabRect(e.Index);
            r.Offset(2, 2);
            Brush TitleBrush = new SolidBrush(Color.Black);
            Font f = this.Font;
            string title = this.tabControl1.TabPages[e.Index].Text;

            e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
            e.Graphics.DrawImage(img, new Point(r.X + (this.tabControl1.GetTabRect(e.Index).Width - ImageLocation.X), ImageLocation.Y));

        }
        private void TabControl1_Mouse_Click(object sender, MouseEventArgs e)
        {
            TabControl tc = (TabControl)sender;
            int tabWidth = this.tabControl1.GetTabRect(tc.SelectedIndex).Width - ImgHitArea.X;
            Rectangle rect = this.tabControl1.GetTabRect(tc.SelectedIndex);
            rect.Offset(tabWidth, ImgHitArea.Y);
            rect.Width = 100;
            rect.Height = 100;
            {
                if (rect.Contains(e.Location))
                {
                    TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                    tc.TabPages.Remove(TabP);
                }

            }
        }


        //Относится к PolynomialSession
        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabNumber++;
            string title = "Polynomial Session " + TabNumber;
            PolynomialLyaMelikTabPage newTabPage = new PolynomialLyaMelikTabPage(title);
            tabControl1.TabPages.Add(newTabPage);
            tabControl1.SelectTab(newTabPage);
        }

        private void SaveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;
            currentPage.Session.SaveSession(); 
        }

        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string sessionText = File.ReadAllText(dialog.FileName);
                LyaMelikTabPage currentPage = (LyaMelikTabPage)tabControl1.SelectedTab;
                currentPage.InputRichTextBox.Text = sessionText; 
            }
        }
    }
}
