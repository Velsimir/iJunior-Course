using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const int CommnadChoseRubleToDollar = 1;
            const int CommandChoseRubleToEuro = 2;
            const int CommandChoseDollarToRuble = 3;
            const int CommandChoseDollarToEuro = 4;
            const int CommandChoseEuroToRuble = 5;
            const int CommandChoseEuroToDollar = 6;
            const int CommandChoseExit = 0;

            float rubleBalance = 1000;
            float dollarBalance = 1000;
            float euroBalance = 1000;
            float rubleToDollarExchangeRate = 88.8f;
            float rubleToEuroExchangeRate = 96.2f;
            float dollarToEuroExchangeRate = 0.9f;
            float dollarToRubleExchangeRate = 0.011f;
            float euroToRubleExchangeRate = 0.010f;
            float euroToDollarExchangeRate = 1f;
            int amountOfMoney;
            int userInput;
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine(" Ваш баланс на текущий момент: " +
                    $"\n\n Рубли = {rubleBalance} " +
                    $"\n Доллары = {dollarBalance}" +
                    $"\n Евро = {euroBalance}");

                Console.WriteLine();

                Console.WriteLine("Выбирете операцию которую хотите выполнить: " +
                    $"\n Рубли в доллар - {CommnadChoseRubleToDollar}" +
                    $"\n Рубли в евро - {CommandChoseRubleToEuro}" +
                    $"\n Доллор в рубли - {CommandChoseDollarToRuble}" +
                    $"\n Доллор в евро - {CommandChoseDollarToEuro}" +
                    $"\n Евро в рубли - {CommandChoseEuroToRuble}" +
                    $"\n Евро в доллар - {CommandChoseEuroToDollar}" +
                    $"\n Выйти из конвертера - {CommandChoseExit}");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case CommnadChoseRubleToDollar:

                        Console.WriteLine("Производится обмен рублей в доллоры");
                        Console.WriteLine();
                        Console.Write("Какую сумму вы хотите обменять?\n");
                        amountOfMoney = Convert.ToInt32(Console.ReadLine());

                        if (amountOfMoney > rubleBalance || amountOfMoney <= 0)
                        {
                            Console.WriteLine("Сумма введена не корректно");
                        }
                        else
                        {
                            rubleBalance -= amountOfMoney;
                            dollarBalance += amountOfMoney * dollarToRubleExchangeRate;
                        }

                        break;

                    case CommandChoseRubleToEuro:

                        Console.WriteLine("Производится обмен рублей в евро");
                        Console.WriteLine();
                        Console.Write("Какую сумму вы хотите обменять?\n");
                        amountOfMoney = Convert.ToInt32(Console.ReadLine());

                        if (amountOfMoney > rubleBalance || amountOfMoney <= 0)
                        {
                            Console.WriteLine("Сумма введена не корректно");
                        }
                        else
                        {
                            rubleBalance -= amountOfMoney;
                            euroBalance += amountOfMoney * euroToRubleExchangeRate;
                        }

                        break;

                    case CommandChoseDollarToRuble:

                        Console.WriteLine("Производится обмен доллоров в рубли");
                        Console.WriteLine();
                        Console.Write("Какую сумму вы хотите обменять?\n");
                        amountOfMoney = Convert.ToInt32(Console.ReadLine());

                        if (amountOfMoney > rubleBalance || amountOfMoney <= 0)
                        {
                            Console.WriteLine("Сумма введена не корректно");
                        }
                        else
                        {
                            dollarBalance -= amountOfMoney;
                            rubleBalance += amountOfMoney * rubleToDollarExchangeRate;
                        }

                        break;

                    case CommandChoseDollarToEuro:

                        Console.WriteLine("Производится обмен доллоров в евро");
                        Console.WriteLine();
                        Console.Write("Какую сумму вы хотите обменять?\n");
                        amountOfMoney = Convert.ToInt32(Console.ReadLine());

                        if (amountOfMoney > rubleBalance || amountOfMoney <= 0)
                        {
                            Console.WriteLine("Сумма введена не корректно");
                        }
                        else
                        {
                            dollarBalance -= amountOfMoney;
                            euroBalance += amountOfMoney * euroToDollarExchangeRate;
                        }

                        break;

                    case CommandChoseEuroToRuble:

                        Console.WriteLine("Производится обмен евро в рубли");
                        Console.WriteLine();
                        Console.Write("Какую сумму вы хотите обменять?\n");
                        amountOfMoney = Convert.ToInt32(Console.ReadLine());

                        if (amountOfMoney > rubleBalance || amountOfMoney <= 0)
                        {
                            Console.WriteLine("Сумма введена не корректно");
                        }
                        else
                        {
                            euroBalance -= amountOfMoney;
                            rubleBalance += amountOfMoney * rubleToEuroExchangeRate;
                        }

                        break;

                    case CommandChoseEuroToDollar:

                        Console.WriteLine("Производится обмен евро в доллоры");
                        Console.WriteLine();
                        Console.Write("Какую сумму вы хотите обменять?\n");
                        amountOfMoney = Convert.ToInt32(Console.ReadLine());

                        if (amountOfMoney > rubleBalance || amountOfMoney <= 0)
                        {
                            Console.WriteLine("Сумма введена не корректно");
                        }
                        else
                        {
                            euroBalance -= amountOfMoney;
                            dollarBalance += amountOfMoney * dollarToEuroExchangeRate;
                        }

                        break;

                    case CommandChoseExit:

                        isWorking = false;

                        break;
                }

                Console.WriteLine("Нажмите Enter для продолжения...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}

