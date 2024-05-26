using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] array =
                {23, 45, 24, 65, 34, 76, 34, 65, 54, 87,
            324, 432, 324, 432, 654, 453, 234, 431, 688, 312,
            634, 536, 457, 133, 876, 456, 234, 654, 967, 1000};
            int localMax;
            int previousNumber;
            int currentNumber;
            int nextNumber;
            int arrayLength = array.GetLength(0);

            if (array[0] > array[1])
            {
                localMax = array[0];
                Console.WriteLine(localMax);
            }

            for (int i = 1; i < arrayLength - 1; i++)
            {
                currentNumber = array[i];
                nextNumber = array[i + 1];
                previousNumber = array[i - 1];

                if (currentNumber >= previousNumber && currentNumber >= nextNumber)
                {
                    localMax = currentNumber;
                    Console.WriteLine(localMax);
                }
            }

            if (array[arrayLength - 1] > array[arrayLength - 2])
            {
                localMax = array[arrayLength - 1];
                Console.WriteLine(localMax);
            }
        }
    }
}
