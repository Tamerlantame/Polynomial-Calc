using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GraphTheory;
using Microsoft.VisualBasic;

namespace ConsoleUI
{
    public partial class UIForm : Form

    {
        private SortedList<string, Graph> graphs;
        private string activeGraph;
        public UIForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphs = new SortedList<string, Graph>();
        }
       
        private void transpose_button_Click(object sender, EventArgs e)
        {
            graphs[activeGraph] = graphs[activeGraph].Transponse();
            richTextBox1.Text = graphs[activeGraph].ToString();
        }

        private void isbiparted_button_Click(object sender, EventArgs e)
        {
            if (graphs.Count != 0)
            {
                var check = graphs[activeGraph].IsBipartite();
                if (check)
                {
                    MessageBox.Show("Этот граф двудолен");
                }
                else
                {
                    MessageBox.Show("Этот граф недвудолен");
                }
            }
            else
            {
                MessageBox.Show("Вы еще не ввели граф");
            }
        }
            
        private void CreateClick()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;


                Arithmetics.Matrix.IntegerSquareMatrix graphMatrix = new Arithmetics.Matrix.IntegerSquareMatrix(path);
                if (graphMatrix.Columns == 0)
                {
                    return;
                }
                string name = Interaction.InputBox("Введите имя графа", "", "");
                if (graphs.ContainsKey(name) == false)
                {
                    Graph NewGraph = new Graph(graphMatrix);
                    graphs.Add(name, NewGraph);
                    activeGraph = name;
                    richTextBox1.Text = "";
                    richTextBox1.Text= graphs[activeGraph].ToString();
                    graphsToolStripMenuItem.DropDownItems.Add(name);

                    DialogResult result = MessageBox.Show("Граф " + name + " успешно добавлен");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Граф c таким именем уже существует");
                }
            }

        }
       

        private void graphsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == createToolStripMenuItem)
            {
                try
                {
                    CreateClick();
                }
                catch
                {
                    DialogResult result = MessageBox.Show(e.ToString());

                }
            }
            else ChangeActiveGraph(e.ClickedItem.Text);
        }
        public void ChangeActiveGraph(string name)
        {
            activeGraph = name;
            richTextBox1.Text = graphs[activeGraph].ToString();

        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string[] text = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Help.txt"));
            foreach (string item in text)
            {
                richTextBox1.Text = richTextBox1.Text + item + "\n";
            }
        }
    }


}


