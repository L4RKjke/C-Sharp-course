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
            char symbol  = Convert.ToChar(Console.ReadLine());
            string symbolLine = new string(symbol, name.Length + 2);
            Console.WriteLine(symbolLine);
            Console.WriteLine(symbol + name + symbol);
            Console.WriteLine(symbolLine);
        }
    }
}
