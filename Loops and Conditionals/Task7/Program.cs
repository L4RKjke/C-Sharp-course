using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите любой символ:");
            char symbol = Convert.ToChar(Console.ReadLine());
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < name.Length + 2; j++)
                {
                    if (i == 1)
                    {
                        Console.Write(symbol + name + symbol);
                        break;
                    }
                    else
                    {
                        Console.Write(symbol);
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
