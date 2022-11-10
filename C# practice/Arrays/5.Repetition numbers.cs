using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*В массиве чисел найдите самый длинный подмассив из одинаковых чисел.
         * Дано 30 чисел. Вывести в консоль сам массив, число, которое само больше раз повторяется подряд и количество повторений.
         * Дополнительный массив не надо создавать.
         * Пример: {5, 5, 9, 9, 9, 5, 5} - число 9 повторяется большее число раз подряд.
         */
        public static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[10];
            int currentStreak = 1;
            int maxStreak = 1;
            int repeatNumber = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 10);
                Console.Write($"{array[i]}\t");
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    currentStreak += 1;

                    if (currentStreak > maxStreak)
                    {
                        maxStreak = currentStreak;
                        repeatNumber = array[i];
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