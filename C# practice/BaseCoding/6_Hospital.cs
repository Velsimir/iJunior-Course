using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int visitors = 0;
            int receptionMinutes = 10;
            int waitingHours = 0;
            int waitingMinutes = 0;
            int totalWaitingMinutes = 0;
            int minutesInOneHour = 60;

            Console.WriteLine($"Сколько перед вами людей в очереди?");
            visitors = Convert.ToInt32(Console.ReadLine());

            totalWaitingMinutes = visitors * receptionMinutes;
            waitingHours = totalWaitingMinutes / minutesInOneHour;
            waitingMinutes = totalWaitingMinutes % minutesInOneHour;

            Console.WriteLine($"Вам осталось ожидать своей очереди {waitingHours} Часов и {waitingMinutes} минут");
        }
    }
}
