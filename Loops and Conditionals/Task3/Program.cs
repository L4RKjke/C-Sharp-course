using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orderСounter = 1;
            Console.WriteLine("Для вывода полседовательности используем цикл 'for' так как: есть счетчик, и у последовательности  постоянный шаг");

            for (int orderElement = 5; orderElement < 97; orderElement += 7)
            {
                Console.WriteLine(orderСounter + "st number of order: " + orderElement);
                orderСounter += 1;
            }

        }
    }
}
