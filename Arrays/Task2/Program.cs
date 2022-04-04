using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] givenArray = new int[10, 10];
            int maxElement = 0;
            Random random = new Random();

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < givenArray.GetLength(0); i++)
                {
                    for (int j = 0; j < givenArray.GetLength(1); j++)
                    {
                        if (k == 0)
                        {
                            givenArray[i, j] = random.Next(1, 100);
                            Console.Write("{0,4}", givenArray[i, j]);

                            if (maxElement < givenArray[i, j])
                            {
                                maxElement = givenArray[i, j];
                            }
                        }
                        else
                        {
                            if (givenArray[i, j] == maxElement)
                            {
                                givenArray[i, j] = 0;
                                Console.Write("{0,4}", givenArray[i, j]);
                            }
                            else
                            {
                                givenArray[i, j] = givenArray[i, j];
                                Console.Write("{0,4}", givenArray[i, j]);
                            }
                        }
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine();
            }
            Console.WriteLine("max element: " + maxElement);
        }
    }
}
