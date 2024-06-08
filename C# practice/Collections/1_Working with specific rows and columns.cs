using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int sumOfSecondRow = 0;
            int multiplicationOfFirstColumn = 1;
            
            int[,] numbers =
            {
                {1,2,3,4,5},
                {6,7,8,9,10}
            };

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                multiplicationOfFirstColumn *= numbers[i, 0];
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                sumOfSecondRow += numbers[1, i];
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write($"{numbers[i,j]}, ");
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine($"Сумма второй строки = {sumOfSecondRow}" +
                              $"\nПроизведение первого столбца = {multiplicationOfFirstColumn}");
        }
    }
}
