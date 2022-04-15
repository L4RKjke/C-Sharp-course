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
            player1.ShowInfo(50, 13, 34, 60);
        }
    }

    class Player
    {
        private int _maxHealth;
        private int _maxDamage;
        private int _maxAtackDistance;
        private int _maxMana;

        public Player (int health, int damage, int maxAtackDistance, int maxMana)
        {
            _maxHealth = health;
            _maxDamage = damage;
            _maxAtackDistance = maxAtackDistance;
            _maxMana = maxMana;
        }

        public void ShowInfo(int health, int damage, int maxAtackDistance, int maxMana)
        {
            Console.WriteLine($"health: {health}/{_maxHealth};\ndamage: {damage}/{_maxDamage};\natack distance: {maxAtackDistance}/{_maxAtackDistance};\nmana: {maxMana}/{_maxMana}");
        }
    }
}