using System;
using System.Collections.Generic;
using System.Linq;

namespace iJunior
{
        class MainClass
    {
        public static void Main(string[] args)
        {
            AnimalCreator.FillAnimals();
            
            Zoo zoo = new Zoo();

            zoo.StartWork();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries;
        private bool _isWork = true;

        public Zoo()
        {
            FillAviaries();
        }

        public void StartWork()
        {
            while (_isWork)
            {
                ShowMenu();
                ExecuteСommand(ChooseCommand());
            }
        }

        private void FillAviaries()
        {
            _aviaries = new List<Aviary>()
            {new Aviary(AnimalCreator.GetRandomAnimal()), new Aviary(AnimalCreator.GetRandomAnimal()), new Aviary(AnimalCreator.GetRandomAnimal()), 
                new Aviary(AnimalCreator.GetRandomAnimal()), new Aviary(AnimalCreator.GetRandomAnimal())};
        }

        private void ShowMenu()
        {
            const int CommandExit = 0;

            Console.Clear();

            Console.WriteLine($"Welcome to Zoo!" +
                              $"\nWhich aviar do you want to chose?" +
                              $"\nPress number to chose:" +
                              $"\n{CommandExit}) Exit");

            ShowAllAviary();
        }

        private void ShowAllAviary()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_aviaries[i].Name}");
            }
        }

        private int ChooseCommand()
        {
            int index;

            do
            {
                Console.WriteLine("Choose a command:");
            } while (int.TryParse(Console.ReadLine(), out index) == false || index > _aviaries.Count || index < 0);
            
            return index;
        }

        private void ExecuteСommand(int command)
        {
            if (command > 0)
                _aviaries[command - 1].ShowInfo();
            else
                _isWork = false;
        }
    }

    class Aviary
    {
        private Animal _animal;
        private List<Animal> _animals;
        private int _femaleCount;
        private int _maleCount;

        public Aviary(Animal animal)
        {
            _animal = animal;
            
            AddAnimals();
            CountAnimalGender();
            
            Name = _animal.Name;
        }
        
        public string Name { get; private set; }

        public void ShowInfo()
        {
            Console.Clear();

            Console.WriteLine($"Aviary:\n{_animal.Name} - {_animal.Discription}." +
                $"\nAnimals:{_animals.Count()}\tMale: {_maleCount}\tFemale: {_femaleCount}");
            _animal.MakeSound();
            
            Console.ReadLine();
        }

        private void AddAnimals()
        {
            _animals = new List<Animal>();
            int minAnimals = 5;
            int maxAnimals = 15;
            int countOfAnimalsToCreate = UserUtils.GetRandomNumber(maxAnimals, minAnimals);
            
            for (int i = 0; i < countOfAnimalsToCreate; i++)
            {
                _animals.Add(_animal.Copy());
            }
        }

        private void CountAnimalGender()
        {
            foreach (var animal in _animals)
            {
                if (animal.Gender == Gender.Male)
                    _maleCount++;
                else
                    _femaleCount++;
            }
        }
    }

    class Animal
    {
        public Animal(string name, string sound, string discription, Gender gender = Gender.Male)
        {
            Discription = discription;
            Name = name;
            Sound = sound;
            Gender = gender;
        }
        
        public string Name { get; private set; }
        public string Discription { get; private set; }
        public string Sound { get; private set; }
        public Gender Gender { get; private set; }

        public void MakeSound()
        {
            Console.Write($"Make sound {Sound}");
        }

        public Animal Copy()
        {
            return new Animal(this.Name, this.Sound, this.Discription, AnimalCreator.GetRandomGender());
        }
    }

    static class AnimalCreator
    {
        static private List<Animal> s_animals;

        static public Animal GetRandomAnimal()
        {
            FillAnimals();
            
            return s_animals[UserUtils.GetRandomNumber(s_animals.Count)];
        }
        
        static public Gender GetRandomGender()
        {
            const int ChanseChose = 100;
            const int HalfChanse = 50;
            const int Male = 0;
            const int Female = 1;
            Gender gender;

            return gender = UserUtils.GetRandomNumber(ChanseChose) > HalfChanse ? Gender.Male : Gender.Female;
        }
        
        public static void FillAnimals()
        {
            s_animals = new List<Animal>();

            s_animals.Add(new Animal("Fox", "What does the fox say?",
                "The fox has triangular face, dark pricked ears, black eyes and elongated muzzle. " +
                "Its whiskers are black the body is red and the lower part of the face and the chest are white. " +
                "It has a bushy tail."));

            s_animals.Add(new Animal("Mouse", "Squeak",
                "Characteristically, mice are known to have a pointed snout, small rounded ears, " +
                "a body-length scaly tail, and a high breeding rate"));

            s_animals.Add(new Animal("Cow", "Moo",
                "Cows are peaceful animals. They are vegetarians and eat grass, giving people milk"));

            s_animals.Add(new Animal("Dog", "Bark",
                "The dog (Canis familiaris or Canis lupus familiaris) is a domesticated descendant of the wolf"));

            s_animals.Add(new Animal("Cat", "Meow",
                "The cat (Felis catus) is a domestic species of small carnivorous mammal"));
        }
    }

    public static class UserUtils
    {
        private const int MinValue = 0;

        private static Random _random = new Random();

        public static int GetRandomNumber(int max, int min = MinValue)
        {
            return _random.Next(min, max);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}