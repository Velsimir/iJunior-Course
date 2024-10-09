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
            Army army = new Army();

            army.Work();
        }
    }

    class Army
    {
        Database _database;

        public Army()
        {
            _database = new Database();
        }

        public void Work()
        {
            _database.ShowPlatoons();

            _database.TransferSoldiers('B');

            _database.ShowPlatoons();

            Console.ReadKey();
        }
    }

    class Database
    {
        private PlatoonFactory _factory;
        private Platoon _soldersPlatoonOne;
        private Platoon _soldersPlatoonTwo;

        public Database()
        {
            _factory = new PlatoonFactory();
            _soldersPlatoonOne = new Platoon(_factory.CreatePlatoonFirst());
            _soldersPlatoonTwo = new Platoon(_factory.CreatePlatoonSecond());
        }

        public void ShowPlatoons()
        {
            Console.WriteLine("\nОтряд 1:");

            foreach (var soldier in _soldersPlatoonOne.Soldiers)
            {
                Console.WriteLine($"Имя: {soldier.Name}");
            }

            Console.WriteLine("\nОтряд 2:");

            foreach (var soldier in _soldersPlatoonTwo.Soldiers)
            {
                Console.WriteLine($"Имя: {soldier.Name}");
            }
        }

        public void TransferSoldiers(char fistСharacter)
        {
            var selectedSoldiers = from player in _soldersPlatoonOne.Soldiers
                                   where player.Name.StartsWith(fistСharacter)
                                   select player;

            _soldersPlatoonOne.RemoveSoldiers(selectedSoldiers.ToList());
            _soldersPlatoonTwo.AddSoldiers(selectedSoldiers.ToList());
        }
    }

    class PlatoonFactory
    {
        public List<Soldier> CreatePlatoonFirst()
        {
            List<Soldier> tempPlatoon = new List<Soldier>();

            tempPlatoon.Add(new Soldier("Brandon", "Blowgun", "Private", 18));
            tempPlatoon.Add(new Soldier("Bakir", "Bomb", "Private Second", 23));
            tempPlatoon.Add(new Soldier("Sam", "Bow", "Specialist", 16));
            tempPlatoon.Add(new Soldier("Stive", "Cannon", "Corporal", 43));
            tempPlatoon.Add(new Soldier("Robert", "Club", "Sergeant", 50));
            tempPlatoon.Add(new Soldier("Bob", "Gun", "Staff sergeant", 68));
            tempPlatoon.Add(new Soldier("Bred", "Knife", "Sergeant First", 80));
            tempPlatoon.Add(new Soldier("Tomas", "Revolver", "Master Sergeant", 93));
            tempPlatoon.Add(new Soldier("Frank", "Rifle", "Command Sergeant Major", 115));
            tempPlatoon.Add(new Soldier("Dick", "Sword", "Private", 15));

            return tempPlatoon;
        }

        public List<Soldier> CreatePlatoonSecond()
        {
            List<Soldier> tempPlatoon = new List<Soldier>();

            tempPlatoon.Add(new Soldier("John", "Blowgun", "Private", 18));
            tempPlatoon.Add(new Soldier("Rick", "Bomb", "Private Second", 23));
            tempPlatoon.Add(new Soldier("Sam", "Bow", "Specialist", 16));
            tempPlatoon.Add(new Soldier("Stive", "Cannon", "Corporal", 43));
            tempPlatoon.Add(new Soldier("Robert", "Club", "Sergeant", 50));
            tempPlatoon.Add(new Soldier("Max", "Gun", "Staff sergeant", 68));
            tempPlatoon.Add(new Soldier("Bred", "Knife", "Sergeant First", 80));
            tempPlatoon.Add(new Soldier("Tomas", "Revolver", "Master Sergeant", 93));
            tempPlatoon.Add(new Soldier("Frank", "Rifle", "Command Sergeant Major", 115));
            tempPlatoon.Add(new Soldier("Dick", "Sword", "Private", 15));

            return tempPlatoon;
        }
    }

    class Platoon
    {
        private List<Soldier> _soldiers;

        public Platoon(List<Soldier> soldiers)
        {
            _soldiers = soldiers;
        }

        public List<Soldier> Soldiers => _soldiers.ToList();

        public void RemoveSoldiers(List<Soldier> soldiers)
        {
            _soldiers = _soldiers.Except(soldiers).ToList();
        }

        public void AddSoldiers(List<Soldier> soldiers)
        {
            _soldiers.AddRange(soldiers);
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
