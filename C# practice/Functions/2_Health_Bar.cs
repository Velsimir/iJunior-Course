using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int currentHealthPercent = 96;
            int maxPercent = 100;
            int healthPositionY = 0;
            int healthPositionX = 0;
            int currenManaPercent = 5;
            int manaPositionY = 1;
            int manaPositionX = 0;
            
            DrawBar(currentHealthPercent, maxPercent, healthPositionY, healthPositionX);
            DrawBar(currenManaPercent, maxPercent, manaPositionX, manaPositionY, ConsoleColor.Cyan);
        }

        static void DrawBar(int value, int maxValue, int positionY, int positionX, ConsoleColor color = ConsoleColor.Red)
        {
            string bar = "";
            
            NormalizeValues(ref value, ref maxValue);
            ConsoleColor defoultColor = Console.BackgroundColor;

            bar = FillBar(bar, value);

            Console.SetCursorPosition(positionY, positionX);
            Console.Write("[");
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defoultColor;

            bar = FillBar(bar, maxValue - value);
            
            Console.Write($"{bar}]");
        }

        private static void NormalizeValues(ref int value, ref int maxValue)
        {
            if (value > maxValue)
                value = maxValue;
        }

        private static string FillBar(string bar, int countOfCycles)
        {
            bar = "";
            
            for (int i = 0; i < countOfCycles; i++)
            {
                bar += ' ';
            }

            return bar;
        }
    }
}
