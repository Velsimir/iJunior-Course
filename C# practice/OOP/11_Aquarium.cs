﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int maxFish = 7;
            Aquarium aquarium = new Aquarium(maxFish);

            Aquarist aquarist = new Aquarist(aquarium);
            
            Console.CursorVisible = false;
            
            aquarist.CareAquarium();
        }
    }
    
    class Aquarist
    {
        private Aquarium _aquarium;

        public Aquarist(Aquarium aquarium)
        {
            _aquarium = aquarium;
        }

        public void CareAquarium()
        {
            const string CommandAdd = "1";
            const string CommandRemove = "2";
            const string CommandWait = "3";
            const string CommandExit = "4";
            
            bool isWorking = true;
            
            while (isWorking)
            {
                Console.Clear();
                _aquarium.ShowAllFish();

                Console.WriteLine($"Что вы хотите сделать?\n{CommandAdd} - Добавить" +
                                  $"\n{CommandRemove} - Убрать" +
                                  $"\n{CommandWait} - Подождать" +
                                  $"\n{CommandExit} - Выключить");

                switch (Console.ReadLine())
                {
                    case CommandAdd:
                        _aquarium.AddFish();
                        break;

                    case CommandRemove:
                        _aquarium.PullOutFish();
                        break;

                    case CommandWait:
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
                
                _aquarium.SpendDay();
            }
        }
    }
    
    class Aquarium
    {
        private List<Fish> _fishes;
        private int _maxFishIn = 7;
        private string _userInput;

        public Aquarium(int maxFishIn)
        {
            _maxFishIn = maxFishIn;
            _fishes = new List<Fish>();
        }

        public void ShowAllFish()
        {
            if (_fishes.Count > 0)
            {
                for (int i = 0; i < _fishes.Count(); i++)
                {
                    _fishes[i].ShowLifeStatus();
                }
            }
            else
            {
                Console.WriteLine("В аквариуме пока никого нет :)");
            }
        }

        public void AddFish()
        {
            if (_fishes.Count < _maxFishIn)
                _fishes.Add(new Fish(Render.GetRandomColor(), UserUtils.GetRandomLiveDays()));
            else
                Console.WriteLine("В аквариуме не осталось места!");
        }

        public void PullOutFish()
        {
            if (_fishes.Count > 0 && TryGetFish(out Fish fish))
            {
                DeleteFish(fish);
            }
            else
            {
                Console.WriteLine("Вы хотите убрать рыбку, которой нет в аквариуме...");
                Console.ReadKey();
            }
        }

        public void SpendDay()
        {
            foreach (var fish in _fishes)
            {
                fish.IncreaceAge();
            }
        }

        private void DeleteFish(Fish fish)
        {
            _fishes.Remove(fish);
        }

        private bool TryGetFish(out Fish findedFish)
        {
            string message = "Какую рыбку вы хотите выбрать? Необходимо ввести ее номер: ";
            int index = UserUtils.GetIndex(message);

            foreach (Fish fish in _fishes)
            {
                if (fish.Index == index)
                {
                    findedFish = fish;
                    return true;
                }
            }

            findedFish = null;
            return false;
        }
    }
    
    static class Render
    {
        private static string s_aliveFish = ">)))8>";
        private static string s_deadFish = ">)))X>";
        public static void DrowFish(ConsoleColor color, bool isFishDead)
        {
            Console.ForegroundColor = color;

            if (isFishDead)
                Console.Write(s_deadFish);
            else
                Console.Write(s_aliveFish);
                
            Console.ResetColor();
        }

        public static ConsoleColor GetRandomColor()
        {
            var colors = Enum.GetValues(typeof(ConsoleColor));
            ConsoleColor randomColor = (ConsoleColor)colors.GetValue(UserUtils.GetRandomNumber(colors.Length));
                
            return randomColor;
        }
    }
    
    class Fish
    {
        private static int s_globalIndex = 0;
            
        private int _maxAge;
        private int _currentAge = 0;
        private ConsoleColor _color;

        public Fish(ConsoleColor color, int maxAge)
        {
            Index = ++s_globalIndex;
            _maxAge = maxAge;
            _color = color;
        }
            
        private bool IsDead => _currentAge >= _maxAge;
            
        public int Index { get; private set; }

        public void IncreaceAge()
        {
            ++_currentAge;
        }
            
        public void ShowLifeStatus()
        {
            Console.Write($"{Index}) ");
            Render.DrowFish(_color, IsDead);
                
            if (IsDead)
                Console.WriteLine(" - мертва");
            else
                Console.WriteLine($" Она живет в аквариуме дней - {_currentAge}");
        }
    }
    
    public static class UserUtils
    {
        private const int MinValue = 0;

        private static Random _random = new Random();

        public static int GetRandomNumber(int max, int min = MinValue)
        {
            return _random.Next(min, max + 1);
        }

        public static int GetRandomLiveDays()
        {
            int minLivedDays = 5;
            int maxLivedDays = 15;

            return GetRandomNumber(maxLivedDays, minLivedDays);
        }
    
        public static int GetIndex(string message)
        {
            int index = 1;

            do
            {
                Console.Write(message);
            } while (int.TryParse(Console.ReadLine(), out index) == false);

            return index;
        }
    }
}