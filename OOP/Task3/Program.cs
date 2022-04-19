using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameMenager maneger = new GameMenager();
            maneger.StartMenu();
        }
    }

    class GameMenager
    {
        private bool _isClose = false;
        private DataBase _data = new DataBase();

        public void StartMenu()
        {
            while (_isClose == false)
            {
                Console.Clear();
                DrawMenu();
                SelectComand();
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
                Console.ReadKey(true);
            }
        }

        public void SelectComand()
        {
            char menuComand = Convert.ToChar(Console.ReadKey(true).Key);
            Console.Clear();

            switch (menuComand)
            {
                case '1':
                    AddNewUser();
                    break;

                case '2':
                    DeleteUser();
                    break;

                case '3':
                    BanUser();
                    break;

                case '4':
                    UnbanUser();
                    break;

                case '5':
                    ShowAllPlayers();
                    break;

                case '0':
                    _isClose = true;
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Неверный номер команды! Нажмите любую кнопку, чтобы продолжить...");
                    Console.ReadKey();
                    break;
            }
        }

        public void DrawMenu()
        {
        Console.WriteLine("Меню\n");
        Console.WriteLine("1 - Добавить игрока\n");
        Console.WriteLine("2 - Удалить игрока\n");
        Console.WriteLine("3 - Забанить игрока\n");
        Console.WriteLine("4 - Разбанить игрока\n");
        Console.WriteLine("5 - Вывести список всех игроков\n");
        Console.WriteLine("0 - Выход\n");
        }

        public void AddNewUser()
        {
            Console.WriteLine("Введите данные для добавления нового игрока: \n");
            Console.Write("Никнейм: ");
            string name = Console.ReadLine();
            Console.Write("Уровень игрока: ");

            if (int.TryParse(Console.ReadLine(), out int result) && result >= 0)
            {
                Console.Write("Статус игрока (true - забанен, false - не забанен): ");
                bool banStatus = (Convert.ToBoolean(Console.ReadLine()));
                _data.AddPlayer(name, result, banStatus);
            }        
            else
            {
                Console.WriteLine("Уровень должен быть целым числом больше 0!");
            }
        }

        public void DeleteUser()
        {
            Console.Write("Введите id для игрока, которого хотите удалить: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            _data.RemovePlayer(userId);
        }

        public void BanUser()
        {
            Console.Write("Введите id для игрока, которого хотите забанить: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            _data.BanPlayer(userId);
        }

        public void UnbanUser()
        {
            Console.Write("Введите id для игрока, которого хотите разбанить: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            _data.UnbanPlayer(userId);
        }

        public void ShowAllPlayers()
        {
            _data.ShowInfo();
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
            _playersData[userId].BanUser(true);
        }

        public void UnbanPlayer(int userId)
        {
            _playersData[userId].BanUser(false);
        }

        public void ShowInfo ()
        {
            foreach (var id in _playersData.Keys)
            {
                Console.WriteLine($"id: {id}, { _playersData[id].ShowPlayerInfo()}");
            }
        }
    }

    class Player
    {
        private string _name;
        private int _level;
        private bool _isBanned;

        public Player(string name, int level, bool isBanned)
        {
            _name = name;
            _level = level;
            _isBanned = isBanned;
        }

        public void BanUser(bool status)
        {
            if (status) 
                _isBanned = true;
            else
                _isBanned = false;
        }

        public string ShowPlayerInfo()
        {
            return ($"name: {_name}, level: {_level}, ban status: {_isBanned}");
        }
    }
}