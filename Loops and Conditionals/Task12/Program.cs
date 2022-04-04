using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float userHealth = 100f;
            float bossHealth = 500f;
            int userMaxDamage = 40;
            int userMinDamage = 25;
            int bossMaxDamage = 40;
            int bossMinDamage = 20;
            float userArmor = 0.6f;
            bool isSpiritCalled = false;
            int damageBuff = 3;
            int userHealthBuff = 1;
            int maxPercent = 100;
            int minPercent = 0;
            Random random = new Random();
            int skipTurnСhance = 40;
            int randomNumberInPercentInterval = random.Next(minPercent + 1, maxPercent + 1);
            Console.WriteLine("Способности: ");
            Console.WriteLine("1) Простой удар: минимальный урон: 25, максимальный урон: 40");
            Console.WriteLine("2) Супер удар (тройной урон, вероятность пропуска хода 50%)");
            Console.WriteLine("3) Призыв духа (вы пропускаете 1 ход)");
            Console.WriteLine("4) Слияние с духом: повышает урон на 200 %, повышает здоровье на 100%. Условие: вы призывали духа");

            while (userHealth > 0 & bossHealth > 0)
            {
                bool skipTurn = false;
                Console.WriteLine("Boss hp: " + bossHealth);
                Console.WriteLine("User hp: " + userHealth);
                Console.WriteLine("Ваш ход: ");
                string userTurn = Console.ReadLine();
                int temporaryDamageBuff = 1;

                switch (userTurn)
                {
                    case "1":
                        break;
                    case "2":
                        if (randomNumberInPercentInterval <= skipTurnСhance)
                        {
                            skipTurn = true;
                            temporaryDamageBuff = 3;
                            bossHealth -= random.Next(userMinDamage, userMaxDamage) * temporaryDamageBuff;
                        }
                        break;
                    case "3":

                        if (!isSpiritCalled)
                        {
                            skipTurn = true;
                            isSpiritCalled = true;
                        }

                        else
                        {
                            Console.WriteLine("Вы уже призывали духа!");
                        }
                        break;
                    case "4":

                        if (isSpiritCalled)
                        {
                            userHealth = userHealth * userHealthBuff;
                            userMinDamage = damageBuff * userMinDamage;
                            userMaxDamage = damageBuff * userMinDamage;
                            isSpiritCalled = false;
                        }
                        else
                        {
                            Console.WriteLine("Вы не можете слится с духом!");
                        }
                        break;
                }
                if (skipTurn)
                {
                    userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                }
                else
                {
                    userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                    bossHealth -= random.Next(userMinDamage, userMaxDamage);
                }
            }
            if (userHealth <= 0)
            {
                if (bossHealth <= 0)
                {
                    Console.WriteLine("Бой закончился ничьей");
                }
                else
                {
                    Console.WriteLine("Бой окончен. Вы проиграли!");
                }
            }
            else
            {
                Console.WriteLine("Бой окончен. Вы победили!");
            }
        }
    }
}
