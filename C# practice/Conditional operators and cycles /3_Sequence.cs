using System;
using Internal;

public class Program
{
/* Нужно написать программу (используя циклы, обязательно пояснить выбор вашего цикла),
*чтобы она выводила следующую последовательность 5 12 19 26 33 40 47 54 61 68 75 82 89 96
*/
    public static void Main()
    {
        int maxValueOfTheCycle = 97;
        int cycleStep = 7;

        for (int minValueOfTheCycle = 5; minValueOfTheCycle < maxValueOfTheCycle; minValueOfTheCycle += cycleStep)
        {
            Console.WriteLine(minValueOfTheCycle);
        }
    }
}

