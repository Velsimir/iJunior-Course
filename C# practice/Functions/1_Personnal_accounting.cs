using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const int CommandAddPerosn = 1;
            const int CommandPrintAllPerosn = 2;
            const int CommandDeletePerosn = 3;
            const int CommandFindPerosn = 4;
            const int CommandExit = 5;
            
            string[] arrayPersonalFullName = new string[0];
            string[] arrayPersonalVacancy = new string[0];
            
            int userCommand;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();

                Console.Write($"1) добавить досье\n" +
                              $"2) вывести все досье \n" +
                              $"3) удалить досье последнее внесенное досье\n" +
                              $"4) поиск по фамилии и имени \n" +
                              $"5) выход\n\n" +
                              $"Ввод пользователя: ");


                if (TryConvertInput(GetUserInput(), out userCommand) == false)
                {
                    WriteErrorMessage();
                    
                    continue;
                }
                
                Console.Clear();

                switch (userCommand)
                {
                    case CommandAddPerosn:
                        AddPerson(ref arrayPersonalFullName, ref arrayPersonalVacancy);
                        break;

                    case CommandPrintAllPerosn:
                        PrintAllPerson(arrayPersonalFullName, arrayPersonalVacancy);
                        break;

                    case CommandDeletePerosn:
                        DeletePerson(ref arrayPersonalFullName, ref arrayPersonalVacancy);
                        break;

                    case CommandFindPerosn:
                        FindPerson(arrayPersonalFullName, arrayPersonalVacancy);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                    
                    default:
                        WriteErrorMessage();
                        break;
                }
                
                WriteContinueMessage();
            }
        }
        
        static string GetUserInput()
        {
            string userInput;

            userInput = Console.ReadLine();

            return userInput;
        }

        static void WriteErrorMessage()
        {
            Console.WriteLine("Введена неверная команда, нажмите клавишу для продолжения...");
            Console.ReadKey();
        }
        
        static void WriteContinueMessage()
        {
            Console.WriteLine("Нажмите клавишу для продолжения...");
            Console.ReadKey();
        }

        static bool TryConvertInput(string userInput, out int correctInput)
        {
            if (Int32.TryParse(userInput, out correctInput))
                return true;
            else
                return false;
        }

        static void AddPerson(ref string[] arrayFullName, ref string[] arrayVacancy)
        {
            arrayFullName = IncreaceArray(arrayFullName);
            arrayVacancy = IncreaceArray(arrayVacancy);
            
            Console.WriteLine("Введите имя сотрудника");
            AddDataToArray(arrayFullName, GetUserInput());
            
            Console.WriteLine("Введите вакансию сотрудника");
            AddDataToArray(arrayVacancy, GetUserInput());
        }
        
        static string[] IncreaceArray(string[] array)
        {
            string[] tempArray = new string[array.Length + 1];
            
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            array = tempArray;
            
            return array;
        }
        
        static void AddDataToArray(string[] array, string data)
        {
            array[array.Length - 1] = data;
        }

        static void DeletePerson(ref string[] arrayFullName, ref string[] arrayVacancy)
        {
            int personIndex;
            
            PrintAllPerson(arrayFullName, arrayVacancy);
            
            Console.WriteLine($"\nВведите номер пользователя, чтобы удалить его из базы: ");

            if (TryConvertInput(GetUserInput(), out personIndex));
            {
                arrayFullName = RemoveDataByIndex(arrayFullName, personIndex);
                arrayVacancy = RemoveDataByIndex(arrayVacancy, personIndex);
            }
        }

        static string[] RemoveDataByIndex(string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];
            int tempIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i < index - 1)
                {
                    tempArray[tempIndex] = array[i];
                    tempIndex++;
                }
                else if (i > index - 1)
                {
                    tempArray[tempIndex] = array[i];
                    tempIndex++;
                }
            }

            array = tempArray;

            return array;
        }

        static void PrintAllPerson(string[] arrayFullName, string[] arrayVacancy)
        {
            Console.WriteLine($"ФИО \t\t\t Должность");
            
            for (int i = 0; i < arrayFullName.Length; i++)
            {
                PrintData(i+1, GetDataByIndex(arrayFullName, i), GetDataByIndex(arrayVacancy, i));
            }
        }

        static void PrintData(int index, string fullName, string vacancy)
        {
            Console.WriteLine($"{index}) {fullName} \t\t {vacancy}");
        }

        static void FindPerson(string[] arrayFullName, string[] arrayVacancy)
        {
            Console.Write("Введите Фамилию человека: ");

            string userInputSurname = GetUserInput();
            
            for (int i = 0; i < arrayFullName.Length; i++)
            {
                string[] tempSurnameArray = arrayFullName[i].Split(' ');

                for (int j = 0; j < tempSurnameArray.Length; j++)
                {
                    if (userInputSurname == tempSurnameArray[j])
                        PrintData(i+1, arrayFullName[i], arrayVacancy[i]);
                }
            }
        }

        static string GetDataByIndex(string [] array, int index)
        {
            return array[index];
        }
    }
}
