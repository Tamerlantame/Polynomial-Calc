using System;
using System.Collections.Generic;
using GraphTheory;
using Arithmetics;
using System.IO;
using Arithmetics.Polynomial1;
using System.Windows.Forms;
using WinFormsUI.Forms;
using Arithmetics.Parsers;
using System.Linq;
using ConsoleUI.Forms;

namespace WinFormsUI
{
    class Program
    {
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UIForLogics());
        }
        /*public static void Main(string[] args)
        {
            var text = "(2+2)*2/(4+4)";
            Console.WriteLine(Arithmetics.Сulculator.ExpressionToRPN(text));
            Console.WriteLine(Arithmetics.Сulculator.RPNtoAnswer(Arithmetics.Сulculator.ExpressionToRPN(text)));

        }*/

    }
}