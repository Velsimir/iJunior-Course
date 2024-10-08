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

            database.ShowList(database.Criminals);

            database.ShowList(database.RunFilter());
            
            Console.ReadKey();
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

        public List<Criminal> Criminals => _criminals.ToList();

        public List<Criminal> RunFilter()
        {
            string typeOfCrime = "Антиправительственное";

            var filteredCriminals = from Criminal criminal in _criminals
                where criminal.TypeOfCrime != typeOfCrime
                select criminal;

            return filteredCriminals.ToList();
        }

        public void ShowList(List<Criminal> criminals)
        {
            foreach (var criminal in criminals)
            {
                Console.WriteLine($"{criminal.Name} - заключен под стражу");
            }
            
            Console.WriteLine();
        }

        private void Fill()
        {
            _criminals.Add(new Criminal("John", "Антиправительственное"));
            _criminals.Add(new Criminal("Ken", "Ограбление"));
            _criminals.Add(new Criminal("Sam", "Антиправительственное"));
            _criminals.Add(new Criminal("Max", "Воровство"));
            _criminals.Add(new Criminal("Joel", "Антиправительственное"));
            _criminals.Add(new Criminal("Alex", "Антиправительственное"));
        }
    }

    class Criminal
    {
        public Criminal(string name, string typeOfCrime)
        {
            Name = name;
            TypeOfCrime = typeOfCrime;
        }
        
        public string Name { get; private set; }
        public string TypeOfCrime { get; private set; }
    }
}
