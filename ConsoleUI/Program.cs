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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UIForm());
                       




        //  SortedList<string, Graph> Graphs = new SortedList<string, Graph>();
        //LyaMelikSession session = new LyaMelikSession();
        //session.Start();
        //Console.ReadKey();
        /*   SortedList<string, Polynomial> polynomialList = new SortedList<string, Polynomial>();
           ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
           while (keyInfo.Key != ConsoleKey.Enter)
           {
               Console.WriteLine("Введите имя полинома");
               string name = Console.ReadLine();
               Console.WriteLine("Введите Полином");
               Polynomial polynomial = new Polynomial(Console.ReadLine());
               polynomialList.Add(name, polynomial);

           }*/
    }
}
}