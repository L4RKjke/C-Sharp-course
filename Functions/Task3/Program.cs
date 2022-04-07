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
            Console.WriteLine(GetInt());
        }

        static int GetInt()
        {
            bool isClose = false;

            while (isClose == false)
            {
                string enteredNumber = Console.ReadLine();

                if (int.TryParse(enteredNumber, out int result))
                {
                    return Convert.ToInt32(enteredNumber);
                    isClose = true;
                }
                else
                {
                    Console.WriteLine("Попробуйте еще раз:");
                }
            }
            return 0;
        }
    }
}
