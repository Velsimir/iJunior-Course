using System;

public class Program
{
//Написать программу, которая будет выполняться до тех пор, пока не будет введено слово exit.
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

