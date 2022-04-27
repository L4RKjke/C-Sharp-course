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
        private List<Train> _flights = new List<Train>();
        private string _pointOfDeparture;
        private string _trainArrivalPoint;
        private int _numberOfPessengers;
        private bool _isFirsteTrainDeparted = false;
        private bool _isClose = false;

        public void StartMenu()
        {
            Console.CursorVisible = false;

            while (_isClose == false)
            {
                Console.Clear();

                if (_isFirsteTrainDeparted)
                    foreach (var train in _flights)
                        train.ShowInfo();

                CreateTrainDirection();
                GenerateNumbersOfPessangers();
                SeatPeople();
                SendTrain();
                Console.WriteLine("1 - продолжить, 0 - выйти");
                SelectComand();
            }
        }

        private void CreateTrainDirection()
        {
            Console.WriteLine("\nЗадать направление для поезда\n");
            Console.Write("Точка отправления воезда: ");
            _pointOfDeparture = Console.ReadLine();
            Console.Write("\nТочка прибытия поезда: ");
            _trainArrivalPoint = Console.ReadLine();
        }

        private void GenerateNumbersOfPessangers()
        {
            Random random = new Random();
            int minPessangers = 32;
            int maxPessangers = 540;
            _numberOfPessengers = random.Next(minPessangers, maxPessangers);
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
                    Console.WriteLine("некорректный номер команды!");
                    break;
            }
        }

        private void SeatPeople()
        {
            List<Wagon> wagons = new List<Wagon>();
            int passengersLeft = _numberOfPessengers;
            int smallWagonMaxPlaces = 36;
            int bigWagonMaxPlaces = 54;

            while (passengersLeft > 0)
            {
                if (passengersLeft <= smallWagonMaxPlaces)
                {
                    wagons.Add(new Wagon(passengersLeft));
                    passengersLeft -= passengersLeft;
                }
                else if (passengersLeft <= bigWagonMaxPlaces)
                {
                    wagons.Add(new Wagon(passengersLeft));
                    passengersLeft -= passengersLeft;
                }
                else
                {
                    wagons.Add(new Wagon(bigWagonMaxPlaces));
                    passengersLeft -= bigWagonMaxPlaces;
                }
            }
            _flights.Add(new Train(new List<Wagon>(wagons), string.Concat(_pointOfDeparture, " - ", _trainArrivalPoint), _numberOfPessengers)); 
            wagons.Clear();
        }

        private void SendTrain()
        {
            if (_isFirsteTrainDeparted == false)
                _isFirsteTrainDeparted = true;
        }
    }

    class Train
    {
        private List<Wagon> _wagons;
        private string _flightName;
        private int _pessangers;

        public Train(List<Wagon> wagons, string flightName, int pessangers)
        {
            _wagons = wagons;
            _flightName = flightName;
            _pessangers = pessangers;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Рейс: {_flightName}, пассажиров: {_pessangers}, вагонов: {_wagons.Count()}");
        }   
    }

    class Wagon
    {
        private int _places;

        public Wagon(int places)
        {
            _places = places;
        }
    }
}