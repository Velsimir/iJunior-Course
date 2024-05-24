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
        /*Цикл for идеально подходит для цикличного выполнения задачи, 
         * когда мы знаем точное количество необходимых нам циклов (или можем их вычислить)
         * Также цикл for работает быстрее и требуют меньше ресурсов для реализации
         */
    }
}

