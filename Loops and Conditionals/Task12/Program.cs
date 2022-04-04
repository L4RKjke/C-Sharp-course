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
            bool isRepeat = true;
            bool isSpiritCalled = false;
            int damageBuff = 2;
            int userHealthBuff = 1;
            int userSpiritBuff = 3;
            Random random = new Random();
            Console.WriteLine("Способности: ");
            Console.WriteLine("1) Простой удар: 25 - 40 урона");
            Console.WriteLine("2) Супер удар (двойной урон, вероятность пропуска хода 50%)");
            Console.WriteLine("3) Призыв духа (вы пропускаете 1 ход)");
            Console.WriteLine("4) Слияние с духом: повышает урон на 200 %, повышает здоровье на 100%. Условие: вы призывали духа");

            while (isRepeat)
            {
                Console.WriteLine("Boss hp: " + bossHealth);
                Console.WriteLine("User hp: " + userHealth);
                Console.WriteLine("Ваш ход: ");
                int UserTurn = Convert.ToInt32(Console.ReadLine()); 
                switch (UserTurn)
                {
                    case 1:
                        userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                        bossHealth -= random.Next(userMinDamage, userMaxDamage);
                        break;
                    case 2:
                        int skipTurnСhance = random.Next(0, 2);

                        if (skipTurnСhance == 0)
                        {
                            userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                            bossHealth -= random.Next(userMinDamage * damageBuff, userMaxDamage * damageBuff);
                        }
                        else
                        {
                            userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                        }
                        break;
                    case 3:

                        if (!isSpiritCalled)
                        {
                            isSpiritCalled = true;
                            userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                        }
                        else
                        {
                            Console.WriteLine("Вы уже призывали духа!");
                            userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                            bossHealth -= random.Next(userMinDamage, userMaxDamage);
                        }
                        break;
                    case 4:

                        if (isSpiritCalled)
                        {
                            userMinDamage = userSpiritBuff * userMinDamage;
                            userMaxDamage = userSpiritBuff * userMaxDamage;
                            bossHealth -= random.Next(userMinDamage, userMaxDamage);
                            userHealth = userHealth * userHealthBuff;
                            userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                            isSpiritCalled = false;
                        }
                        else
                        {
                            Console.WriteLine("Вы не можете слится с духом!");
                            bossHealth -= random.Next(userMinDamage, userMaxDamage);
                            userHealth -= (random.Next(bossMinDamage, bossMaxDamage) * userArmor);
                        }
                        break;
                }
                if (userHealth <= 0)
                {
                    Console.WriteLine("Бой окончен. Вы проиграли!");
                    isRepeat = false;
                }
                else if (bossHealth <= 0)
                {
                    Console.WriteLine("Бой окончен. Вы победили!");
                    isRepeat = false;
                }
            }
        }
    }
}
