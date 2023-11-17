using System;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Дано N (1 ≤ N ≤ 27). Найти количество трехзначных натуральных чисел, которые кратны N.
         * Операции деления (/, %) не использовать. А умножение не требуется.
         * Число N всего одно, его надо получить в нужном диапазоне.
         */
        public static void Main(string[] args)
        {
            Random random = new Random();

            int smallestNumber = 1;
            int highestNumber = 27;
            int devider = random.Next(smallestNumber, highestNumber);
            int quantityOfDivisibleNumbers = 0;
            int maxValue = 999;
            int minValue = 100;

            for (int i = 1; i <= maxValue; i += devider)
                quantityOfDivisibleNumbers += i >= minValue ? 1 : 0;

            Console.WriteLine($"{devider}, {quantityOfDivisibleNumbers}");
        }
    }
}
