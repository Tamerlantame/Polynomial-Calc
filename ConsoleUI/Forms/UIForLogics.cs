using GraphTheory;
using Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleUI.Forms
{
    public partial class UIForLogics : Form
    {
        public UIForLogics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempString = textBox1.Text;
            var expression = new BooleanExpression(tempString); // "(~x1\/x2)/\(x1\/~x4)/\(x2\/~x4)/\(x2\/~x5)/\(x3\/x4)"
            var graph = new LogicGraph(expression.booleanExpression);
            var answer = graph.TwoCnfSat();
            label1.Text = "";
            for (int i = 0; i < answer.Count; i++)
            {
                if (answer[i] == true)
                    label1.Text += "x" + (i + 1).ToString() + "=" + 1 + "; ";
                else
                    label1.Text += "x" + (i + 1).ToString() + "=" + 0 + "; ";
            }
        }
    }
}
