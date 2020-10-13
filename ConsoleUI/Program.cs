using System;
using System.Collections.Generic;
using GraphTheory;
using Arithmetics;
using System.IO;
using Arithmetics.Polynomial1;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //SortedList<string, Graph> Graphs = new SortedList<string, Graph>();
            LyaMelikSession session = new LyaMelikSession();
            //session.Start();
            //Console.ReadKey();
            string str = "1234567890";
            Console.WriteLine(str.Substring(0, 4));
            Console.WriteLine(str.Substring(4));
            //session.PolynomialCulc();
            string path = "name1 * name2";
            SortedList<string, Polynomial> polynomialList = new SortedList<string, Polynomial>();
            polynomialList.Add("name1", new Polynomial("x^2+2"));
            polynomialList.Add("name2", new Polynomial("x^2+2"));
            for (int i = 0; i < path.Length; i++)//цикл для выполнения оперaций первого приоритета
            {
                if (path[i] == '*')
                {
                    int j = i;
                    try
                    {
                        while ((path[j] != '+') || (path[j] != '-'))        ///  выделяю операнды при операции "*"
                            j--;
                    }                                                     ///  name1 и name2 это строки с
                    catch (IndexOutOfRangeException e)
                    {
                        j = 0;
                    }
                    string name1 = path.Substring(j, i - j);             ///  справа от "*" соответственно
                    int k = i;
                    try { 
                    while ((path[k] != '+') || (path[k] != '-'))
                        k++;
                    }                                                     ///  name1 и name2 это строки с
                    catch (IndexOutOfRangeException e)
                    {
                        k = path.Length;
                        throw e;
                    }

                    string name2 = path.Substring(i, i + k);
                    string path1 = path.Substring(0, i - j);
                    string path2 = path.Substring(i + k);
                    string result;
                    try
                    {
                        result = (polynomialList[name1] * polynomialList[name2]).ToString();
                    }
                    catch (KeyNotFoundException t)
                    {
                        throw t;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    path = path1 + "result" + path2;

                }
            }
            Console.WriteLine(path);
        }
    }
}