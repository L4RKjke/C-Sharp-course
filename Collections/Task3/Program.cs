﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isClose = false;
            List<int> numbers = new List<int>();
            Console.WriteLine("Суммирование чисел. 'exit'- выход из программы, 'sum' - вывод суммы введенных чисел \n");

            while (isClose == false)
            {
                Console.WriteLine("Ввод:");
                string inputValue = Console.ReadLine();

                switch (inputValue)
                {
                    case "exit":
                        isClose = true;
                        break;

                    case "sum":
                        Console.WriteLine(FoldNumbers(out int sum, numbers));
                        numbers.RemoveAll(numbers.Contains);
                        Console.WriteLine("Нажмите любую кнопку, чтобы продолжить");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;

                    default:

                        if (int.TryParse(inputValue, out int result) == true)
                        {
                            numbers.Add(result);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка ввода!");
                        }
                        break;
                }
            }
        }

        static int FoldNumbers(out int sum, List<int> numbers)
        {
            return sum = numbers.Sum();
        }
    }
}