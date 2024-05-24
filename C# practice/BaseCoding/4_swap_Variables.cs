using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading;

namespace iJunior
{
    class MainClass
    {
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
