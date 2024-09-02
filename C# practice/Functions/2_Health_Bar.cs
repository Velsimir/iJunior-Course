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
            
            DrowBar(currentHealthPercent, maxPercent, healthPositionY, healthPositionX);
            DrowBar(currenManaPercent, maxPercent, manaPositionX, manaPositionY, ConsoleColor.Cyan);
        }

        static void DrowBar(int value, int maxValue, int positionY, int positionX, ConsoleColor color = ConsoleColor.Red)
        {
            int remains;
            
            NormalizeValues(ref value, ref maxValue);
            ConsoleColor defoultColor = Console.BackgroundColor;
            string bar = "";

            FillBar(ref bar, value);

            Console.SetCursorPosition(positionY, positionX);
            Console.Write("[");
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defoultColor;

            bar = "";

            remains = maxValue - value;
            
            FillBar(ref bar, maxValue - value);
            
            Console.Write($"{bar}]");
        }

        private static void NormalizeValues(ref int value, ref int maxValue)
        {
            if (value > maxValue)
                value = maxValue;
        }

        private static void FillBar(ref string bar, int countOfCycles)
        {
            for (int i = 0; i < countOfCycles; i++)
            {
                bar += ' ';
            }
        }
    }
}
