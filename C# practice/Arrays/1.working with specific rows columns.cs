using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace iJunior
{
    class MainClass
    {
        /*Дан двумерный массив.
         * Вычислить сумму второй строки и произведение первого столбца. 
         * Вывести исходную матрицу и результаты вычислений.
         */
        public static void Main(string[] args)
        {
            int[,] array =
            {
                {1, 2, 3, 4, 5 },
                {7, 8, 9, 10, 11 },
                {12, 13, 14, 15, 16 }
            };
            int sumSecondString = 0;
            int multipleFirstColumn = 1;
            int maxLenghtSecondString = array.GetLength(1);
            int maxLenghtColumns = array.GetLength(0);

            for (int i = 0; i < maxLenghtColumns; i++)
            {
                for (int j = 0; j < maxLenghtSecondString; j++)
                {
                    Console.Write(array[i, j]);

                    Console.Write("\t");
                }

                Console.WriteLine();
            }

            for (int i = 0; i < maxLenghtSecondString; i++)
            {
                sumSecondString += array[1, i];
            }

            for (int i = 0; i < maxLenghtColumns; i++)
            {
                multipleFirstColumn *= array[i, 0];
            }

            Console.WriteLine($"Сумма второй строки = {sumSecondString}");
            Console.WriteLine($"Произведений первого столбца = {multipleFirstColumn}");
        }
    }
}
