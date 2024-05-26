using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>();
            Database database = new Database();

            criminals.Add(new Criminal("John", "Антиправительственное"));
            criminals.Add(new Criminal("Ken", "Ограбление"));
            criminals.Add(new Criminal("Sam", "Антиправительственное"));
            criminals.Add(new Criminal("Max", "Воровство"));
            criminals.Add(new Criminal("Joel", "Антиправительственное"));
            criminals.Add(new Criminal("Alex", "Антиправительственное"));

            criminals = criminals.Except(database.RunFilter(criminals)).ToList();

            database.ShowList(criminals);

            Console.ReadKey();
        }
    }

    class Database
    {
        public List<Criminal> RunFilter(List<Criminal> criminals)
        {
            string typeOfCrime = "Антиправительственное";

            var filteredCriminals = from Criminal criminal in criminals
                                    where criminal.TypeOfCrime == typeOfCrime
                                    select criminal;

            return filteredCriminals.ToList();
        }

        public void ShowList(List<Criminal> criminals)
        {
            foreach (var criminal in criminals)
            {
                Console.WriteLine($"{criminal.Name} - заключен под стражу");
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string TypeOfCrime { get; private set; }

        public Criminal(string name, string typeOfCrime)
        {
            Name = name;
            TypeOfCrime = typeOfCrime;
        }
    }
}
