using System;
using System.Collections.Generic;

namespace Task12_zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.OpenZoo();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();
        private bool _isClose = false;

        public Zoo()
        {
            _aviaries.Add(new Aviary(new List<Animal>() { new Animal("male", "гав-гав"), new Animal("female", "муу-муу"), new Animal("female", "мау-мау")}, "домашние животные"));
            _aviaries.Add(new Aviary(new List<Animal>() { new Animal("female", "кар-кар"), new Animal("male", "кря-кря") }, "птицы"));
            _aviaries.Add(new Aviary(new List<Animal>() { new Animal("male", "ква-ква"), new Animal("female", "пиу-пиу") }, "дикие животные"));
            _aviaries.Add(new Aviary(new List<Animal>() { new Animal("female", "ш-ш-ш"), new Animal("male", "р-р-р") }, "хищники"));
        }

        public void OpenZoo()
        {
            while (_isClose == false)
            {
                Console.Write($"Выберите 1 вольер из {_aviaries.Count}: ");

                if (int.TryParse(Console.ReadLine(), out int id) && id <= _aviaries.Count && id > 0)
                    ShowAviary(id);
                else
                    Console.WriteLine("Повторите команду...");

                Console.WriteLine("\n1 - вернуться назад, 0 - выйти.");
                ChooseComand();
            }
        }

        private void ShowAviary(int id)
        {
            Console.WriteLine($"\n{_aviaries[id].Name}\n" );
            _aviaries[id].ShowAnimals();
            Console.WriteLine($"всего животных: {_aviaries[id].GetNumberOfAnimals()}");
        }

        private void ChooseComand()
        {
            char menuComand = Convert.ToChar(Console.ReadKey(true).Key);

            switch (menuComand)
            {
                case '1':
                    Console.Clear();
                    break;

                case '0':
                    _isClose = true;
                    break;

                default:
                    Console.WriteLine("Повторите команду!");
                    break;
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public string Name { get; set; }

        public Aviary(List<Animal> animals, string name)
        {
            Name = name;
            _animals = animals;
        }

        public int GetNumberOfAnimals()
        {
            return _animals.Count;
        }

        public void ShowAnimals()
        {
            foreach (var animal in _animals)
                Console.WriteLine(animal.Noise + ", " + animal.Gender);
        }
    }

    class Animal
    {
        public string Gender { get; set; }

        public string Noise { get; set; }

        public Animal(string gender, string noise)
        {
            Gender = gender;
            Noise = noise;
        }
    }
}