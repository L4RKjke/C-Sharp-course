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
            int shopBalance = 0;
            List<int> prices = new List<int>() { 700, 80, 2000, 60 };
            Queue<int> productPrices = new Queue<int>(prices);

            while (productPrices.Count > 0)
            {
                shopBalance += productPrices.Peek();
                productPrices.Dequeue();
                Console.WriteLine($"Баланс магазина: {shopBalance}");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
