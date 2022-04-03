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
            float ducatToFloren = 0.37f;
            float ducatToCrown = 1.1f;
            float userDucatBalance = 420;
            float userFlorenceBalance = 100;
            float userCrownBalance = 300;
            float initialUserDucatBalance = userDucatBalance;
            float initialUserFlorenceBalance = userFlorenceBalance;
            float initialUserCrownBalance = userCrownBalance;
            bool isReapeat = true;
            int numberOfOperations = 0;

            while (isReapeat == true)
            {
                numberOfOperations++;
                Console.WriteLine($"Баланc. d: {userDucatBalance} f: {userFlorenceBalance} k: {userCrownBalance}");
                Console.WriteLine("Валюта для обмена: флорены(f), дукаты(d), кроны(k).");
                Console.WriteLine("Выберите операцию: 1) кроны -> флорены, 2) кроны -> дукаты, 3) флорены -> кроны, 4) флорены -> дукаты, 5) дукаты -> флорены, 6) дукаты -> кроны");
                int currentDeal = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Сколько хотите обменять?");
                float currencySaleAmount = float.Parse(Console.ReadLine());

                switch (currentDeal)
                {
                    case 4:
                        if (userFlorenceBalance < currencySaleAmount)
                        {
                            Console.WriteLine("Недостаточно средств, попробуйте еще раз!");
                            break;
                        }
                        userFlorenceBalance -= currencySaleAmount;
                        userDucatBalance += (currencySaleAmount * florenToDucat);
                        break;
                    case 3:
                        if (userFlorenceBalance < currencySaleAmount)
                        {
                            Console.WriteLine("Недостаточно средств, попробуйте еще раз!");
                            break;
                        }
                        userFlorenceBalance -= currencySaleAmount;
                        userCrownBalance += (currencySaleAmount * florenToCrown);
                        break;
                    case 5:
                        if (userDucatBalance < currencySaleAmount)
                        {
                            Console.WriteLine("Недостаточно средств, попробуйте еще раз!");
                            break;
                        }
                        userDucatBalance -= currencySaleAmount;
                        userFlorenceBalance += (currencySaleAmount * ducatToFloren);
                        break;
                    case 6:
                        if (userDucatBalance < currencySaleAmount)
                        {
                            Console.WriteLine("Недостаточно средств, попробуйте еще раз!");
                            break;
                        }
                        userDucatBalance -= currencySaleAmount;
                        userCrownBalance += (currencySaleAmount * ducatToCrown);
                        break;
                    case 1:
                        if (userCrownBalance < currencySaleAmount)
                        {
                            Console.WriteLine("Недостаточно средств, попробуйте еще раз!");
                            break;
                        }
                        userCrownBalance -= currencySaleAmount;
                        userFlorenceBalance += (currencySaleAmount * crownToFloren);
                        break;
                    case 2:
                        if (userCrownBalance < currencySaleAmount)
                        {
                            Console.WriteLine("Недостаточно средств, попробуйте еще раз!");
                            break;
                        }
                        userCrownBalance -= currencySaleAmount;
                        userDucatBalance += (currencySaleAmount * crownToDucat);
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