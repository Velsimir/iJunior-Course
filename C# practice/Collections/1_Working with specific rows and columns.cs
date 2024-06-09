using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int sumOfSecondRow = 0;
            int multiplicationOfFirstColumn = 1;
            int rowNumber = 1;
            int columnNumber = 1;
            
            int[,] numbers =
            {
                {1,2,3,4,5},
                {6,7,8,9,10}
            };

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                multiplicationOfFirstColumn *= numbers[i, columnNumber];
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                sumOfSecondRow += numbers[rowNumber, i];
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
