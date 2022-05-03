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
                    SortByFullName();
                    break;

                case '2':
                    SortByAge();
                    break;

                case '3':
                    PatientsWithCertainDisease();
                    break;

                case '4':
                    _isClose = true;
                    break;

                default:
                    Console.WriteLine("Повторите команду!");
                    break;
            }
        }

        private void SortByFullName()
        {
            _data.SortByFullName(out IEnumerable<Patient> sortedByFullName);
            ShowPatients(sortedByFullName);
        }

        private void SortByAge()
        {
            _data.SortByAge(out IEnumerable<Patient> sortedByAge);
            ShowPatients(sortedByAge);
        }

        private void PatientsWithCertainDisease()
        {
            string disease = Console.ReadLine();
            _data.FindByDisease(disease, out IEnumerable<Patient> searchedPatients);

            if (searchedPatients.Count() == 0)
            {
                Console.WriteLine("\nПациента найти не удалось.");
            }
            else
            {
                ShowPatients(searchedPatients);
            }
        }

        private void ShowPatients(IEnumerable<Patient> patients)
        {
            _data.ShowPatients(patients);
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
                { new Patient("Петров Василий Иванович", 12,  "Сахарный диабет") },
                { new Patient("Иванов Никита Викторович", 4, "Перелом") },
                { new Patient("Петров Аркадий Никитович", 65, "Простуда") },
                { new Patient("Пугачев Василий Алексанрович", 23, "Вывих") },
                { new Patient("Пушкин Алекстандр Сергеевич", 23, "Перелом") }
            };
        }

        public void SortByFullName(out IEnumerable<Patient> sortedByFullName)
        {
            sortedByFullName = _patients.OrderBy(patient => patient.FullName);
        }

        public void SortByAge(out IEnumerable<Patient> sortedByAge)
        {
            sortedByAge = _patients.OrderBy(patient => patient.Age);
        }

        public void FindByDisease(string disease, out IEnumerable<Patient> searchedPatients)
        {
            searchedPatients = _patients.Where(patient => patient.Disease.ToLower() == disease.ToLower());
        }

        public void ShowPatients(IEnumerable<Patient> patients)
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