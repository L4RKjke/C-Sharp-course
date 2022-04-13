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
            Random random = new Random();
            int randomProduct;
            int shopBalance = 0;
            List<string> clientsNames = new List<string>() { "Никита", "Максим", "Саша" };
            Queue<string> clients = new Queue<string>(clientsNames);
            Dictionary<string, int> gods = new Dictionary<string, int>()
            {
                { "Сапоги", 700 },
                { "Перчатки", 80 },
                { "Каска", 2000 },
                { "Клей", 60 },

            };
            Dictionary<int, string> productOrder = new Dictionary<int, string>()
            {
                { 1,  "Сапоги"},
                { 2,  "Перчатки"},
                { 3,  "Каска"},
                { 4,  "Клей"},

            };
            while (clients.Count > 0)
            {
                randomProduct = random.Next(1, 5);
                shopBalance += gods[productOrder[randomProduct]];
                Console.WriteLine($"{clients.Peek()} купил: '{productOrder[randomProduct]}'");
                clients.Dequeue();
                Console.WriteLine($"Баланс магазина: {shopBalance}");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
