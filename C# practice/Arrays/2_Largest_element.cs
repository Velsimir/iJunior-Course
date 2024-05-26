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
            int[,] array =
            {
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                {15, 123, 43, 76, 34, 334, 768, 325, 222, 523},
                {54, 43, 23, 56, 78, 43, 234, 645, 346, 253},
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                {15, 123, 43, 76, 34, 334, 768, 325, 222, 523},
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                {54, 43, 23, 56, 78, 43, 234, 645, 346, 253},
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                {54, 43, 23, 56, 78, 43, 234, 645, 346, 253},
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
            };
            int maxValue = int.MinValue;
            int changeNumber = 0;

            Console.WriteLine("Изначальный массив");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[i, j] + "\t");

                    if (maxValue < array[i, j])
                    {
                        maxValue = array[i, j];
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Полученный массив");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (maxValue == array[i, j])
                    {
                        array[i, j] = changeNumber;
                    }

                    Console.Write(array[i, j] + "\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"\nМаксимальное значение в массиве = {maxValue}");
        }
    }
}
