using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            float barLenght = 20;
            
            float currentHealth = 344;
            float maxHealth = 500;
            int healthPositionY = 0;
            int healthPositionX = 0;
            
            float currentMana = 10;
            float maxMana = 60;
            int manaPositionY = 0;
            int manaPositionX = 1;
            
            float currentHealthPercent;
            float currentManaPercent;

            currentHealthPercent = CalculateBarPercent(barLenght, currentHealth, maxHealth);
            currentManaPercent = CalculateBarPercent(barLenght, currentMana, maxMana);
            
            DrawBar(currentHealthPercent, barLenght, healthPositionY, healthPositionX, ConsoleColor.Red);
            DrawBar(currentManaPercent, barLenght, manaPositionY, manaPositionX, ConsoleColor.Blue);
        }
        
        static void DrawBar(float currentPercentHealth, float barLenght, int positionY, int positionX, ConsoleColor color = ConsoleColor.Black)
        {
            Console.SetCursorPosition(positionY, positionX);
            
            Console.Write("[");
            FillBar(currentPercentHealth, color);
            FillBar(barLenght - currentPercentHealth, ConsoleColor.Black);
            Console.Write("]");
        }

        static void FillBar(float currentHealthPercent, ConsoleColor color = ConsoleColor.Black)
        {
            Console.BackgroundColor = color;

            int countOfCycles = Convert.ToInt32(currentHealthPercent);
            
            for (int i = 0; i < countOfCycles; i++)
            {
                Console.Write(" ");
            }
        }
        
        static float CalculateBarPercent(float barLenght, float currentHealth, float maxHealth)
        {
            float currentPercentHealth = CalculatePercentage(currentHealth, maxHealth);
            float onePercentFromBar = CalculateOnePercentage(barLenght);

            return currentPercentHealth * onePercentFromBar;
        }

        static float CalculateOnePercentage(float barLenght)
        {
            float oneHundredPercent = 100;
            
            return barLenght / oneHundredPercent;
        }
        
        static float CalculatePercentage(float currentValue, float maxValue)
        {
            int oneHundredPercent = 100;
            float requiredPercentage;

            requiredPercentage = (currentValue / maxValue) * oneHundredPercent;

            return requiredPercentage;
        }
    }
}
