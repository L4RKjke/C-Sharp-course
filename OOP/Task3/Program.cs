using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Bob", 12, false);
            Player player2 = new Player("Max", 6, true);
            DataBase base1 = new DataBase();
            base1.AddPlayer(player1.WriteInfo());
            base1.AddPlayer(player2.WriteInfo());
            base1.ShowInfo();
            base1.BanPlayer(0);
            base1.UnbanPlayer(1);
            base1.ShowInfo();
        }
    }

    class DataBase
    {
        private Dictionary<int, Dictionary<string, string>> _playersData = new Dictionary<int, Dictionary<string, string>>();
        private int _userId;

        public void AddPlayer(Dictionary<string, string> userInfo)
        {
            _playersData[_userId] = userInfo;
            _userId++;
        }

        public void RemovePlayer(int userId)
        {
            _playersData.Remove(userId);
        }

        public void BanPlayer(int userId)
        {
            _playersData[userId]["is banned"] = "True";
        }

        public void UnbanPlayer(int userId)
        {
            _playersData[userId]["is banned"] = "False";
        }

        public void ShowInfo()
        {
            foreach (var id in _playersData.Keys)
            {
                Console.WriteLine($"id: {id}; name: {_playersData[id]["name"]}; level: {_playersData[id]["level"]}; banned: {_playersData[id]["is banned"]}");
            }
        }
    }

    class Player
    {
        private string _name;
        private int _level;
        private bool _isBanned = false;

        public Player(string name, int level, bool isBanned)
        {
            _name = name;
            _level = level;
            _isBanned = isBanned;
        }

        public Dictionary<string, string> WriteInfo()
        {
            Dictionary<string, string> userData = new Dictionary<string, string>() { { "name", _name }, { "level", Convert.ToString(_level) }, { "is banned", Convert.ToString(_isBanned) } };
            return userData;
        }
    }
}