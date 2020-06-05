using System;
using System.Collections.Generic;
using GraphTheory;
using Arithmetics;
using System.IO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //SortedList<string, Graph> Graphs = new SortedList<string, Graph>();
            LyaMelikSession session = new LyaMelikSession();
            session.Start();
            //Console.ReadKey();
        }
    }
}