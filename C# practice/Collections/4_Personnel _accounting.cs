using System;
using System.Collections.Generic;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*В функциях вы выполняли задание "Кадровый учёт"
         * Используя одну из изученных коллекций, вы смогли бы сильно себе упростить код выполненной программы, 
         * ведь у нас данные, это ФИО и позиция.
         * Поиск в данном задании не нужен.
         * 1) добавить досье
         * 2) вывести все досье (в одну строку через “-” фио и должность)
         * 3) удалить досье
         * 4) выход
         */
        public static void Main(string[] args)
        {
            const string AddEmploye = "Add";
            const string PrintEmploye = "Print";
            const string DeleteEmploye = "Delete";
            const string CloseProgramm = "Close";
            Dictionary<string, string> listOfEmployers = new Dictionary<string, string>();
            bool isWorking = true;
            string userInput;

            while (isWorking)
            {
                Console.Write($"Введите команду для продолжения" +
                    $"\n{AddEmploye} - добавить досье" +
                    $"\n{PrintEmploye} - вывести все досье (в одну строку через “-” фио и должность)" +
                    $"\n{DeleteEmploye} - удалить досье" +
                    $"\n{CloseProgramm} - выход из программы" +
                    $"\nВвод пользователя: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddEmploye:
                        AddNewEmploye(listOfEmployers);
                        break;

                    case PrintEmploye:
                        WriteAllEmploye(listOfEmployers);

                        Console.ReadKey();
                        break;

                    case DeleteEmploye:
                        MainClass.DeleteEmploye(listOfEmployers);

                        Console.ReadKey();
                        break;

                    case CloseProgramm:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Не корректный ввод");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }

        static void AddNewEmploye(Dictionary<string, string> listOfEmployers)
        {
            string nameEmploye;
            string vacancy;

            Console.Write("Введите Фамилию Имя сотрудника: ");
            nameEmploye = Console.ReadLine();

            Console.Write("Введите должность сотрудника: ");
            vacancy = Console.ReadLine();

            if (listOfEmployers.ContainsKey(nameEmploye))
            {
                Console.WriteLine("Данный пользователь есть в базе");
                Console.ReadKey();
            }
            else
            {
                listOfEmployers.Add(nameEmploye, vacancy);
            }
        }

        static void WriteAllEmploye(Dictionary<string, string> listOfEmployers)
        {
            foreach (var person in listOfEmployers)
            {
                Console.Write($"-{person.Key}({person.Value})");
            }
        }

        static void DeleteEmploye(Dictionary<string, string> listOfEmployers)
        {
            string nameEmploye;

            WriteAllEmploye(listOfEmployers);

            Console.WriteLine("\nВведите фамилию имя сотрудника, чье досье хотите удалить: ");
            nameEmploye = Console.ReadLine();

            if (listOfEmployers.ContainsKey(nameEmploye))
            {
                listOfEmployers.Remove(nameEmploye);
            }
            else
            {
                Console.WriteLine("Пользователя с указанными вами данными - не существует.");
            }
        }
    }
}
