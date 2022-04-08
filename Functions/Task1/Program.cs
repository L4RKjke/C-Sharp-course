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
            string[,] userData = new string[0, 4];

            while (isClose == false)
            {
                Console.SetCursorPosition(7, 1);
                Console.WriteLine("Меню\n");
                Console.WriteLine("1 - Добавить досье\n");
                Console.WriteLine("2 - Вывести все досье\n");
                Console.WriteLine("3 - Удалить досье\n");
                Console.WriteLine("4 - Поиск по фамилии\n");
                Console.WriteLine("0 - Выход\n");
                string menuComand = Convert.ToString(Convert.ToChar(Console.ReadKey(true).Key));

                switch (menuComand)
                {
                    case "1":
                        AddDossier(ref userData);
                        break;

                    case "2":
                        DossierList(ref userData);
                        break;

                    case "3":
                        DeleteDossier(ref userData);
                        break;

                    case "4":
                        SearchLastName(ref userData);
                        break;

                    case "0":
                        Console.Clear();
                        isClose = true;
                        break;

                    default:
                        Console.WriteLine("Неверный номер команды!");
                        break;
                }
            }
        }

        static void AddDossier(ref string[,] dataArray)
        {
            bool closeSection1 = false;
            int dossierСounter = 0;

            while (closeSection1 == false)
            {
                Console.Clear();
                Console.WriteLine("Добавление досье\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1 - добавить; 0 - выйти назад в меню\n");
                Console.ResetColor();
                Console.WriteLine("Кол-во досье:\n" + dataArray.GetLength(0));
                string sectionComand1 = Convert.ToString(Convert.ToChar(Console.ReadKey(true).Key));

                switch (sectionComand1)
                {
                    case "0":
                        Console.Clear();
                        closeSection1 = true;
                        break;

                    case "1":
                        string[,] temporaryNumbersArray = new string[dataArray.GetLength(0) + 1, 4];

                        for (int k = 0; k < dataArray.GetLength(0); k++)
                        {
                            for (int j = 0; j < dataArray.GetLength(1); j++)
                            {
                                temporaryNumbersArray[k, j] = dataArray[k, j];
                            }
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    Console.Write("Напишите фамилию: \n");
                                    break;

                                case 1:
                                    Console.Write("Напишите имя: \n");
                                    break;

                                case 2:
                                    Console.Write("Напишите отчество: \n");
                                    break;

                                case 3:
                                    Console.Write("Ваша должность: \n");
                                    break;
                            }
                            temporaryNumbersArray[dossierСounter, i] = Console.ReadLine();
                            dataArray = temporaryNumbersArray;
                        }

                        Console.WriteLine($"Ваши введенные данные: {dataArray[dossierСounter, 0]} {dataArray[dossierСounter, 1]} {dataArray[dossierСounter, 2]}, Должность: {dataArray[dossierСounter, 3]}\n");
                        dossierСounter++;
                        Console.WriteLine("Чтобы продолжить нажмите любую кнопку.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        static void DossierList(ref string[,] dataArray)
        {
            Console.Clear();
            Console.WriteLine("Список всех досье:\n");

            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                Console.Write(i + 1 + ") ");

                for (int j = 0; j < dataArray.GetLength(1) - 1; j++)
                {
                    Console.Write(dataArray[i, j] + " ");
                }
                Console.Write("- " + (dataArray[i, 3]));
                Console.WriteLine();
            }
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню.");
            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(ref string[,] dataArray)
        {
            bool closeSection2 = false;

            while (closeSection2 == false)
            {
                Console.Clear();
                Console.WriteLine("Удаление досье\n");
                Console.WriteLine("Кол-во досье:" + dataArray.GetLength(0) + "\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1 - удалить; 0 - выйти назад в меню\n");
                Console.ResetColor();
                string sectionComand2 = Convert.ToString(Convert.ToChar(Console.ReadKey(true).Key));

                switch (sectionComand2)
                {
                    case "0":
                        Console.Clear();
                        closeSection2 = true;
                        break;

                    case "1":
                                        Console.WriteLine("Выберите номер номер досье, которое хотите удалить");
                int removeFileNumber = Convert.ToInt32(Console.ReadLine());

                        if (removeFileNumber > dataArray.GetLength(0))
                        {
                            Console.WriteLine("Номер введен некорректно!");
                        }
                        else
                        {
                            string[,] removeArray = new string[dataArray.GetLength(0) - 1, 4];

                            for (int i = 0; i < removeArray.GetLength(0); i++)
                            {
                                for (int j = 0; j < removeArray.GetLength(1); j++)
                                {
                                    if (i < removeFileNumber - 1)
                                    {
                                        removeArray[i, j] = dataArray[i, j];
                                    }
                                    else
                                    {
                                        removeArray[i, j] = dataArray[i + 1, j];
                                    }
                                }
                            }
                            dataArray = removeArray;
                            Console.WriteLine("Кол-во досье:\n" + dataArray.GetLength(0));
                        }
                        Console.WriteLine("Чтобы продолжить нажмите любую кнопку.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        static void SearchLastName(ref string[,] dataArray)
        {
            Console.Clear();
            Console.WriteLine("Поиск по фамилии\n");
            Console.WriteLine("Введите фамилию для поиска по фамилии:");
            string enteredLastName = Console.ReadLine();
            Console.WriteLine("Результат поиска:\n");
            Console.ForegroundColor = ConsoleColor.Green;
            int lastNameCounter = 1;

            for (int i = 0; i < dataArray.GetLength(0); i++)
            {
                for (int j = 0; j < dataArray.GetLength(1); j++)
                {
                    if (enteredLastName == dataArray[i, 0])
                    {
                        switch (j)
                        {
                            case 0:
                                Console.Write($"{lastNameCounter}) Имя: ");
                                break;

                            case 1:
                                Console.Write(", Фамилия: ");
                                break;

                            case 2:
                                Console.Write(", Отчество: ");
                                break;

                            case 3:
                                Console.Write(", Должность: ");
                                break;
                        }
                        Console.Write($"{dataArray[i, j]}");
                    }
                }
                if (enteredLastName == dataArray[i, 0])
                {
                    lastNameCounter++;
                    Console.WriteLine("");
                }
            }
            Console.ResetColor();
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
