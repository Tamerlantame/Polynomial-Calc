using System;
using System.Collections.Generic;
using GraphTheory;
using Arithmetics;
using System.IO;
using Arithmetics.Polynomial1;
using System.Windows.Forms;
using WinFormsUI.Forms;

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
    }
}