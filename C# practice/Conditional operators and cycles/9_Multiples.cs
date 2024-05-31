using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
        	Random random = new Random();
        
        	int smallestNumber = 10;
        	int highestNumber = 26;
        	int devider = random.Next(smallestNumber, highestNumber);
        	int quantityOfDivisibleNumbers = 0;
        	int maxValue = 150;
        	int minValue = 50;

        	for (int i = minValue; i <= maxValue; i += devider)
        	{
            	if (i < maxValue)
                	quantityOfDivisibleNumbers++;
        	}

        	Console.WriteLine($"Количество чисел N ({devider}) в диапазоне" +
            	              $" от {minValue} до {maxValue} = {quantityOfDivisibleNumbers}");
        }
    }
}
