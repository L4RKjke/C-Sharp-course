using System;
using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.OpenShop();
        }
    }

    class Shop
    {
        private Seller _seller = new Seller(new List<Product>()
            {
                new Product("сливки", 60),
                new Product("молоко", 80),
                new Product("кефир", 35)
            });
        private Customer _customer = new Customer();
        private bool _isClose = false;

        public void OpenShop()
        {
            Console.CursorVisible = false;

            while (_isClose == false)
            {
                Console.Clear();
                Console.WriteLine("1 - купить продукт, 2 - выйти из магазин, 3 - вывести список купленных товаров\n");
                _seller.ShowUserProducts();
                SelectComand();
            }
        }

        private void SelectComand()
        {
            char menuComand = Convert.ToChar(Console.ReadKey(true).Key);

            switch (menuComand)
            {
                case '1':
                    BuyProduct();
                    break;

                case '2':
                    _isClose = true;
                    break;

                case '3':
                    ShowPurchasedProducts();
                    break;

                default:
                    throw new Exception("некорректный номер команды!");
            }
        }

        private void BuyProduct()
        {
            Console.Write("\nНапишите номер продукта, который вы хотите купить: ");
            string UserInput = Console.ReadLine();

            if (int.TryParse(UserInput, out int numberOfProduct) && numberOfProduct <= _seller.GetLength())
            {
                _customer.BuyProduct(_seller.SellProduct(numberOfProduct - 1));
            }
            else
            {
                throw new Exception("некорректный номер команды!");
            }
        }

        private void ShowPurchasedProducts()
        {
            Console.Clear();
            _customer.ShowUserProducts();
            Console.ReadKey(true);
        }
    }

    class User
    {
        protected List<Product> _productList = new List<Product>();

        public User (List<Product>  productList)
        {
            _productList = productList;
        }

        public User(){}

        public void ShowUserProducts()
        {
            int id = 1;

            foreach (var product in _productList)
            {
                Console.WriteLine($"{id++}) { product.Name}, {product.Price}");
            }
        }
    }

    class Customer: User
    {
        public Customer() : base() { }
 
        public void BuyProduct(Product product)
        {
            _productList.Add(product);
        }
    }

    class Seller: User
    {
        public Seller(List<Product> productList) : base(productList) { }

        public Seller() : base() { }

        public Product SellProduct(int id)
        {
            Product product = _productList[id];
            _productList.RemoveAt(id);
            return product;
        }

        public int GetLength()
        {
            return _productList.Count();
        }
    }

    class Product
    {
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}