using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";
            
            int[] numbers = { };
            int userNumber;
            int lenghtTempArray;
            string userAnswer;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write("Список всех чисел: ");
                
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write($"{numbers[i]} ");
                }
                
                Console.WriteLine();
                
                Console.Write($"Введите {CommandSum}, чтобы посчитать введенные числа." +
                              $"\nВведите {CommandExit}, чтобы выйти из программы." +
                              $"\nВведите число, чтобы добавить его в список." +
                              $"Ввод пользователя:");

                userAnswer = Console.ReadLine();
                Console.Clear();
                
                if (Int32.TryParse(userAnswer, out userNumber) == true)
                {
                    int[] tempArray = new int[numbers.Length + 1];
                    lenghtTempArray = tempArray.Length;

                    userNumber = Convert.ToInt32(userAnswer);

                    for (int i = 0; i < numbers.Length; i++)
                    {
                        tempArray[i] = numbers[i];
                    }

                    tempArray[lenghtTempArray - 1] = userNumber;
                    numbers = tempArray;

                    continue;
                }

                if (userAnswer == CommandExit || userAnswer == CommandSum)
                {
                    if (userAnswer == CommandExit)
                    {
                        isWorking = false;
                    }

                    if (userAnswer == CommandSum)
                    {
                        int sumOfAllNumbers = 0;

                        for (int i = 0; i < numbers.Length - 1; i++)
                        {
                            sumOfAllNumbers += numbers[i];
                        }

                        Console.WriteLine($"Сумма всех числел = {sumOfAllNumbers}" +
                                          $"\nНажмите любую клавишу, чтобы вернуться в меню...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Введена неверная команда" +
                                      "\nНажмите любую клавишу, чтобы вернуться в меню...");
                    Console.ReadKey();
                }

                Console.Clear();
            }
        }
    }
}
