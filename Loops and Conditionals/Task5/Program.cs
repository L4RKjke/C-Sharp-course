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
            float crownFlorenExchangeRate = 0.33f;
            int florenCrownExchangeRate = 3;
            float DucatCrownExchangeRate = 1.1f;
            float userDucatBalance = 420;
            float userFlorenceBalance = 100;
            float userCrownBalance = 300;
            bool isReapeat = true;
            int numberOfOperations = 0;

            while (isReapeat == true)
            {
                numberOfOperations++;
                Console.WriteLine($"Баланc. d: {userDucatBalance} f: {userFlorenceBalance} k: {userCrownBalance}");
                Console.WriteLine("Выбирите валюту для обмена: флорены(f), дукаты(d), кроны(k).");
                Console.WriteLine("Продать:");
                string currencySale = Console.ReadLine();
                Console.WriteLine("Сколько вы хотите " + currencySale + " обменять?");
                float currencySaleAmount = float.Parse(Console.ReadLine());
                Console.WriteLine("Купить:");
                string currencyPurchase = Console.ReadLine();

                switch (currencySale)
                {
                    case "f":
                        switch (currencyPurchase)
                        {
                            case "d":
                                userFlorenceBalance -= currencySaleAmount;
                                userDucatBalance += ((currencySaleAmount / crownFlorenExchangeRate) / DucatCrownExchangeRate);
                                break;
                            case "k":
                                userFlorenceBalance -= currencySaleAmount;
                                userCrownBalance += (currencySaleAmount * florenCrownExchangeRate);
                                break;
                        }
                        break;
                    case "d":
                        switch (currencyPurchase)
                        {
                            case "f":
                                userDucatBalance -= currencySaleAmount;
                                userFlorenceBalance += ((currencySaleAmount * DucatCrownExchangeRate) / florenCrownExchangeRate);
                                break;
                            case "k":
                                userDucatBalance -= currencySaleAmount;
                                userCrownBalance += DucatCrownExchangeRate * currencySaleAmount;
                                break;
                        }
                        break;
                    case "k":
                        switch (currencyPurchase)
                        {
                            case "f":
                                userCrownBalance -= currencySaleAmount;
                                userFlorenceBalance += currencySaleAmount / florenCrownExchangeRate;
                                break;
                            case "d":
                                userCrownBalance -= currencySaleAmount;
                                userDucatBalance += (currencySaleAmount / DucatCrownExchangeRate);
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Ошибка ввода!");
                        break;
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