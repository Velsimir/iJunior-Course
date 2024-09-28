using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string CommandAdd = "1";
            const string CommandRemove = "2";
            const string CommandWait = "3";
            const string CommandExit = "4";
            const string AddInfo = "Добавить";
            const string RemoveInfo = "Убрать";
            const string WaitInfo = "Подождать";
            const string ExitInfo = "Выключить";

            string userInput;
            bool isWorking = true;
            Aquarium aquarium = new Aquarium();

            Console.CursorVisible = false;
            
            while (isWorking)
            {
                Console.Clear();
                aquarium.ShowAllFish();

                Console.WriteLine($"Что вы хотите сделать?\n{CommandAdd} - {AddInfo}" +
                                  $"\n{CommandRemove} - {RemoveInfo}" +
                                  $"\n{CommandWait} - {WaitInfo}" +
                                  $"\n{CommandExit} - {ExitInfo}");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAdd:
                        aquarium.AddFish();
                        break;

                    case CommandRemove:
                        aquarium.PullOutFish();
                        break;

                    case CommandWait:
                        aquarium.SpendDay();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
        
        class Aquarium
        {
            private List<Fish> _fishes;
            private int _maxFishIn = 7;
            private string _userInput;

            public Aquarium()
            {
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
                {
                    _fishes.Add(new Fish());
                }
                else
                {
                    Console.WriteLine("В аквариуме не осталось места!");
                }

                SpendDay();
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

                SpendDay();
            }

            public void SpendDay()
            {
                foreach (var fish in _fishes)
                {
                    fish.SpendDay();
                }
            }

            private void DeleteFish(Fish fish)
            {
                _fishes.Remove(fish);
            }

            private bool TryGetFish(out Fish findedFish)
            {
                int index = GetIndex();

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

            private int GetIndex()
            {
                int index = 1;

                do
                {
                    Console.Write("Какую рыбку вы хотите выбрать? Необходимо ввести ее номер: ");
                    _userInput = Console.ReadLine();
                } while (int.TryParse(_userInput, out index) == false);

                return index;
            }
        }
        
        class Fish
        {
            private static int s_globalIndex = 0;
            
            private int _daysToDie;
            private int _daysLived = 0;
            private ConsoleColor _color;
            private bool _isDead => _daysToDie <= 0;

            public Fish()
            {
                int minLivedDays = 5;
                int maxLivedDays = 15;
                
                Index = ++s_globalIndex;
                _daysToDie = UserUtils.GetRandomNumber(maxLivedDays, minLivedDays);
                _color = SetRandomColor();
            }
            
            public int Index { get; private set; }

            public void SpendDay()
            {
                ++_daysLived;
                _daysToDie--;
            }
            
            public void ShowLifeStatus()
            {
                Console.Write($"{Index}) ");
                DrowFish();
                
                if (_isDead)
                    Console.WriteLine(" - мертва");
                else
                {
                    Console.WriteLine($" Она живет в аквариуме дней - {_daysLived}");
                }

            }

            private void DrowFish()
            {
                Console.ForegroundColor = _color;

                if (_isDead)
                    Console.Write("><(((X>");
                else
                    Console.Write("><(((8>");

                Console.ResetColor();
            }

            private ConsoleColor SetRandomColor()
            {
                var colors = Enum.GetValues(typeof(ConsoleColor));
                ConsoleColor randomColor = (ConsoleColor)colors.GetValue(UserUtils.GetRandomNumber(colors.Length));
                
                return randomColor;
            }
        }
    }
}