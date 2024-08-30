using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[30];
            int currentStreak = 1;
            int maxStreak = 1;
            int repeatNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 10);
                Console.Write($"{numbers[i]}\t");
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    currentStreak += 1;

                    if (currentStreak > maxStreak)
                    {
                        maxStreak = currentStreak;
                        repeatNumber = numbers[i];
                    }
                }
                else
                {
                    currentStreak = 1;
                }
            }

            Console.WriteLine($"\nМаксимальная последовательность одинаковых чисел = {maxStreak}");
            
            if (repeatNumber == 0)
            {
                Console.WriteLine("В массиве нет повторяющихся чисел");
            }
            else
            {
                Console.WriteLine($"Повторяющееся число = {repeatNumber}");
            }
        }
    }
}
