using System;
using System.Collections.Generic;
using System.IO;
using GraphTheory;
namespace ConsoleUI
{
    class UIMethods
    {
        private static string ActiveGraph = "";
        public static SortedList<string, Graph> Input(SortedList<string, Graph> graphs)
        {

            Console.Write(">");
            if (ActiveGraph != "")
            {
                Console.Write("(" + ActiveGraph + ") ");
            }

            string Inputed = Console.ReadLine();
            switch (Inputed)
            {
                case "help":
                    string[] text = File.ReadAllLines(@"C:\Users\Backa\source\repos\Homework\lyamelik\ConsoleUI\Help.txt");///нужно заменить, доделать автоопределение
                    foreach (string item in text)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "create":
                    Console.WriteLine("Введите путь к текстовому файлу с матрицей смежности");
                    Console.Write(">");
                    string path = Console.ReadLine();
                    Arithmetics.Matrix.IntegerSquareMatrix a = new Arithmetics.Matrix.IntegerSquareMatrix(path);
                    Console.WriteLine(a);
                    if (a.columns == 0)
                    {
                        break;
                    }

                    Console.WriteLine("Введите имя графа");
                    Console.Write(">");
                    string name = Console.ReadLine();
                    if (graphs.ContainsKey(name) == false)
                    {
                        Graph NewGraph = new Graph(a);
                        graphs.Add(name, NewGraph);
                        Console.WriteLine("Граф " + name + " успешно добавлен");
                        ActiveGraph = name;
                    }
                    else
                    {
                        Console.WriteLine("это имя уже занято");
                    }

                    break;
                case "change":
                    Console.WriteLine("Введите имя графа, на который хотите переключиться");
                    Console.WriteLine("Доступные имена графов:");
                    foreach (string item in graphs.Keys)
                    {
                        Console.WriteLine(item);
                    }

                    Console.Write(">");
                    string s = Console.ReadLine();
                    if (graphs.ContainsKey(s) == true)
                    {
                        ActiveGraph = s;
                    }
                    else
                    {
                        Console.WriteLine("Графа с таким именем не существует");
                    }

                    break;
                case "write":
                    if (graphs.Count != 0)
                    {
                        Console.WriteLine(graphs[ActiveGraph]);
                    }

                    break;
                case "get diam":
                    Console.WriteLine(GraphBasicFunctions.GraphDiam(graphs[ActiveGraph]));
                    break;
                case "add node":
                    try
                    {
                        if (ActiveGraph != "")
                        {
                            Console.WriteLine("Введите через пробел номера вершин, с которыми будет соседствовать новая вершина");
                            string str = Console.ReadLine();
                            string[] splited = str.Split(' ');
                            List<int> outgoing = new List<int>();
                            foreach (string item in splited)
                            {
                                outgoing.Add(Convert.ToInt32(item));
                            }
                            Console.WriteLine("Введите через пробел номера вершин, которые соседствовуют с новой вершиной");
                            str = Console.ReadLine();
                            splited = str.Split(' ');
                            List<int> incoming = new List<int>();
                            foreach (string item in splited)
                            {
                                incoming.Add(Convert.ToInt32(item));
                            }
                            graphs[ActiveGraph].AddNode(graphs[ActiveGraph], incoming, outgoing);
                            Console.WriteLine("вершина успешно добавлена");
                        }
                        else
                        {
                            Console.WriteLine("вы не выбрали граф");
                        }

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели что-то не то");
                        break;
                    }
                case "add edge":
                    try
                    {

                        Console.WriteLine("введите номер начала ребра");
                        string st = Console.ReadLine();
                        Console.WriteLine("введите номер конца ребра");
                        string st1 = Console.ReadLine();
                        graphs[ActiveGraph].AddEdge(graphs[ActiveGraph], Convert.ToInt32(st), Convert.ToInt32(st1));
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Вы ввели что-то не то");
                        break;
                    }
                case "transpose":
                    {
                        graphs[ActiveGraph].Transponse();
                        break;
                    }
                case "save":
                    Console.WriteLine("Введите путь к папке, в которой будем сохранять");
                    string p = Console.ReadLine();
                    p = p + "\\" + ActiveGraph;
                    graphs[ActiveGraph].SaveGraph(p, graphs[ActiveGraph]);
                    break;
            }
            return Input(graphs);

        }
    }
}
