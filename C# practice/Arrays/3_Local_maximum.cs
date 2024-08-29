﻿using System;

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
            int localMax;
            int previousNumber;
            int currentNumber;
            int nextNumber;
            int arrayLength = numbers.Length;
            int penultimateNumber = numbers[arrayLength - 2];

            if (numbers[0] > numbers[1])
            {
                localMax = numbers[0];
                Console.WriteLine(localMax);
            }

            for (int i = 1; i < arrayLength - 1; i++)
            {
                currentNumber = numbers[i];
                nextNumber = numbers[i + 1];
                previousNumber = numbers[i - 1];

                if (currentNumber >= previousNumber && currentNumber >= nextNumber)
                {
                    localMax = currentNumber;
                    Console.WriteLine(localMax);
                }
            }

            if (numbers[arrayLength - 1] > penultimateNumber)
            {
                localMax = numbers[arrayLength - 1];
                Console.WriteLine(localMax);
            }
        }
    }
}
