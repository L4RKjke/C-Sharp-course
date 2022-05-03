using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
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
            string detentionReason = "Антиправительственное";
            _data.SearchByDetention(detentionReason);
        }
    }

    class DataBase
    {
        private List<Сriminal> _criminals;

        public DataBase()
        {
            _criminals = new List<Сriminal>()
            {
                { new Сriminal("Петров Василий Иванович", "Кража") },
                { new Сriminal("Иванов Никита Викторович", "Убийство") },
                { new Сriminal("Петров Аркадий Никитович", "Антиправительственное") },
                { new Сriminal("Пугачев Василий Алексанрович", "Антиправительственное") },
                { new Сriminal("Пушкин Алекстандр Сергеевич", "Хулиганство") }
            };
        }

        public void SearchByDetention(string detentionReason)
        {
            var SearchedСriminals = _criminals.Where(criminal => criminal.DetentionReason.Contains(detentionReason));

            foreach (var сriminal in SearchedСriminals)
            {
                Console.WriteLine(сriminal.FullName);
            }
        }
    }

    class Сriminal
    {
        public string FullName { get; private set; }

        public string DetentionReason { get; private set; }

        public Сriminal(string fullName, string detentionReason)
        {
            FullName = fullName;
            DetentionReason = detentionReason;
        }
    }
}