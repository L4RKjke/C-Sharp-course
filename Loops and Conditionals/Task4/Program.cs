using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(0, 101);
            int sum = 0;
            int firstDivisibilityCheck = 3;
            int secondDivisibilityCheck = 5;

            for (int i = 0; i <= randomNumber; i ++)
            {
                if (i%firstDivisibilityCheck == 0 || i % secondDivisibilityCheck == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
