using System;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string userName;
            string userZodiacSign;
            int userAge;
            int userInput = 1;
            int currentYear = 2022;
            bool IsWorking = true;

            Console.Write("Привет пользователь! \nКак тебя зовут? - ");
            userName = Console.ReadLine();

            Console.Clear();

            Console.Write($"Отлично, {userName} \nА сколько тебе лет? - ");
            userAge = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            Console.Write($"И последний вопрос {userName} \nКто ты по гороскопу? - ");
            userZodiacSign = Console.ReadLine();

            Console.Clear();

            while (IsWorking)
            {
                Console.WriteLine("Что ты хочешь узнать?" +
                "\n Свой гороскоп на завтра - 1" +
                "\n Свой психологический возраст - 2" +
                "\n В каком году вы родились? - 3" +
                "\n Узнать смысл жизни - 4" +
                "\n Выход из приложения - 0");

                userInput = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (userInput)
                {
                    case 1:

                        Console.WriteLine($"Не так важно, кто ты по гороскопу. Важно, что завтра день будет отличный!" +
                            $"\n Ну развае что у тех чей знак задиака - {userZodiacSign}. У них может пойти что-то не так..." +
                            $"\n Нажмите Enter, чтобы продолжить");

                        Console.ReadLine();

                        Console.Clear();
                        break;

                    case 2:

                        Console.WriteLine($"Будь уверен тебе {userAge}, и что это не изменит " +
                            $"\nНажмите Enter, чтобы продолжить");

                        Console.ReadLine();

                        Console.Clear();
                        break;

                    case 3:

                        Console.WriteLine($"Серьезно? Не думал, что у тебя есть сложности с этим... \n {currentYear - userAge}" +
                            $"\nНажмите Enter, чтобы продолжить");

                        Console.ReadLine();

                        Console.Clear();
                        break;

                    case 4:

                        Console.WriteLine("We're no strangers to love" +
                            "\nYou know the rules and so do I" +
                            "\nA full commitment's what I'm thinking of" +
                            "\nYou wouldn't get this from any other guy" +
                            "\n[Pre-Chorus]" +
                            "\nI just wanna tell you how I'm feeling" +
                            "\nGotta make you understand" +
                            "\n\nNever gonna give you up" +
                            "\nNever gonna let you down" +
                            "\nNever gonna run around and desert you" +
                            "\nNever gonna make you cry" +
                            "\nNever gonna say goodbye" +
                            "\nNever gonna tell a lie and hurt you");

                        Console.WriteLine("Мы оба знали, что так и будет..." +
                            "\nНажмите Enter, чтобы продолжить");

                        Console.ReadLine();

                        Console.Clear();
                        break;
                    case 0:
                        IsWorking = false;
                        break;
                }
            }

        }
    }
}
