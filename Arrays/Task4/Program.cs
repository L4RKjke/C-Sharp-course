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
            int sum = 0;
            Console.WriteLine("Введите числа, сумму которых вы хотите узнать.\n");

            while (isInput)
            {
                int[] temporaryNumbersArray = new int[numbersArray.Length + 1];
                string inputValue = Console.ReadLine();

                if (inputValue == "exit" || inputValue == "sum" || !int.TryParse(inputValue, out int result)) 
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
                    for (int i = 0; i < numbersArray.Length; i++)
                    {
                        temporaryNumbersArray[i] = numbersArray[i];
                    }
                    temporaryNumbersArray[temporaryNumbersArray.Length - 1] = Convert.ToInt32(inputValue);
                    numbersArray = temporaryNumbersArray;
                    sum += Convert.ToInt32(inputValue);
                }
            }
        }
    }
}
