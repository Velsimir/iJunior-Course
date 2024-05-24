using System;

public class Program
{
    public static void Main()
    {
        int maxValueOfTheCycle = 97;
        int cycleStep = 7;
        int minValue = 5;

        for (int i = minValue; i < maxValueOfTheCycle; i += cycleStep)
        {
            Console.WriteLine(i);
        }
    }
}

