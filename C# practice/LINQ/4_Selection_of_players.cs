using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Filter filter = new Filter();

            filter.Work();
        }
    }

    class Filter
    {
        private const string CommandSelectTopByLevel = "1";
        private const string CommandSelectTopByPower = "2";
        private const string CommandExit = "ex";
        private const int TopPlayersCount = 3;

        private Database _database;

        public Filter()
        {
            _database = new Database();
        }

        public void Work()
        {
            bool isWorking = true;
            string userInput;

            do
            {
                Console.Clear();

                Console.WriteLine($"{CommandSelectTopByLevel} - выбрать топ {TopPlayersCount} игрока с самым высоким уровнем" +
                    $"\n{CommandSelectTopByPower} - выбрать топ {TopPlayersCount} игрока с самым высоким показателем силы" +
                    $"\n{CommandExit} - выход");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSelectTopByLevel:
                        _database.SelectByLevel(TopPlayersCount);
                        break;

                    case CommandSelectTopByPower:
                        _database.SelectByPower(TopPlayersCount);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }

                Console.ReadKey();

            } while (isWorking);
        }
    }

    class Database
    {
        private List<Player> _players;

        public Database()
        {
            _players = new List<Player>();

            Fill();
        }

        public void SelectByLevel(int index)
        {
            var selectedPlayers = _players.OrderBy(player => player.Level).Take(index).ToList();

            ShowPlayers(selectedPlayers.ToList());
        }

        public void SelectByPower(int index)
        {
            var selectedPlayers = _players.OrderBy(player => player.Power).Take(index).ToList();

            ShowPlayers(selectedPlayers.ToList());
        }

        private void ShowPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Имя: {player.Name}\tУровень: {player.Level}\tСила: {player.Power}");
            }
        }

        private void Fill()
        {
            _players.Add(new Player("Sam", 20, 50));
            _players.Add(new Player("Snake", 15, 43));
            _players.Add(new Player("Velsimir", 7, 20));
            _players.Add(new Player("Covack", 10, 23));
            _players.Add(new Player("Impeller", 14, 28));
            _players.Add(new Player("Furs", 25, 60));
            _players.Add(new Player("Dash", 24, 68));
            _players.Add(new Player("Light", 30, 112));
            _players.Add(new Player("Beshanniy", 13, 43));
            _players.Add(new Player("Yaichiro", 28, 53));
            _players.Add(new Player("Parris", 24, 60));
        }
    }

    class Player
    {
        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }
    }
}
