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
            int[] array = { 1, 2, 3, 4 };
            int arrayLenght = array.Length - 1;
            int userInput = 0;
            int tempArray = 0;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }

            Console.Write($"Введите число, на которое хотите сдвинуть массив: ");

            userInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userInput; i++)
            {
                tempArray = array[0];

                for (int j = 0; j < arrayLenght; j++)
                {
                    array[j] = array[j + 1];
                }

                array[arrayLenght] = tempArray;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }
    }
}
