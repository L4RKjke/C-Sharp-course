using System;

internal class Program
{
    static void Main(string[] args)
    {
        int apples = 5;
        int pears = 10;
        Console.WriteLine($"Изначально: a = {apples}, b = {pears}");
        int replacingValue = apples;
        apples = pears;
        pears = replacingValue;
        Console.WriteLine($"После перестановки: a = {apples}, b = {pears}");
    }
}