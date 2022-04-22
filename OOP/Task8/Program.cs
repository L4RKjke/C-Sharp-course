using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_FIGHTERS = 5;
            Fighter[] fighters = new Fighter[NUMBER_OF_FIGHTERS]
                {
                new Magician("Маг", 200, 5, 5, 3),
                new Warrior("Воин", 300, 30, 1, 10),
                new Hunter("Охотник", 220, 15, 3, 6),
                new Rogue("Разбойник", 300, 20, 1, 2),
                new Shaman("Шаман", 200, 8, 4, 30)
                };
            ChooseFighters(fighters, out Fighter ForcesOfLight, out Fighter ForcesOfDarkness, NUMBER_OF_FIGHTERS);
        }

        static void ChooseFighters(Fighter[] fighters, out Fighter forcesOfLight, out Fighter forcesOfDarkness, int NUMBER_OF_FIGHTERS)
        {
            for (int i = 0; i < fighters.Length; i++)
            {
                fighters[i].ShowStats(i + 1);
            }

            VerifyInputFighters(forcesOfLight = null, forcesOfDarkness = null, fighters, NUMBER_OF_FIGHTERS);
        }

        static void VerifyInputFighters(Fighter forcesOfLight, Fighter forcesOfDarkness, Fighter[] fighters, int NUMBER_OF_FIGHTERS)
        {
            Console.Write("Боец сил света: ");
            string leftFighter = Console.ReadLine();
            Console.Write("Боец сил тьмы: ");
            string rightFighter = Console.ReadLine();

            if ((int.TryParse(leftFighter, out int leftIndex) && leftIndex > 0 && leftIndex <= NUMBER_OF_FIGHTERS) &&
                (int.TryParse(rightFighter, out int rightIndex) && rightIndex > 0 && rightIndex <= NUMBER_OF_FIGHTERS))
            {
                forcesOfLight = fighters[leftIndex - 1];
                forcesOfDarkness = fighters[rightIndex - 1];
                StartFighting(forcesOfLight, forcesOfDarkness);
            }
            else
            {
                forcesOfLight = null;
                forcesOfDarkness = null;
            }
        }

        static void StartFighting(Fighter forcesOfLight, Fighter forcesOfDarkness)
        {
            Console.Clear();
            const int CRITICAL_HEALTH = 50;
            const int LIGHT_FORCES_ID = 1;
            const int DARKNESS_FORCES_ID = 2;

            while (forcesOfLight.Health > 0 && forcesOfDarkness.Health > 0)
            {
                forcesOfLight.TakeDamage(forcesOfDarkness.Damage, forcesOfDarkness.AttackSpeed, forcesOfDarkness.Armor);
                forcesOfDarkness.TakeDamage(forcesOfLight.Damage, forcesOfLight.AttackSpeed, forcesOfLight.Armor);
                forcesOfLight.ShowStats(LIGHT_FORCES_ID);
                forcesOfDarkness.ShowStats(DARKNESS_FORCES_ID);
                ActivateBonus(forcesOfLight, forcesOfDarkness, CRITICAL_HEALTH);
                PickTheWinner(forcesOfLight, forcesOfDarkness);
            }
        }

        static void PickTheWinner(Fighter forcesOfLight, Fighter forcesOfDarkness)
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

        static void ActivateBonus (Fighter forcesOfLight, Fighter forcesOfDarkness, int CRITICAL_HEALTH)
        {
            if (forcesOfLight.Health <= CRITICAL_HEALTH)
            {
                forcesOfLight.UpСharacter();
            }
            if (forcesOfDarkness.Health <= CRITICAL_HEALTH)
            {
                forcesOfDarkness.UpСharacter();
            }
        }
    } 

    class Fighter
    {
        private string _name;

        public int Armor { get; protected set; }

        public int AttackSpeed { get; protected set; }

        public int Health { get; protected set; }

        public int Damage { get; protected set; }

        public Fighter(string name, int health, int damage, int attackSpeed, int armor)
        {
            _name = name;
            Health = health;
            Damage = damage;
            AttackSpeed = attackSpeed;
            Armor = armor;
        }

        public void TakeDamage(int damage, int attackSpeed, int armor)
        {
            Health -= damage * attackSpeed - armor;

        }

        public void ShowStats(int id)
        {
            Console.WriteLine($"{id}) класс: {_name}, здоровье: {Health}, урон: {Damage}, скорость атаки: {AttackSpeed}, броня: {Armor}");
        }

        virtual public void UpСharacter() { }
    }

    class Magician: Fighter
    {
        public Magician(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UpСharacter()
        {
            const int HEALTH_BUFFER = 20;
            Health += HEALTH_BUFFER;
        }
    }

    class Warrior : Fighter
    {
        public Warrior(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UpСharacter()
        {
            const int ARMOR_BUFFER = 5;
            Armor += ARMOR_BUFFER;
        }
    }

    class Hunter : Fighter
    {
        public Hunter(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UpСharacter()
        {
            const int DAMAGE_BUFFER = 10;
            Damage += DAMAGE_BUFFER;
        }
    }

    class Rogue : Fighter
    {
        public Rogue(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UpСharacter()
        {
            int buffer;
            buffer = Damage;
            Damage = Health;
            Health = buffer;
        }
    }

    class Shaman : Fighter
    {
        public Shaman(string name, int health, int damage, int atackspeed, int armor) : base(name, health, damage, atackspeed, armor) { }

        override public void UpСharacter()
        {
            const int ATACK_SPEED_BUFFER = 2;
            AttackSpeed += ATACK_SPEED_BUFFER;
        }
    }
}