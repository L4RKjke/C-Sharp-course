﻿using System;

internal class Program
{
    static void Main(string[] args)
    {
        int receptionTime = 10;
        Console.WriteLine("Кол-во людей в очереди:");
        int peopleInQueues = Convert.ToInt32(Console.ReadLine());
        int hours = (receptionTime * peopleInQueues) / 60;
        int minutes = (receptionTime * peopleInQueues) % 60;
        Console.WriteLine($"Вы должны отстоять в очереди {hours} часа и {minutes} минут.");
    }
}