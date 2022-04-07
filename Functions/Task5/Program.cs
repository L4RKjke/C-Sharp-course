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

            Shuffle(numberArray);   

            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.WriteLine(numberArray[i]);
            }
        }
        static void Shuffle(int[] array)
        {
            int randomNumber = 0;
            int tempValue = 0;
            Random random = new Random();

            for (int j = 0; j < random.Next(0, array.Length); j++)
            {
                randomNumber = random.Next(0, array.Length);

                for (int i = 0; i < array.Length - 1; i++)
                {
                    tempValue = array[i];
                    array[i] = array[randomNumber + 1];
                    array[randomNumber + 1] = tempValue;
                }
            }
        }
    }
}