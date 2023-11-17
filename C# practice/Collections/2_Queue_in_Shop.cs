using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        /*У вас есть множество целых чисел. Каждое целое число - это сумма покупки.
         * Вам нужно обслуживать клиентов до тех пор, пока очередь не станет пуста.
         * После каждого обслуженного клиента деньги нужно добавлять на наш счёт и выводить его в консоль.
         * После обслуживания каждого клиента программа ожидает нажатия любой клавиши, 
         * после чего затирает консоль и по новой выводит всю информацию, только уже со следующим клиентом
         */
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
