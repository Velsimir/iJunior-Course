using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[10];
            int tempNumber;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 100);
                Console.Write(numbers[i] + "\t");
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        tempNumber = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = tempNumber;
                    }
                }
            }

            Console.WriteLine("\n\n");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + "\t");
            }
        }
    }
}
