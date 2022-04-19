using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase data = new DataBase();
            data.AddPlayer("Bob", 12, false);
            data.AddPlayer("Max", 6, true);
            data.BanPlayer(0);
            data.UnbanPlayer(1);;
            data.RemovePlayer(1); ;
        }
    }

    class DataBase
    {
        private Dictionary<int, Player> _playersData = new Dictionary<int, Player>();
        private int _userId;

        public void AddPlayer(string name, int level, bool isBanned)
        {
            _playersData[_userId] = (new Player(name, level, isBanned));
            _userId++;
        }

        public void RemovePlayer(int userId)
        {
            _playersData.Remove(userId);

        }

        public void BanPlayer(int userId)
        {
            _playersData[userId].IsBanned = true;

        }

        public void UnbanPlayer(int userId)
        {
            _playersData[userId].IsBanned = false;
        }
    }

    class Player
    {
        private string _name;
        private int _level;
        public bool IsBanned { private get; set; }

        public Player(string name, int level, bool isBanned)
        {
            _name = name;
            _level = level;
            IsBanned = isBanned;
        }
    }
}