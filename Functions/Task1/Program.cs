using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isClose = false;
            string[] usersFullName = new string[1];
            string[] usersPosition = new string[1];

            while (isClose == false)
            {
                Console.Clear();
                Console.SetCursorPosition(7, 1);
                Console.WriteLine("Меню\n");
                Console.WriteLine("1 - Добавить досье\n");
                Console.WriteLine("2 - Вывести все досье\n");
                Console.WriteLine("3 - Удалить досье\n");
                Console.WriteLine("4 - Поиск по фамилии\n");
                Console.WriteLine("0 - Выход\n");
                string menuComand = Convert.ToString(Console.ReadKey(true).Key);

                switch (menuComand)
                {
                    case "D1":
                        AddDossier(ref usersFullName, ref usersPosition);
                        break;

                    case "D2":
                        PrintDossieList(usersFullName, usersPosition);
                        break;

                    case "D3":
                        DeleteDossier(ref usersFullName, ref usersPosition);
                        break;

                    case "D4":
                        SearchDossier(usersFullName, usersPosition);
                        break;

                    case "D0":
                        Console.Clear();
                        isClose = true;
                        break;

                    default:
                        Console.WriteLine("Неверный номер команды!");
                        break;
                }
            }
        }

        static void AddDossier(ref string[] dataArray1, ref string[] dataArray2)
        {
            Console.Clear();
            string[] temporaryArray1 = new string[dataArray1.Length + 1];
            string[] temporaryArray2 = new string[dataArray1.Length + 1];

            for (int i = 0; i < dataArray1.Length; i++)
            {
                temporaryArray1[i] = dataArray1[i];
            }
            Console.WriteLine("Ваше ФИО:");
            temporaryArray1[dataArray1.Length-1] = Console.ReadLine();
            dataArray1 = temporaryArray1;

            for (int i = 0; i < dataArray2.Length; i++)
            {
                temporaryArray2[i] = dataArray2[i];
            }
            Console.WriteLine("Должность:");
            temporaryArray2[dataArray2.Length - 1] = Console.ReadLine();
            dataArray2 = temporaryArray2;
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню.");
            Console.ReadKey();
            Console.Clear();
        }

        static void PrintDossieList(string[] dataArray1, string[] dataArray2)
        {
            Console.Clear();
            Console.WriteLine("Список всех досье:\n");

            for (int i = 0; i < dataArray1.Length-1; i++)
            {
                Console.WriteLine($"{i + 1}) {dataArray1[i]} - {dataArray2[i]}");
            }
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню.");
            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(ref string[] dataArray1, ref string[] dataArray2)
        {
            Console.Clear();
            Console.WriteLine("Удаление досье\n");
            Console.WriteLine("Номер досье, которые вы хотите удалить:");
            int dossierToDelete = Convert.ToInt32(Console.ReadLine());
            string[] removeArray1 = new string[dataArray1.Length - 1];
            string[] removeArray2 = new string[dataArray1.Length - 1];
            int mixDossierNumber = 1;
            int maxDossierNumber = dataArray1.Length;

            if (dossierToDelete <= maxDossierNumber & dossierToDelete >= mixDossierNumber)
            {
                for (int i = 0; i < removeArray1.Length; i++)
                {
                    if (i < dossierToDelete - 1)
                    {
                        removeArray1[i] = dataArray1[i];
                        removeArray2[i] = dataArray2[i];
                    }
                    else
                    {
                        removeArray1[i] = dataArray1[i + 1];
                        removeArray2[i] = dataArray2[i + 1];
                    }
                }
                dataArray1 = removeArray1;
                dataArray2 = removeArray2;
            }
            else
            {
                Console.WriteLine("Номер введен некорректно!");
            }
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню.");
            Console.ReadKey();
            Console.Clear();
        }

        static void SearchDossier(string[] dataArray1, string[] dataArray2)
        {
            Console.Clear();
            Console.WriteLine("Поиск по фамилии\n");
            Console.WriteLine("Введите фамилию для поиска по фамилии:");
            string enteredLastName = Console.ReadLine();
            Console.WriteLine("Результат поиска:\n");

            for (int i = 0; i < dataArray1.Length-1; i++)
            {
                if (dataArray1[i].Contains(enteredLastName))
                {
                    Console.WriteLine(dataArray1[i] + " - " + dataArray2[i]);
                }
            }
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}