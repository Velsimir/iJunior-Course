using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace iJunior
{
    /*Реализовать базу данных игроков и методы для работы с ней.
     * У игрока может быть уникальный номер, ник, уровень, флаг – забанен ли он(флаг - bool).
     * Реализовать возможность добавления игрока, бана игрока по уникальный номеру, 
     * разбана игрока по уникальный номеру и удаление игрока.
     * Создание самой БД не требуется, задание выполняется инструментами, 
     * которые вы уже изучили в рамках курса. Но нужен класс, 
     * который содержит игроков и её можно назвать "База данных".
     */
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddPlayer = "Add";
            const string PrintPlayers = "Show";
            const string BlockPlayer = "Block";
            const string UnBlockPlayer = "UnBlock";
            const string DeletePlayer = "Delete";
            const string CloseProgramm = "Close";

            bool isWorking = true;
            Database dataBase = new Database();

            while (isWorking)
            {
                string userInput;

                Console.Write($"Введите команду для продолжения" +
                    $"\n{AddPlayer} - добавить игрока" +
                    $"\n{PrintPlayers} - вывести всю базу" +
                    $"\n{BlockPlayer} - забанить игрока" +
                    $"\n{UnBlockPlayer} - разбанить игрока" +
                    $"\n{DeletePlayer} - удалить игрока" +
                    $"\n{CloseProgramm} - выход из программы" +
                    $"\nВвод пользователя: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddPlayer:
                        dataBase.AddPlayer();
                        break;

                    case PrintPlayers:
                        dataBase.ShowPlayers();

                        Console.ReadKey();
                        break;

                    case BlockPlayer:
                        dataBase.BlockPlayer();
                        break;

                    case UnBlockPlayer:
                        dataBase.UnBlockPlayer();
                        break;

                    case DeletePlayer:
                        dataBase.DeletePlayer();
                        break;

                    case CloseProgramm:
                        isWorking = false;
                        break;

                    default:

                        Console.Clear();

                        Console.WriteLine("Некорректный ввод");

                        Console.ReadKey();

                        break;
                }

                Console.Clear();
            }
        }
    }

    class Player
    {
        public string Nickname { get; private set; }
        public int Level { get; private set; }
        public bool IsBlocked { get; private set; }
        public int Id { get; private set; }

        public Player(string nickname, int level, int id)
        {
            Nickname = nickname;
            Level = level;
            Id = id;
        }

        public void ChangeStatusBlock()
        {
            IsBlocked = true;
        }

        public void ChangeStatusUnBlock()
        {
            IsBlocked = false;
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        private int _playerID = 1;

        public void AddPlayer()
        {
            string nickName;
            string userInput;
            int level;
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();

                Console.Write("Введите Nick Name игрока: ");
                nickName = Console.ReadLine();

                Console.Write("Введите уровень игрока: ");
                userInput = Console.ReadLine();

                if (ReadNumber(userInput, out level))
                {
                    Player player = new Player(nickName, level, _playerID);

                    _players.Add(player);

                    _playerID++;

                    isWorking = false;
                }
                else
                {
                    WriteUnCorrectInput();
                }
            }
        }

        public void ShowPlayers()
        {
            Console.Clear();

            foreach (var player in _players)
            {
                string blockStatus;

                if (player.IsBlocked == false)
                {
                    blockStatus = "Разблокирован(а)";
                }
                else
                {
                    blockStatus = "Заблокирован(а)";
                }

                Console.WriteLine($"ID игрока - {player.Id}\tNickname игрока - {player.Nickname}" +
                    $"\tLevel игрока - {player.Level}\tСтатус игрока - {blockStatus}");
            }
        }

        public void BlockPlayer()
        {
            Player player;

            TryGetPlayer(out player);

            player.ChangeStatusBlock();
        }

        public void UnBlockPlayer()
        {
            Player player;

            TryGetPlayer(out player);

            player.ChangeStatusUnBlock();
        }

        public void DeletePlayer()
        {
            Player player;

            TryGetPlayer(out player);

            _players.Remove(player);
        }

        private bool TryGetPlayer(out Player playerData)
        {
            bool result = true;
            int id = 1;

            while (result)
            {
                string userInput;

                ShowPlayers();

                Console.WriteLine("\nВведите ID игрока");
                userInput = Console.ReadLine();

                if (ReadNumber(userInput, out int idInt))
                {

                    if (idInt > 0 && idInt <= _playerID)
                    {
                        id = idInt;
                        result = false;
                    }
                    else
                    {
                        WriteUnCorrectInput();
                    }
                }
                else
                {
                    WriteUnCorrectInput();
                }
            }

            if (_playerID >= id)
            {

                foreach (var player in _players)
                {

                    if (player.Id == id)
                    {
                        playerData = player;
                        return true;
                    }
                }
            }
            else
            {
                WriteUnCorrectInput();
            }

            playerData = null;
            return false;
        }

        private void WriteUnCorrectInput()
        {
            Console.WriteLine("Некорректный ввод" +
                        "\nНажмите любую клавишу, чтобы повторить...");
            Console.ReadKey();
            Console.Clear();
        }

        private bool ReadNumber(string userInput, out int number)
        {
            if (int.TryParse(userInput, out number))
            {
                return true;
            }

            return false;
        }
    }
}
