using System;

public class MasteringCycles
{
    public static void Main()
    {
        string userMessage;
        int counter;
        
	Console.Write("Введите сообщение: ");
        userMessage = Console.ReadLine();
        
	Console.Write("Сколько раз вы хотите повторить сообщение?: ");
        counter = Convert.ToInt32(Console.ReadLine());
        
	for (int i = 0; i < counter; i++)
        {
            Console.WriteLine(userMessage);
        }
    }
}