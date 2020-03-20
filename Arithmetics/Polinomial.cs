// verified by ususucsus. gadost' detected and destructed

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetics

{
    interface IComparer
    {
        int Compare(object o1, object o2);
    }
    public interface ISequence<T>

    {
        T Next();

    }
    class RandomPolinom : ISequence<Polinomial>
    {
        private int maxDeg;
        private int minDeg;
        private int maxCoeff;
        private int minCoeff;


        public RandomPolinom()
        {
            maxDeg = 10;
            minDeg = 0;
            minCoeff = 0;
            maxCoeff = 100;
        }

        public RandomPolinom(int minDeg, int maxDeg) : this()
        {
            this.minDeg = minDeg;
            this.maxDeg = maxDeg;
        }

        public RandomPolinom(int minDeg, int maxDeg, int minCoeff, int maxCoeff) : this(minDeg, maxDeg)
        {
            this.minCoeff = minCoeff;
            this.maxCoeff = maxCoeff;
        }
        public Polinomial Next()
        {
            Random rnd = new Random();
            int SIZE = rnd.Next(minDeg, maxDeg) + 1;
            double[] q = new double[SIZE];
            for(int i=0; i<q.Length; i++)
            {
                q[i] = rnd.Next(minCoeff, maxCoeff);
            }
            SortedList<int, double> arr = new SortedList<int, double>();
            for (int i = 0; i < SIZE; i++)
            {
                arr.Add(i, q[i]);
            }
            return new Polinomial(arr);
        }
    }
    internal class Polinomial : IComparable
    {
        public SortedList<int, double> coeff;
        public Polinomial(string s) : this()
        {
            Parse(s);
        }
        public Polinomial()
        {
            coeff = new SortedList<int, double>();
        }
        public Polinomial(SortedList<int, double> a) : this()
        {
            foreach (KeyValuePair<int, double> kvp in a)
            {
                coeff.Add(kvp.Key, kvp.Value);
            }
        }
        public static Polinomial operator +(Polinomial p1, Polinomial p2)
        {
            Polinomial p3 = new Polinomial();
          foreach (KeyValuePair<int, double> kvp in p1.coeff) 
            {
                p3.coeff.Add(kvp.Key, kvp.Value);
            }
            foreach (KeyValuePair<int, double> kvp in p2.coeff)
            {   if (p3.coeff.ContainsKey(kvp.Key)==true)
                {
                    p3.coeff[kvp.Key] += kvp.Value;

                }
            else    p3.coeff.Add(kvp.Key, kvp.Value);
            }
            return p3;
        }
        public static Polinomial operator *(Polinomial p1, Polinomial p2)
        {
            Polinomial p3 = new Polinomial();
            foreach (KeyValuePair<int, double> kvp1 in p1.coeff)
            {
                foreach (KeyValuePair<int, double> kvp2 in p2.coeff)
                {
                    if (p3.coeff.ContainsKey(kvp1.Key + kvp2.Key))
                    {
                        p3.coeff[kvp1.Key + kvp2.Key] += kvp1.Value * kvp2.Value;
                    }
                    else p3.coeff.Add(kvp1.Key + kvp2.Key, kvp1.Value * kvp2.Value);
                }
            }
            return p3;
        }
        public override string ToString()
        {
            string poly = "";
            foreach (KeyValuePair<int, double> kvp in coeff)
            {
                if (kvp.Value != 0)
                {
                    switch (kvp.Key)
                    {
                        case 0:
                            if (kvp.Value > 0)
                                poly += "+" + Convert.ToString(kvp.Value);
                            if (kvp.Value < 0)
                            {
                                poly += Convert.ToString(kvp.Value);
                            }


                            break;
                        case 1:
                            if (kvp.Value == 1)
                            {
                                poly += "+x";
                            }
                            if (kvp.Value == -1)
                            {
                                poly += "-x";
                            }

                            if (kvp.Value < 0 && kvp.Value != 1 && kvp.Value != -1) { poly += Convert.ToString(kvp.Value) + "x"; }
                            if (kvp.Value > 0 && kvp.Value != 1 && kvp.Value != -1) { poly += "+"+Convert.ToString(kvp.Value) + "x"; }

                            break;
                        default:
                            if (kvp.Value == 1)
                                poly += "+x" + "^" + kvp.Key;
                            if (kvp.Value == -1)
                                poly += "-x" + "^" + kvp.Key;

                            if (kvp.Value < 0&& kvp.Value!=1&& kvp.Value != -1) { poly += Convert.ToString(kvp.Value) + "x^" + Convert.ToString(kvp.Key); }
                            if (kvp.Value > 0 && kvp.Value != 1 && kvp.Value != -1) { poly += "+" + Convert.ToString(kvp.Value) + "x^"+ Convert.ToString(kvp.Key); }


                            break;

                    }
                }
                else continue;
            }
           if (poly != "")
            {
                if (poly[0] == '+')
                    poly = poly.Substring(1, poly.Length - 1);
                else { }
            }
            else poly = "0";
            return poly;
        }
        public int CompareTo(object o1)
        {
            if (o1 is Polinomial)
            {
                Polinomial p1 = o1 as Polinomial;

                if (this.coeff.Keys.Max() > p1.coeff.Keys.Max())
                {
                    return 1;
                }
                else if (this.coeff.Keys.Max() < p1.coeff.Keys.Max())
                {
                    return -1;
                }
                else
                {
                    if (this.coeff[this.coeff.Keys.Max()] > p1.coeff[p1.coeff.Keys.Max()])
                    {
                        return 1;
                    }
                    else if (this.coeff[p1.coeff.Keys.Max()] < p1.coeff[p1.coeff.Keys.Max()])
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                throw new Exception("unpossible to compare");
            }
        }
        //сравниваем по старшей степени и коэффициенту при ней
        public void Parse(string s)
        {
            s.Replace("--", "+");
            s.Replace("++", "+");
            s.Replace("-+", "-");
            s.Replace("+-", "-");
            string[] partialPolynomial = s.Split('+');

            for (int i = 0; i < partialPolynomial.Length; i++)
            {
                string[] monomials = partialPolynomial[i].Split('-');
                if (monomials[0]=="")
                {
                    monomials[0] = "0" + monomials[0];
                }


                try
                { 
                    ///надо добавить - в начало строки 
                    
                        int degPos = monomials[0].IndexOf('^') + 1;
                        int coef = monomials[0].IndexOf('x');
                        if (degPos == 0 && coef > 0)
                        {
                            string p;
                            p = monomials[0].Substring(0, coef);
                            if (coeff.ContainsKey(1))
                            {
                                coeff[1] -= Convert.ToDouble(p);
                            }

                            else coeff.Add(1, -Convert.ToDouble(p));
                        }
                        if (degPos > 0 && coef > 0)
                        {
                            string a, p;
                            p = monomials[0].Substring(0, coef);
                            a = monomials[0].Substring(degPos, monomials[0].Length - degPos);
                            if (coeff.ContainsKey(Convert.ToInt32(a)))
                            {
                                coeff[Convert.ToInt32(a)] += Convert.ToDouble(p);
                            }
                            else
                                coeff.Add(Convert.ToInt32(a), Convert.ToDouble(p));
                        }
                        if (degPos > 0 && coef == 0)
                        {
                            string a;
                            a = monomials[0].Substring(degPos, monomials[0].Length - degPos);
                            if (coeff.ContainsKey(Convert.ToInt32(a)))
                            {
                                coeff[Convert.ToInt32(a)] += 1;
                            }
                            else coeff.Add(Convert.ToInt32(a), 1);
                        }
                        if (degPos == 0 && coef == 0)
                        {
                            if (coeff.ContainsKey(1))
                            {
                                coeff[1] += 1;
                            }
                            else coeff.Add(1, 1);
                        }

                    if (degPos == 0 && coef < 0)
                    {
                        if (coeff.ContainsKey(0))
                        {
                            coeff[0] += Convert.ToInt32(monomials[0]);
                        }
                        else coeff.Add(0, Convert.ToInt32(monomials[0]));
                    }
                    if (monomials.Length > 1)
                    {
                        for (int j = 1; j < monomials.Length; j++)
                        {
                             degPos = monomials[j].IndexOf('^') + 1;
                             coef = monomials[j].IndexOf('x');
                            if (degPos == 0 && coef > 0)
                            {
                                string p;
                                p = monomials[j].Substring(0, coef);
                                if (coeff.ContainsKey(1))
                                {
                                    coeff[1] -= Convert.ToDouble(p);
                                }

                                else coeff.Add(1, Convert.ToDouble(p));
                            }
                            if (degPos > 0 && coef > 0)
                            {
                                string a, p;
                                p = monomials[j].Substring(0, coef);
                                a = monomials[j].Substring(degPos, monomials[j].Length - degPos);
                                if (coeff.ContainsKey(Convert.ToInt32(a)))
                                {
                                    coeff[Convert.ToInt32(a)] -= Convert.ToDouble(p);
                                }
                                else
                                    coeff.Add(Convert.ToInt32(a), -Convert.ToDouble(p));
                            }
                            if (degPos > 0 && coef == 0)
                            {
                                string a;
                                a = monomials[j].Substring(degPos, monomials[j].Length - degPos);
                                if (coeff.ContainsKey(Convert.ToInt32(a)))
                                {
                                    coeff[Convert.ToInt32(a)] -= 1;
                                }
                                else coeff.Add(Convert.ToInt32(a), -1);
                            }
                            if (degPos == 0 && coef == 0)
                            {
                                if (coeff.ContainsKey(1))
                                {
                                    coeff[1] -= 1;
                                }
                                else coeff.Add(1, -1);
                            }

                            if (degPos == 0 && coef < 0)
                            {
                                if (coeff.ContainsKey(0))
                                {
                                    coeff[0] -= Convert.ToDouble(monomials[j]);

                                }
                                else coeff.Add(0, -Convert.ToDouble(monomials[j]));
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("введи другую строку");
                    throw new FormatException();
                }
            }

        }

    }
}