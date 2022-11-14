using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        /*Будет 2 массива: 1) фио 2) должность.
         * Описать функцию заполнения массивов досье, функцию форматированного вывода, 
         * функцию поиска по фамилии и функцию удаления досье.
         * Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение.
         * 
         * Программа должна быть с меню, которое содержит пункты:
         * 1) добавить досье
         * 2) вывести все досье (в одну строку через “-” фио и должность с порядковым номером в начале)
         * 3) удалить досье (Массивы уменьшаются на один элемент. Нужны дополнительные проверки, чтобы не возникало ошибок)
         * 4) поиск по фамилии
         * 5) выход
         */
        public static void Main(string[] args)
        {
            string[] arrayPersonalData = new string[0];
            string[] arraySpecialistPosition = new string[0];
            string userChose;
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

                userChose = Console.ReadLine();

                Console.Clear();

                switch (userChose)
                {
                    case "1":
                        AddDosier(ref arrayPersonalData, ref arraySpecialistPosition);
                        break;

                    case "2":
                        PrintAllDossier(arrayPersonalData, arraySpecialistPosition);
                        break;

                    case "3":
                        DeleteDosier(ref arrayPersonalData, ref arraySpecialistPosition);
                        break;

                    case "4":
                        FindPerson(userChose, arrayPersonalData, arraySpecialistPosition);
                        break;

                    case "5":
                        isWorking = false;
                        break;
                }
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

        static void DeleteDosier(ref string[] arraySpecialistPosition, ref string[] arrayPersonalData)
        {
            DeletePerson(ref arraySpecialistPosition);
            DeletePerson(ref arrayPersonalData);
        }

        static void AddUserInput(ref string[] magnifedArray, string userInput)
        {
            magnifedArray[magnifedArray.Length - 1] = userInput;
        }

        static void AddDosier(ref string[] arrayPersonalData, ref string[] arraySpecialistPosition)
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

        static void FindPerson(string userChose, string[] arrayPersonalData, string[] arraySpecialistPosition)
        {
            Console.Write("Введите Фамилию Имя человека: ");
            userChose = Console.ReadLine();
            bool isPersonFind = false;

            for (int i = 0; i < arrayPersonalData.Length; i++)
            {
                string[] surname = arrayPersonalData[i].Split(' ');

                for (int j = 0; j < surname.Length; j++)
                {
                    if (userChose == surname[j])
                    {
                        Console.WriteLine($"Досье {arrayPersonalData[i]}(а/ой) на должости ({arraySpecialistPosition[i]}) находится под номером - {i + 1}");
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

        static void PrintAllDossier(string[] arrayPersonalData, string[] arraySpecialistPosition)
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