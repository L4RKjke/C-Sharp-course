using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Searcher searcher = new Searcher();
            searcher.StartMenu();
        }
    }

    class Searcher
    {
        private DataBase _data = new DataBase();
        private bool _isClose = false;

        public void StartMenu()
        {
            while (_isClose == false)
            {
                Console.Clear();
                Console.WriteLine("1 - отсортировать по ФИО, 2 - отсортировать по возрасту, 3 - вывести больных с определенным заболеванием, 4 - выйти\n");
                ChooseComand();
                Console.WriteLine("\nНажмите любую кнопку, чтобы вернуться в меню.");
                Console.ReadKey(true);
            }
        }

        private void ChooseComand()
        {
            char menuComand = Convert.ToChar(Console.ReadKey(true).Key);
            Console.Clear();

            switch (menuComand)
            {
                case '1':
                    _data.SortByFullName();
                    break;

                case '2':
                    _data.SortByAge();
                    break;

                case '3':
                    _data.FindByDisease(Console.ReadLine());
                    break;

                case '4':
                    _isClose = true;
                    break;

                default:
                    Console.WriteLine("Повторите команду!");
                    break;
            }
        }
    }

    class DataBase
    {
        private List<Patient> _patients;

        public DataBase()
        {
            _patients = new List<Patient>()
            {
                { new Patient("Петров Василий Иванович", 54,  "Сахарный диабет") },
                { new Patient("Иванов Никита Викторович", 5, "Перелом") },
                { new Patient("Петров Аркадий Никитович", 15, "Перелом") },
                { new Patient("Пугачев Василий Алексанрович", 23, "Вывих") },
                { new Patient("Пушкин Алекстандр Сергеевич", 34, "Простуда") },
                { new Patient("Рыбаков Николай Леонидович", 65,  "Ушиб") },
                { new Patient("Маркова Кира Олеговна", 5, "Перелом") },
                { new Patient("Черный Михаил Павлович", 12, "Перелом") },
                { new Patient("Овсянникова Варвара Дмитриевна", 76, "Вывих") },
                { new Patient("Серебрякова Екатерина Степановна", 87, "Простуда") }
            };
        }

        public void SortByFullName()
        {
            ShowPatients(_patients.OrderBy(patient => patient.FullName)); 
        }

        public void SortByAge()
        {
            ShowPatients(_patients.OrderBy(patient => patient.Age));
        }

        public void FindByDisease(string disease)
        {
            ShowPatients(_patients.Where(patient => patient.Disease.ToLower() == disease.ToLower()));
        }

        private void ShowPatients(IEnumerable<Patient> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"Пациент: {patient.FullName}, заболевание: {patient.Disease}, возраст: {patient.Age}");
            }
        }
    }   

    class Patient
    {
        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public Patient(string fullName, int age, string disease)
        {
            FullName = fullName;
            Age = age;
            Disease = disease;
        }
    }
}