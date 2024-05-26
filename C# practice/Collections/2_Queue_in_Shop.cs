using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Queue<int> queueVisitors = new Queue<int>();
            queueVisitors.Enqueue(123);
            queueVisitors.Enqueue(432);
            queueVisitors.Enqueue(3456);
            queueVisitors.Enqueue(534);
            queueVisitors.Enqueue(654);

            ServeClients(queueVisitors);
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
