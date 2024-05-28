using System;

namespace iJunior
{
    class MainClass
    {
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
