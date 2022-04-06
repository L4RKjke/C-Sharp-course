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
            int randomNumber = 0;
            int tempValue = 0;
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                while (Contain(randomArray, randomNumber))
                {
                    randomNumber = random.Next(0, array.Length + 1);
                }
                randomArray[i] = randomNumber;
            }

            for (int i = 0; i < array.Length; i++)
            {
                tempValue = array[i];
                array[i] = array[randomArray[i] - 1];
                array[randomArray[i] - 1] = tempValue;
            }
        }

        static bool Contain(int[] array, int num)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == num)
                {
                    return true;
                }
            }
            return false;
        }
    }
}