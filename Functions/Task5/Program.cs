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

            Shuffle(ref numberArray);

            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.WriteLine(numberArray[i]);
            }
        }
        static void Shuffle(ref int[] array)
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

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = resultArray[i];
            }
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