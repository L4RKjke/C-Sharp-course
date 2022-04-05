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
            bool isInput = true;
            int[] numbersArray = new int[1];
            int[] tempararyNumberArray = new int[numbersArray.Length + 1];
            int sum = 0;
            bool isDigit = false;
            Console.WriteLine("Введите числа, сумму которых вы хотите узнать.\n");

            while (isInput)
            {
                numbersArray = tempararyNumberArray;
                string inputValue = Console.ReadLine();

                if (inputValue == "exit" || inputValue == "sum") 
                {
                    switch (inputValue)
                    {
                        case "sum":
                            Console.WriteLine("Сумма введенных чисел равна: " + sum);
                            sum = 0;
                            break;
                        case "exit":
                            isInput = false;
                            break;
                        default:
                            Console.WriteLine("Ошибка ввода!");
                            break;
                    }
                }
                else
                {
                    for (int i = int.MinValue; i < int.MaxValue; i++)
                    {
                        if (inputValue == Convert.ToString(i))
                        {
                            isDigit = true;
                            break;
                        }
                        else
                        {
                            isDigit = false;
                        }
                    }
                    if (isDigit)
                    {
                        tempararyNumberArray[tempararyNumberArray.Length - 1] = Convert.ToInt32(inputValue);
                        sum += Convert.ToInt32(inputValue);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода!");
                    }
                }
            }    
        }
    }
}