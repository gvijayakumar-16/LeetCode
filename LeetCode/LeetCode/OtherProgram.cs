using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class OtherProgram
    {
        /// <summary>
        /// 166. Fraction to Recurring Decimal - Start
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        /// <remarks>Fails for -2147483648, -1999</remarks>
        public static string FractionToDecimal(int numerator, int denominator)
        {
            decimal fraction = (decimal)numerator / denominator;
            var output = fraction.ToString();
            if (output.Split('.').Length <= 1)
            {
                return output;
            }
            int previousNumber = -1, index = 0;
            foreach (var number in output.Split('.')[1].ToCharArray())
            {
                if (previousNumber == (number - '0'))
                {
                    var decimalPart = output.Split('.')[1].Substring(0, index - 1);
                    decimalPart += "(" + output.Split('.')[1].Substring(index - 1, index) + ")";
                    output = output.Split('.')[0] + "." + decimalPart;
                    break;
                }
                previousNumber = number - '0';
                ++index;
            }
            return output;
        }

        public static void PrintOutput(IList<IList<int>> values)
        {
            Console.WriteLine("Output: ");
            foreach (var level in values)
            {
                foreach (var lvl in level)
                {
                    Console.Write(lvl);
                }
                Console.WriteLine("");
            }
        }

        public static void PrintOutput<T>(T output)// where T : struct
        {
            Console.WriteLine("Output: " + output);
        }
    }
}
