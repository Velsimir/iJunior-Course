using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace iJunior
{
    class MainClass
    {
        /*На экране, в специальной зоне, выводятся картинки, по 3 в ряд (условно, ничего рисовать не надо). 
         * Всего у пользователя в альбоме 52 картинки. 
         * Код должен вывести, сколько полностью заполненных рядов можно будет вывести, 
         * и сколько картинок будет сверх меры. 
         * 
         * В качестве решения ожидаются объявленные переменные с необходимыми значениями и, 
         * основываясь на значениях переменных, вывод необходимых данных. 
         * По задаче требуется выполнить простые математические действия.*/

        public static void Main(string[] args)
        {
            int images = 52;
            int imageInRow = 3;
            int filledRows;
            int lefttImages;

            filledRows = images / imageInRow;
            lefttImages = filledRows % imageInRow;

            Console.WriteLine($"Заполненных рядов = {filledRows} \nОстанется картинок вне рядов = {lefttImages}");
        }
    }
}
