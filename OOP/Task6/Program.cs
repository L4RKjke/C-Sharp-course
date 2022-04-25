using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Seller seller = new Seller();
        private Customer customer = new Customer();
        private bool IsClose = false;
        private List<Product> products = new List<Product>();

        public void OpenShop()
        {
            Console.CursorVisible = false;

            while (IsClose == false)
            {
                Console.Clear();
                Console.WriteLine("1 - купить продукт, 2 - выйти из магазин, 3 - вывести список купленных товаров\n");
                seller.ShowProducts();
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
                    IsClose = true;
                    break;

                case '3':
                    customer.ShowCustomerProducts();
                    break;

                default:
                    throw new Exception("некорректный номер команды!");
            }
        }

        private void BuyProduct()
        {
            Console.Write("\nНапишите номер продукта, который вы хотите купить: ");
            string UserInput = Console.ReadLine();

            if (int.TryParse(UserInput, out int numberOfProduct) && numberOfProduct <= seller.GetLength())
            {
                seller.GetProducts().RemoveAt(numberOfProduct - 1);
                customer.BuyProduct(numberOfProduct);
            }
            else
            { 
                throw new Exception("некорректный номер команды!");
            }
        }
    }

    class Customer
    {
        private List<Product> _customerList = new List<Product>();
        private Seller Shop = new Seller();

        public void BuyProduct(int id)
        {
            _customerList.Add(Shop.SellProduct(id - 1));
        }

        public void ShowCustomerProducts()
        {
            Console.Clear();

            foreach (var product in _customerList)
            {
                Console.WriteLine($"{ product.Name}");
            }

            Console.ReadKey(true);
        }
    }

    class Seller
    {
        private List<Product> _productList =  new List<Product>();

        public Seller()
        {
            _productList.Add(new Product("молоко", 80));
            _productList.Add(new Product("кефир", 50));
            _productList.Add(new Product("сливки", 100));
        }

        public Product SellProduct(int id)
        {
            Product product = _productList[id];

            return product;
        }

        public List<Product> GetProducts()
        {
            return _productList;
        }

        public int GetLength()
        {
            return _productList.Count();
        }

        public void ShowProducts()
        {
            int id = 1;

            foreach (var product in _productList)
            {
                Console.WriteLine($"{id++} ) { product.Name}, цена: { product.Price}");
            }
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