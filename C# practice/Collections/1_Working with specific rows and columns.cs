using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int sumOfSecondRow = 0;
            int multiplicationOfFirstColumn = 0;
            
            int[,] array =
            {
                {1,2,3,4,5},
                {6,7,8,9,10}
            };

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i == 1)
                        sumOfSecondRow += array[i, j];

                    if (j == 0 && i == 0)
                        multiplicationOfFirstColumn += array[i, j];

                    if (j == 0 && i == 1)
                        multiplicationOfFirstColumn *= array[i, j];
                    
                    Console.Write($"{array[i,j]}, ");
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine($"Сумма второй строки = {sumOfSecondRow}" +
                              $"\nПроизведение первого столбца {multiplicationOfFirstColumn}");
        }
    }
}
