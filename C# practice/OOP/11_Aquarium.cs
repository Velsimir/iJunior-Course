using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime;
using Internal;

namespace iJunior
{
    class MainClass
    {
        /*Есть аквариум, в котором плавают рыбы. 
         * В этом аквариуме может быть максимум определенное кол-во рыб. 
         * Рыб можно добавить в аквариум или рыб можно достать из аквариума. 
         * (программу делать в цикле для того, чтобы рыбы могли “жить”)
         * Все рыбы отображаются списком, у рыб также есть возраст. 
         * За 1 итерацию рыбы стареют на определенное кол-во жизней и могут умереть. 
         * Рыб также вывести в консоль, чтобы можно было мониторить показатели.
         */
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
                        aquarium.SkipDay();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;
                }
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fishes;
        private int _maxFishIn = 7;
        private int _currentDay = 1;
        private int _indexFish = 1;
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
                    _fishes[i].ShowLifeStatus(_currentDay);
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
                _fishes.Add(new Fish(_currentDay, _indexFish));
                _indexFish++;
            }
            else
            {
                Console.WriteLine("В аквариуме не осталось места!");
            }

            SkipDay();
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

            SkipDay();
        }

        public void SkipDay()
        {
            _currentDay++;
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
        private int _lifeCycleInDays = 15;
        private int _birthday;
        private int _lifeTime;
        private bool _isDead = false;

        public int Index { get; private set; }

        public Fish(int birthday, int index)
        {
            _birthday = birthday;
            Index = index;
        }

        public void ShowLifeStatus(int currentDay)
        {
            if (IsFishDead(currentDay))
            {
                Console.WriteLine($"Номер рыбки {Index}) - мертва");
            }
            else
            {
                Console.WriteLine($"Номер рыбки {Index}) Она живет в аквариуме дней - {_lifeTime}");
            }
        }

        private bool IsFishDead(int currentDay)
        {
            _lifeTime = currentDay - _birthday;

            return _isDead = _lifeTime >= _lifeCycleInDays;
        }
    }
}
