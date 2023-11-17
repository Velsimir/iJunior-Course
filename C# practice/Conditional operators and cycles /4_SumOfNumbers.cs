using System;
using Internal;

public class Program
{
/*С помощью Random получить число number, которое не больше 100. 
 * Найти сумму всех положительных чисел меньше number (включая число), которые кратные 3 или 5. 
 * (К примеру, это числа 3, 5, 6, 9, 10, 12, 15 и т.д.)
 */
    public static void Main()
    {
        Random random = new Random();
        int lowLimited = 0;
        int upperLimited = 101;
        int randomNumber = random.Next(lowLimited, upperLimited);
        int sumOfDividedNumbers = 0;
        int deviderOne = 3;
        int deviderTwo = 5;

        for (int i = 0; i < randomNumber; i++)
        {
            Console.WriteLine(i);

            if (i % deviderOne == 0 | i % deviderTwo == 0)
            {
                sumOfDividedNumbers += i;
            }
        }

        Console.WriteLine($"Суммы чисел кратных {deviderOne} и {deviderTwo} = {sumOfDividedNumbers}");
    }
}
