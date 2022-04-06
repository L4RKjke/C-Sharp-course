using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int [] array = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110 };
            Console.WriteLine("Введите шаг сдвига n: \n");
            int moveStep = Convert.ToInt32(Console.ReadLine());
            int tempValue = 0;
            Console.WriteLine("");

            for (int j = 0; j < moveStep; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    tempValue = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = tempValue;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
