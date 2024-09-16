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

        class Player
        {
            public Player(string nickname, int level, int id)
            {
                Nickname = nickname;
                Level = level;
                Id = id;
                IsBlocked = false;
            }

            public string Nickname { get; private set; }
            public int Level { get; private set; }
            public bool IsBlocked { get; private set; }
            public int Id { get; private set; }

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
            private int _playerId = 1;

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
                        Player player = new Player(nickName, level, _playerId);

                        _players.Add(player);

                        _playerId++;

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
                GetPlayer().ChangeStatusBlock();
            }

            public void UnBlockPlayer()
            {
                GetPlayer().ChangeStatusUnBlock();
            }

            public void DeletePlayer()
            {
                _players.Remove(GetPlayer());
            }

            private Player GetPlayer()
            {
                bool isWorking = true;
                int id;
                string userInput;

                while (isWorking)
                {
                    ShowPlayers();

                    Console.WriteLine("\nВведите ID игрока");
                    userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out id))
                    {
                        if (id > 0 && id <= _playerId)
                        {
                            isWorking = false;
                            return _players[id];
                        }
                    }
                    else
                    {
                        WriteUnCorrectInput();
                    }
                    
                    Console.Clear();
                }

                return null;
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
