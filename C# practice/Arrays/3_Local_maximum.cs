using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] numbers =
            {23, 45, 24, 65, 34, 76, 34, 65, 54, 87,
                324, 432, 324, 432, 654, 453, 234, 431, 688, 312,
                634, 536, 457, 133, 876, 456, 234, 654, 967, 1000};
            int lastIndex = numbers.Length - 1;

            if (numbers[0] > numbers[1])
                Console.WriteLine(numbers[0]);

            for (int i = 1; i < lastIndex; i++)
            {
                if (numbers[i] >= numbers[i - 1] && numbers[i] >= numbers[i + 1])
                    Console.WriteLine(numbers[i]);
            }

            if (numbers[lastIndex] > lastIndex - 1)
                Console.WriteLine(numbers[lastIndex]);
        }
    }
}