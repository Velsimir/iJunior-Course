using System;

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
            
            string[] stuffPersonalFullName = new string[0];
            string[] staffPersonalVacancy = new string[0];
            
            int userCommand;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();

                Console.Write($"{CommandAddPerosn}) добавить досье\n" +
                              $"{CommandPrintAllPerosn}) вывести все досье \n" +
                              $"{CommandDeletePerosn}) удалить досье последнее внесенное досье\n" +
                              $"{CommandFindPerosn}) поиск по фамилии и имени \n" +
                              $"{CommandExit}) выход\n\n" +
                              $"Ввод пользователя: ");


                if (Int32.TryParse(Console.ReadLine(), out userCommand) == false)
                {
                    WriteErrorMessage();
                    
                    continue;
                }
                
                Console.Clear();

                switch (userCommand)
                {
                    case CommandAddPerosn:
                        AddPerson(ref stuffPersonalFullName, ref staffPersonalVacancy);
                        break;

                    case CommandPrintAllPerosn:
                        PrintAllPerson(stuffPersonalFullName, staffPersonalVacancy);
                        break;

                    case CommandDeletePerosn:
                        DeletePerson(ref stuffPersonalFullName, ref staffPersonalVacancy);
                        break;

                    case CommandFindPerosn:
                        FindPerson(stuffPersonalFullName, staffPersonalVacancy);
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

        static void AddPerson(ref string[] arrayFullName, ref string[] arrayVacancy)
        {
            Console.WriteLine("Введите имя сотрудника");
            arrayFullName = IncreaceArray(arrayFullName, Console.ReadLine());
            
            Console.WriteLine("Введите вакансию сотрудника");
            arrayVacancy = IncreaceArray(arrayVacancy, Console.ReadLine());
        }
        
        static string[] IncreaceArray(string[] array, string data)
        {
            string[] tempArray = new string[array.Length + 1];
            
            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            tempArray[tempArray.Length - 1] = data;
            
            return tempArray;
        }

        static void DeletePerson(ref string[] arrayFullName, ref string[] arrayVacancy)
        {
            int personIndex;
            int maxInedex = arrayFullName.Length;
            
            PrintAllPerson(arrayFullName, arrayVacancy);
            
            Console.WriteLine($"\nВведите номер пользователя, чтобы удалить его из базы: ");

            if (Int32.TryParse(Console.ReadLine(), out personIndex))
            {
                personIndex = personIndex - 1;

                if (personIndex >= 0 && personIndex < maxInedex)
                {
                    arrayFullName = RemoveDataByIndex(arrayFullName, personIndex);
                    arrayVacancy = RemoveDataByIndex(arrayVacancy, personIndex);   
                }
                else
                {
                    WriteErrorMessage();
                }
            }
            else
            {
                WriteErrorMessage();
            }
        }

        static string[] RemoveDataByIndex(string[] array, int index)
        {
            string[] tempArray = new string[array.Length - 1];
            int tempIndex = 0;

            for (int i = 0; i < index; i++)
            {
                tempArray[tempIndex] = array[i];
                tempIndex++;
            }

            index++;
            
            for (int i = index; i < array.Length; i++)
            {
                tempArray[tempIndex] = array[i];
                tempIndex++;
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
            bool isFound = false;
            
            Console.Write("Введите Фамилию человека: ");

            string userInputSurname = Console.ReadLine();
            
            for (int i = 0; i < arrayFullName.Length; i++)
            {
                string[] tempSurnameArray = arrayFullName[i].Split();

                for (int j = 0; j < tempSurnameArray.Length; j++)
                {
                    if (userInputSurname == tempSurnameArray[j])
                    {
                        PrintData(i+1, arrayFullName[i], arrayVacancy[i]);
                        isFound = true;
                    }

                }
            }

            if (isFound == false)
            {
                Console.WriteLine("Сотрудников с данной фамилией не найдено");
            }
        }

        static string GetDataByIndex(string [] array, int index)
        {
            return array[index];
        }
    }
}
