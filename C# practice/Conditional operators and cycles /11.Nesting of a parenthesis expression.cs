using System;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Дана строка из символов '(' и ')'. Определить, является ли она корректным скобочным выражением. 
         * Определить максимальную глубину вложенности скобок.
         * Пример “(()(()))” - строка корректная и максимум глубины равняется 3.
         * Пример не верных строк: "(()", "())", ")(", "(()))(()"
         * Для перебора строки по символам можно использовать цикл foreach, к примеру будет так foreach (var symbol in text)
         * Или цикл for(int i = 0; i < text.Length; i++) и дальше обращаться к каждому символу внутри цикла как text[i]
         * Цикл нужен для перебора всех символов в строке.
         */
        public static void Main(string[] args)
        {
            int numberOfBrackets = 0;
            string userInput;
            bool expressionIsCorrect = true;
            char previousSymbol = ' ';
            int streak = 1;
            int minStreak = 1;
            int maxStreak = 1;

            Console.Write("Введите случайное количество симовлов ( ) - ");
            userInput = Console.ReadLine();

            int lenghtInput = userInput.Length - 1;

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
                Console.WriteLine("Скобочное выражение является не корректным");
            }
        }
    }
}
