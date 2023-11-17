using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Дана строка с текстом, используя метод строки String.Split() 
         * получить массив слов, которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.
         */
        public static void Main(string[] args)
        {
            string message = "Дана строка с текстом, используя метод строки String.Split() получить массив слов, " +
                "которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.";
            string[] subMessage = message.Split(' ');

            foreach (var word in subMessage)
            {
                Console.WriteLine(word);
            }
        }
    }
}
