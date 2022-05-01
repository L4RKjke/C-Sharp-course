using System;
using System.Collections.Generic;

namespace Task11_aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AquariumAdministration aquariumAdministration = new AquariumAdministration();
            aquariumAdministration.StartLive();
        }
    }

    class AquariumAdministration
    {
        private Aquarium _aquarium = new Aquarium();
        private int _day = 240;
        private bool _isClose = false;

        public void StartLive()
        {
            while (_isClose == false)
            {
                Console.Clear();
                StartAquarium();
                _aquarium.ShowFish();
                _aquarium.MakeOlder();
                System.Threading.Thread.Sleep(_day);
            }
        }

        private void StartAquarium()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("1 - добавить рыбу в аквариум, 2 - достать рыбу из аквариума, 3 - отойти от аквариума");

            if (Console.KeyAvailable)
            {
                char menuComand = Convert.ToChar(Console.ReadKey(true).Key);

                switch (menuComand)
                {
                    case '1':
                        AddFish();
                        break;

                    case '2':
                        TakeFish();
                        break;

                    case '3':
                        _isClose = true;
                        break;

                    default:
                        Console.WriteLine("Повторите команду!");
                        break;
                }
            }     
        }

        private void AddFish()
        {
            Console.Write("\nНазвание рыбы: ");
            string name = Console.ReadLine();
            Console.Write("Возраст рыбы (в днях): ");

            if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
                _aquarium.AddFish(new Fish(name, age));
            else
                Console.WriteLine("введите правильный возраст!");
        }

        private void TakeFish()
        {
            Console.Write("Номер рыбы, которую хотите достать: ");

            if (int.TryParse(Console.ReadLine(), out int numberOfFish) && numberOfFish <= _aquarium.GetNumberOfFish() && numberOfFish > 0)
                _aquarium.DeleteFish(numberOfFish - 1);
            else
                Console.WriteLine("введите правльный номер!");
        }
    }

    class Aquarium
    {
        private List<Fish> _fishList = new List<Fish>();
        private int _maxPlaces = 10;

        public void AddFish(Fish fish)
        {
            if (_fishList.Count <= _maxPlaces)
                _fishList.Add(fish);
            else
                Console.WriteLine("Аквариум переполнен!");
        }

        public void DeleteFish(int id)
        {
            _fishList.RemoveAt(id);
        }

        public void ShowFish()
        {
            int fishLabelPositionY = 0;
            int fishLabelPositionX = 87;

            foreach (var fish in _fishList)
            {
                Console.SetCursorPosition(fishLabelPositionX, fishLabelPositionY++);

                if (fish.Age <= fish.Health)
                    Console.WriteLine("| " + fish.Name + ", " + "возраст: " + fish.Age);
                else
                    Console.WriteLine("| " + fish.Name + " - мертва");
            }
        }

        public void MakeOlder()
        {
            foreach (var fish in _fishList)
                fish.MakeOlder();
        }
        
        public int GetNumberOfFish()
        {
            return _fishList.Count;
        }
    }

    class Fish
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Health { get; private set; } = 100;

        public Fish(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void MakeOlder()
        {
            Age++;
        }
    }
}