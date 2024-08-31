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
            char previousSymbol = ' ';
            int streak = 1;
            int minStreak = 1;
            int maxStreak = 1;
            int lenghtInput;

            Console.Write("Введите случайное количество симовлов ( ) - ");
            userInput = Console.ReadLine();

            lenghtInput = userInput.Length - 1;
            
            if (userInput[0] == ')' || userInput[lenghtInput] == '(')
            {
                expressionIsCorrect = false;
            }
            else
            {
                foreach (var symbol in userInput)
                {
                    if (symbol == '(')
                        numberOfBrackets++;
                    else
                        numberOfBrackets--;

                    if (numberOfBrackets < 0)
                    {
                        Console.WriteLine("Закрывающих скобок больше, чем открывающих");
                        expressionIsCorrect = false;
                        break;
                    }

                    if (symbol == previousSymbol)
                        streak++;
                    else
                        streak = minStreak;

                    if (streak > maxStreak)
                        maxStreak = streak;

                    previousSymbol = symbol;
                }
            }

            if (expressionIsCorrect)
            {
                Console.WriteLine($"Скобочное выражение является корректным" +
                                  $"\nГлубина скобочного выражения = {maxStreak}");
            }
            else
            {
                Console.WriteLine("Открывающих скобок больше, чем закрывающих");
            }
        }
    }
}
