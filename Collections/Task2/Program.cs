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
            Queue<int> clients = new Queue<int>(prices);

            while (clients.Count > 0)
            {
                shopBalance += clients.Peek();
                clients.Dequeue();
                Console.WriteLine($"Баланс магазина: {shopBalance}");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
