using System;

public class Program
{
    public static void Main()
    {
        Random random = new Random();
        int minRandomNumber = 0;
        int maxRandomNumber = 101;
        int randomNumber = random.Next(minRandomNumber, maxRandomNumber);
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
