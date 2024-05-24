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
            int playerCoins = 0;
            int playerCrystals = 0;
            int crystalsWantToBuy = 0;
            int crystalPrice = 15;

            Console.WriteLine("Сколько у вас монеток?");
            playerCoins = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Сколько кристалов вы хотите приобрести?");
            crystalsWantToBuy = Convert.ToInt32(Console.ReadLine());

            playerCrystals += crystalsWantToBuy;
            playerCoins -= crystalsWantToBuy * crystalPrice;

            Console.WriteLine($"У вас осталось {playerCoins} монет \nВы смогли приобрести {playerCrystals} рупий ");
        }
    }
}
