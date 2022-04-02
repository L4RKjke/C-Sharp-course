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
            int startOfSequence = 5;
            int endOfSequence = 96;
            int stepOfSequence = 7;
            Console.WriteLine("Для вывода полседовательности используем цикл 'for' так как: есть счетчик, и у последовательности  постоянный шаг");

            for (int i = startOfSequence; i < endOfSequence + 1; i += stepOfSequence)
            {
                Console.WriteLine(orderСounter + "st number of order: " + i);
                orderСounter += 1;
            }

        }
    }
}