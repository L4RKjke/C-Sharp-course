using System;
using System.Collections.Generic;
using System.Linq;

namespace Task10_war
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battle battle = new Battle();
            battle.StartFighting();
        }
    }

    class Battle
    {
        private Random _random  = new Random();
        private Squad _firstSquad;
        private Squad _secondSquad;

        public Battle()
        {
            _firstSquad = new Squad(new List<Fighter>()
            {
                new Magician("Маг", 200, 5, 5, 3),
                new Warrior("Воин", 300, 30, 1, 10),
                new Hunter("Охотник", 220, 15, 3, 6)
            });

            _secondSquad = new Squad(new List<Fighter>()
            {
                new Rogue("Разбойник", 300, 20, 1, 2),
                new Shaman("Шаман", 200, 8, 4, 30),
                new Druid("Друид", 200, 8, 4, 6)
            });
        }

        public void StartFighting()
        {
            Fighter forcesOfLight;
            Fighter forcesOfDarkness;
            int lightForcesId = 1;
            int darknessForcesId = 2;

            while (_firstSquad.GetLength() > 0 && _secondSquad.GetLength() > 0)
            {
                int numberOfLeftFighter = _random.Next(0, _firstSquad.GetLength());
                int numberOfRightFighter = _random.Next(0, _secondSquad.GetLength());

                forcesOfLight = _firstSquad.GetById(numberOfLeftFighter);
                forcesOfDarkness = _secondSquad.GetById(numberOfRightFighter);
                forcesOfLight.TakeDamage(forcesOfDarkness.Damage, forcesOfDarkness.AttackSpeed);
                TryToActivateBonus(forcesOfLight);
                forcesOfDarkness.TakeDamage(forcesOfLight.Damage, forcesOfLight.AttackSpeed);
                TryToActivateBonus(forcesOfDarkness);
                forcesOfLight.ShowStats(lightForcesId);
                forcesOfDarkness.ShowStats(darknessForcesId);
                ShowBattleProgress(forcesOfLight, numberOfLeftFighter, _firstSquad);
                ShowBattleProgress(forcesOfDarkness, numberOfRightFighter, _secondSquad);
            }
            PickTheWinner();
        }

        private void ShowBattleProgress(Fighter figher, int id, Squad squad) 
        {
            if (figher.Health < 0)
            {
                Console.WriteLine($"Боец пал...");
                squad.RemoveById(id);
            }
        }

        private void PickTheWinner()
        {
            if (_firstSquad.GetLength() == 0 && _secondSquad.GetLength() == 0)
                Console.Write("\nНичья\n");

            else if (_firstSquad.GetLength() == 0)
                Console.Write("\nБой окончен, победа за силами тьмы!\n");

            else if (_secondSquad.GetLength() == 0)
                Console.Write("\nБой окончен, победа за силами света!\n");
        }

        private void TryToActivateBonus(Fighter figher)
        {
            if (figher.FightingSpirit == 2)
                figher.UseActiveAbility();
        }
    }

    class Squad
    {
        private List<Fighter> _fighters;

        public Squad(List<Fighter> fighters)
        {
            _fighters = fighters;
        }

        public int GetLength()
        {
            return _fighters.Count;
        }

        public void RemoveById(int id)
        {
            _fighters.RemoveAt(id);
        }

        public Fighter GetById(int id)
        {  
            return _fighters[id];
        }
}

    abstract class Fighter
    {
        protected string Name;
        protected int HealthChanges;
        protected Random Random = new Random();

        public int FightingSpirit { get; protected set; } = 0;

        public int Armor { get; protected set; }

        public int AttackSpeed { get; protected set; }

        public int Health { get; protected set; }

        public int Damage { get; protected set; }

        public int EnemyDamage { get; protected set; }

        public Fighter(string name, int health, int damage, int attackSpeed, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            AttackSpeed = attackSpeed;
            Armor = armor;
        }

        public void TakeDamage(int damage, int attackSpeed)
        {
            UsePassiveAbility();
            HealthChanges = damage * attackSpeed - Armor;
            EnemyDamage = damage;
            Health -= HealthChanges;
        }

        public void ShowStats(int id)
        {
            Console.WriteLine($"{id}) класс: {Name}, здоровье: {Health}, урон: {Damage}, скорость атаки: {AttackSpeed}, броня: {Armor}");
        }

        public abstract void UsePassiveAbility();

        public abstract void UseActiveAbility();

        public bool CheckIsBonusActive()
        {
            return false;
        }
    }

    class Magician : Fighter
    {

        public Magician(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UsePassiveAbility()
        {
            int abilityChance = 40;

            if (Random.Next(1, 101) < abilityChance)
            {
                Health += HealthChanges;
                FightingSpirit++;
            }
        }

        override public void UseActiveAbility()
        {
            Console.Write($"{Name} ... Лечение!\n");
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
            Console.Write($"{Name} ... Супер удар!\n");
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
            Console.Write($"{Name} ... Собаки призваны!\n");
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
            Console.Write($"{Name} ... Переворот!\n");
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
                Console.Write($"{Name} ... Слияние с духом!\n");
                Health += _spiritHealth;
                Damage += _spiritArmor;
                Armor += _spiritdDamage;
                _isAbilityActivated = true;
            }
        }
    }

    class Druid : Fighter
    {
        public Druid(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor){ }

        override public void UsePassiveAbility()
        {
            int abilityChance = 20;

            if (Random.Next(1, 101) < abilityChance)
            {
                Health += 20;
                FightingSpirit++;
            }
        }

        override public void UseActiveAbility()
        {
            Console.Write($"{Name} ... Бронирование!\n");
            int armorBonus = 10;
            Armor += armorBonus;
            FightingSpirit = 0;
        }
    }
}
