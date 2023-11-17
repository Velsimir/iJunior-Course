using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        /*Создать программу, которая принимает от пользователя слово и выводит его значение. 
         * Если такого слова нет, то следует вывести соответствующее сообщение.
         */
        static void Main(string[] args)
        {
            string userInput;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("Компьютер", "Устройство или система, способная выполнять заданную, чётко определённую, изменяемую последовательность операций");
            dictionary.Add("Юнити", "Межплатформенная среда разработки компьютерных игр, разработанная американской компанией Unity Technologies.");
            dictionary.Add("Телефон", "Аппарат для передачи и приёма звука (в основном — человеческой речи) на расстоянии");

            TakeWord(out userInput);

            FindWord(dictionary, userInput);
        }

        static void TakeWord(out string userInput)
        {
            Console.Write("Введите слово:");
            userInput = Console.ReadLine();
        }

        static void FindWord(Dictionary<string, string> dictionary, string userInput)
        {
            bool isWordFind = false;

            foreach (var wrod in dictionary)
            {
                if (userInput == wrod.Key)
                {
                    Console.WriteLine(dictionary[userInput]);
                    isWordFind = true;
                }
            }

            if (isWordFind == false)
            {
                Console.WriteLine("Данного слова нет в словаре.");
            }
        }
    }
}
