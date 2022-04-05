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

            int[] array = new int[30] { 5, 5, 9, 9, 9, 13, 5, 5, 5, 5, 9, 9, 9, 9, 9, 5, 5, 9, 9, 14, 5, 5, 54, 5, 6, 9, 12, 9, 54, 9 };

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            int tempMinValue = int.MinValue;
            int repeatСounter = 0;
            int meetingsTimes = 0;
            int frequentNumber = 0;

            for (int i = 0; i < array.Length; i++)
            {

                if (tempMinValue != array[i])
                {
                    repeatСounter = 0;
                    tempMinValue = array[i];
                }
                else
                {
                    repeatСounter++;

                    if (repeatСounter >= meetingsTimes)
                    {
                        meetingsTimes = repeatСounter;
                        frequentNumber = array[i];
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Число {frequentNumber} повторяется {(meetingsTimes + 1)} раз подряд.");
        }
    }
}
