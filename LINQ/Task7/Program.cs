using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Army army = new Army();
            Console.WriteLine("Выберите id отряда, из которого вы хотите забрать бойцов: 0");
            int firstId = 0;
            Console.WriteLine("Выберите id отряда, в который вы хотите переместить бойцов: 1\n");
            int secondId = 1;
            army.TranferSoldier(firstId, secondId);
            Console.WriteLine("\nОтряд 1.\n");
            army.ShowPlatoon(firstId);
            Console.WriteLine("\nОтряд 2.\n");
            army.ShowPlatoon(secondId);
        }
    }

    class Army
    {
        private List<List<Soldier>> _platoons = new List<List<Soldier>>();

        public Army()
        {
            _platoons.Add(new List<Soldier>
            {
            new Soldier("Пушкин", "some equipment", "silver1", 24),
            new Soldier("Бурунов", "some equipment", "silver2", 24),
            new Soldier("Борисов", "some equipment", "silver3", 12),
            new Soldier("Абрамович", "some equipment", "silver4", 12),
            new Soldier("Плюшкин", "some equipment", "silver5", 24)
            });
            _platoons.Add(new List<Soldier>
            {
            new Soldier("Иванов", "some equipment", "silver1", 24),
            new Soldier("Бурунов", "some equipment", "silver3", 24),
            new Soldier("Деревянко", "some equipment", "silver7", 12),
            new Soldier("Абрамович", "some equipment", "silver5", 12),
            new Soldier("Собакевич", "some equipment", "silver6", 24)
            });
        }

        public void TranferSoldier(int firstId, int secondId)
        {
            _platoons[secondId] = _platoons[secondId].Union(from soldier in _platoons[firstId] where soldier.LastName.StartsWith("Б") select soldier).ToList();
            _platoons[firstId] = (from soldier in _platoons[firstId] where soldier.LastName.StartsWith("Б") == false select soldier).ToList();
        }

        public void ShowPlatoon(int id)
        {
            foreach (var soldier in _platoons[id]) 
            {
                Console.WriteLine(soldier.LastName);
            }
        }
    }

    class Soldier
    {
        public string LastName { get; private set; }
        public string Equipment { get; private set; }
        public string Rank { get; private set; }
        public int ServiceTime { get; private set; }

        public Soldier(string name, string equipment, string rank, int serviceTime)
        {
            LastName = name;
            Equipment = equipment;
            Rank = rank;
            ServiceTime = serviceTime;
        }
    }
}
