using System;
using System.Collections.Generic;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameAdministration gameManagement = new GameAdministration();
            gameManagement.StartMenu();
        }
    }

    class GameAdministration
    {
        private bool _isClose = false;
        private DataBase _data = new DataBase();

        private enum Action
        {
            Delete,
            Ban,
            Unban
        }

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

        private void SelectComand()
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

        private void DrawMenu()
        {
            Console.WriteLine("Меню\n");
            Console.WriteLine("1 - Добавить игрока\n");
            Console.WriteLine("2 - Удалить игрока\n");
            Console.WriteLine("3 - Забанить игрока\n");
            Console.WriteLine("4 - Разбанить игрока\n");
            Console.WriteLine("5 - Вывести список всех игроков\n");
            Console.WriteLine("0 - Выход\n");
        }

        private void AddNewUser()
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

        private void DeleteUser()
        {
            Console.Write("Введите id для игрока, которого хотите удалить: ");
            SelectPlayer(Console.ReadLine(), Action.Delete);
        }

        private void BanUser()
        {
            Console.Write("Введите id для игрока, которого хотите забанить: ");
            SelectPlayer(Console.ReadLine(), Action.Ban);
        }

        private void UnbanUser()
        {
            Console.Write("Введите id для игрока, которого хотите разбанить: ");
            SelectPlayer(Console.ReadLine(), Action.Unban);
        }

        private void ShowAllPlayers()
        {
            _data.ShowInfo();
        }

        private void SelectPlayer(string id, GameAdministration.Action action)
        {
            if (int.TryParse(id, out int res) && res >= 0)
            {
                int userId = res;

                if (_data.TryGetPlayerIndex(userId, out int result))
                {
                    SwitchAction(result, action);
                }
                else
                {
                    Console.WriteLine("Id с таким значением не найдено!");
                }
            }
            else
            {
                Console.WriteLine("Введите целое пложительное число!");
            }
        }

        private void SwitchAction(int id, GameAdministration.Action action)
        {
            switch (action)
            {
                case GameAdministration.Action.Delete:
                    _data.RemovePlayer(id);
                    break;

                case GameAdministration.Action.Ban:
                    _data.UnbanPlayer(id);
                    break;

                case GameAdministration.Action.Unban:
                    _data.BanPlayer(id);
                    break;
            }
        }
    }

    class DataBase
    {
        private Dictionary<int, Player> _playersData = new Dictionary<int, Player>();
        private int _userId;
        private List<int> UserIdList = new List<int>();

        public void AddPlayer(string name, int level, bool isBanned)
        {
            _playersData[_userId] = (new Player(name, level, isBanned));
            UserIdList.Add(_userId);
            _userId++;
        }

        public void RemovePlayer(int userId)
        {
            _playersData.Remove(userId);
            UserIdList.Remove(userId);
        }

        public void BanPlayer(int userId)
        {
            _playersData[userId].BanUser();
        }

        public void UnbanPlayer(int userId)
        {
            _playersData[userId].UnbanUser();
        }

        public void ShowInfo ()
        {
            foreach (var id in _playersData.Keys)
            {
                Console.WriteLine($"id: {id}, { _playersData[id].ShowPlayerInfo()}");
            }
        }

        public bool TryGetPlayerIndex(int userId, out int result)
        {
            result = userId;
            return UserIdList.Contains(userId);
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

        public void BanUser()   
        {
            _isBanned = true;
        }

        public void UnbanUser()
        {
            _isBanned = false;
        }

        public string ShowPlayerInfo()
        {
            return ($"name: {_name}, level: {_level}, ban status: {_isBanned}");
        }
    }
}