using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isClose = false;
            Dictionary<string, string> allDossier = new Dictionary<string, string>();  

            while (isClose == false)
            {
                Console.Clear();
                Console.SetCursorPosition(7, 1);
                Console.WriteLine("Меню\n");
                Console.WriteLine("1 - Добавить досье\n");
                Console.WriteLine("2 - Вывести все досье\n");
                Console.WriteLine("3 - Удалить досье\n");
                Console.WriteLine("0 - Выход\n");
                char menuComand = Convert.ToChar(Console.ReadKey(true).Key);

                switch (menuComand)
                {
                    case '1':
                        AddDossier(allDossier);
                        break;

                    case '2':
                        PrintDossieList(allDossier);
                        break;

                    case '3':
                        DeleteDossier(allDossier);
                        break;

                    case '0':
                        Console.Clear();
                        isClose = true;
                        break;

                    default:
                        Console.WriteLine("Неверный номер команды!");
                        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddDossier(Dictionary<string, string> allDossier)
        {
            Console.Clear();
            Console.WriteLine("Введите ФИО и должность:");
            string usersfullName = Console.ReadLine();
            string usersPosition = Console.ReadLine();;
            allDossier[usersfullName] = usersPosition;
        }

        static void PrintDossieList(Dictionary<string, string> allDossier)
        {
            Console.Clear();

            foreach (var Dossier in allDossier)
            {
                Console.WriteLine(Dossier.Value + " - " + Dossier.Key);
            }
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню.");
            Console.ReadKey();
        }

        static void DeleteDossier(Dictionary<string, string> allDossier)
        {
            Console.Clear();
            Console.WriteLine("Введите ФИО для удаления досье: ");
            string lastName = Console.ReadLine();
            allDossier.Remove(lastName);
        }
    }
}
