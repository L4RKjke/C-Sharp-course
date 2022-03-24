using System;



internal class Program
{
    static void Main(string[] args)
    {
        int a = 5;
        int b = 10;
        Console.WriteLine($"Изначально: a = {a}, b = {b}");
        int c = a;
        a = b;
        b = c;
        Console.WriteLine($"После перестановки: a = {a}, b = {b}");
    }
}

