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
            
            int[] array = { 0 };
            int userNumber;
            string userAnswer;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write($"Введите {CommandSum}, чтобы посчитать введенные числа." +
                $"\nВведите {CommandExit}, чтобы выйти из программы." +
                $"\nВведите число, чтобы добавить его в список." +
                $"Ввод пользователя:");

                userAnswer = Console.ReadLine();

                if (userAnswer == CommandExit)
                    isWorking = false;
                else if (userAnswer == CommandSum)
                {
                    int sumOfAllNumbers = 0;

                    for (int i = 0; i < array.Length; i++)
                    {
                        sumOfAllNumbers += array[i];
                    }

                    Console.WriteLine(sumOfAllNumbers);
                    Console.ReadKey();
                }
                else
                {
                    int[] tempArray = new int[array.Length + 1];
                    int lenghtTempArray = tempArray.Length - 1;

                    userNumber = Convert.ToInt32(userAnswer);

                    for (int i = 0; i < array.Length; i++)
                    {
                        tempArray[i] = array[i];
                    }

                    tempArray[lenghtTempArray] = userNumber;
                    array = tempArray;
                }

                Console.Clear();
            }
        }
    }
}
