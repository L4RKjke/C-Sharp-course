using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "12345678";
            bool isRepeat = true;
            int attemptsLeft = 3;

            while (isRepeat == true)
            {
                Console.WriteLine("Введите пароль:");
                string enteredPassword = Console.ReadLine();
                attemptsLeft--;

                if (enteredPassword == password)
                {
                    Console.WriteLine("safe password: 83742803");
                    isRepeat = false;
                }
                else
                {
                    Console.WriteLine("Пароль невверный! Попыток осталось: " + attemptsLeft);

                    if (attemptsLeft == 0)
                    {
                        Console.WriteLine("Попыток больше нет!");
                        isRepeat = false;
                    }
                }
            }
        }
    }
}
