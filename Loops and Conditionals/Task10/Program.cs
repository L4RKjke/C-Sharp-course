using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int givenNumber = random.Next(1, 32769);
            int maxPower = 15;
            int numberForRaiseToPower = 2;
            Console.WriteLine(givenNumber);

            for (int i = 0; i <= maxPower; i++)
            {
                int poweredNumber = (Convert.ToInt32(Math.Pow(numberForRaiseToPower, i)));

                if (poweredNumber > givenNumber)
                {
                    Console.WriteLine(Convert.ToInt32(Math.Pow(numberForRaiseToPower, i)));
                    break;
                }
            }
        }
    }
}
