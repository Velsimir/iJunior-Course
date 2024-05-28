using System;
using System.Security.Policy;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const int CommandChoseRuble = 1;
            const int CommandChoseDollar = 2;
            const int CommandChoseEuro = 3;
            const int CommandChoseExit = 0;

            float rubBalance = 1000;
            float usdBalance = 1000;
            float euroBalance = 1000;
            float rubleToDollarExchangeRate = 88.8f;
            float rubleToEuroExchangeRate = 96.2f;
            float dollarToEuroExchangeRate = 0.9f;
            float dollarToRubleExchangeRate = 0.011f;
            float euroToRubleExchangeRate = 0.010f;
            float euroToDollarExchangeRate = 1f;
            int amountOfMoney;
            int userInput;
            bool userChoose = true;

            while (userChoose)
            {
                Console.WriteLine(" Ваш баланс на текущий момент: " +
                    $"\n\n Рубли = {rubBalance} " +
                    $"\n Доллары = {usdBalance}" +
                    $"\n Евро = {euroBalance}");

                Console.WriteLine();

                Console.WriteLine("Выбирете валюту с которой хотите выполнить операцию: " +
                    $"\n Рубли - {CommandChoseRuble} " +
                    $"\n Доллоры - {CommandChoseDollar} " +
                    $"\n Евро - {CommandChoseEuro}" +
                    $"\n Выйти из конвертера - {CommandChoseExit}");

                userInput = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine($"Выбирете валюту для конвертации: " +
                        $"\n Доллоры - {CommandChoseDollar}" +
                        $"\n Евро - {CommandChoseEuro}");

                        userInput = Convert.ToInt32(Console.ReadLine());

                        switch (userInput)
                        {
                            case 2:
                                Console.WriteLine("Производится обмен рублей в доллоры");
                                Console.WriteLine();
                                Console.Write("Какую сумму вы хотите обменять?");
                                amountOfMoney = Convert.ToInt32(Console.ReadLine());

                                if (amountOfMoney > rubBalance)
                                {
                                    Console.WriteLine("У вас на счету недостаточно средств");
                                }
                                else
                                {
                                    rubBalance -= amountOfMoney;
                                    usdBalance += amountOfMoney * dollarToRubleExchangeRate;
                                }
                                break;

                            case 3:
                                Console.WriteLine("Производится обмен рублей в евро");
                                Console.WriteLine();
                                Console.Write("Какую сумму вы хотите обменять?");
                                amountOfMoney = Convert.ToInt32(Console.ReadLine());

                                if (amountOfMoney > rubBalance)
                                {
                                    Console.WriteLine("У вас на счету недостаточно средств");
                                }
                                else
                                {
                                    rubBalance -= amountOfMoney;
                                    euroBalance += amountOfMoney * euroToRubleExchangeRate;
                                }
                                break;
                        }
                        break;

                    case 2:

                        Console.WriteLine($"Выбирете валюту для конвертации " +
                        $"\n Рубли - {CommandChoseRuble}" +
                        $"\n Евро - {CommandChoseEuro}");

                        userInput = Convert.ToInt32(Console.ReadLine());

                        switch (userInput)
                        {
                            case 1:

                                Console.WriteLine("Производится обмен доллоров в рубли");
                                Console.WriteLine();
                                Console.Write("Какую сумму вы хотите обменять?");
                                amountOfMoney = Convert.ToInt32(Console.ReadLine());

                                if (amountOfMoney > usdBalance)
                                {
                                    Console.WriteLine("У вас на счету недостаточно средств");
                                }
                                else
                                {
                                    usdBalance -= amountOfMoney;
                                    rubBalance += amountOfMoney * rubleToDollarExchangeRate;
                                }
                                break;

                            case 3:

                                Console.WriteLine("Производится обмен доллоров в евро");
                                Console.WriteLine();
                                Console.Write("Какую сумму вы хотите обменять?");
                                amountOfMoney = Convert.ToInt32(Console.ReadLine());

                                if (amountOfMoney > usdBalance)
                                {
                                    Console.WriteLine("У вас на счету недостаточно средств");
                                }
                                else
                                {
                                    usdBalance -= amountOfMoney;
                                    euroBalance += amountOfMoney * euroToDollarExchangeRate;
                                }
                                break;
                        }
                        break;

                    case 3:

                        Console.WriteLine($"Выбирете валюту для конвертации " +
                        $"\n Рубли - {CommandChoseRuble}" +
                        $"\n Доллоры - {CommandChoseDollar}");

                        userInput = Convert.ToInt32(Console.ReadLine());

                        switch (userInput)
                        {
                            case 1:

                                Console.WriteLine("Производится обмен евро в рубли");
                                Console.WriteLine();
                                Console.Write("Какую сумму вы хотите обменять?");
                                amountOfMoney = Convert.ToInt32(Console.ReadLine());

                                if (amountOfMoney > euroBalance)
                                {
                                    Console.WriteLine("У вас на счету недостаточно средств");
                                }
                                else
                                {
                                    euroBalance -= amountOfMoney;
                                    rubBalance += amountOfMoney * rubleToEuroExchangeRate;
                                }
                                break;

                            case 3:

                                Console.WriteLine("Производится обмен евро в доллоры");
                                Console.WriteLine();
                                Console.Write("Какую сумму вы хотите обменять?");
                                amountOfMoney = Convert.ToInt32(Console.ReadLine());

                                if (amountOfMoney > euroBalance)
                                {
                                    Console.WriteLine("У вас на счету недостаточно средств");
                                }
                                else
                                {
                                    euroBalance -= amountOfMoney;
                                    usdBalance += amountOfMoney * dollarToEuroExchangeRate;
                                }
                                break;
                        }
                        break;

                    case 0:
                        userChoose = false;
                        break;
                }

            }
        }
    }
}

