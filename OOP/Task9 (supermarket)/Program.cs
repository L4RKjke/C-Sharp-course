using System;
using System.Collections.Generic;
using System.Linq;

namespace Task9__supermarket_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.StartShop();
        }
    }

    class Shop
    {
        private Queue<Client> _clients = new Queue<Client>();

        public Shop()
        {
            _clients.Enqueue(new Client(new List<Product>()
        {
            { new Product(1000, "икра") } ,
            { new Product (200, "хлеб") }
        }, 1500));
            _clients.Enqueue(new Client(new List<Product>()
        {
            { new Product(150, "масло") } ,
            { new Product (45, "хлеб") },   
            { new Product (50, "гречка") }
        }, 200));
            _clients.Enqueue(new Client(new List<Product>()
        {
            { new Product(150, "масло") } ,
            { new Product (80, "хлеб") },
            { new Product (120, "тушенка") }
        }, 160));
        }

        public void StartShop()
        {
            int clientNumber = 1;

            while (_clients.Count() > 0)
            {
                Console.WriteLine($"\nПокупатель {clientNumber++}:");
                TryToPay();
            }
        }

        public void TryToPay ()
        {
            while (_clients.Peek().GetBasketPrice() > _clients.Peek().Money)
            {
                Console.Write("Не хватило денег, покупатель убрал: ");
                _clients.Peek().DeleteRandomProductInBasket();
            }
            Console.WriteLine("Завершил покупку товаров");
            _clients.Dequeue();
        }
    }

    class Client
    {
        private List<Product> _basket = new List<Product>();
        private Random Random = new Random();

        public decimal Money { get; private set; }

        public Client (List<Product> basket, decimal money)
        {
           _basket = basket;
           Money = money;
        }

        public void DeleteRandomProductInBasket()
        {
            int randomProduct = Random.Next(0, _basket.Count());
            Console.WriteLine(_basket[randomProduct].Name);
            _basket.RemoveAt(randomProduct);
        }

        public decimal GetBasketPrice()
        {
            decimal sum = 0;
            foreach (Product product in _basket)
            {
                sum += product.Price;
            }
            return sum;
        }
    }

    class Product
    {
        public decimal Price { get; private set; }

        public string Name { get; private set; }

        public Product(decimal price, string name)
        {
            Name = name;
            Price = price;
        }
    }
}