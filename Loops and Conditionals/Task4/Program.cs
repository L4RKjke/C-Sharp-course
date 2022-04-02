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

            for (int i = 0; i <= randomNumber; i ++)
            {
                Console.WriteLine(i);
                if (i%5 == 0 || i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
                
            }
        }
    }
}
