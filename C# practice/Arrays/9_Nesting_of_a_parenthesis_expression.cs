using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int numberOfBrackets = 0;
            string userInput;
            bool expressionIsCorrect = true;
            int streak = 1;
            int lenghtInput;
            char openBracket = '(';
            char closeBracket = ')';

            Console.Write($"Введите случайное количество симовлов {openBracket} {closeBracket} - ");
            userInput = Console.ReadLine();

            lenghtInput = userInput.Length - 1;
            
            if (userInput[0] == closeBracket || userInput[lenghtInput] == openBracket)
            {
                expressionIsCorrect = false;
            }
            else
            {
                foreach (var symbol in userInput)
                {
                    if (symbol == openBracket)
                        numberOfBrackets++;
                    else
                        numberOfBrackets--;

                    if (numberOfBrackets < 0)
                    {
                        Console.WriteLine("Закрывающих скобок больше, чем открывающих");
                        expressionIsCorrect = false;
                        break;
                    }

                    if (numberOfBrackets > streak)
                        streak = numberOfBrackets;
                }
            }

            if (numberOfBrackets > 0)
            {
                Console.WriteLine("Открывающих скобок больше, чем закрывающих");
                expressionIsCorrect = false;
            }
            
            if (expressionIsCorrect)
            {
                Console.WriteLine($"Скобочное выражение является корректным" +
                                  $"\nГлубина скобочного выражения = {streak}");
            }
        }
    }
}
