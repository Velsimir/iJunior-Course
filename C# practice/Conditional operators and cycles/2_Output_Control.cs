using System;

public class Program
{
    public static void Main()
    {
        string secretWord = "Exit";
        string userWord = "Default";

        while (userWord != secretWord)
        {
            Console.Write("Введите секретное слово (анаграмма слова - itxE) = ");
            userWord = Console.ReadLine();
        }
    }
}

