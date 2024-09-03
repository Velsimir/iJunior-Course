using System;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            Shuffle(numbers);
        }

        static void Shuffle(int[] array)
        {
            Random random = new Random();

            for (int i = array.Length - 1; i >= 1; i--)
            {
                int randomIndex = random.Next(i + 1);

                int temp = array[randomIndex];
                array[randomIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}
