using System;
using System.Collections.Generic;
using GraphTheory;
using Arithmetics;
using System.IO;
using Arithmetics.Polynomial;
using System.Windows.Forms;

namespace ConsoleUI
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UIForm());
        }
    }
}