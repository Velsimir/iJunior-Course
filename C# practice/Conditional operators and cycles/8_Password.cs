using System;
using System.Security.Policy;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string password = "qwerty1234";
            string userInput;
            string secretSword = "Secret Sword";
            int countMax = 3;

            for (int i = 1; i <= countMax; i++)
            {
                Console.Write("Введите пароль: ");

                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine($"Пароль введен верно!\nСекретное слово - {secretSword}");
                    i = countMax;
                }
                else
                {
                    int currentCount = countMax - i;
                    Console.WriteLine($"Пароль введен не верно!\nОстальо попыток - {currentCount}");
                }
            }
        }
    }
}
