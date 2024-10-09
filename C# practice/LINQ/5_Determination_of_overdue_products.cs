using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            Factory factory = new Factory();

            factory.Work();
        }
    }


    class Factory
    {
        Database _database;

        public Factory()
        {
            _database = new Database();
        }

        public void Work()
        {
            _database.SelectByNotExpiredStew();
            Console.ReadKey();
        }
    }

    class Database
    {
        private List<Stew> _stews;

        public Database()
        {
            _stews = new List<Stew>();

            Fill();
        }

        public void SelectByNotExpiredStew()
        {
            var selectedStews = from Stew stew in _stews
                                where (DateTime.Now.Year - stew.ProductDate) >= stew.ExpirationDate
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

        private void Fill()
        {
            _stews.Add(new Stew("Тушенка из Свинины", 1995, 30));
            _stews.Add(new Stew("Тушенка из Говядины", 1996, 12));
            _stews.Add(new Stew("Тушенка из Курицы", 1992, 15));
            _stews.Add(new Stew("Тушенка из Баранины", 1991, 16));
            _stews.Add(new Stew("Тушенка из Оленины", 1999, 20));
            _stews.Add(new Stew("Тушенка из Конины", 1992, 43));
            _stews.Add(new Stew("Тушенка из Индейки", 1990, 14));
            _stews.Add(new Stew("Тушенка из Индейки", 1997, 23));
            _stews.Add(new Stew("Тушенка из Оленины", 1994, 30));
            _stews.Add(new Stew("Тушенка из Баранины", 1996, 15));
            _stews.Add(new Stew("Тушенка из Говядины", 1991, 40));
        }
    }

    class Stew
    {
        public Stew(string name, int productDate, int expirationDate)
        {
            Name = name;
            ProductDate = productDate;
            ExpirationDate = expirationDate;
        }

        public string Name { get; private set; }
        public int ProductDate { get; private set; }
        public int ExpirationDate { get; private set; }
    }
}
