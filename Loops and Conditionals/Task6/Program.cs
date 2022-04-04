using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRepeat = true;
            string userPlace = "menu";
            int menuCommand = 0;

            while (isRepeat)
            {
                if (userPlace == "menu")
                {
                    Console.WriteLine("1 - Изменить никнейм, 2 - Поменять цвет текста, 3 - Поменять цвет фона, 4 - Выход из меню");
                    menuCommand = int.Parse(Console.ReadLine());
                }

                if (userPlace == "setTextСolor") 
                {
                    menuCommand = 2;
                }

                if (userPlace == "setMenuСolor")
                {
                    menuCommand = 3;
                }
                switch (menuCommand)
                {
                    case 1:
                        Console.WriteLine("Введите имя пользователя");
                        string name = Console.ReadLine();
                        Console.WriteLine("Привет, " + name);
                        break;
                    case 2:
                        Console.WriteLine("1 - зеленый цвет текста, 2 - красный цвет, 3 - сбросить настрйки цвета, 0 - назад в меню");
                        string setTextcolor = Console.ReadLine();
                        userPlace = "setTextСolor";

                        switch (setTextcolor)
                        {
                            case "1":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "2":
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case "3":
                                Console.ResetColor();
                                break;
                            case "0":
                                userPlace = "menu";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("1 - синий цвет фона, 2 - белый цвет фона, 3 - сбросить настрйки цвета, 0 - назад в меню");
                        string setMenucolor = Console.ReadLine();
                        userPlace = "setMenuColor";

                        switch (setMenucolor)
                        {
                            case "1":
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                break;
                            case "2":
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case "3":
                                Console.ResetColor();
                                break;
                            case "0":
                                userPlace = "menu";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 4:
                        isRepeat = false;
                        break;
                }
            }
        }
    }
}
    