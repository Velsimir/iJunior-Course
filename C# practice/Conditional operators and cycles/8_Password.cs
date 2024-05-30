using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string password = "qwerty1234";
            string userInput;
            string secretMessage = "Secret Message";
            int maximumNumberOfAttempts = 3;

            for (int i = 1; i <= maximumNumberOfAttempts; i++)
            {
                Console.Write("Введите пароль: ");

                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine($"Пароль введен верно!\nСекретное слово - {secretMessage}");
                    i = maximumNumberOfAttempts;
                }
                else
                {
                    int currentCount = maximumNumberOfAttempts - i;
                    Console.WriteLine($"Пароль введен не верно!\nОстальо попыток - {currentCount}");
                }
            }
        }
    }
}
