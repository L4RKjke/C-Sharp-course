using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Searcher searcher = new Searcher();
            searcher.SearchCriminals();
        }
    }

    class Searcher
    {
        private DataBase _data = new DataBase();

        public void SearchCriminals()
        { 
            Console.Write("Введите вес: ");

            if (decimal.TryParse(Console.ReadLine(), out decimal weight) && weight > 0)
            {
                decimal inputWeight = weight;
                Console.Write("Введите рост: ");

                if (decimal.TryParse(Console.ReadLine(), out decimal height) && height > 0)
                {
                    decimal inputHeight = height;
                    Console.Write("Введите национальность: ");
                    string inputNationality = Console.ReadLine();
                    _data.SearchedCriminals(inputWeight, inputHeight, inputNationality);
                }
                else
                {
                    Console.WriteLine("Неправльно введен рост!");
                }
            }
            else
            {
                Console.WriteLine("Неправльно введен вес!");
            }
        }
    }

    class DataBase
    {
        private List<Сriminal> _criminals;

        public DataBase()
        {
            _criminals = new List<Сriminal>()
            {
                { new Сriminal("Петров Василий Иванович", 173, 76, "Фин", false) },
                { new Сriminal("Иванов Никита Викторович", 193, 100, "Филиппинец", false) },
                { new Сriminal("Петров Аркадий Никитович", 167, 65, "Русский", false) },
                { new Сriminal("Пугачев Василий Алексанрович", 180, 92, "Русский", true) },
                { new Сriminal("Пушкин Алекстандр Сергеевич", 167, 65, "Русский", false) }
            };
        }

        public void SearchedCriminals(decimal inputWeight, decimal inputHeight, string inputNationality)
        {
            var SearchedСriminals = from criminal in _criminals
                                    where inputWeight == criminal.Weight && inputHeight == criminal.Height && inputNationality == criminal.Nationality && criminal.IsArested == false
                                    select criminal;

            foreach (var сriminal in SearchedСriminals)
            {
                Console.WriteLine(сriminal.FullName);
            }
        }
    }

    class Сriminal
    {
        public string FullName { get; private set; }

        public decimal Height { get; private set; }

        public decimal Weight { get; private set; }

        public string Nationality { get; private set; }

        public bool IsArested { get; private set; }

        public Сriminal(string fullName, decimal height, decimal weight, string nationality, bool isArested)
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            Nationality = nationality;
            IsArested = isArested;
        }
    }
}
