// verified by ususucsus. gadost' detected and destructed

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics.Polynomial
{
    public class Polynomial : IComparable
    {
        public SortedList<int, double> coeff;
        public int deg;
        public Polynomial(string poly)
        {
            try
            {
                poly = poly.Replace("-", "+-");
                string[] s = poly.Split(new char[] { '+' });//разбиваю строку на массив подстрок по каждому из +(+ при этом удаляется)
                int deg;
                coeff = new SortedList<int, double>();
                for (int i = 0; i < s.Length; i++)
                {
                    string m = s[i];
                    if (m == "")
                        continue;
                    m = m.Replace("-x", "-1x");
                    int indexOfDeg = m.IndexOf("^") + 1;
                    int indexOfx = m.IndexOf("x");//определяю границы каждого монома
                    if ((indexOfDeg > 0) && (indexOfx >= 0))
                    {

                        deg = Convert.ToInt32(m.Substring(indexOfDeg));
                        if (indexOfx != 0)
                        {
                            if (!coeff.ContainsKey(deg))
                                coeff.Add(deg, Convert.ToInt32(m.Substring(0, indexOfx)));
                            else
                                coeff[deg] += Convert.ToInt32(m.Substring(0, indexOfx));
                        }
                        else
                        {
                            if (!coeff.ContainsKey(deg))
                                coeff.Add(deg, 1);
                            else
                                coeff[deg]++;
                        }
                    }
                    if (m.Contains("x") && !m.Contains("^"))
                    {
                        if (indexOfx == 0)
                        {
                            if (!coeff.ContainsKey(1))
                                coeff.Add(1, 1);
                            else
                                coeff[1]++;
                        }
                        else
                        {
                            if (!coeff.ContainsKey(1))
                                coeff.Add(1, Convert.ToInt32(m.Substring(0, indexOfx)));

                            else
                                coeff[1] += Convert.ToInt32(m.Substring(0, indexOfx));
                        }
                    }
                    if (!m.Contains("x") && !m.Contains("^"))
                    {
                        if (!coeff.ContainsKey(0))
                            coeff.Add(0, Convert.ToInt32(m));
                        else
                            coeff[0] += Convert.ToInt32(m);
                    }
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("Ошибка" + e);
                coeff.Add(0, 0);
            }
            deg = coeff.Keys[coeff.Keys.Count - 1];
        }
        public Polynomial()
        {
            deg = 0;
            coeff = new SortedList<int, double>();
        }

        public Polynomial(int Deg)
        {
            deg = Deg;
            coeff = new SortedList<int, double>();
            for (int i = 0; i < deg + 1; i++)
            {
                coeff.Add(i, 0);
            }
        }

        public Polynomial(SortedList<int, double> coeff)
        {
            try
            {
                deg = coeff.Keys[coeff.Count - 1];
                this.coeff = new SortedList<int, double>();
                for (int i = 0; i < deg + 1; i++)
                {
                    if (coeff.ContainsKey(i))
                        this.coeff.Add(i, coeff[i]);
                }
            }
            catch (Exception e)
            {
                deg = 0;
                this.coeff = null;
                Console.WriteLine(e + "Error. Not correct input");
            }

        }

        public Polynomial(Polynomial a)
        {
            deg = a.deg;
            coeff = new SortedList<int, double>();
            for (int i = 0; i < deg + 1; i++)
            {
                if (a.coeff.ContainsKey(i))
                    coeff.Add(i, a.coeff[i]);
            }

        }

        public int CompareTo(object obj)
        {
            try
            {
                Polynomial a = obj as Polynomial;
                if (this.deg != a.deg)
                    return this.deg.CompareTo(a.deg);
                else
                    return this.coeff[this.deg].CompareTo(a.coeff[a.deg]);
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        public override string ToString()
        {
            string s = "";

            for (int i = deg; i >= 0; i--)
            {
                if (this.coeff.ContainsKey(i))
                {
                    if (coeff[i] >= 0)
                    {
                        switch (i)
                        {
                            case 0:
                                if (coeff[i] != 0)
                                    s += "+" + coeff[i];
                                break;
                            case 1:
                                if (coeff[i] != 0)
                                {
                                    if (deg >= 2)
                                    {
                                        if (coeff[i] == 1)
                                            s += "+x";
                                        else
                                            s += "+" + coeff[i] + "x";
                                    }
                                    else
                                    {
                                        if (coeff[i] == 1)
                                            s += "x";
                                        else
                                            s += coeff[i] + "x";
                                    }
                                }
                                break;
                            default:
                                if (coeff[i] != 0)
                                {
                                    if (i != this.coeff.Keys[this.coeff.Keys.Count - 1])
                                    {
                                        if (coeff[i] == 1)
                                            s += "+x^" + i;
                                        else
                                            s += "+" + coeff[i] + "x^" + i;
                                    }
                                    else
                                    {
                                        if (coeff[i] == 1)
                                            s += "x^" + i;
                                        else
                                            s += coeff[i] + "x^" + i;
                                    }
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                s += coeff[i];
                                break;
                            case 1:
                                if (coeff[i] == -1)
                                    s += "-x";
                                else
                                    s += coeff[i] + "x";

                                break;
                            default:
                                if (coeff[i] == -1)
                                    s += "-x^" + i;
                                else
                                    s += +coeff[i] + "x^" + i;

                                break;
                        }
                    }
                }
            }
            if (s == "")
                return "0";
            else
                return s;
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            int localmaxdeg = Math.Max(p1.deg, p2.deg);
            Polynomial p3 = new Polynomial();
            for (int i = 0; i < localmaxdeg + 1; i++)
            {
                if (p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p1.coeff[i] + p2.coeff[i]);
                if (p1.coeff.ContainsKey(i) && !p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p1.coeff[i]);
                if (!p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p2.coeff[i]);
            }
            p3.deg = localmaxdeg;
            return p3;
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            int localmaxdeg = Math.Max(p1.deg, p2.deg);
            Polynomial p3 = new Polynomial();
            for (int i = 0; i < localmaxdeg + 1; i++)
            {
                if (p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p1.coeff[i] - p2.coeff[i]);
                if (p1.coeff.ContainsKey(i) && !p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p1.coeff[i]);
                if (!p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, -p2.coeff[i]);
            }
            p3.deg = localmaxdeg;
            return p3;
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            Polynomial p3 = new Polynomial(p1.deg + p2.deg);
            for (int i = p1.deg + 1; i >= 0; i--)
            {
                if (p1.coeff.ContainsKey(i))
                {
                    for (int j = 0; j < p2.deg + 1; j++)
                    {
                        if (p2.coeff.ContainsKey(j))
                            p3.coeff[i + j] += p1.coeff[i] * p2.coeff[j];
                    }
                }
            }

            return p3;
        }

        public static Polynomial operator *(Polynomial p1, int number)
        {
            Polynomial p3 = new Polynomial(p1);
            for (int i = p1.deg + 1; i > -(1); i--)
            {
                if (p1.coeff.ContainsKey(i))
                    p3.coeff[i] = p1.coeff[i] * number;
            }
            return p3;
        }

        public static Polynomial operator *(int number, Polynomial p1)
        {
            Polynomial p3 = new Polynomial(p1);
            for (int i = p1.deg + 1; i > -(1); i--)
            {
                if (p1.coeff.ContainsKey(i))
                    p3.coeff[i] = p1.coeff[i] * number;
            }
            return p3;
        }
        public static Polynomial operator /(Polynomial p1, int number)
        {
            Polynomial result = new Polynomial(p1);
            for (int i = 0; i < result.deg; i++)
            {
                if (result.coeff.ContainsKey(i))
                    result.coeff[i] /= number;
            }

            return result;
        }
        public static Polynomial operator /(Polynomial p1, Polynomial p2)
        {

            if (p1.deg < p2.deg)
            {
                string s = "Error 431, polynomial was input in incorrect form.'/n' please reload the program.";
                Console.WriteLine(s);
                return null;
            }
            else
            {
                Polynomial p4 = new Polynomial(p1.deg - (p2.deg - 1));
                Polynomial p3 = new Polynomial(p1.coeff);



                //result.deg = result.coeff.Keys[result.coeff.Count - 1];
                return null;
            }
        }
        /*
         * 
         * public static Polynomial operator /(Polynomial p1, Polynomial p2)//Определяю целочисленное деление полиномов. Тут написал почти полную фигню, но она работает)
        {
            if (p1.deg >= p2.deg)
            {

                Polynomial p4 = new Polynomial(p1.deg-(p2.deg-1));
                Polynomial p3 = new Polynomial(p1.coeff);

                for (int i = p3.deg, m = 0 ; i >= p2.deg; i--)
                {
                    int j = p2.deg;
                    
                    if (p3.coeff[i ] >= 0 && p2.coeff[j] >= 0)
                    {
                        while (p3.coeff[i ] >= p2.coeff[j])

                        {
                            p3.coeff[i ] -= p2.coeff[j];
                            int k = 1;
                            while (k - 1 < j)
                            {
                                p3.coeff[i - k] -= p2.coeff[j - k];
                                k++;
                            }
                            p4.coeff[p1.deg - p2.deg  - m]++;
                        }
                    }
                    else
                    {
                        if (p3.coeff[i] >= 0 && p2.coeff[j] < 0)
                        {
                            while (p3.coeff[i ] >= -(p2.coeff[j]))

                            {
                                p3.coeff[i ] += p2.coeff[j];
                                int k = 1;
                                while (k - 1 < j)
                                {
                                    p3.coeff[i  - k] += p2.coeff[j - k];
                                    k++;
                                }
                                p4.coeff[p1.deg - p2.deg - m]--;
                            }
                        }
                        else
                        {
                            if (p3.coeff[i ] < 0 && p2.coeff[j] >= 0)
                            {
                                while (-(p3.coeff[i ]) >= p2.coeff[j])

                                {
                                    p3.coeff[i ] += p2.coeff[j];
                                    int k = 1;
                                    while (k - 1 < j)
                                    {
                                        p3.coeff[i  - k] += p2.coeff[j - k];
                                        k++;
                                    }
                                    p4.coeff[p1.deg - p2.deg - m]--;
                                }
                            }
                            else
                            {
                                if (p3.coeff[i ] >= 0 && p2.coeff[j] >= 0)
                                {
                                    while (p3.coeff[i ] >= p2.coeff[j])
                                    {
                                        p3.coeff[i ] -= p2.coeff[j];
                                        int k = 1;
                                        while (k - 1 < j)
                                        {
                                            p3.coeff[i  - k] -= p2.coeff[j - k];
                                            k++;
                                        }
                                        p4.coeff[p1.deg - p2.deg - m]++;
                                    }
                                }
                                else
                                {
                                    string s = "Error 431, polynomial was input in incorrect form.'/n' please reload the program.";
                                    Console.WriteLine(s);
                                    
                                    
                                }
                            }

                        }
                    }
                    m++;
                }


                p4.deg = p4.coeff.Length;
                p3.deg = p3.coeff.Length;
                return p4;
            }

            else
            {
                Polynomial p4 = new Polynomial(1);
                return p4;
            }

        }
         * 
         */

        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            int localmindeg = Math.Min(p1.deg, p2.deg);
            for (int i = 0; i < localmindeg; i++)
            {
                if (!(p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i) && (p1.coeff[i] == p2.coeff[i])))
                    return false;

            }
            return true;
        }

        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            int localmindeg = Math.Min(p1.deg, p2.deg);
            for (int i = 0; i < localmindeg; i++)
            {
                if (!(p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i) && (p1.coeff[i] == p2.coeff[i])))
                    return true;

            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is Polynomial polynomial &&
                   EqualityComparer<SortedList<int, double>>.Default.Equals(coeff, polynomial.coeff) &&
                   deg == polynomial.deg;
        }

    }
}