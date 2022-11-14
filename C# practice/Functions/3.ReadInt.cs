using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        /*Написать функцию, которая запрашивает число у пользователя (с помощью метода Console.ReadLine() ) 
         * и пытается сконвертировать его в тип int (с помощью int.TryParse())
         * Если конвертация не удалась у пользователя запрашивается число повторно до тех пор, 
         * пока не будет введено верно. После ввода, который удалось преобразовать в число, число возвращается.
         * P.S Задача решается с помощью циклов
         * P.S Также в TryParse используется модфикатор параметра out
         */
        static void Main(string[] args)
        {
            GetNumber();
        }

        static int GetNumber()
        {
            bool isWorking = true;
            string userInput;
            int result = 0;

            while (isWorking)
            {
                Console.WriteLine("Введите число:");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out result))
                {
                    Console.WriteLine($"Число {result}, сконвертировано");
                    isWorking = false;
                }
                else
                {
                    Console.WriteLine($"{userInput}, не может быть сконвертировано");
                }
            }
            return result;
        }
    }
}