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
            Database database = new Database();
            
            database.FindByParameters();
        }
    }
    
    class Database
    {
        private List<Criminal> _criminals;

        public Database()
        {
            _criminals = new List<Criminal>();
            Fill();
        }

        public void FindByParameters()
        {
            int height = ReturnParameter("Введите рост:");

            int weight = ReturnParameter("Введите вес:");

            Console.WriteLine("Введите национальность (ru/eu):");
            string nationality = Console.ReadLine();

            var filterList = from Criminal criminal in _criminals
                where criminal.Weight > weight
                      && criminal.Height > height
                      && criminal.Nationality == nationality
                      && criminal.IsArested == false
                select criminal;

            ShowList(filterList);

            Console.ReadKey();
        }

        private void ShowList(IEnumerable<Criminal> criminals)
        {
            foreach (var criminal in criminals)
            {
                Console.WriteLine(criminal.Name);
            }
        }

        private int ReturnParameter(string nameParameter)
        {
            string userInputString;
            int userInputInt;

            Console.WriteLine(nameParameter);
            do
            {
                userInputString = Console.ReadLine();

            } while (int.TryParse(userInputString, out userInputInt) == false);

            Console.Clear();

            return userInputInt;
        }

        private void Fill()
        {
            _criminals.Add(new Criminal("John", "ru", 172, 60, false));
            _criminals.Add(new Criminal("Ken", "eu", 164, 79, true));
            _criminals.Add(new Criminal("Sam", "ru", 174, 92, false));
            _criminals.Add(new Criminal("Max", "eu", 189, 98, true));
            _criminals.Add(new Criminal("Joel", "ru", 167, 55, true));
            _criminals.Add(new Criminal("Alex", "eu", 169, 59, false));
        }
    }

    class Criminal
    {
        public Criminal(string name, string nationality, int height, int weight, bool isArested)
        {
            Name = name;
            Nationality = nationality;
            Height = height;
            Weight = weight;
            IsArested = isArested;
        }
        
        public string Name { get; private set; }
        public string Nationality { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public bool IsArested { get; private set; }
    }
}
