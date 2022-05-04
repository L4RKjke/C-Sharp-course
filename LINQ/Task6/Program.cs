using System;
using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.ShowSoldierRank();
        }
    }

    class DataBase
    {
        private List<Soldier> _soldiers;

        public DataBase()
        {
            _soldiers = new List<Soldier>()
            {
                new Soldier("Name1", "some equipment", "silver1", 24),
                new Soldier("Name2", "some equipment", "silver2", 24),
                new Soldier("Name3", "some equipment", "silver3", 12),
                new Soldier("Name4", "some equipment", "silver4", 12),
                new Soldier("Name5", "some equipment", "silver5", 24),
            };
        }

        public void ShowSoldierRank() 
        {
            var soldersList = from soldier in _soldiers
                              select new
                              {
                                  soldier.Name,
                                  soldier.Rank
                              };

            foreach (var solder in soldersList)
            {
                Console.WriteLine(solder.Name + ", ранг: " + solder.Rank);
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Equipment { get; private set; }
        public string Rank { get; private set; }
        public int ServiceTime { get; private set; }

        public Soldier(string name, string equipment, string rank, int serviceTime)
        {
            Name = name;
            Equipment = equipment;
            Rank = rank;
            ServiceTime = serviceTime;               
        }
    }
}
