using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberArray = { 10, 20, 30, 40, 50, 60, 70 };
            string[] stringArray = { "Ночевала", "тучка", "золотая", "На", "груди", "утеса", "великана" };

            foreach (int i in Shuffle(numberArray))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            foreach (string i in Shuffle(stringArray))
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

        }
        static Array Shuffle(int[] array)
        {
            int[] randomArray = new int[array.Length];
            int[] resultArray = new int[array.Length];
            int r = 0;
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                while (Contain(randomArray, r))
                {
                    r = random.Next(0, array.Length + 1);
                }
                randomArray[i] = r;
            }

            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = array[randomArray[i] - 1];
            }

            return resultArray;
        }
        static Array Shuffle(string[] array)
        {
            int[] randomArray = new int[array.Length];
            string[] resultArray = new string[array.Length];
            int r = 0;
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                while (Contain(randomArray, r))
                {
                    r = random.Next(0, array.Length + 1);
                }
                randomArray[i] = r;
            }

            for (int i = 0; i < array.Length; i++)
            {
                resultArray[i] = array[randomArray[i] - 1];
            }

            return resultArray;
        }

        static bool Contain(int[] arr, int num)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    return true;
                }
            }
            return false;
        }
    }
}