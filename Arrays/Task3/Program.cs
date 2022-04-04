using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[30];
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(5, 40);
                Console.Write(array[i] + " ");
            }
            int localMax = array[0];
            Console.WriteLine();
            Console.Write("Локальные максимумы: \n");

            if (array[0] > array[1])
            {
                Console.Write(array[0] + " ");
            }

            for (int j = 1; j < array.Length - 1; j++)
            {
                if (array[j] > array[j + 1] & array[j] > array[j - 1])
                {
                    Console.Write(array[j] + " ");
                }
            }
            if (array[array.Length - 1] > array[array.Length - 2])
            {
                Console.Write(array[array.Length - 1]);
            }
            Console.WriteLine();
        }
    }
}
