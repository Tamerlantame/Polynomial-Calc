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

        private void help_button_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string[] text = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Help.txt"));
            foreach (string item in text)
            {
                richTextBox1.Text = richTextBox1.Text + item + "\n";
            }

        }

        private void create_button_Click(object sender, EventArgs e)
        {

            string path = Interaction.InputBox("Введите путь к графу", "", "");

            try
            {
                Arithmetics.Matrix.IntegerSquareMatrix graphMatrix = new Arithmetics.Matrix.IntegerSquareMatrix(path);
                if (graphMatrix.columns == 0)
                {
                    return;
                }
                string name = Interaction.InputBox("Введите имя графа", "", "");
                if (graphs.ContainsKey(name) == false)
                {
                    Graph NewGraph = new Graph(graphMatrix);
                    graphs.Add(name, NewGraph);
                    Console.WriteLine("Граф " + name + " успешно добавлен");
                    activeGraph = name;
                    richTextBox1.Text = graphs[activeGraph].ToString();
                    graphs_ToolStripMenuItem.DropDownItems.Add(name);

                }
                else
                {
                    Console.WriteLine("это имя уже занято");
                }
            }
            catch
            {
                dialogue_value.Text = "Вы ввели что-то не то";
                return;
            }


        }

        private void graphs_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void delete_button_Click(object sender, EventArgs e)
        {for (int i=0; i<graphs_ToolStripMenuItem.DropDownItems.Count;i++)
            {
                if (graphs_ToolStripMenuItem.DropDownItems[i].Text == activeGraph) graphs_ToolStripMenuItem.DropDownItems.RemoveAt(i);
            }
                   
            menuStrip1.Items.Remove(menuStrip1.Items[activeGraph]);
            graphs.Remove(activeGraph);
            activeGraph = null;
            richTextBox1.Text = "";
        }

        private void graphs_ToolStripMenuItem_DropDownItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Text;
            activeGraph = name;
            richTextBox1.Text = graphs[name].ToString();
        }
    }
}


