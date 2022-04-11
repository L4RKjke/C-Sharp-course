using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isClose = true;

            while (isClose)
            {
                Console.Clear();
                Console.WriteLine("Собирите 15 яблок, при этом постарайтесь не умереть от голада.");
                Console.WriteLine("Красная шкала показывает голод, а синяя уровень сытости. \n");
                Console.WriteLine("Чтобы начать игру нажмите 1");
                char menuComand = Convert.ToChar(Console.ReadKey(true).Key);

                switch (menuComand)
                {
                    case '1':
                        Console.Clear();
                        bool isPlaying = true;
                        int snakeX, snakeY;
                        int DX = 0, DY = 1;
                        int randX = 0;
                        int randY = 0;
                        int apples = 0;
                        int tempValue = 0;
                        int[,] snake = new int[5, 2] { { 2, 3 }, { 2, 4 }, { 2, 5 }, { 2, 6 }, { 2, 7 } };
                        int time = 0;
                        char[,] map = new char[31, 15];
                        int pastPositionX = snake[0, 0];
                        int pastPositionY = snake[0, 1];
                        Random rand = new Random();
                        snakeX = 2;
                        snakeY = 7;
                        int speed = 300;
                        int healthPoint = 3;
                        DrawMap(map);

                        while (isPlaying)
                        {
                            if (Console.KeyAvailable)
                            {
                                ConsoleKeyInfo key = Console.ReadKey(true);
                                switch (key.Key)
                                {
                                    case ConsoleKey.UpArrow:
                                        DX = -1; DY = 0;
                                        break;

                                    case ConsoleKey.DownArrow:
                                        DX = 1; DY = 0;
                                        break;

                                    case ConsoleKey.LeftArrow:
                                        DX = 0; DY = -1;
                                        break;

                                    case ConsoleKey.RightArrow:
                                        DX = 0; DY = 1;
                                        break;
                                }
                            }
                            MoveSnake(ref snakeX, ref snakeY, ref snake, DX, DY, tempValue, ref pastPositionX, ref pastPositionY);
                            DrawSnake(snake);
                            UpdateApples(ref time, ref randX, ref randY, ref healthPoint, rand);
                            EatApple(ref apples, healthPoint, snakeX, snakeY, randX, randY, ref time, ref speed, pastPositionX, pastPositionY, ref snake);
                            CheckWinLose(apples, healthPoint, snake, ref isPlaying);
                            int inticatorPos1 = 16;
                            int inticatorPos2 = 18;
                            float barMultiplier1 = 6.666f;
                            float barMultiplier2 = 31.01f;
                            DrawBar(apples, barMultiplier1, inticatorPos1, ConsoleColor.Red);
                            DrawBar(healthPoint, barMultiplier2, inticatorPos2, ConsoleColor.DarkCyan);
                            System.Threading.Thread.Sleep(speed);
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный номер команды!");
                        isClose = false;
                        break;
                }
            }
        }

        static void MoveSnake (ref int snakeX, ref int snakeY, ref int [,] snake, int DX, int DY, int tempValue, ref int pastPositionX, ref int pastPositionY)
        {
            pastPositionX = snake[0, 0];
            pastPositionY = snake[0, 1];

            for (int i = 0; i < snake.GetLength(0) - 1; i++)
            {
                tempValue = snake[i, 0];
                snake[i, 0] = snake[i + 1, 0];
                snake[i + 1, 0] = tempValue;
                tempValue = snake[i, 1];
                snake[i, 1] = snake[i + 1, 1];
                snake[i + 1, 1] = tempValue;
            }
            snakeX += DX;
            snakeY += DY;
            snake[snake.GetLength(0) - 1, 0] = snakeX;
            snake[snake.GetLength(0) - 1, 1] = snakeY;
        }

        static void DrawSnake (int [,] snake)
        {
            for (int i = 1; i < snake.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(snake[i, 1], snake[i, 0]);
                Console.WriteLine("o");
                Console.ResetColor();

            }
            Console.SetCursorPosition(snake[0, 1], snake[0, 0]);
            Console.WriteLine(" ");
        }

        static void UpdateApples(ref int time, ref int randX, ref int randY, ref int healthPoint, Random rand)
        {
            time++;

            if (time == 30)
            {
                randX = rand.Next(3, 10);
                randY = rand.Next(3, 27);
                Console.SetCursorPosition(randY, randX);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("+");
                Console.ResetColor();
            }

            if (time > 30)
            {
                Console.SetCursorPosition(randY, randX);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("+");
            }

            if (time == 55)
            {
                Console.SetCursorPosition(randY, randX);
                Console.WriteLine(" ");
                Console.ResetColor();
                time = 0;
                healthPoint--;
            }
        }

        static void EatApple(ref int apples, int healthPoint, int snakeX, int snakeY, int randX, int randY, ref int time, ref int speed, int pastPositionX, int pastPositionY, ref int[,] snake)
        {
            if (snakeX == randX & snakeY == randY)
            {
                apples++;
                time = 0;
                speed -= 20;
                int[,] temporaryArray = new int[snake.GetLength(0) + 1, snake.GetLength(1)];

                for (int i = 0; i < snake.GetLength(0); i++)
                {
                    for (int j = 0; j < snake.GetLength(1); j++)
                    {
                        temporaryArray[i, j] = snake[i, j];
                    }

                }
                snake = temporaryArray;
                temporaryArray[snake.GetLength(0) - 1, 0] = pastPositionX;
                temporaryArray[snake.GetLength(0) - 1, 1] = pastPositionY;
                int tempValue1;

                for (int i = 0; i < snake.GetLength(0); i++)
                {
                    for (int j = 0; j < snake.GetLength(1); j++)
                    {
                        tempValue1 = snake[snake.GetLength(0) - 1, j];
                        snake[snake.GetLength(0) - 1, j] = snake[i, j];
                        snake[i, j] = tempValue1;
                    }
                }
            }
        }

        static void DrawBar(int indicatorValue, float barMultiplier, int inticatorPos, ConsoleColor color)
        {
            Console.SetCursorPosition(0, inticatorPos);

            int barSizeDivider = 3;
            double givenPercent = indicatorValue * barMultiplier;
            int maxPercent = 95;

            Console.Write("|");
            for (int i = 0; i < maxPercent / barSizeDivider; i++)
            {
                if (i < givenPercent / barSizeDivider)
                {
                    Console.BackgroundColor = color;
                    Console.Write('_');
                    Console.ResetColor();
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("_");
                }
            }
            Console.Write("|");

            Console.SetCursorPosition(0, 18);
        }

        static void CheckWinLose(int apples, int healthPoint, int [,] snake, ref bool isPlaying)
        {
            if (apples == 15)
            {
                string message = "Победа!";
                WriteFinalMessage(ref isPlaying, message);
            }

            for (int i = 0; i < snake.GetLength(0) - 1; i++)
            {
                for (int j = i; j < snake.GetLength(0) - 1; j++)
                {

                    if ((snake[i, 0] == snake[j + 1, 0]) & (snake[i, 1] == snake[j + 1, 1]))
                    {
                        string message = "Вы съели сами себя...";
                        WriteFinalMessage(ref isPlaying, message);
                    }
                }
            }

            if (healthPoint == 0)
            {
                string message = "Вы умерли от голода!";
                WriteFinalMessage(ref isPlaying, message);
            }

            if (snake[snake.GetLength(0) - 1, 0] == 15 || snake[snake.GetLength(0) - 1, 1] == 31 || snake[snake.GetLength(0) - 1, 1] == 0 || snake[snake.GetLength(0) - 1, 0] == 0)
            {
                string message =  "Вы вышли за пределы карты!";
                WriteFinalMessage(ref isPlaying, message);
            }

        }

        static void WriteFinalMessage(ref bool isPlaying, string resultMessage)
        {
            Console.Clear();
            Console.SetCursorPosition(2, 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(resultMessage);
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("Нажмите любую кнопку, чтобы вернуться в меню....");
            isPlaying = false;
            Console.ReadKey(true);
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (i == 0 || i == 31 || j == 0 || j == 15)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write('#');
                    }
                    else
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(' ');
                    }                   
                }
                Console.WriteLine();
            }
        }
    }
}