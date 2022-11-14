using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Разработайте функцию, которая рисует некий бар (Healthbar, Manabar) в определённой позиции. 
         * Она также принимает некий закрашенный процент.
         * При 40% бар выглядит так:
         * [####______]
         */
        static void Main(string[] args)
        {
            int health = 963;
            int maxHealth = 1000;
            int positionY = 1;
            int positionX = 1;
            DrowBar(health, maxHealth, positionY, positionX);
        }

        static void DrowBar(int value, int maxValue, int positionY, int positionX, ConsoleColor color = ConsoleColor.Red)
        {
            CalculatePercentage(ref value, ref maxValue);
            ConsoleColor defoultColor = Console.BackgroundColor;
            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += ' ';
            }

            Console.SetCursorPosition(positionY, positionX);
            Console.Write("[");
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defoultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += ' ';
            }
            Console.Write($"{bar}]");
        }

        static void CalculatePercentage(ref int value, ref int maxValue)
        {
            value = (value / (maxValue / 100));
            maxValue = 100;
        }
    }
}