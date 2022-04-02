using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isReapeat = true;

            while (isReapeat == true)
            {
                Console.WriteLine("Введите свое сообщение:");
                string userMessage = Console.ReadLine();
                Console.WriteLine("Сколько раз вы хотите продублировать свое сообщение?");
                int numberOfMessages = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < numberOfMessages; i++)
                {
                    Console.WriteLine(userMessage);
                }

                Console.WriteLine("Хотите запустить код еще раз? Если нет нажмите 'exit'");

                if (Console.ReadLine() == "exit")
                {
                    isReapeat = false;
                }
                else
                {
                    isReapeat = true;
                }
            }
        }
    }
}