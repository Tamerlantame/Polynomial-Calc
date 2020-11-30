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
            if (operation.Contains(":="))
            {
                string[] operands = operation.Split(new string[] { ":=" }, StringSplitOptions.None);
                result = calculator.Execute(operands[1]);
                if (!calculator.PolyVars.ContainsKey(operands[0]))
                    calculator.PolyVars.Add(operands[0], new Polynomial(PolynomialParser.Parse(result)));
                else
                    calculator.PolyVars[operands[0]] = new Polynomial(PolynomialParser.Parse(result));
                result = $"{operands[0]}:={result}";
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
            var lines = cycle;
            // Условие, добавлена только обработка >< оперторов
            var condition = lines.Substring(lines.IndexOf('(')+1, lines.IndexOf(')') - (lines.IndexOf('(')+1));
            var result = "";
            while (Convert.ToBoolean(Convert.ToDouble(Execute(condition))))
            {
                result = Launch(GetBody(lines, out int bodyLenght));
            }
            return result;
        }
        public string Launch(string text)
        {

            var lines = text.Replace(" ", "").Split(new Char[] { '\n' });
            string result = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("While"))
                {
                    result += PerformWhile(lines[i] + '\n' + GetBody(text, out int bodyLenght)) + '\n';
                    i += bodyLenght;
                }
                else
                {
                    if (!(i < lines.Length))
                        break;
                    result += Execute(lines[i]) + "\n";
                }
            }
            return result;
        }
        private string GetBody (string text, out int bodyLength)
        {
            int leftBracetNum  = 0, rightBracetNum = 0, stringNum=0;
            int firstBracetIndex = 0, lastBracetIndex = text.Length;
            for (int i = 0; i< text.Length;i++)
            {
                if (text[i] == '\n')
                    stringNum++;
                if (text[i] == '{')
                    leftBracetNum++;
                if (text[i] == '}')
                    rightBracetNum++;
                if (leftBracetNum != 0 && leftBracetNum == rightBracetNum)
                    break;
            }
            if (leftBracetNum != rightBracetNum)
                throw new Exception("Ошибка с фигурными скобками");
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '{')
                {
                    firstBracetIndex = i;
                    break;
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '}')
                {
                    rightBracetNum--;
                    if (rightBracetNum == 0)
                        lastBracetIndex = i;
                }

            }
            bodyLength = stringNum;
            return text.Substring(firstBracetIndex+1, lastBracetIndex - (firstBracetIndex+1));
        }
    }
}
