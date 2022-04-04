using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumOfsecondString = 0;
            int multiplyOfFirstColumn = 1;
            int[,] givenArray =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            for (int i = 0; i < givenArray.GetLength(0); i++)
            {
                multiplyOfFirstColumn *= givenArray[i, 0];

                for (int j = 0; j < givenArray.GetLength(1); j++)
                {
                    if (i == 1)
                    {
                        sumOfsecondString += givenArray[i, j];
                    }
                }
            }
            Console.WriteLine("sum of second string: " + sumOfsecondString);
            Console.WriteLine("multiply of first column: " + multiplyOfFirstColumn);
        }
    }
}
