using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string CommandAddPerosn = "1";
            const string CommandPrintAllPerosn = "2";
            const string CommandDeletePerosn = "3";
            const string CommandFindPerosn = "4";
            const string CommandExit = "5";
            string[] arrayPersonalData = new string[0];
            string[] arraySpecialistPosition = new string[0];
            string userInput;
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

                userInput = Console.ReadLine();

                Console.Clear();

                switch (userInput)
                {
                    case CommandAddPerosn:
                        AddPerson(ref arrayPersonalData, ref arraySpecialistPosition);
                        break;

                    case CommandPrintAllPerosn:
                        PrintAllPerson(arrayPersonalData, arraySpecialistPosition);
                        break;

                    case CommandDeletePerosn:
                        DeletePerson(ref arrayPersonalData, ref arraySpecialistPosition);
                        break;

                    case CommandFindPerosn:
                        FindPerson(userInput, arrayPersonalData, arraySpecialistPosition);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
        }

                static void EnlargeArray(ref string[] magnifedArray)
            {
                string[] magnifedTempArry = new string[magnifedArray.Length + 1];

                for (int i = 0; i < magnifedArray.Length; i++)
                {
                    magnifedTempArry[i] = magnifedArray[i];
                }

                magnifedArray = magnifedTempArry;
            }

            static void DeletePerson(ref string[] arraySpecialistPosition, ref string[] arrayPersonalData)
            {
                DeletePerson(ref arraySpecialistPosition);
                DeletePerson(ref arrayPersonalData);
            }

            static void AddUserInput(ref string[] magnifedArray, string userInput)
            {
                magnifedArray[magnifedArray.Length - 1] = userInput;
            }

            static void AddPerson(ref string[] arrayPersonalData, ref string[] arraySpecialistPosition)
            {
                EnlargeArray(ref arrayPersonalData);
                EnlargeArray(ref arraySpecialistPosition);

                Console.WriteLine("Введите Фамилию и Имя человека: ");
                string userInputFirstSecondName = Console.ReadLine();

                AddUserInput(ref arrayPersonalData, userInputFirstSecondName);

                Console.WriteLine("Введите должность: ");
                string userInputSpecialiation = Console.ReadLine();

                AddUserInput(ref arraySpecialistPosition, userInputSpecialiation);
            }

            static void DeletePerson(ref string[] redusedArray)
            {
                if (redusedArray.Length > 1)
                {
                    string[] arrayTempReduceArray = new string[redusedArray.Length - 1];

                    for (int i = 0; i < arrayTempReduceArray.Length; i++)
                    {
                        arrayTempReduceArray[i] = redusedArray[i];
                    }

                    redusedArray = arrayTempReduceArray;
                }
                else
                {
                    Console.WriteLine("В базе данных нет досье");
                }
            }

            static void FindPerson(string userChoose, string[] arrayPersonalData, string[] arraySpecialistPosition)
            {
                Console.Write("Введите Фамилию Имя человека: ");
                userChoose = Console.ReadLine();
                bool isPersonFind = false;

                for (int i = 0; i < arrayPersonalData.Length; i++)
                {
                    string[] surname = arrayPersonalData[i].Split(' ');

                    for (int j = 0; j < surname.Length; j++)
                    {
                        if (userChoose == surname[j])
                        {
                            Console.WriteLine(
                                $"Досье {arrayPersonalData[i]}(а/ой) на должости ({arraySpecialistPosition[i]}) находится под номером - {i + 1}");
                            isPersonFind = true;
                        }
                    }
                }

                if (isPersonFind == false)
                {
                    Console.WriteLine("Пользователь не найден");
                }

                Console.ReadKey();
            }

            static void PrintAllPerson(string[] arrayPersonalData, string[] arraySpecialistPosition)
            {
                for (int i = 0; i < arrayPersonalData.Length; i++)
                {
                    Console.Write($" - {i + 1}). {arrayPersonalData[i]}({arraySpecialistPosition[i]})");
                }

                Console.ReadKey();
                Console.Clear();
            }
    }
}
