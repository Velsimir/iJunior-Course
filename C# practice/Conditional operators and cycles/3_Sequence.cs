using System;

public class Program
{
    public static void Main()
    {
        int maxValueOfTheCycle = 97;
        int step = 7;
        int minValue = 5;

        for (int i = minValue; i < maxValueOfTheCycle; i += step)
        {
            Console.WriteLine(i);
        }
    }
}

