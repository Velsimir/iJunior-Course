using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Существует класс солдата. В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
         * Написать запрос, при помощи которого получить набор данных состоящий из имени и звания.
         * Вывести все полученные данные в консоль.
         * (Не менее 5 записей)
         */
        public static void Main(string[] args)
        {
            List<Soldier> solders = new List<Soldier>();
            Database database = new Database();

            solders.Add(new Soldier("John", "Blowgun", "Private", 18));
            solders.Add(new Soldier("Rick", "Bomb", "Private Second", 23));
            solders.Add(new Soldier("Sam", "Bow", "Specialist", 16));
            solders.Add(new Soldier("Stive", "Cannon", "Corporal", 43));
            solders.Add(new Soldier("Robert", "Club", "Sergeant", 50));
            solders.Add(new Soldier("Max", "Gun", "Staff sergeant", 68));
            solders.Add(new Soldier("Bred", "Knife", "Sergeant First", 80));
            solders.Add(new Soldier("Tomas", "Revolver", "Master Sergeant", 93));
            solders.Add(new Soldier("Frank", "Rifle", "Command Sergeant Major", 115));
            solders.Add(new Soldier("Dick", "Sword", "Private", 15));

            database.CreateSelection(solders);
            Console.ReadKey();
        }
    }

    class Database
    {
        public void CreateSelection(List<Soldier> soldiers)
        {
            var selectedSoldiersFields = from Soldier soldier in soldiers
                                         select new
                                         {
                                             Name = soldier.Name,
                                             Rank = soldier.Rank
                                         };

            foreach (var soldier in selectedSoldiersFields)
            {
                Console.WriteLine($"Имя: {soldier.Name}\tЗвание: {soldier.Rank}");
            }
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
