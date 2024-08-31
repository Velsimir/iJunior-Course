using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4 };
            int arrayLengh = numbers.Length;
            int userInput;
            int tempNumber;

            for (int i = 0; i < arrayLengh; i++)
            {
                Console.Write($"{numbers[i]}\t");
            }

            Console.Write($"Введите число, на которое хотите сдвинуть массив: ");

            userInput = Convert.ToInt32(Console.ReadLine());

            if (userInput > arrayLengh)
                userInput = userInput % arrayLengh;
            
            Console.WriteLine(userInput);
            
            for (int i = 0; i < userInput; i++)
            {
                tempNumber = numbers[0];
                
                for (int j = 0; j < arrayLengh - 1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }
                
                numbers[arrayLengh - 1] = tempNumber;
            }

            for (int i = 0; i < arrayLengh; i++)
            {
                Console.Write($"{numbers[i]}\t");
            }
        }
    }
}
