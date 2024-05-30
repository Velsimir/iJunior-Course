using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            char userSymbol;
            string userName;
            string basicsOfRectangleSymbols = null;
            int nameLength = 0;

            Console.Write("Привет! Как тебя зовут? - ");
            userName = Console.ReadLine();
        
            Console.Write("Введи любой символ: ");
            userSymbol = Convert.ToChar(Console.ReadLine());

            userName = $"{userSymbol}{userName}{userSymbol}";

            Console.Clear();

            for (int i = 0; i < userName.Length; i++)
            {
                basicsOfRectangleSymbols += userSymbol;
            }
        
            Console.WriteLine($"{basicsOfRectangleSymbols}\n{userName}\n{basicsOfRectangleSymbols}");
        }
    }
}
