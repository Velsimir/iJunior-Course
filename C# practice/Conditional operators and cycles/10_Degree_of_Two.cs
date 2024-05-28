using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int originalNumber = random.Next(0, 100);
            int numberRaisedToPower = 1;
            int degree = 2;
            int numberInPower = 0;
            bool isWorking = true;

            while (isWorking)
            {
                if (originalNumber > numberRaisedToPower)
                {
                    numberRaisedToPower *= degree;
                    numberInPower += 1;
                }
                else
                {
                    isWorking = false;
                }
            }

            Console.WriteLine($"Изначальное число - {originalNumber}" +
                $"\nСтеперь - {numberInPower}" +
                $"\nЧисло в найденной степени - {numberRaisedToPower} ");
        }
    }
}
@Velsimir
