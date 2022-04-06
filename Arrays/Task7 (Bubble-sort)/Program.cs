using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7__Bubble_sort_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 1, 43, 2, 8, 41, 43, 1, 6, 1};
            int tempValue = 0;
            bool isSorted = true;
            bool endSort = false;
            Console.WriteLine("Bubble - sort: \n");

            while (endSort == false)
            {
                isSorted = true;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        tempValue = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tempValue;
                        isSorted = false;
                    }
                }
                if (isSorted)
                {
                    endSort = true;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
