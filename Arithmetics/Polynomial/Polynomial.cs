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
        private SortedList<int, double> coeff;
        private readonly int deg;

        public int Deg { get => deg; }

        public double this[int index]
        {
            get
            {
                if (coeff.ContainsKey(index))
                {
                    return coeff[index];
                }
                else return 0;
            }
        }

        /// <summary>
        /// If <paramref name="poly"/> is a correct representaion of a polynomial (i.e. a sum of monomials of the form either a, ax or ax^b for some integers a and b.), 
        /// constructs the corresponding polynomial. Otherwise the polynomial is initialized as 0. 
        /// </summary>
        /// <param name="poly">string representation of a polynomial</param>
        [Obsolete("Use Polynomial(SortedList<int, double> coeff) instead")]
        public Polynomial(string poly)
        {
            try 
            {
                coeff = PolynomialParser.Parse(poly);
            }
            catch(InvalidPolynomialStringException)
            {
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
            this.deg = Deg;
            coeff = new SortedList<int, double>();
            for (int i = 0; i < this.Deg + 1; i++)
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
                for (int i = 0; i < Deg + 1; i++)
                {
                    if (coeff.ContainsKey(i))
                        this.coeff.Add(i, coeff[i]);
                }
            }
            catch (Exception e) // не вполне ясно, что означает это исключение.
            {
                deg = 0;
                this.coeff = null;
                Console.WriteLine(e + "Error. Not correct input");
            }

        }

        public Polynomial(Polynomial a)
        {
            deg = a.Deg;
            coeff = new SortedList<int, double>();
            for (int i = 0; i < Deg + 1; i++)
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
                if (this.Deg != a.Deg)
                    return this.Deg.CompareTo(a.Deg);
                else
                    return this.coeff[this.Deg].CompareTo(a.coeff[a.Deg]);
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        /// <summary>
        /// Пока что совсем не аккуратно.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "";

            for (int i = Deg; i >= 0; i--)
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
                                    if (Deg >= 2)
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
            int localmaxdeg = Math.Max(p1.Deg, p2.Deg);
            Polynomial p3 = new Polynomial(localmaxdeg);
            for (int i = 0; i < localmaxdeg + 1; i++)
            {
                if (p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p1.coeff[i] + p2.coeff[i]);
                if (p1.coeff.ContainsKey(i) && !p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p1.coeff[i]);
                if (!p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p2.coeff[i]);
            }
            return p3;
        }

        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            int localmaxdeg = Math.Max(p1.Deg, p2.Deg);
            Polynomial p3 = new Polynomial(localmaxdeg);
            for (int i = 0; i < localmaxdeg + 1; i++)
            {
                if (p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p1[i] - p2[i]);
                if (p1.coeff.ContainsKey(i) && !p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, p1[i]);
                if (!p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i))
                    p3.coeff.Add(i, -p2[i]);
            }
            return p3;
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            Polynomial p3 = new Polynomial(p1.Deg + p2.Deg);
            for (int i = p1.Deg + 1; i >= 0; i--)
            {
                if (p1.coeff.ContainsKey(i))
                {
                    for (int j = 0; j < p2.Deg + 1; j++)
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
            for (int i = p1.Deg + 1; i > -(1); i--)
            {
                if (p1.coeff.ContainsKey(i))
                    p3.coeff[i] = p1.coeff[i] * number;
            }
            return p3;
        }

        public static Polynomial operator *(int number, Polynomial p1)
        {
            return p1*number;
        }
        public static Polynomial operator /(Polynomial p1, int number)
        {
            Polynomial result = new Polynomial(p1);
            for (int i = 0; i < result.Deg; i++)
            {
                if (result.coeff.ContainsKey(i))
                    result.coeff[i] /= number;
            }

            return result;
        }
        public static Polynomial operator /(Polynomial p1, Polynomial p2)
        {

            if (p1.Deg < p2.Deg)
            {
                string s = "Error 431, polynomial was input in incorrect form.'/n' please reload the program.";
                Console.WriteLine(s);
                return null;
            }
            else
            {
                Polynomial p4 = new Polynomial(p1.Deg - (p2.Deg - 1));
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
            int localmindeg = Math.Min(p1.Deg, p2.Deg);
            for (int i = 0; i < localmindeg; i++)
            {
                if (!(p1.coeff.ContainsKey(i) && p2.coeff.ContainsKey(i) && (p1.coeff[i] == p2.coeff[i])))
                    return false;

            }
            return true;
        }

        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            int localmindeg = Math.Min(p1.Deg, p2.Deg);
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
                   Deg == polynomial.Deg;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}