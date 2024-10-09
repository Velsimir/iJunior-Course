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
            Filter filter = new Filter();

            filter.Work();
        }
    }

    class Filter
    {
        private Database _database;

        public Filter()
        {
            _database = new Database();
        }

        public void Work()
        {
            _database.CreateSelection();
            Console.ReadKey();
        }
    }

    class Database
    {
        private List<Soldier> _soldiers;

        public Database()
        {
            _soldiers = new List<Soldier>();

            Fill();
        }

        public void CreateSelection()
        {
            var selectedSoldiersFields = from Soldier soldier in _soldiers
                                         select new
                                         {
                                             Name = soldier.Name,
                                             Rank = soldier.Rank
                                         };

            Show(selectedSoldiersFields);
        }

        private void Show(IEnumerable<dynamic> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine($"Имя: {soldier.Name}\tЗвание: {soldier.Rank}");
            }
        }

        private void Fill()
        {
            _soldiers.Add(new Soldier("John", "Blowgun", "Private", 18));
            _soldiers.Add(new Soldier("Rick", "Bomb", "Private Second", 23));
            _soldiers.Add(new Soldier("Sam", "Bow", "Specialist", 16));
            _soldiers.Add(new Soldier("Stive", "Cannon", "Corporal", 43));
            _soldiers.Add(new Soldier("Robert", "Club", "Sergeant", 50));
            _soldiers.Add(new Soldier("Max", "Gun", "Staff sergeant", 68));
            _soldiers.Add(new Soldier("Bred", "Knife", "Sergeant First", 80));
            _soldiers.Add(new Soldier("Tomas", "Revolver", "Master Sergeant", 93));
            _soldiers.Add(new Soldier("Frank", "Rifle", "Command Sergeant Major", 115));
            _soldiers.Add(new Soldier("Dick", "Sword", "Private", 15));
        }
    }

    class Soldier
    {
        public Soldier(string name, string armament, string rank, int period)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            Period = period;
        }

        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int Period { get; private set; }
    }
}
