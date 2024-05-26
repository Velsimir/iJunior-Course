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
            const string CommandSelectTopByLevel = "1";
            const string CommandSelectTopByPower = "2";
            const string CommandExit = "ex";

            bool isWorking = true;
            string userInput;
            List<Player> players = new List<Player>();
            Database database = new Database();

            players.Add(new Player("Sam", 20, 50));
            players.Add(new Player("Snake", 15, 43));
            players.Add(new Player("Velsimir", 7, 20));
            players.Add(new Player("Covack", 10, 23));
            players.Add(new Player("Impeller", 14, 28));
            players.Add(new Player("Furs", 25, 60));
            players.Add(new Player("Dash", 24, 68));
            players.Add(new Player("Light", 30, 112));
            players.Add(new Player("Beshanniy", 13, 43));
            players.Add(new Player("Yaichiro", 28, 53));
            players.Add(new Player("Parris", 24, 60));

            do
            {
                Console.Clear();

                Console.WriteLine($"{CommandSelectTopByLevel} - выбрать топ 3 игрока с самым высоким уровнем" +
                    $"\n{CommandSelectTopByPower} - выбрать топ 3 игрока с самым высоким показателем силы" +
                    $"\n{CommandExit} - выход");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSelectTopByLevel:
                        database.SelectionByLevel(players);
                        break;

                    case CommandSelectTopByPower:
                        database.SelectionByPower(players);
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
        public void SelectionByLevel(List<Player> players)
        {
            var selectedPlayers = players.OrderBy(player => player.Level).Take(3).ToList();

            ShowPlayers(selectedPlayers.Take(3).ToList());
        }

        public void SelectionByPower(List<Player> players)
        {
            var selectedPlayers = players.OrderBy(player => player.Power).Take(3).ToList();

            ShowPlayers(selectedPlayers.Take(3).ToList());
        }

        private void ShowPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Имя: {player.Name}\tУровень: {player.Level}\tСила: {player.Power}");
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Power { get; private set; }

        public Player(string name, int level, int power)
        {
            Name = name;
            Level = level;
            Power = power;
        }
    }
}
