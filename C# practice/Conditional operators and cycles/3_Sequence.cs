using System;

public class Program
{
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

