using System;
using System.Collections.Generic;
using GraphTheory;
using Arithmetics;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, Graph> Graphs = new SortedList<string, Graph>();
            UIMethods.Input(Graphs);
            Console.ReadKey();
        }
    }
}