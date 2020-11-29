using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetics;
using Arithmetics.Polynomial1;
using Arithmetics.Parsers;


namespace Arithmetics
{
    public class Executor
    {
        private Сulculator calculator;
        public Executor()
        {
            calculator = new Сulculator();
        }
        /// <summary>
        ///  A:= some expression,
        ///  A:= A*A;
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        private string Execute(string operation)
        {
            string result;
            // нужен regex
            if (operation.Contains("="))
            {
                string[] operands = operation.Split(new string[] { "=" }, StringSplitOptions.None);
                result = calculator.Execute(operands[1]);
                if (!calculator.PolyVars.ContainsKey(operands[0]))
                    calculator.PolyVars.Add(operands[0], new Polynomial(PolynomialParser.Parse(result)));
                else
                    calculator.PolyVars[operands[0]] = new Polynomial(PolynomialParser.Parse(result));
                result = $"{operands[0]}={result}";
            }
            else
            {
                result = calculator.Execute(operation);
            }
            return result;
        }
        /// <summary>
        /// Get result of while cycle
        /// </summary>
        /// <param name="cycle">
        /// string with cycle in 
        /// "While(...)
        /// {
        /// ...
        /// }"
        /// format</param>
        /// <returns></returns>
        private string PerformWhile(string cycle)
        {

            var lines = cycle.Replace(" ", "").Split(new Char[] { '\n' });
            // Условие
            var condition = lines[0].Substring(lines[0].IndexOf('('), lines[0].IndexOf(')') - lines[0].IndexOf('('));
            

            // Body Of Cycle
            return "";
        }
        public string Launch(string text)
        {

            var lines = text.Replace(" ", "").Split(new Char[] { '\n' });
            string result = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("While"))
                {
                    var currCycle = "";
                    while (!lines[i].Contains('}'))
                    {
                        currCycle += lines[i] + '\n';
                        i++;
                    }
                    result += PerformWhile(currCycle) + '\n';
                }
                result += Execute(lines[i]) + "\n";
            }
            return result;
        }
    }
}
