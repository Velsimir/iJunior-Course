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
            int originalNumber = random.Next(minValue, maxValue);
            int numberRaisedToPower = 1;
            int degree = 2;
            int numberInPower = 0;

            while (originalNumber > numberRaisedToPower)
            {
                numberRaisedToPower *= degree;
                numberInPower += 1;
            }

            Console.WriteLine($"Изначальное число - {originalNumber}" +
                $"\nСтеперь - {numberInPower}" +
                $"\nЧисло в найденной степени - {numberRaisedToPower} ");
        }
    }
}