using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int minValue = 0;
            int maxValue = 100;
            int randomNumber = random.Next(minValue, maxValue+1);
            int finishNumber = 1;
            int number = 2;
            int degree = 0;

            while (randomNumber >= finishNumber)
            {
                finishNumber *= number;
                degree += 1;
            }

            Console.WriteLine($"Изначальное число - {randomNumber}" +
                              $"\nСтепень - {degree}" +
                              $"\nЧисло в найденной степени - {finishNumber} ");
        }
    }
}