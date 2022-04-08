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
            Console.WriteLine("Ваше ФИО:");
            dataArray1 = ExpandArray(dataArray1);
            Console.WriteLine("Должность:");
            dataArray2 = ExpandArray(dataArray2);
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
            int mixDossierNumber = 1;
            int maxDossierNumber = dataArray1.Length;

            if (dossierToDelete <= maxDossierNumber & dossierToDelete >= mixDossierNumber)
            {    
                dataArray1 = СutArray(dataArray1, dossierToDelete);
                dataArray2 = СutArray(dataArray2, dossierToDelete);
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

        static string[] ExpandArray(string [] array)
        {
            string[] temporaryArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temporaryArray[i] = array[i];
            }
            temporaryArray[array.Length - 1] = Console.ReadLine();
            array = temporaryArray;
            return array;
        }
        
        static string [] СutArray(string [] array, int number)
        {
            string[] removeArray = new string[array.Length - 1];

            for (int i = 0; i < removeArray.Length; i++)
            {
                if (i < number - 1)
                {
                    removeArray[i] = array[i];
                }
                else
                {
                    removeArray[i] = array[i + 1];
                }
            }
            return removeArray;
        }
    }
}