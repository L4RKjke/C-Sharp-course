using System;

internal class Program
{
    static void Main(string[] args)
    {
        int receptionTime = 10;
        int minutesInHour = 60;
        Console.WriteLine("Кол-во людей в очереди:");
        int peopleInQueue = Convert.ToInt32(Console.ReadLine());
        int waitingHours = (receptionTime * peopleInQueue) / minutesInHour;
        int waitingMinutes = (receptionTime * peopleInQueue) % minutesInHour;
        Console.WriteLine($"Вы должны отстоять в очереди {waitingHours} часа и {waitingMinutes} минут.");
    }
}