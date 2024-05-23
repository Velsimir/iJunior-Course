using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace iJunior
{
    class MainClass
    {
        /*Даны две переменные. 
         * Поменять местами значения двух переменных. 
         * Вывести на экран значения переменных до перестановки и после.

        Два примера.
        1. Есть две переменные имя и фамилия, они сразу инициализированные, но данные не верные, перепутанные. 
        Вот эти данные и надо поменять местами через код.
        2. Есть две чашки, в одном кофе, во втором чай. 
        Вам надо поменять местами содержимое чашек*/

        public static void Main(string[] args)
        {
            string name = "Koniashov";
            string surname = "Ivan";
            string tempString;

            Console.WriteLine($"Name = {name} \nSurname = {surname}");

            tempString = name;
            name = surname;
            surname = tempString;

            Console.WriteLine($"Name = {name} \nSurname = {surname}");
        }
    }
}
