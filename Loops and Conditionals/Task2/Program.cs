using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Перечислите реки России, которые вы знаете:");
            string stopWord = "exit";

            while (true)
            {
                string word = Convert.ToString(Console.ReadLine());

                if (word == stopWord)
                {
                    break;
                }
            }
        }
    }
}
