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
            int numberRaisedToPower = 1;
            int degree = 2;
            int numberInPower = 0;

            while (16 >= numberRaisedToPower)
            {
                numberRaisedToPower *= degree;
                numberInPower += 1;
            }

            Console.WriteLine($"Изначальное число - {randomNumber}" +
                              $"\nСтепень - {numberInPower}" +
                              $"\nЧисло в найденной степени - {numberRaisedToPower} ");
        }
    }
}