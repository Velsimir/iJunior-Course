using System;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Найдите минимальную степень двойки, превосходящую заданное число.
         * К примеру, для числа 4 будет 2 в степени 3, то есть 8. 4<8.
         * Для числа 29 будет 2 в степени 5, то есть 32. 29<32.
         * В консоль вывести число (лучше получить от Random), степень и само число 2 в найденной степени.
         */
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
