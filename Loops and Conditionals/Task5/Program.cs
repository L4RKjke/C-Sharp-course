using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float crownToFloren = 0.33f;
            float crownToDucat = 0.91f;
            float florenToCrown = 3.0f;
            float florenToDucat = 2.73f;
            float DucatToFloren = 0.37f;
            float DucatToCrown = 1.1f;
            float userDucatBalance = 420;
            float userFlorenceBalance = 100;
            float userCrownBalance = 300;
            bool isReapeat = true;
            int numberOfOperations = 0;

            while (isReapeat == true)
            {
                numberOfOperations++;
                Console.WriteLine($"Баланc. d: {userDucatBalance} f: {userFlorenceBalance} k: {userCrownBalance}");
                Console.WriteLine("Валюта для обмена: флорены(f), дукаты(d), кроны(k).");
                Console.WriteLine("Выберите операцию: 1) кроны -> флорены, 2) кроны -> дукаты, 3) флорены -> кроны, 4) флорены -> дукаты, 5) дукаты -> флорены, 6) дукаты -> кроны");
                string currentDeal = Console.ReadLine();
                Console.WriteLine("Сколько хотите обменять?");
                float currencySaleAmount = float.Parse(Console.ReadLine());

                switch (currentDeal)
                {
                    case "4":
                        userFlorenceBalance -= currencySaleAmount;
                        userDucatBalance += (currencySaleAmount * florenToDucat);
                        break;
                    case "3":
                        userFlorenceBalance -= currencySaleAmount;
                        userCrownBalance += (currencySaleAmount * florenToCrown);
                        break;
                    case "5":
                        userDucatBalance -= currencySaleAmount;
                        userFlorenceBalance += (currencySaleAmount * DucatToFloren);
                        break;
                    case "6":
                        userDucatBalance -= currencySaleAmount;
                        userCrownBalance += (currencySaleAmount * DucatToCrown);
                        break;
                    case "1":
                        userCrownBalance -= currencySaleAmount;
                        userFlorenceBalance += (currencySaleAmount * crownToFloren);
                        break;
                    case "2":
                        userCrownBalance -= currencySaleAmount;
                        userDucatBalance += (currencySaleAmount * crownToDucat);
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода!");
                        break;
                }
                if (userDucatBalance < 0 || userCrownBalance < 0 || userFlorenceBalance < 0)
                {
                    Console.WriteLine("Недостаточно средств, попробуйте еще раз!");
                    userDucatBalance = 420;
                    userFlorenceBalance = 100;
                    userCrownBalance = 300;
                }
                Console.WriteLine("Продолжить обмен? Если нет напишите 'exit'");
                Console.WriteLine($"Баланc после {numberOfOperations} операции. d: {userDucatBalance} f: {userFlorenceBalance} k: {userCrownBalance}");

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