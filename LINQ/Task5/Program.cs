using System;
using System.Collections.Generic;
using System.Linq;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            int currentYear = 2022;
            dataBase.ShowOverdue(currentYear);
        }
    }

    class DataBase
    {
        private List<Stew> _stewPackage;

        public DataBase()
        {
            _stewPackage = new List<Stew>() 
            {
                new Stew("stew1", 1990, 25),
                new Stew("stew2", 2020, 4),
                new Stew("stew3", 2017, 9),
                new Stew("stew4", 2014, 8),
                new Stew("stew5", 2012, 5),
                new Stew("stew6", 2012, 11),
                new Stew("stew7", 2015, 12),
                new Stew("stew8", 1992, 35),
                new Stew("stew9", 1990, 15),
                new Stew("stew10", 2021, 35),
                new Stew("stew11", 1999, 15),
                new Stew("stew12", 1989, 10) 
            };
        }

        public void ShowOverdue(int currentYear) 
        {
            var overdue = _stewPackage.Where(stew => currentYear - stew.YearOfIssue > stew.ShelfLife);

            foreach (var stew in overdue)
            {
                Console.WriteLine($"{stew.Name}, год производства: {stew.YearOfIssue}, срок годности: {stew.ShelfLife}, просрочена на: {(currentYear - stew.YearOfIssue) - stew.ShelfLife} лет");
            }
        }
    }

    class Stew
    {
        public string Name { get; private set; }    
        public int YearOfIssue { get; private set; }
        public int ShelfLife { get; private set; }

        public Stew(string name, int yearOfIssue, int shelfLife)
        {
            Name = name;
            YearOfIssue = yearOfIssue;
            ShelfLife = shelfLife;
        }
    }
}
