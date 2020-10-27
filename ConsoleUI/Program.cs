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

namespace WinFormsUI
{
    class Program
    {
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UIFormWithTabs());

        }
        //public static void Main(string[] args)
        //{
        //    var text = Console.ReadLine();
        //    using (var reader = new StringReader(text))
        //    {
        //        var parser = new Parser();
        //        var tokens = parser.Tokenize(reader).ToList();
        //        //Console.WriteLine(string.Join("\n", tokens));

        //        var rpn = parser.ShuntingYard(tokens);
        //        Console.WriteLine(string.Join(" ", rpn.Select(t => t.Value)));
        //    }
        //}
    }
}