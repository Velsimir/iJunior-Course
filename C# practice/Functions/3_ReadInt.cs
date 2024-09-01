using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetNumber());
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
