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
            Dictionary<int, string> firstNames = new Dictionary<int, string>()
            {
                { 1, "Tom"},
                { 2, "Sam"},
                { 3, "Bob"}
            };
            foreach (var nameIndex in firstNames.Keys)
            {
                if (firstNames.Values.Contains(userWord))
                {
                    Console.WriteLine("Значение введенного слова: " + nameIndex);
                    break;
                }
                else
                {
                    Console.WriteLine("'" + userWord + "' нет в списке!");
                    break;
                }
            }
        }
    }
}