using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlanMaker planMaker = new PlanMaker();
            planMaker.StartMenu();
        }
    }

    class PlanMaker
    {
        private List<Wagon> _wagons = new List<Wagon>();
        private List<Flight> _flights = new List<Flight>();
        private SmallWagon _smallWagon = new SmallWagon();
        private BigWagon _bigWagon = new BigWagon();
        private Random _random = new Random();
        private Flight _flightOfTheTrain;
        private Flights _trainFlights;
        private Train _train;
        private string _pointOfDeparture;
        private string _trainArrivalPoint;
        private bool _isClose = false;
        private bool _isFirsteTrainDeparted = false;
        private int minPessangers = 32;
        private int maxPessangers = 540;
        private int _numberOfPessengers = 0;

        public void StartMenu()
        {
            Console.CursorVisible = false;

            while (_isClose == false)
            {
                Console.Clear();

                if (ShowFlights() != null)
                {
                    foreach (var flight in ShowFlights())
                    {
                        Console.WriteLine(flight);
                    }
                }
                СreateTrainDirection();
                GenerateNumbersOfPessangers();
                SeatPeople();
                SendTrain();
                Console.WriteLine("1 - продолжить, 0 - выйти");
                SelectComand();
            }
        }

        private void СreateTrainDirection()
        {
            Console.WriteLine("\nЗадать направление для поезда\n");
            Console.Write("Точка отправления воезда: ");
            _pointOfDeparture = Console.ReadLine();
            Console.Write("\nТочка прибытия поезда: ");
            _trainArrivalPoint = Console.ReadLine();
        }

        private void GenerateNumbersOfPessangers()
        {
            _numberOfPessengers = _random.Next(minPessangers, maxPessangers);
            Console.WriteLine("\nКуплено билетов: " + _numberOfPessengers);
            Console.WriteLine("\nНажмите любую кнопку, чтобы продолжить...");
            Console.ReadKey(true);
        }

        private void SelectComand()
        {
            char menuComand = Convert.ToChar(Console.ReadKey(true).Key);

            switch (menuComand)
            {
                case '1':
                    break;

                case '0':
                    _isClose = true;
                    break;

                default:
                    throw new Exception("некорректный номер команды!");
            }
        }

        private void SeatPeople()
        {
            int passengersLeft = _numberOfPessengers;

            while (passengersLeft > 0)
            {
                if (passengersLeft <= _smallWagon.MaxPlaces)
                {
                    _wagons.Add(new SmallWagon(passengersLeft));
                    passengersLeft -= passengersLeft;
                }
                else if (passengersLeft <= _bigWagon.MaxPlaces)
                {
                    _wagons.Add(new BigWagon(passengersLeft));
                    passengersLeft -= passengersLeft;
                }
                else
                {
                    _wagons.Add(new BigWagon(_bigWagon.MaxPlaces));
                    passengersLeft -= _bigWagon.MaxPlaces;
                }
            }
            _train = new Train(new List<Wagon>(_wagons));
            _wagons.Clear();
        }

        private void SendTrain()
        {
            _flightOfTheTrain = new Flight(string.Concat(_pointOfDeparture, " - ", _trainArrivalPoint), _train.GetSumOfPessengers());
            _flights.Add(_flightOfTheTrain);
            _trainFlights = new Flights(new List<Flight>(_flights));
            _isFirsteTrainDeparted = true;
        }

        private List<string> ShowFlights()
        {
            if (_isFirsteTrainDeparted)
                return _trainFlights.ShowFlights();  
            else
                return null;
        }
    }

    class Flights
    {
        private List<Flight> _flights = new List<Flight>();

        public Flights(List<Flight> flight)
        {
            _flights = flight;
        }

        public List<string> ShowFlights()
        {
            List<string> flights = new List<string>();

            foreach (var flight in _flights)
            {
                flights.Add($"Маршрут: {flight.RaceName}, пассажиров в поезде: {flight.Pessangers}");
            }

            return flights;
        }

        public int GetNumberOfRaces()
        {
            return _flights.Count();
        }
    }

    class Flight
    {
        public string RaceName { get; protected set; }

        public int Pessangers { get; protected set; }

        public Flight() { }

        public Flight(string raceName, int pessangers)
        {
            RaceName = raceName;
            Pessangers = pessangers;
        }
    }

    class Train
    {
        private List<Wagon> _wagons = new List<Wagon>();

        public Train(List<Wagon> wagons)
        {
            _wagons = wagons;
        }

        public Train() { }

        public void ShowWagons()
        {
            foreach (var wagon in _wagons)
            {
                Console.WriteLine(wagon.Places);
            }
        }

        public int GetSumOfPessengers()
        {
            int sum = 0;

            foreach (var wagon in _wagons)
            {
                sum += wagon.Places;
            }
            return sum;
        }
    }

    class Wagon
    {
        public int Places { get; protected set; }

        public Wagon(int places)
        {
            Places = places;
        }

        public Wagon()
        {
        }
    }

    class SmallWagon : Wagon
    {
        public int MaxPlaces { get; private set; } = 36;

        public SmallWagon(int places) : base(places)
        {
            Places = places;
        }

        public SmallWagon() : base() { }
    }

    class BigWagon : Wagon
    {
        public int MaxPlaces { get; private set; } = 54;

        public BigWagon(int places) : base(places)
        {
            Places = places;
        }

        public BigWagon() : base(){}
    }
}