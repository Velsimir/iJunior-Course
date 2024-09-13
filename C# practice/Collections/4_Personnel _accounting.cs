using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
                        const string AddCommand = "Add";
            const string PrintCommand = "Print";
            const string DeleteCommand = "Delete";
            const string CloseCommand = "Close";

            Dictionary<string, List<string>> listOfEmployers = new Dictionary<string, List<string>>();
            bool isWorking = true;
            string userInput;

            listOfEmployers.Add("Разработчик", new List<string>());
            listOfEmployers.Add("Художник", new List<string>());
            listOfEmployers.Add("Тестировщик", new List<string>());

            listOfEmployers["Разработчик"].Add("Коняшов Иван");
            listOfEmployers["Разработчик"].Add("Паттисон Роберт");
            listOfEmployers["Разработчик"].Add("Ленин Владимир");

            listOfEmployers["Художник"].Add("Клод Моне");
            listOfEmployers["Художник"].Add("Сальвадор Дали");
            listOfEmployers["Художник"].Add("Айвазовский Иван");

            listOfEmployers["Тестировщик"].Add("Герцен Яков");
            listOfEmployers["Тестировщик"].Add("Гальперов Василий");

            while (isWorking)
            {
                Console.Write($"Введите команду для продолжения" +
                              $"\n{AddCommand} - добавить досье" +
                              $"\n{PrintCommand} - вывести все досье (в одну строку через “-” фио и должность)" +
                              $"\n{DeleteCommand} - удалить досье" +
                              $"\n{CloseCommand} - выход из программы" +
                              $"\nВвод пользователя: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddCommand:
                        AddNewEmploye(listOfEmployers);
                        break;

                    case PrintCommand:
                        WriteAllEmploye(listOfEmployers);
                        break;

                    case DeleteCommand:
                        DeleteEmploye(listOfEmployers);
                        break;

                    case CloseCommand:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Не корректный ввод");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddNewEmploye(Dictionary<string, List<string>> listOfEmployers)
        {
            string nameEmploye;
            string vacancy;

            GetEmployeInfo(out nameEmploye, out vacancy);

            if (listOfEmployers.ContainsKey(vacancy) && TryFindEmploye(listOfEmployers, nameEmploye, vacancy))
            {
                Console.WriteLine("Пользователь есть в базе");
            }
            else if (listOfEmployers.ContainsKey(vacancy) && TryFindEmploye(listOfEmployers, nameEmploye, vacancy) == false)
            {
                listOfEmployers[vacancy].Add(nameEmploye);
                Console.WriteLine("Пользователь добавлен в базу");
            }
            else
            {
                listOfEmployers.Add(vacancy, new List<string>());
                listOfEmployers[vacancy].Add(nameEmploye);
                Console.WriteLine("Пользователь добавлен в базу");
            }
        }

        static void WriteAllEmploye(Dictionary<string, List<string>> listOfEmployers)
        {
            Console.Clear();
            
            foreach (var vacancy in listOfEmployers)
            {
                Console.WriteLine($"Список специалистов на позиции {vacancy.Key}");

                foreach (var employe in vacancy.Value)
                {
                    Console.WriteLine(employe);
                }
                
                Console.WriteLine();
            }
        }

        static void DeleteEmploye(Dictionary<string, List<string>> listOfEmployers)
        {
            string nameEmploye;
            string vacancy;

            GetEmployeInfo(out nameEmploye, out vacancy);

            if (TryFindEmploye(listOfEmployers, nameEmploye, vacancy))
            {
                listOfEmployers[vacancy].Remove(nameEmploye);
                
                DeleteEmptyVacancy(listOfEmployers, vacancy);
                
                Console.WriteLine("Пользователь удален");
            }
            else
            {
                Console.WriteLine("Пользователь не найден");
            }
        }

        static bool TryFindEmploye(Dictionary<string, List<string>> employersData, string desiredEmployee, string vacancy)
        {
            foreach (var employe in employersData[vacancy])
            {
                if (employe == desiredEmployee)
                    return true;
            }

            return false;
        }
        
        static void GetEmployeInfo(out string nameEmploye, out string vacancy)
        {
            Console.Write("Введите Фамилию Имя сотрудника: ");
            nameEmploye = Console.ReadLine();

            Console.Write("Введите должность сотрудника: ");
            vacancy = Console.ReadLine();
        }

        static void DeleteEmptyVacancy(Dictionary<string, List<string>> employersData, string vacancy)
        {
            if (employersData[vacancy].Count <= 0)
                employersData.Remove(vacancy);
        }
    }
}
