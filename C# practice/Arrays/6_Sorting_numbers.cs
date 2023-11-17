using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Дан массив чисел (минимум 10 чисел). Надо вывести в консоль числа отсортированы, от меньшего до большего.
         * Нельзя использовать Array.Sort. 
         * Можно найти подходящий алгоритм сортировки и использовать его для задачи.
         */
        public static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[10];
            int tempNumber;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 100);
                Console.Write(array[i] + "\t");
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        tempNumber = array[i];
                        array[i] = array[j];
                        array[j] = tempNumber;
                    }
                }
            }

            Console.WriteLine("\n\n");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "\t");
            }
        }
    }
}
