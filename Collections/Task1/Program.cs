using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasl1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userWord = Console.ReadLine();
            Dictionary<string, int> firstNames = new Dictionary<string, int>()
            {
                { "Tom", 1},
                { "Sam", 2},
                { "Bob", 3}
            };
            if (firstNames.ContainsKey(userWord))
            {
                Console.WriteLine(firstNames[userWord]);
            }
            else
            {
                Console.WriteLine("'" + userWord + "' нет в списке!");
            }
        }
    }
}