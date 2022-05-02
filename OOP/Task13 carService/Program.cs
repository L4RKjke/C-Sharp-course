using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task13_Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();
            carService.StartService();
        }
    }

    class CarService
    {
        private bool _isClose = false;
        private decimal _forfeit = 1000;
        private decimal _balance = 5000;
        private string _detailToRapair;
        private Random _random = new Random();
        private Dictionary<Detail, int> _details;
        private Dictionary<string, int> _priceList = new Dictionary<string, int>() 
        {
            { "Пыльник", 500 },
            { "Тормозной диск", 1000 },
            { "Тормозные колодки", 500 },
            { "Передний амортизатор", 1500 },
            { "Задний амортизатор", 1500 },
            { "Свечи", 100 },
            { "Воздушный фильтр", 500 },
        };

        public CarService()
        {
            _details = new Dictionary<Detail, int>()
            {
                { new Detail("Пыльник", 500), 2 },
                { new Detail("Тормозной диск", 5000), 4},
                { new Detail("Тормозные колодки", 1000), 12},
                { new Detail("Передний амортизатор", 3000), 1},
                { new Detail("Задний амортизатор", 3000), 4 },
                { new Detail("Свечи", 500), 20 },
                { new Detail("Воздушный фильтр", 500), 1 }
            };
        }

        public void StartService()
        {
            int numberOfClient = 1;

            while (_isClose == false)
            {
                _detailToRapair = GenerateBrokenDetail();
                ShowAllDetails();
                Console.WriteLine("\nБаланс сервиса: " + _balance);
                Console.WriteLine($"\n{numberOfClient} клиент, деталь на починку: {_detailToRapair}, цена c работой: {GetRapairPrice(_detailToRapair)}");
                numberOfClient++;
                Console.WriteLine("\n1 - починить деталь, 2 - отказать, 0 - закрыть сервис");
                SelectComand();
            }
        }

        private void SelectComand()
        {
            char menuComand = Convert.ToChar(Console.ReadKey(true).Key);
            Console.Clear();

            switch (menuComand)
            {
                case '1':
                    TryToRapairDetail(_detailToRapair);
                    break;

                case '2':
                    _balance -= _forfeit;
                    break;

                case '0':
                    _isClose = true;
                    break;

                default:
                    Console.WriteLine("Неверный номер команды! Нажмите любую кнопку, чтобы продолжить...");
                    Console.ReadKey();
                    break;
            }
        }

        private void ShowAllDetails()
        {
            foreach (var detail in _details.Keys)
            {
                Console.WriteLine($"{detail.Name}: {_details[detail]}");
            }
        }

        private void TryToRapairDetail(string detailToRapair) 
        {
            Detail detailValue = null;
            bool isInStock = false;

            foreach (var detail in _details.Keys)
                if (detail.Name == _detailToRapair)
                {
                    detailValue = detail;

                    if (_details[detail] != 0)
                    {
                        isInStock = true;
                    }
                }

            if (isInStock == false)
            {
                _balance -= GetRapairPrice(_detailToRapair);
            }
            else if (detailValue != null)
            {
                _details[detailValue] = _details[detailValue] - 1;
                _balance += GetRapairPrice(_detailToRapair);
            }
        }

        private decimal GetRapairPrice(string detailToRapair)
        {
            foreach (Detail detail in _details.Keys)
            {
                if (detail.Name == detailToRapair)
                    return detail.Price + _priceList[detailToRapair];
            }

            return 0;
        }

        private string GenerateBrokenDetail()
        {
            List<String> details = new List<String>() 
            {
                "Пыльник",
                "Тормозной диск",
                "Тормозные колодки",
                "Передний амортизатор",
                "Задний амортизатор",
                "Свечи",
                "Воздушный фильтр",
            };

            int randomDetail = _random.Next(0, details.Count);

            return details[randomDetail];
        }
    }

    class Client
    {
        public Detail BrokenDetail { get; private set; }

        public Client(Detail brokenDatail)
        {
            BrokenDetail = brokenDatail;
        }
    }

    class Detail
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Detail(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}