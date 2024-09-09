using System;
using System.Collections.Generic;
using Internal;

namespace iJunior
{
    class MainClass
    {
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
                numbers.Add(userNumber);
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
