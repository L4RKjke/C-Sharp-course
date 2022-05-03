using System;
using System.Collections.Generic;

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
        private DataBase _dataBase = new DataBase();

        public void StartService()
        {
            int numberOfClient = 1;

            while (_isClose == false)
            {
                _detailToRapair = GenerateBrokenDetail();
                _dataBase.ShowAllDetails();
                Console.WriteLine("\nБаланс сервиса: " + _balance);
                Console.WriteLine($"\n{numberOfClient} клиент, деталь на починку: {_detailToRapair}, цена c работой: {GetRapairPrice(_detailToRapair)}");
                numberOfClient++;
                Console.WriteLine("\n1 - починить деталь, 2 - отказать, 0 - закрыть сервис");
                SelectComand();

                if (_balance <= 0)
                {
                    Console.WriteLine("В вашем сервисе закончились деньги! Нажмите любую кнопку, чтобы закрыть сервис...");
                    Console.ReadKey(true);
                    _isClose = true;
                }
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

        private void TryToRapairDetail(string detailToRapair) 
        {
            Detail detailValue = null;
            bool isInStock = false;

            foreach (var detail in _dataBase.GetKeys())
                if (detail.Name == _detailToRapair)
                {
                    detailValue = detail;

                    if (_dataBase.GetDetailCount(detail) != 0)
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
                _dataBase.TakeDetail(detailValue);
                _balance += GetRapairPrice(_detailToRapair);
            }
        }

        private decimal GetRapairPrice(string detailToRapair)
        {
            foreach (Detail detail in _dataBase.GetKeys())
            {
                if (detail.Name == detailToRapair)
                    return detail.Price + _dataBase.GetDetailRepairPrice(detailToRapair);
            }

            return 0;
        }

        private string GenerateBrokenDetail()
        {
            int randomDetail = _random.Next(0, _dataBase.GetKeys().Count);
            int dictonaryCounter = 0;
            string randomDetailName = null;

            foreach (var detail in _dataBase.GetKeys())
            {

                if (dictonaryCounter == randomDetail)
                    randomDetailName = detail.Name;
                dictonaryCounter++;
            }

            return randomDetailName;
        }
    }

    class DataBase
    {
        private Dictionary<Detail, int> _details;

        public DataBase()
        {
            _details = new Dictionary<Detail, int>()
            {
                { new Detail("Пыльник", 500 , 500), 2 },
                { new Detail("Тормозной диск", 5000, 100), 4},
                { new Detail("Тормозные колодки", 1000, 500), 12},
                { new Detail("Передний амортизатор", 3000, 1500), 1},
                { new Detail("Задний амортизатор", 3000, 1500), 4 },
                { new Detail("Свечи", 500, 200), 20 },
                { new Detail("Воздушный фильтр", 500, 300), 1 }
            };
        }

        public void ShowAllDetails()
        {
            foreach (var detail in _details.Keys)
            {
                Console.WriteLine($"{detail.Name}: {_details[detail]}");
            }
        }

        public Dictionary<Detail, int>.KeyCollection GetKeys()
        {
            return _details.Keys;
        }

        public int GetDetailCount(Detail detail) 
        {
            return _details[detail];
        }

        public void TakeDetail(Detail detail)
        {
            _details[detail] = _details[detail] - 1;
        }

        public decimal GetDetailRepairPrice(string detailName)
        {
            decimal price = 0;

            foreach (var detail in _details.Keys)
            {
                if (detail.Name == detailName)
                    price = detail.RepairPrice;
            }

            return price;
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
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public decimal RepairPrice { get; private set; }

        public Detail(string name, decimal price, decimal repairPrice)
        {
            Name = name;
            Price = price;
            RepairPrice = repairPrice;
        }
    }
}