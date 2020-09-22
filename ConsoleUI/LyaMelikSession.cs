using System;
using System.Collections.Generic;
using System.IO;
using GraphTheory;
using Arithmetics.Polynomial;


namespace ConsoleUI
{
    /// <summary>
    /// Класс сеанса работы с графами. 
    /// </summary>
    class LyaMelikSession
    {
        private string activeGraph;
        private SortedList<string, Graph> graphs;
        public LyaMelikSession()
        {
            graphs = new SortedList<string, Graph>();
            activeGraph = "";
        }
        public LyaMelikSession(SortedList<string, Graph> graphs)
        {
            this.graphs = new SortedList<string, Graph>(graphs);
            activeGraph = "";
        }

        public LyaMelikSession(SortedList<string, Graph> graphs, string activeGraph)
        {
            this.graphs = new SortedList<string, Graph>(graphs);
            this.activeGraph = activeGraph;
        }

        public void Start()
        {
            bool exit = false;
            Help();
            while(!exit)
            {
                Console.Write("\n>");
                if (activeGraph != "")
                {
                    Console.Write("(" + activeGraph + ") ");
                }
                switch (Console.ReadLine())
                {
                    case "help":
                        Help();
                        break;
                    case "polynomial":
                        PolynomialCulc();
                        break;
                    case "create":
                        Create();
                        break;
                    case "change":
                        Change();
                        break;
                    case "write":
                        if (graphs.Count != 0)
                        {
                            Console.WriteLine(graphs[activeGraph]);
                        }
                        break;
                    case "get diam":
                        Console.WriteLine(GraphBasicFunctions.GraphDiam(graphs[activeGraph]));
                        break;
                    case "add node":
                        try
                        {
                            if (activeGraph != "")
                            {
                                AddNode();
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
                            AddEdge();
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Вы ввели что-то не то");
                            break;
                        }
                    case "transpose":
                        {
                            graphs[activeGraph].Transponse();
                            break;
                        }
                    case "save":
                        Save();
                        break;
                    case "exit":
                        exit = true;
                        break;
                }
            }
            return;
        }


        private void Help()
        {
            string[] text = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Help.txt"));
            foreach (string item in text)
            {
                Console.WriteLine(item);
            }
        }
        public void PolynomialCulc()//сменить на private
        {
            SortedList<string, Polynomial> polynomialList = new SortedList<string, Polynomial>();
            do
            {
                string str = Console.ReadLine();
                try
                {
                    str.Replace(" ", "");
                    string name = str.Substring(0, str.IndexOf('='));
                    string value = str.Substring(str.IndexOf('='));
                    try
                    { 
                        Polynomial polynomial = new Polynomial(value);
                        polynomialList.Add(name, polynomial);
                    }
                    catch
                    {
                        continue;
                    }
                    if (polynomialList.ContainsKey(name))
                    {
                        try // переопределение
                        {
                            polynomialList.Remove(name);
                            polynomialList.Add(name, new Polynomial(value));
                        }
                        catch // вычисление
                        {
                            for (int i = 0; i < value.Length; i++)
                            {
                                char symbol = value[i];
                                switch (symbol)
                                {
                                    case '*':
                                        string name1, name2;
                                        name1 = value.Substring(0, i);
                                        name2 = value.Substring(i);
                                        break;
                                    case '+':

                                        break;
                                    case '-':
                                        break;
                                    default:
                                        break;


                                }

                            }
                        }
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine("Error format"+e);
                }

            } while (Console.ReadKey().Key != ConsoleKey.Enter);
           foreach (KeyValuePair<string, Polynomial> kvp in polynomialList)

                Console.WriteLine(kvp.Key + " = " + kvp.Value);

            string path = Console.ReadLine();

        }
        private void Create()
        {
            Console.WriteLine("Введите путь к текстовому файлу с матрицей смежности");
            Console.Write(">");
            string path = Console.ReadLine();
            Arithmetics.Matrix.IntegerSquareMatrix a = new Arithmetics.Matrix.IntegerSquareMatrix(path);
            Console.WriteLine(a);
            if (a.columns == 0)
                return;
            Console.WriteLine("Введите имя графа");
            Console.Write(">");
            string name = Console.ReadLine();
            if (graphs.ContainsKey(name) == false)
            {
                Graph NewGraph = new Graph(a);
                graphs.Add(name, NewGraph);
                Console.WriteLine("Граф " + name + " успешно добавлен");
                activeGraph = name;
            }
            else
            {
                Console.WriteLine("это имя уже занято");
            }
        }
        private void Change()
        {
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
                activeGraph = s;
            }
            else
            {
                Console.WriteLine("Графа с таким именем не существует");
            }
        }
        private void AddNode()
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
            graphs[activeGraph].AddNode(graphs[activeGraph], incoming, outgoing);
            Console.WriteLine("вершина успешно добавлена");
        }
        private void AddEdge()
        {
            Console.WriteLine("введите номер начала ребра");
            string st = Console.ReadLine();
            Console.WriteLine("введите номер конца ребра");
            string st1 = Console.ReadLine();
            graphs[activeGraph].AddEdge(graphs[activeGraph], Convert.ToInt32(st), Convert.ToInt32(st1));
        }
        private void Save()
        {
            Console.WriteLine("Введите путь к папке, в которой будем сохранять");
            string p = Console.ReadLine();
            p = p + "\\" + activeGraph;
            graphs[activeGraph].SaveGraph(p, graphs[activeGraph]);
        }

        private Polynomial Culc(string str, SortedList<string, Polynomial> polynomialList)
        {

            int countleft=0, countright=0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                    countleft++;
                if (str[i] == ')')
                    countright++;
            }
            if (
                (countleft != countright)
                ||
                ((str.Contains("(")) && (!str.Contains(")")))
                ||
                ((str.Contains("(")) && (!str.Contains(")")))
                )
            {
                Console.WriteLine("ошибка со скобками"); // Exception для скобок
                return null;
            }
            if (countleft>0)//часть кода для реализации скобок
            {
              
            }

            for (int i = 0; i < str.Length; i++)//цикл для выполнения оперaций первого приоритета
            {
                if (str[i] == '*')
                {
                    int j = i; 
                    while((str[j]!='+')||(str[j]!='-'))        ///  выделяю операнды при операции "*"
                        j--;                                     ///  name1 и name2 это строки с
                                                                 ///  названиями переменных слева и 
                    string name1 = str.Substring(j, i - j);     ///  справа от "*" соответственно
                    int k = i;
                    while ((str[k] != '+') || (str[k] != '-')) 
                        k++;

                    string name2 = str.Substring(i, i + k);
                    string path1 = str.Substring(0, i-j);
                    string path2 = str.Substring(i + k);
                    Polynomial result;
                    try
                    {
                        result = (polynomialList[name1] * polynomialList[name2]);
                        if(!polynomialList.ContainsKey(result.ToString()))
                        {
                            polynomialList.Add(result.ToString(), result);
                        }
                    }
                    catch (KeyNotFoundException t)
                    {
                        throw t;
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }

                }
            }
            
            



            return null;
            
        }
        private Polynomial Computation(string str)
        {
            string path = str;

            return null;
        }
    }
}
