using System;

internal class Program
{
    static void Main(string[] args)
    {
        int gemsPrice = 5;
        Console.WriteLine("Золота в кармане:");
        int gold = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Сколько кристаллов хотите купить?");
        int gems = Convert.ToInt32(Console.ReadLine());
        int goldAfterDeal = gold - gemsPrice * gems;
        Console.WriteLine($"золота после покупки: {goldAfterDeal}, кристаллов куплено: {gems}");
    }
}