using System;
using System.Collections.Generic;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string AddPlayerCommand = "Add";
            const string PrintPlayersCommand = "Show";
            const string BlockPlayerCommand = "Block";
            const string UnBlockPlayerCommand = "UnBlock";
            const string DeletePlayerCommand = "Delete";
            const string CloseProgrammCommand = "Close";

            bool isWorking = true;
            Database dataBase = new Database();

            while (isWorking)
            {
                string userInput;

                Console.Write($"Введите команду для продолжения" +
                    $"\n{AddPlayerCommand} - добавить игрока" +
                    $"\n{PrintPlayersCommand} - вывести всю базу" +
                    $"\n{BlockPlayerCommand} - забанить игрока" +
                    $"\n{UnBlockPlayerCommand} - разбанить игрока" +
                    $"\n{DeletePlayerCommand} - удалить игрока" +
                    $"\n{CloseProgrammCommand} - выход из программы" +
                    $"\nВвод пользователя: ");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddPlayerCommand:
                        dataBase.AddPlayer();
                        break;

                    case PrintPlayersCommand:
                        dataBase.ShowPlayers();

                        Console.ReadKey();
                        break;

                    case BlockPlayerCommand:
                        dataBase.BlockPlayer();
                        break;

                    case UnBlockPlayerCommand:
                        dataBase.UnBlockPlayer();
                        break;

                    case DeletePlayerCommand:
                        dataBase.DeletePlayer();
                        break;

                    case CloseProgrammCommand:
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
            IsBlocked = false;
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

                    if (int.TryParse(userInput, out level))
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
                string userInput;

                while (result)
                {
                    ShowPlayers();

                    Console.WriteLine("\nВведите ID игрока");
                    userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out id))
                    {
                        if (id > 0 && id <= _playerID)
                            result = false;
                        else
                            WriteUnCorrectInput();
                    }
                    else
                        WriteUnCorrectInput();
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
        }
    }
}
