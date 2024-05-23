using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace iJunior
{
    class MainClass
    {
        /*Легенда: 
        Вы приходите в магазин и хотите купить за своё золото кристаллы. 
        В вашем кошельке есть какое-то количество золота, продавец спрашивает у вас, сколько кристаллов вы хотите купить? 
        После сделки у вас остаётся какое-то количество золота в кошельке и появляется какое-то количество кристаллов.

        Формально: 
        При старте программы пользователь вводит начальное количество золота. 
        Потом ему предлагается купить какое-то количество кристаллов по цене N(задать в программе самому). 
        Пользователь вводит число и его золото конвертируется в кристаллы. Остаток золота и кристаллов выводится на экран. 

        Проверять на то, что у игрока достаточно денег не нужно. .*/

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
