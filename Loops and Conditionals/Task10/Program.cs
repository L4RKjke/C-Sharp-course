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
            int maxPower = 15;
            int minNumber = 0;
            int maxNumber = 32769;
            int givenNumber = random.Next(minNumber, maxNumber);
            int numberForRaiseToPower = 2;
            Console.WriteLine("Заданное число:" + givenNumber);
            int power = 1;
            bool isRepeat = true;

            while (isRepeat)
            {
                power++;

                if (power == maxPower)
                {
                    isRepeat = false;
                }
                int poweredNumber = Convert.ToInt32(Math.Pow(numberForRaiseToPower, power));

                if (poweredNumber > givenNumber)
                {
                    Console.WriteLine("Найденное число: " + Convert.ToInt32(Math.Pow(numberForRaiseToPower, power)));
                    isRepeat = false;
                }
            }
        }
    }
}
