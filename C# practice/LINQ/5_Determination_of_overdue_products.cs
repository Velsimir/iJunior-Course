using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Есть набор тушенки. У тушенки есть название, год производства и срок годности.
         * Написать запрос для получения всех просроченных банок тушенки.
         * Чтобы не заморачиваться, можете думать, что считаем только года, без месяцев.
         */
        public static void Main(string[] args)
        {
            List<Stew> stews = new List<Stew>();
            Database database = new Database();

            stews.Add(new Stew("Тушенка из Свинины", 1995, 30));
            stews.Add(new Stew("Тушенка из Говядины", 1996, 12));
            stews.Add(new Stew("Тушенка из Курицы", 1992, 15));
            stews.Add(new Stew("Тушенка из Баранины", 1991, 16));
            stews.Add(new Stew("Тушенка из Оленины", 1999, 20));
            stews.Add(new Stew("Тушенка из Конины", 1992, 43));
            stews.Add(new Stew("Тушенка из Индейки", 1990, 14));
            stews.Add(new Stew("Тушенка из Индейки", 1997, 23));
            stews.Add(new Stew("Тушенка из Оленины", 1994, 30));
            stews.Add(new Stew("Тушенка из Баранины", 1996, 15));
            stews.Add(new Stew("Тушенка из Говядины", 1991, 40));

            database.SelectByNotExpiredStew(stews);
            Console.ReadKey();
        }
    }

    class Database
    {
        public void SelectByNotExpiredStew(List<Stew> stews)
        {
            int currentDate = 2022;

            var selectedStews = from Stew stew in stews
                                where (currentDate - stew.ProductDate) >= stew.ExpirationDate
                                select stew;

            ShowSelectedStew(selectedStews.ToList());
        }

        private void ShowSelectedStew(List<Stew> stews)
        {
            foreach (var stew in stews)
            {
                Console.WriteLine($"Название {stew.Name}\tДата производства: {stew.ProductDate}\tСрок годности: {stew.ExpirationDate}");
            }
        }
    }

    class Stew
    {
        public string Name { get; private set; }
        public int ProductDate { get; private set; }
        public int ExpirationDate { get; private set; }

        public Stew(string name, int productDate, int expirationDate)
        {
            Name = name;
            ProductDate = productDate;
            ExpirationDate = expirationDate;
        }
    }
}
