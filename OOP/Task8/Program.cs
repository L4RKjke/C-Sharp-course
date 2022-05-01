using System;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arena arena = new Arena();
            arena.StartBattle();
        }
    }

    class Arena
    {
        private int _numberOfFighers = 5;

        public void StartBattle()
        {
            Fighter[] fighters = new Fighter[5]
                {
                new Magician("Маг", 200, 5, 5, 3),
                new Warrior("Воин", 300, 30, 1, 10),
                new Hunter("Охотник", 220, 15, 3, 6),
                new Rogue("Разбойник", 300, 20, 1, 2),
                new Shaman("Шаман", 200, 8, 4, 30)
                };
            ChooseFighters(fighters, out Fighter ForcesOfLight, out Fighter ForcesOfDarkness, _numberOfFighers);
        }

        private void ChooseFighters(Fighter[] fighters, out Fighter forcesOfLight, out Fighter forcesOfDarkness, int numberOfFighers)
        {
            for (int i = 0; i < fighters.Length; i++)
            {
                fighters[i].ShowStats(i + 1);
            }

            VerifyInputFighters(forcesOfLight = null, forcesOfDarkness = null, fighters, numberOfFighers);
        }

        private void VerifyInputFighters(Fighter forcesOfLight, Fighter forcesOfDarkness, Fighter[] fighters, int numberOfFighers)
        {
            Console.Write("Боец сил света: ");
            string leftFighter = Console.ReadLine();
            Console.Write("Боец сил тьмы: ");
            string rightFighter = Console.ReadLine();

            if ((int.TryParse(leftFighter, out int leftIndex) && leftIndex > 0 && leftIndex <= numberOfFighers) &&
                (int.TryParse(rightFighter, out int rightIndex) && rightIndex > 0 && rightIndex <= numberOfFighers))
            {
                forcesOfLight = fighters[leftIndex - 1];
                forcesOfDarkness = fighters[rightIndex - 1];

                if (rightIndex != leftIndex)
                    StartFighting(forcesOfLight, forcesOfDarkness);
                else
                    Console.WriteLine("Нельзя выбирать одинаковых бойцов!");
            }
            else
            {
                forcesOfLight = null;
                forcesOfDarkness = null;
            }
        }

        private void StartFighting(Fighter forcesOfLight, Fighter forcesOfDarkness)
        {
            Console.Clear();
            int lightForcesId = 1;
            int darknessForcesId = 2;

            while (forcesOfLight.Health > 0 && forcesOfDarkness.Health > 0)
            {
                forcesOfLight.TakeDamage(forcesOfDarkness.Damage, forcesOfDarkness.AttackSpeed);
                TryToActivateBonus(forcesOfLight);
                forcesOfDarkness.TakeDamage(forcesOfLight.Damage, forcesOfLight.AttackSpeed);
                TryToActivateBonus(forcesOfDarkness);
                forcesOfLight.ShowStats(lightForcesId);
                forcesOfDarkness.ShowStats(darknessForcesId);
            }
            PickTheWinner(forcesOfLight, forcesOfDarkness);
        }

        private void PickTheWinner(Fighter forcesOfLight, Fighter forcesOfDarkness)
        {
            if (forcesOfLight.Health <= 0 && forcesOfDarkness.Health <= 0)
            {
                Console.WriteLine("Ничья!");
            }
            else if (forcesOfLight.Health <= 0)
            {
                Console.WriteLine("Победа сил тьмы!");
            }
            else if (forcesOfDarkness.Health <= 0)
            {
                Console.WriteLine("Победа сил света!");
            }
        }

        private void TryToActivateBonus(Fighter figher)
        {
            if (figher.FightingSpirit == 2)
                figher.UseActiveAbility();
        }
    }

    abstract class Fighter
    {
        protected string _name;
        protected int _healthChanges;
        protected Random Random = new Random();

        public int FightingSpirit { get; protected set; } = 0;

        public int Armor { get; protected set; }

        public int AttackSpeed { get; protected set; }

        public int Health { get; protected set; }

        public int Damage { get; protected set; }

        public int EnemyDamage { get; protected set; }

        public Fighter(string name, int health, int damage, int attackSpeed, int armor)
        {
            _name = name;
            Health = health;
            Damage = damage;
            AttackSpeed = attackSpeed;
            Armor = armor;
        }

        public void TakeDamage(int damage, int attackSpeed)
        {
            UsePassiveAbility();
            _healthChanges = damage * attackSpeed - Armor;
            EnemyDamage = damage;
            Health -= _healthChanges;
        }

        public void ShowStats(int id)
        {
            Console.WriteLine($"{id}) класс: {_name}, здоровье: {Health}, урон: {Damage}, скорость атаки: {AttackSpeed}, броня: {Armor}");
        }

        public abstract void UsePassiveAbility();

        public abstract void UseActiveAbility();
    }

    class Magician : Fighter
    {

        public Magician(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UsePassiveAbility()
        {
            int abilityChance = 40;

            if (Random.Next(1, 101) < abilityChance)
            {
                Health += _healthChanges;
                FightingSpirit++;
            }
        }

        override public void UseActiveAbility()
        {
            Console.Write($"{_name} ... Лечение!\n");
            int healthBonus = 100;
            Health += healthBonus;
            FightingSpirit = 0;
        }
    }

    class Warrior : Fighter
    {
        private int _extraDamage;
        private int _superPunch = 200;

        public Warrior(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor)
        {
            Damage = _extraDamage + Damage;
        }

        override public void UsePassiveAbility()
        {
            int abilityChance = 15;

            if (Random.Next(1, 101) < abilityChance)
            {
                FightingSpirit++;
                _extraDamage = 12;
            }
            else
                _extraDamage = 0;
        }

        override public void UseActiveAbility()
        {
            Console.Write($"{_name} ... Супер удар!\n");
            Damage = _superPunch;
            FightingSpirit = 0;
        }
    }

    class Hunter : Fighter
    {
        private int _rageBonus = 1;
        private int _dogsDamage = 20;
        private int _dogsHealth = 100;

        public Hunter(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) 
        {
            Damage = _rageBonus * Damage;
        }

        override public void UsePassiveAbility()
        {
            int abilityChance = 20;

            if (Random.Next(1, 101) < abilityChance)
            {
                FightingSpirit++;
                _rageBonus = 2;
            }
            else
                _rageBonus = 1;
        }

        override public void UseActiveAbility()
        {
            Console.Write($"{_name} ... Собаки призваны!\n");
            Damage += _dogsDamage;
            Health += _dogsHealth;
            FightingSpirit = 0;
        }
    }

    class Rogue : Fighter
    {
        public Rogue(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UsePassiveAbility()
        {
            int abilityChance = 30;

            if (Random.Next(1, 101) < abilityChance)
            {
                FightingSpirit++;
                Damage += EnemyDamage;
            }
        }

        override public void UseActiveAbility()
        {
            Console.Write($"{_name} ... Переворот!\n");
            int buffer;
            buffer = Damage;
            Damage = Health;
            Health = buffer;
            FightingSpirit = 0;
        }
    }

    class Shaman : Fighter
    {
        private int _spiritHealth = 30;
        private int _spiritArmor = 2;
        private int _spiritdDamage = 13;
        private bool _isAbilityActivated = false;

        public Shaman(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UsePassiveAbility()
        {
            int abilityChance = 10;

            if (Random.Next(1, 101) < abilityChance)
            {
                AttackSpeed = AttackSpeed + 2;
                FightingSpirit++;
            }  
        }

        override public void UseActiveAbility()
        {
            if (_isAbilityActivated == false)
            {
                Console.Write($"{_name} ... Слияние с духом!\n");
                Health += _spiritHealth;
                Damage += _spiritArmor;
                Armor += _spiritdDamage;
                _isAbilityActivated = true;
            }
        }
    }
}