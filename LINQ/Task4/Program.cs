using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            Console.WriteLine("Топ 3 игрока по силе:\n");
            dataBase.ShowTopByStrenght();
            Console.WriteLine("\nТоп 3 по игрока уровню:\n");
            dataBase.ShowTopByLevel();
        }
    }

    class DataBase
    {
        private List<Player> _players;

        public DataBase()
        {
            _players = new List<Player>() 
            {
                new Player("player1", 2, 20),
                new Player("player2", 4, 10),
                new Player("player3", 14, 10),
                new Player("player4", 26, 200),
                new Player("player5", 4, 23),
                new Player("player6", 50, 100),
                new Player("player7", 1, 10),
                new Player("player8", 54, 5000),
                new Player("player9", 12, 12),
                new Player("player10", 80, 3000),
            };
        }

        public void ShowTopByLevel()
        {
            int topLength = 3;
            var topLevelPlayers = _players.OrderByDescending(player => player.Level).Take(topLength);
            ShowPlayers(topLevelPlayers);
        }

        public void ShowTopByStrenght()
        {
            int topLength = 3;
            var topStrenghtPlayers = _players.OrderByDescending(player => player.Strenght).Take(topLength); ;
            ShowPlayers(topStrenghtPlayers);
        }

        private void ShowPlayers(IEnumerable<Player> selectedPlayers) 
        {
            foreach (var player in selectedPlayers)
            {
                Console.WriteLine($"{player.Name}, уровень: {player.Level}, сила: {player.Strenght}");
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Strenght { get; private set; }

        public Player(string name, int level, int strenght)
        {
            Name = name; 
            Level = level;
            Strenght = strenght;
        }
    }
}