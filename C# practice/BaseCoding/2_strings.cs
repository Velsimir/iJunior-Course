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
            string name;
            string city;
            string dish;

            Console.WriteLine("Как вас зовут?");
            name = Console.ReadLine();

            Console.WriteLine("В каком городе вы проживаете?");
            city = Console.ReadLine();

            Console.WriteLine("Ваше любимое блюдо?");
            dish = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}. Вы проживаете в городе {city}. Ваше любимое блюдо {dish}");
        }
    }
}
