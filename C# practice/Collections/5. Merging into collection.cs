using System;
using System.Collections.Generic;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Есть два массива строк. Надо их объединить в одну коллекцию, 
         * исключив повторения, не используя Linq. 
         * Пример: {"1", "2", "1"} + {"3", "2"} => {"1", "2", "3"}
         */
        public static void Main(string[] args)
        {
            string[] firstArray = { "1", "2", "1" };
            string[] secondArray = { "3", "2", "4", "5" };
            List<string> numbers = new List<string>();

            MergeArrays(firstArray, numbers);
            MergeArrays(secondArray, numbers);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }

        static void MergeArrays(string[] array, List<string> numbers)
        {

            for (int i = 0; i < array.Length; i++)
            {
                if (numbers.Contains(array[i]) == false)
                {
                    numbers.Add(array[i]);
                }
            }
        }
    }
}