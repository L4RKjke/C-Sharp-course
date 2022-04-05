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
            string[] numbersArray = new string[1];
            string[] tempararyNumberArray = new string[numbersArray.Length + 1];
            int sum = 0;
            Console.WriteLine("Введите числа, сумму которых вы хотите узнать.\n");

            while (isInput)
            {
                tempararyNumberArray[tempararyNumberArray.Length - 1] = Console.ReadLine();
                numbersArray = tempararyNumberArray;

                if (tempararyNumberArray[tempararyNumberArray.Length - 1] == "exit" || tempararyNumberArray[tempararyNumberArray.Length - 1] == "sum") 
                {
                    switch(tempararyNumberArray[tempararyNumberArray.Length - 1])
                    {
                        case "exit":
                            isInput = false;
                            break;
                        case "sum":
                            Console.WriteLine("Сумма введенных чисел равна: " + sum);
                            sum = 0;
                            break;
                    }
                }
                else
                {
                sum += Convert.ToInt32(tempararyNumberArray[tempararyNumberArray.Length - 1]);
                }
            }
            
        }
    }
}
