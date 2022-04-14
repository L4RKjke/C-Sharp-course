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
            Dictionary<string, string> employees = new Dictionary<string, string>();  

            while (isClose == false)
            {
                Console.Clear();
                Console.SetCursorPosition(7, 1);
                Console.WriteLine("Меню\n");
                Console.WriteLine("1 - Добавить сотрудника\n");
                Console.WriteLine("2 - Список всех сотрудников\n");
                Console.WriteLine("3 - Удалить досье сотрдника\n");
                Console.WriteLine("0 - Выход\n");
                char menuComand = Convert.ToChar(Console.ReadKey(true).Key);
                Console.Clear();

                switch (menuComand)
                {
                    case '1':
                        AddEmployee(employees);
                        break;

                    case '2':
                        PrintEmployees(employees);
                        break;

                    case '3':
                        DeleteEmployee(employees);
                        break;

                    case '0':
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

        static void AddEmployee(Dictionary<string, string> employees)
        {
            Console.WriteLine("Введите ФИО и должность:");
            string fullName = Console.ReadLine();
            string employeePosition = Console.ReadLine();;
            employees[fullName] = employeePosition;
        }

        static void PrintEmployees(Dictionary<string, string> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Value + " - " + employee.Key);
            }
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню.");
            Console.ReadKey();
        }

        static void DeleteEmployee(Dictionary<string, string> employees)
        {
            Console.WriteLine("Введите ФИО для удаления досье: ");
            string employeeFullName = Console.ReadLine();
            employees.Remove(employeeFullName);
        }
    }
}