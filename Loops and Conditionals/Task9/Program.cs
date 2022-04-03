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
            Console.WriteLine("Введите N от 1 до 27:");
            int n = Convert.ToInt32(Console.ReadLine());
            int sumOfN = 0;
            int sumOfMultipleNumbers = 0;
            int maxThreeDigitNumber = 999;
            int minThreeDigitNumber = 100;

            for (int i = 0; i <= (maxThreeDigitNumber + 1) / n; i++)
            {
                sumOfN += n;
                for (int j = minThreeDigitNumber; j < maxThreeDigitNumber + 1; j++)
                {
                    if (sumOfN == j)
                    {
                        Console.WriteLine(sumOfN);
                        sumOfMultipleNumbers++;
                    }
                }
            }
            Console.WriteLine($"Кол-во 3х значных чисел кратных {n}: {sumOfMultipleNumbers}");
        }
    }
}
