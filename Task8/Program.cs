using System;

internal class Program
{
    static void Main(string[] args)
    {
        int receptionTime = 10;
        int minutesInHour = 60;
        Console.WriteLine("Кол-во людей в очереди:");
        int peopleInQueues = Convert.ToInt32(Console.ReadLine());
        int waitingHours = (receptionTime * peopleInQueues) / minutesInHour;
        int waitingMinutes = (receptionTime * peopleInQueues) % minutesInHour;
        Console.WriteLine($"Вы должны отстоять в очереди {waitingHours} часа и {waitingMinutes} минут.");
    }
}