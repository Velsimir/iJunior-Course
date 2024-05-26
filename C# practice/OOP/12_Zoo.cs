using System;
using System.Collections.Generic;
using System.Linq;
using Internal;

namespace iJunior
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.ShowMenu();
        }
    }

    enum Animals
    {
        Cats = 1,
        Dogs,
        Cows,
        Mouse,
        Fox
    }

    class Zoo
    {
        private const int CommandExit = 0;

        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            _aviaries.Add(new Aviary(Animals.Cats));
            _aviaries.Add(new Aviary(Animals.Dogs));
            _aviaries.Add(new Aviary(Animals.Cows));
            _aviaries.Add(new Aviary(Animals.Mouse));
            _aviaries.Add(new Aviary(Animals.Fox));
        }

        public void ShowMenu()
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.Clear();

                Console.WriteLine($"Welcome to Zoo!" +
                    $"\nWhich aviar do you want to chose?" +
                    $"\nPress number to chose:" +
                    $"\n{CommandExit}) Exit");

                ShowAllAviary();

                int index = GetIndex();

                if (index >= 0)
                {
                    _aviaries[index].ShowInfo();
                }
                else
                {
                    isWorking = false;
                }
            }
        }

        private void ShowAllAviary()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_aviaries[i].Name}");
            }
        }

        private int GetIndex()
        {
            int index = 1;
            string userInput;

            do
            {
                do
                {
                    Console.Write("Press number to chose: ");
                    userInput = Console.ReadLine();

                } while (int.TryParse(userInput, out index) == false);

            } while (index < 0 | index > _aviaries.Count);

            return index - 1;
        }
    }

    class Aviary
    {
        private const string CommandSoundOn = "y";
        private const string CommandSoundOff = "n";

        private int _maleCount;
        private int _femaleCount;
        private List<Animal> _animals;

        public string Name { get; private set; }

        public Aviary(Animals animals)
        {
            AddAnimals(animals);

            CountAnimalGender();

            Name = _animals[0].Name;
        }

        public void ShowInfo()
        {
            Console.Clear();

            Animal typeOfAnimal = _animals[0];

            Console.WriteLine($"Aviary:\n{typeOfAnimal.Name} - {typeOfAnimal.Discription}." +
                $"\nAnimals:{_animals.Count()}\tMale: {_maleCount}\tFemale: {_femaleCount}");

            ListenSound();
        }

        private void ListenSound()
        {
            bool isChosing = true;
            string userInput;

            do
            {
                Console.WriteLine($"Wanna listen animals sound?\n{CommandSoundOn} - yes\n{CommandSoundOff} - no");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSoundOn:
                        _animals[0].MakeSound();
                        isChosing = false;
                        break;

                    case CommandSoundOff:
                        isChosing = false;
                        break;

                    default:
                        Console.WriteLine("Incorrect command");
                        break;
                }

            } while (isChosing);
        }

        private void AddAnimals(Animals animals)
        {
            Random random = new Random();
            int minAnimals = 5;
            int maxAnimals = 15;
            int _countOfAnimalsToCreate = random.Next(minAnimals, maxAnimals);
            _animals = new List<Animal>();

            for (int i = 0; i < _countOfAnimalsToCreate; i++)
            {
                _animals.Add(CreateAnimal(animals));
            }
        }

        private void CountAnimalGender()
        {
            foreach (var animal in _animals)
            {
                if (animal.IsSexFemale)
                {
                    _femaleCount++;
                }
                else if (animal.IsSexFemale == false)
                {
                    _maleCount++;
                }
            }
        }

        private Animal CreateAnimal(Animals animals)
        {
            switch (animals)
            {
                case Animals.Cats:
                    return new Cat();

                case Animals.Dogs:
                    return new Dog();

                case Animals.Cows:
                    return new Cow();

                case Animals.Mouse:
                    return new Mouse();

                case Animals.Fox:
                    return new Fox();
            }

            return null;
        }
    }

    abstract class Animal
    {
        private Random _random = new Random();
        private int _chanseChose = 50;

        public string Name { get; private set; }
        public string Discription { get; private set; }
        public string Sound { get; private set; }
        public bool IsSexFemale { get; private set; }

        protected Animal(string name, string sound, string discription)
        {
            Discription = discription;
            Name = name;
            Sound = sound;

            ChoseGender();
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} make sound {Sound}");
            Console.ReadKey();
        }

        private void ChoseGender()
        {
            int gender;

            gender = _random.Next(100);

            IsSexFemale = gender >= _chanseChose;
        }
    }

    class Cat : Animal
    {
        public Cat() : base("Cat", "Meow", "The cat (Felis catus) is a domestic species of small carnivorous mammal") { }
    }

    class Dog : Animal
    {
        public Dog() : base("Dog", "Bark", "The dog (Canis familiaris or Canis lupus familiaris) is a domesticated descendant of the wolf") { }
    }

    class Cow : Animal
    {
        public Cow() : base("Cow", "Moo", "Cows are peaceful animals. They are vegetarians and eat grass, giving people milk") { }
    }

    class Mouse : Animal
    {
        public Mouse() : base("Mouse", "Squeak", "Characteristically, mice are known to have a pointed snout, small rounded ears, a body-length scaly tail, and a high breeding rate") { }
    }

    class Fox : Animal
    {
        public Fox() : base("Fox", "What does the fox say?", "The fox has triangular face, dark pricked ears, black eyes and elongated muzzle. Its whiskers are black the body is red and the lower part of the face and the chest are white. It has a bushy tail.") { }
    }
}
