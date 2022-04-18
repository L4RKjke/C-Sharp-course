using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Renderer drawPlayer1 = new Renderer();
            drawPlayer1.RenderPosition(player1.PositionX, player1.PositionY);
        }
    }

    class Player
    {
        public int PositionX
        {
            get;
            private set;
        } = 5;

        public int PositionY
        {
            get;
            private set;
        } = 2;
    }

    class Renderer
    {
        public void RenderPosition(int PositionX, int PositionY)
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.WriteLine("/ (-)(-) \\");
        }
    }
}