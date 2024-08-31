using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4 };
            int arrayLengh = array.Length - 1;
            int userInput;
            int tempArray;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }

            Console.Write($"Введите число, на которое хотите сдвинуть массив: ");

            userInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userInput; i++)
            {
                tempArray = array[0];

                for (int j = 0; j < arrayLengh; j++)
                {
                    array[j] = array[j + 1];
                }

                array[arrayLengh] = tempArray;
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
        }
    }
}
