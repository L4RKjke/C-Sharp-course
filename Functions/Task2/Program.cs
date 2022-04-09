using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.SetCursorPosition(0, 5);
                int maxPercent = 100;
                Console.WriteLine("Процент маны:");
                int manaPercent = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Процент здоровья:");
                int healthPercent = Convert.ToInt32(Console.ReadLine());
                DrawBar(manaPercent, maxPercent, ConsoleColor.Red, 0, '_');
                DrawBar(healthPercent, maxPercent, ConsoleColor.Blue, 1, '_');
                Console.SetCursorPosition(0, 9);
                Console.WriteLine("Для продолжения нажмите любую кнопку.");
                Console.ReadKey();
                Console.Clear();
            }

        }

        static void DrawBar(int givenPercent, int maxPercent, ConsoleColor color, int position, char symbol = ' ')
        {
            Console.SetCursorPosition(0, position);
            ConsoleColor barColor = Console.BackgroundColor;
            int barSizeDivider = 5;

            if (givenPercent <= maxPercent & givenPercent >= 0)
            {
                Console.Write("|");
                for (int i = 0; i < maxPercent / barSizeDivider; i++)
                {
                    if (i < givenPercent / barSizeDivider)
                    {
                        Console.BackgroundColor = color;
                        Console.Write('#');
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(symbol);
                    }
                }
                Console.Write("|");
            }
            else
            {
                Console.WriteLine("Введите процент от 0 до 100!");
            }
        }
    }
}
