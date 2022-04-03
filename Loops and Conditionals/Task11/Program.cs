using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string testString = "((())(()))";
            int bracketBalance = 0;
            bool error = false;
            int maxBracketDeep = 0;

            foreach (var symbol in testString)
            {
                if (bracketBalance < 0)
                {
                    error = true;
                }
                else
                {
                    if (Convert.ToString(symbol) == "(")
                    {
                        bracketBalance += 1;
                    }

                    if (Convert.ToString(symbol) == ")")
                    {
                        bracketBalance -= 1;
                    }

                    if (maxBracketDeep < bracketBalance)
                    {
                        maxBracketDeep = bracketBalance;
                    }                  
                }
            }
            if (bracketBalance == 0 & error == false)
            {
                Console.WriteLine("Ok!");
                Console.WriteLine("Максимальная глубина вложенности скобок: " + maxBracketDeep);
            }
            else
            {
                Console.WriteLine("bracketError!");
            }
        }
    }
}
