using System;
using System.Collections.Generic;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Создать класс игрока, у которого есть поля с его положением в x,y.
         * Создать класс отрисовщик, с методом, который отрисует игрока.
         * Попрактиковаться в работе со свойствами.
         */
        public static void Main(string[] args)
        {
            Player player1 = new Player(20, 9, '#');
            Player player2 = new Player(10, 5, '@');

            Renderer renderer = new Renderer();

            renderer.DrowPlayer(player1);
            Console.ReadKey();

            renderer.DrowPlayer(player2);
            Console.ReadKey();
        }
    }

    class Player
    {
        public char BodySymbol { get; private set; }
        public int CoordinateX { get; private set; }
        public int CoordinateY { get; private set; }

        public Player(int coordinateX, int coordinateY, char bodySymbol)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            BodySymbol = bodySymbol;
        }
    }

    class Renderer
    {
        public void DrowPlayer(Player player)
        {
            Console.SetCursorPosition(player.CoordinateX, player.CoordinateY);
            Console.Write(player.BodySymbol);
            Console.SetCursorPosition(0, 0);
        }
    }
}
