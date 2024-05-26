using System;
using System.Security.Policy;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            char userSymbol;
            string userName;
            int charactersUpToRectangle = 2;
            int cycleInteration = 2;

            Console.Write("Привет! Как тебя зовут? - ");
            userName = Console.ReadLine();

            Console.Write("Введи любой символ: ");
            userSymbol = Convert.ToChar(Console.ReadLine());

            Console.Clear();

            for (int i = 0; i < cycleInteration; i++)
            {
                for (int j = 0; j < userName.Length + charactersUpToRectangle; j++)
                {
                    Console.Write(userSymbol);
                }

                Console.WriteLine();

                if (i == 0)
                {
                    Console.WriteLine(userSymbol + userName + userSymbol);
                }
            }
        }
    }
}
