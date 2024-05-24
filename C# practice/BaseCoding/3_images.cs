using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int images = 52;
            int imagesInRow = 3;
            int filledRows;
            int leftImages;

            filledRows = images / imagesInRow;
            leftImages = filledRows % imagesInRow;

            Console.WriteLine($"Заполненных рядов = {filledRows} \nОстанется картинок вне рядов = {lefttImages}");
        }
    }
}
