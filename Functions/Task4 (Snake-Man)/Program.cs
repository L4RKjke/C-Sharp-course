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
            bool isPlaying = true;
            int directionX = 0;
            int directionY = 0;
            int snakeX = 4;
            int snakeY = 2;
            int minThornHeight = 7;
            int thornHeigth = 1;
            int thornDirectionY = 1;
            int[] thornPositionsX = { 6, 8, 10, 12, 14, 16 };
            char[,] map = ReadMap("snakeEscape");
            DrawMap(map);

            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, ref directionX, ref directionY);
                    Move(ref snakeX, ref snakeY, directionX, directionY, map, '~');
                }
                Move(ref thornHeigth, map, '|', ref thornDirectionY, minThornHeight, thornPositionsX);

                if (PrintGameResult(snakeY, snakeX, thornHeigth, thornPositionsX) == false)
                {
                    isPlaying = false;
                }
                System.Threading.Thread.Sleep(50);
            }
        }

        static bool PrintGameResult(int snakeY, int snakeX, int thornHeigth, int [] thornPositionsX)
        {
            int goalPositionY = 22;
            int goalPositionX = 4;

            if (thornPositionsX.Contains(snakeY) & snakeX == thornHeigth)
            {
                Console.Clear();
                Console.WriteLine("Вы проиграли!");
                Console.ReadKey();

                return false;
            }

            if (snakeY == goalPositionY & snakeX == goalPositionX)
            {
                Console.Clear();
                Console.WriteLine("Вы прошли 1 уровень.");
                Console.ReadKey();

                return false;
            }

            return true;
        }

        static void Move(ref int snakeX, ref int snakeY, int directionX, int directionY, char[,] map, char symbol)
        {
            if (map[snakeX + directionX, snakeY + directionY] != '#')
            {
                Console.SetCursorPosition(snakeY, snakeX);
                Console.WriteLine(" ");

                snakeX += directionX;
                snakeY += directionY;

                Console.SetCursorPosition(snakeY, snakeX);
                Console.WriteLine(symbol);
            }
        }

        static void Move(ref int thornHeigth, char[,] map, char symbol, ref int thornDirectionY, int minThornHeight, int [] thornPositionsX)
        {
            int numberSignPosition = 17;

            if (map[thornHeigth + thornDirectionY, numberSignPosition] != '#')
            {
                for (int i = thornPositionsX[0]; i < thornPositionsX[5] + 1; i = i + 2)
                {
                    Console.SetCursorPosition(i, thornHeigth);
                    Console.WriteLine(" ");
                }

                thornHeigth += thornDirectionY;

                for (int i = thornPositionsX[0]; i < thornPositionsX[5] + 1; i = i + 2)
                {
                    Console.SetCursorPosition(i, thornHeigth);
                    Console.WriteLine(symbol);
                }
            }
            else
            {
                ChangeDirection(ref thornDirectionY, thornHeigth, minThornHeight);
            }
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1; directionY = 0;
                    break;

                case ConsoleKey.DownArrow:
                    directionX = 1; directionY = 0;
                    break;

                case ConsoleKey.LeftArrow:
                    directionX = 0; directionY = -1;
                    break;

                case ConsoleKey.RightArrow:
                    directionX = 0; directionY = 1;
                    break;
            }
        }

        static void ChangeDirection(ref int thornDirectionY, int thornHeigth, int minThornHeight)
        {
            if  (thornHeigth == minThornHeight)
            {
                thornDirectionY = 0; thornDirectionY = -1;
            }
            else
            {
                thornDirectionY = 0; thornDirectionY = 1;
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName)
        {
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];
                }
            }

            return map;
        }
    }
}