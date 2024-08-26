using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int rowSum = 0;
            int сolumnMultiplication = 1;
            int rowIndex = 1;
            int columnIndex = 0;
            
            int[,] numbers =
            {
                {1,2,3,4,5},
                {6,7,8,9,10}
            };

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                сolumnMultiplication *= numbers[i, columnIndex];
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                rowSum += numbers[rowIndex, i];
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Console.Write($"{numbers[i,j]}, ");
                }
                
                Console.WriteLine();
            }
            
            Console.WriteLine($"Сумма {rowIndex + 1} строки = {rowSum}" +
                              $"\nПроизведение {columnIndex + 1} столбца = {сolumnMultiplication}");
        }
    }
}
