using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Queue<int> visitors = new Queue<int>();
            visitors.Enqueue(123);
            visitors.Enqueue(432);
            visitors.Enqueue(3456);
            visitors.Enqueue(534);
            visitors.Enqueue(654);

            ServeClients(visitors);
        }

        static void ServeClients(Queue<int> queueVisitors)
        {
            int sum = 0;

            while (queueVisitors.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"Сумма сбережений в кассе = {sum}" +
                $"\nСумма покупки текущего покупателя = {queueVisitors.Peek()}");
                Console.ReadKey();
                sum += queueVisitors.Dequeue();
            }
        }
    }
}
