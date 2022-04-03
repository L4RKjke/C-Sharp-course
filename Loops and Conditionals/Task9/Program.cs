using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startOfRange = 1;
            int endOfRange = 27;
            Random random = new Random();
            int givenNumber = random.Next(startOfRange, endOfRange+1);
            int sumOfN = 0;
            int sumOfMultipleNumbers = 0;
            int maxNumber = 999;
            int minNumber = 100;

            for (int i = 0; i <= maxNumber; i++)
            {
                sumOfN += givenNumber;
                
                for (int j = minNumber; j < maxNumber + 1; j++)
                {
                    if (sumOfN == j)
                    {
                        sumOfMultipleNumbers++;
                    }
                }
            }
            Console.WriteLine($"Кол-во 3х значных чисел кратных {givenNumber}: {sumOfMultipleNumbers}");
        }
    }
}
