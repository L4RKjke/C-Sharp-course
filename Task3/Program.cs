using System;


internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите свое имя:");
        string name = Console.ReadLine();
        Console.Write("Ваш рост:");
        string height = Console.ReadLine();
        Console.Write("Ваш возраст:");
        string age = Console.ReadLine();
        Console.Write("Ваш любимый фильм:");
        string favoriteMovie = Console.ReadLine();
        Console.WriteLine($"Вас зовут {name}, рост {height}см, вам {age}, любимый фильм {favoriteMovie}");
    }
}