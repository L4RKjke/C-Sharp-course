using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое сообщение:");
            string userMessage = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Сколько раз вы хотите продублировать свое сообщение?");
            int numberOfMessages = Convert.ToInt32(Console.ReadLine());
            int writtenMessages = 0;
            while (writtenMessages < numberOfMessages)
            {
                writtenMessages++;
                Console.WriteLine(userMessage);
            }
        }
    }
}
