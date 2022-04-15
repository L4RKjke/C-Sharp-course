using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(100, 15, 80, 90);
            player1.ShowPlayerInfo(50, 13, 34, 60);
        }
    }

    class Player
    {
        private int _maxHealth = 100;
        private int _maxDamage = 20;
        private int _maxAtackDistance = 100;
        private int _maxMana = 100;

        public Player (int health, int damage, int maxAtackDistance, int maxMana)
        {
            _maxHealth = health;
            _maxDamage = damage;
            _maxAtackDistance = maxAtackDistance;
            _maxMana = maxMana;
        }

        public Player()
        {
        }

        public void ShowPlayerInfo(int health, int damage, int maxAtackDistance, int maxMana)
        {
            Console.WriteLine($"health: {health}/{_maxHealth};\ndamage: {damage}/{_maxDamage};\natack distance: {maxAtackDistance}/{_maxAtackDistance};\nmana: {maxMana}/{_maxMana}");
        }
    }
}