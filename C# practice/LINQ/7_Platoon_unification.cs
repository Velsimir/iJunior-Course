using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Database database = new Database();

            database.ShowPlatoons();

            database.TransferSoldiers('B');

            database.ShowPlatoons();

            Console.ReadKey();
        }
    }

    class Database
    {
        private List<Soldier> _soldersPlatoonOne;
        private List<Soldier> _soldersPlatoonTwo;

        public Database()
        {
            _soldersPlatoonOne = new List<Soldier>();
            _soldersPlatoonTwo = new List<Soldier>();

            _soldersPlatoonOne.Add(new Soldier("Brandon", "Blowgun", "Private", 18));
            _soldersPlatoonOne.Add(new Soldier("Bakir", "Bomb", "Private Second", 23));
            _soldersPlatoonOne.Add(new Soldier("Sam", "Bow", "Specialist", 16));
            _soldersPlatoonOne.Add(new Soldier("Stive", "Cannon", "Corporal", 43));
            _soldersPlatoonOne.Add(new Soldier("Robert", "Club", "Sergeant", 50));
            _soldersPlatoonOne.Add(new Soldier("Bob", "Gun", "Staff sergeant", 68));
            _soldersPlatoonOne.Add(new Soldier("Bred", "Knife", "Sergeant First", 80));
            _soldersPlatoonOne.Add(new Soldier("Tomas", "Revolver", "Master Sergeant", 93));
            _soldersPlatoonOne.Add(new Soldier("Frank", "Rifle", "Command Sergeant Major", 115));
            _soldersPlatoonOne.Add(new Soldier("Dick", "Sword", "Private", 15));

            _soldersPlatoonTwo.Add(new Soldier("John", "Blowgun", "Private", 18));
            _soldersPlatoonTwo.Add(new Soldier("Rick", "Bomb", "Private Second", 23));
            _soldersPlatoonTwo.Add(new Soldier("Sam", "Bow", "Specialist", 16));
            _soldersPlatoonTwo.Add(new Soldier("Stive", "Cannon", "Corporal", 43));
            _soldersPlatoonTwo.Add(new Soldier("Robert", "Club", "Sergeant", 50));
            _soldersPlatoonTwo.Add(new Soldier("Max", "Gun", "Staff sergeant", 68));
            _soldersPlatoonTwo.Add(new Soldier("Bred", "Knife", "Sergeant First", 80));
            _soldersPlatoonTwo.Add(new Soldier("Tomas", "Revolver", "Master Sergeant", 93));
            _soldersPlatoonTwo.Add(new Soldier("Frank", "Rifle", "Command Sergeant Major", 115));
            _soldersPlatoonTwo.Add(new Soldier("Dick", "Sword", "Private", 15));
        }

        public void ShowPlatoons()
        {
            Console.WriteLine("\nОтряд 1:");

            foreach (var soldier in _soldersPlatoonOne)
            {
                Console.WriteLine($"Имя: {soldier.Name}");
            }

            Console.WriteLine("\nОтряд 2:");

            foreach (var soldier in _soldersPlatoonTwo)
            {
                Console.WriteLine($"Имя: {soldier.Name}");
            }
        }

        public void TransferSoldiers(char fistСharacter)
        {
            var selectedSoldiers = from player in _soldersPlatoonOne
                                   where player.Name.StartsWith(fistСharacter)
                                   select player;

            _soldersPlatoonOne = _soldersPlatoonOne.Except(selectedSoldiers).ToList();
            _soldersPlatoonTwo = _soldersPlatoonTwo.Union(selectedSoldiers).ToList();
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Rank { get; private set; }
        public int Period { get; private set; }

        public Soldier(string name, string armament, string rank, int period)
        {
            Name = name;
            Armament = armament;
            Rank = rank;
            Period = period;
        }
    }
}
