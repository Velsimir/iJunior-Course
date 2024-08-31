using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string message = "Дана строка с текстом, используя метод строки String.Split() получить массив слов, " +
                "которые разделены пробелом в тексте и вывести массив, каждое слово с новой строки.";
            char divider = ' ';
            string[] subMessage = message.Split(divider);

            foreach (var word in subMessage)
            {
                Console.WriteLine(word);
            }
        }
    }
}
