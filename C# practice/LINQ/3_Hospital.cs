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
            Hospital hospital = new Hospital();

            hospital.Work();
        }
    }

    class Hospital
    {
        private const string CommandFilterByName = "1";
        private const string CommandFilterByAge = "2";
        private const string CommandFilterByDisease = "3";
        private const string CommandExit = "ex";

        private Database _database;

        public Hospital()
        {
            _database = new Database();
        }

        public void Work()
        {
            string userInput;

            bool isWorking = true;

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
                        _database.SortByName();
                        break;

                    case CommandFilterByAge:
                        _database.SortByAge();
                        break;

                    case CommandFilterByDisease:
                        _database.SortByDisease();
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
        private List<Patient> _patients;

        public Database()
        {
            _patients = new List<Patient>();

            Fill();
        }

        public void SortByDisease()
        {
            string disease;

            Console.WriteLine("Введите название болезни:");
            disease = Console.ReadLine();

            var filteredPeoples = from Patient patient in _patients
                                  where patient.Disease == disease
                                  select patient;

            ShowList(filteredPeoples.ToList());
        }

        public void SortByAge()
        {
            var filteredPeoples = from Patient patient in _patients
                                  orderby patient.Age
                                  select patient;

            ShowList(filteredPeoples.ToList());
        }

        public void SortByName()
        {
            var filteredPeoples = from Patient patient in _patients
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

        private void Fill()
        {
            _patients.Add(new Patient("Ваня", "Кашель", 32));
            _patients.Add(new Patient("Андрей", "Кашель", 16));
            _patients.Add(new Patient("Ольга", "Насморк", 48));
            _patients.Add(new Patient("Наталья", "Головная боль", 56));
            _patients.Add(new Patient("Семен", "Насморк", 43));
            _patients.Add(new Patient("Дарья", "Кашель", 34));
            _patients.Add(new Patient("Яков", "Мигрень", 23));
            _patients.Add(new Patient("Дмитрий", "Гастрит", 25));
            _patients.Add(new Patient("Татьяна", "Мигрень", 49));
            _patients.Add(new Patient("Артур", "Гастрит", 20));
        }
    }

    class Patient
    {
        public Patient(string name, string disease, int age)
        {
            Name = name;
            Disease = disease;
            Age = age;
        }

        public string Name { get; private set; }
        public string Disease { get; private set; }
        public int Age { get; private set; }
    }
}
