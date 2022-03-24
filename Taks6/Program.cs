using System;

internal class Program
{
    static void Main(string[] args)
    {
        int images = 52;
        int imagesInRaw = 3;
        int pictureRows = images / imagesInRaw;
        int excessPictures = images % imagesInRaw;
        Console.WriteLine($"Рядов с картинками: {pictureRows}, картинок сверх меры: {excessPictures}");
    }
}
