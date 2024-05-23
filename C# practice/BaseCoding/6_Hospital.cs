using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace iJunior
{
    class MainClass
    {
        /*Вы заходите в поликлинику и видите огромную очередь из пациентов, вам нужно рассчитать время ожидания в очереди.  
         * Формально: 
         * Пользователь вводит кол-во людей в очереди.  
         * Фиксированное время приема одного человека всегда равно 10 минутам.  
         * Пример ввода: Введите кол-во пациентов: 14
         * Пример вывода: "Вы должны отстоять в очереди 2 часа и 20 минут."
         * Примечание:
         * - при расчетах надо использовать только переменные. 
         * Если число не присваивается переменной, то в большинстве случаев это число магическое 
         * (исключение 0 и 1, но не во всех ситуациях).
         * - повторные расчеты так же стоит выносить в переменные*/

        public static void Main(string[] args)
        {
            int visitors = 0;
            int receptionTime = 10;
            int hours = 0;
            int miutes = 0;
            int totalWaitingTime = 0;
            int minutesInOneHour = 60;

            Console.WriteLine($"Сколько перед вами людей в очереди?");
            visitors = Convert.ToInt32(Console.ReadLine());

            totalWaitingTime = visitors * receptionTime;
            hours = totalWaitingTime / minutesInOneHour;
            miutes = totalWaitingTime % minutesInOneHour;

            Console.WriteLine($"Вам осталось ожидать своей очереди {hours} Часов и {miutes} минут");
        }
    }
}
