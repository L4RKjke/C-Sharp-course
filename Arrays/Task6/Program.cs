using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string randomTxt = Console.ReadLine();
            string[] textString = randomTxt.Split(' ');

            foreach (string word in textString)
            {
                Console.WriteLine(word);
            }
        }
    }
}
