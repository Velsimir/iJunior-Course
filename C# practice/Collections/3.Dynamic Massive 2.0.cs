using System;
using System.Collections.Generic;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*В массивах вы выполняли задание "Динамический массив"
         * Используя всё изученное, напишите улучшенную версию динамического массива(не обязательно брать своё старое решение)
         * Задание нужно, чтобы вы освоились с List и прощупали его преимущество.
         * Проверка на ввод числа обязательна.
         * 
         * Пользователь вводит числа, и программа их запоминает.
         * Как только пользователь введёт команду sum, программа выведет сумму всех веденных чисел.
         * Выход из программы должен происходить только в том случае, если пользователь введет команду exit.
         */
        static void Main(string[] args)
        {
            const string SumString = "sum";
            const string ExitString = "exit";
            List<int> numbers = new List<int>();
            string userInput;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write($"Введите {SumString}, чтобы посчитать введенные числа." +
                $"\nВведите {ExitString}, чтобы выйти из программы." +
                $"\nВведите число, чтобы добавить его в список." +
                $"Ввод пользователя:");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case SumString:
                        PrintSumNumbers(numbers);
                        break;
                    case ExitString:
                        isWorking = false;
                        break;
                    default:
                        AddNumberToList(numbers, userInput);
                        break;
                }

                Console.Clear();
            }
        }

        static void AddNumberToList(List<int> numbers, string userInput)
        {
            if (Int32.TryParse(userInput, out int userNumber))
            {
                numbers.Add(Convert.ToInt32(userNumber));
            }
        }

        static void PrintSumNumbers(List<int> numbers)
        {
            int sumOfNumbers = 0;

            foreach (var number in numbers)
            {
                sumOfNumbers += number;
            }

            Console.WriteLine($"Сумма всех чисел = {sumOfNumbers}");
            Console.ReadKey();
        }
    }
}