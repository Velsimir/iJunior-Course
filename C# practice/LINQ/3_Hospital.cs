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
            const string CommandFilterByName = "1";
            const string CommandFilterByAge = "2";
            const string CommandFilterByDisease = "3";
            const string CommandExit = "ex";

            string userInput;
            bool isWorking = true;
            List<Patient> patients = new List<Patient>();
            Database database = new Database();

            patients.Add(new Patient("Ваня", "Кашель", 32));
            patients.Add(new Patient("Андрей", "Кашель", 16));
            patients.Add(new Patient("Ольга", "Насморк", 48));
            patients.Add(new Patient("Наталья", "Головная боль", 56));
            patients.Add(new Patient("Семен", "Насморк", 43));
            patients.Add(new Patient("Дарья", "Кашель", 34));
            patients.Add(new Patient("Яков", "Мигрень", 23));
            patients.Add(new Patient("Дмитрий", "Гастрит", 25));
            patients.Add(new Patient("Татьяна", "Мигрень", 49));
            patients.Add(new Patient("Артур", "Гастрит", 20));

            do
            {
                Console.Clear();

                Console.WriteLine($"Стол администрации:" +
                    $"\nВыбор команды:" +
                    $"\n{CommandFilterByName} - фильтрация пациентов по имени" +
                    $"\n{CommandFilterByAge} - фильтрация пациентов по возрасту" +
                    $"\n{CommandFilterByDisease} - фильтрация пациентов по болезни" +
                    $"\n{CommandExit} - выход");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandFilterByName:
                        database.SortByName(patients);
                        break;

                    case CommandFilterByAge:
                        database.SortByAge(patients);
                        break;

                    case CommandFilterByDisease:
                        database.SortByDisease(patients);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }

                Console.ReadKey();

            } while (isWorking);
        }
    }

    class Database
    {
        public void SortByDisease(List<Patient> peoples)
        {
            string disease;

            Console.WriteLine("Введите название болезни:");
            disease = Console.ReadLine();

            var filteredPeoples = from Patient patient in peoples
                                  where patient.Disease == disease
                                  select patient;

            ShowList(filteredPeoples.ToList());
        }

        public void SortByAge(List<Patient> peoples)
        {
            var filteredPeoples = from Patient patient in peoples
                                  orderby patient.Age
                                  select patient;

            ShowList(filteredPeoples.ToList());
        }

        public void SortByName(List<Patient> peoples)
        {
            var filteredPeoples = from Patient patient in peoples
                                  orderby patient.Name
                                  select patient;

            ShowList(filteredPeoples.ToList());
        }

        private void ShowList(List<Patient> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"Имя: {patient.Name}\tВозраст:{patient.Age} \tБолезнь: {patient.Disease}");
            }
        }
    }

    class Patient
    {
        public string Name { get; private set; }
        public string Disease { get; private set; }
        public int Age { get; private set; }

        public Patient(string name, string disease, int age)
        {
            Name = name;
            Disease = disease;
            Age = age;
        }
    }
}
