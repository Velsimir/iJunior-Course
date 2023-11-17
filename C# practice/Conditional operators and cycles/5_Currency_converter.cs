using System;
using System.Security.Policy;
using Internal;

namespace iJunior
{
/*Написать конвертер валют (3 валюты).
*
*У пользователя есть баланс в каждой из представленных валют. Он может попросить сконвертировать часть баланса с одной валюты в другую. Тогда у него с баланса одной валюты снимется X и зачислится на баланс другой Y. Курс конвертации должен быть просто прописан в программе.
*По имени переменной курса конвертации должно быть понятно, из какой валюты в какую валюту конвертируется.
*Программа должна завершиться тогда, когда это решит пользователь.
*/
    class MainClass
    {
        public static void Main(string[] args)
        {
            float rubBalance = 1000;
            float usdBalance = 1000;
            float euroBalance = 1000;
            float rubleToDollarExchangeRate = 59.9f;
            float rubleToEuroExchangeRate = 60.9f;
            float dollarToEuroExchangeRate = 0.9f;
            float dollarToRubleExchangeRate = 0.016f;
            float euroToRubleExchangeRate = 0.016f;
            float euroToDollarExchangeRate = 0.9f;
            int choseRuble = 1;
            int choseDollar = 2;
            int choseEuro = 3;
            int choseExit = 0;
            int amountOfMoney;
            int userInput;
            bool userChoose = true;

            while (userChoose)
            {
                Console.WriteLine($" Ваш баланс на текущий момент: " +
                    $"\n\n Рубли = {rubBalance} " +
                    $"\n Доллары = {usdBalance}" +
                    $"\n Евро = {euroBalance}");

                Console.WriteLine();

                Console.WriteLine($"Выбирете валюту с которой хотите выполнить операцию: " +
                    $"\n Рубли - {choseRuble} " +
                    $"\n Доллоры - {choseDollar} " +
                    $"\n Евро - {choseEuro}" +
                    $"\n Выйти из конвертера - {choseExit}");

                userInput = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine($"Выбирете валюту для конвертации: " +
                        $"\n Доллоры - {choseDollar}" +
                        $"\n Евро - {choseEuro}");

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
                        $"\n Рубли - {choseRuble}" +
                        $"\n Евро - {choseEuro}");

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
                        $"\n Рубли - {choseRuble}" +
                        $"\n Доллоры - {choseDollar}");

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

