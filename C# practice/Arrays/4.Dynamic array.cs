using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Пользователь вводит числа, и программа их запоминает.
         * Как только пользователь введёт команду sum, программа выведет сумму всех веденных чисел.
         * Выход из программы должен происходить только в том случае, если пользователь введет команду exit.
         * Если введено не sum и не exit, значит это число и его надо добавить в массив.
         * Программа должна работать на основе расширения массива.
         * Внимание, нельзя использовать List<T> и Array.Resize
         */
        public static void Main(string[] args)
        {
            int[] array = { 0 };
            string sum = "sum";
            string exit = "exit";
            string userAnswer;
            bool isWorking = true;
            int userNumber;

            while (isWorking)
            {
                Console.Write($"Введите {sum}, чтобы посчитать введенные числа." +
                $"\nВведите {exit}, чтобы выйти из программы." +
                $"\nВведите число, чтобы добавить его в список." +
                $"Ввод пользователя:");

                userAnswer = Console.ReadLine();

                if (userAnswer == exit)
                {
                    isWorking = false;
                }
                else if (userAnswer == sum)
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